﻿using ClassificationNumbers.Helpers;
using CommonLibrary.NeuralNetworks;
using CommonLibrary.DataDTO;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using ClassificationNumbers.Logger;

namespace ClassificationNumbers.Forms
{
    public partial class MainForm : Form
    {
        private PainterForm _painterForm;
        private CheckerNNForm _checkerNNForm;
        private GeneratingDataForm _generatingDataForm;

        private Neural3NetworkProperties _neural3NetworkProperties;
        private Neural3NetworkTeacherProperties _neural3NetworkTeacherProperties;

        private OpenFileDialog _pngImagesDialogSelecting;
        private FileStream _mainFileStream;
        private DataNumberDTO_28x28_Set[] _dataNumberDTO_28x28_Set;
        private MainLogger _mainLogger;

        public Neural3NetworkCreator Neural3NetworkCreator { get; private set; }
        public Neural3NetworkTeacher Neural3NetworkTeacher { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            _mainLogger = new MainLogger(_mainLoggerLstBx);
        }

        /// <summary>
        /// Создаем простую трехслойную нейросеть.
        /// Создаем нейроны, генерируем между ними связи со случайными значениями весов.
        /// </summary>
        private void _createNeuralNetworkBtn_Click(object sender, EventArgs e)
        {
            _neural3NetworkProperties = new Neural3NetworkProperties(this, Neural3NetworkCreator);

            var functionActivation = _neural3NetworkProperties.FuncActivation;
            var amountInputNeurons = _neural3NetworkProperties.AmountInputNeurons;
            var amountHiddenNeurons = _neural3NetworkProperties.AmountHiddenNeurons;
            var amountOutputNeurons = _neural3NetworkProperties.AmountOutputNeurons;
            var minWeight = _neural3NetworkProperties.MinWeight;
            var maxWeight = _neural3NetworkProperties.MaxWeight;

            Neural3NetworkCreator = new Neural3NetworkCreator(functionActivation, amountInputNeurons, amountHiddenNeurons, amountOutputNeurons, minWeight, maxWeight);

            _mainLogger.Log("Трехслойная нейросеть успешна создана.", isShowMsg: true);
            UIHelper.ChangeStatusLabel(_creatingNNStsLbl, true);
        }

        private void _LearnBtn_Click(object sender, EventArgs e)
        {
            if (_neural3NetworkTeacherProperties == null)
            {
                _mainLogger.Log("Задайте явно параметры для обучения.", isShowMsg: true);
                return;
            }

            if (Neural3NetworkCreator == null)
            {
                _mainLogger.Log("Не создана трехслойная нейронная сеть.", isShowMsg: true);
                return;
            }

            if (Neural3NetworkCreator.InputLayer.Neurons.Length != 28 * 28)
            {
                _mainLogger.Log($"Нейросеть должна иметь {28 * 28} нейронов во входном слое для работы с картинками 28x28 пикселей.", isShowMsg: true);
                return;
            }

            if (_dataNumberDTO_28x28_Set == null || _dataNumberDTO_28x28_Set.Length == 0)
            {
                _mainLogger.Log("Нет данных, пожалуйста, выберите подходящий JSON файл.", isShowMsg: true);
                return;
            }

            UIHelper.BlockAllControls(this);

            // Обучение трехслойной нейронной сети
            // ЗАДАЧА - классифицировать на картинках цифры от 0 до 9, написанные от руки
            // Входные данные, где int - цифры, а double[] - массив преобразованных RGB компонент из картинок
            _mainBackgroundWorker.DoWork += LearnNeuralNetwork_DoWork;
            _mainBackgroundWorker.RunWorkerCompleted += LearnNeuralNetwork_RunWorkerCompleted;
            _mainBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Обучение трехслойной нейронной сети
        /// </summary>
        private void LearnNeuralNetwork_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var alpha = _neural3NetworkTeacherProperties.Alpha;

            var data = _dataNumberDTO_28x28_Set;

            Neural3NetworkTeacher = new Neural3NetworkTeacher(Neural3NetworkCreator, alpha);
            Neural3NetworkTeacher.Learn(data);
        }

        private void LearnNeuralNetwork_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            _mainLogger.Log("Обучение успешно завершено!", isShowMsg: true);
            _mainBackgroundWorker.DoWork -= LearnNeuralNetwork_DoWork;
            _mainBackgroundWorker.RunWorkerCompleted -= LearnNeuralNetwork_RunWorkerCompleted;
            UIHelper.EnableAllControls(this);
            UIHelper.ChangeStatusLabel(_learningNNStsLbl, true);
        }

        /// <summary>
        /// Выбираем JSON файл, подгружаем его и вытаскиваем data set для тренировки neural networks
        /// </summary>
        private void _loadJsonDataSetBtn_Click(object sender, EventArgs e)
        {
            _pngImagesDialogSelecting = new OpenFileDialog();
            _pngImagesDialogSelecting.Filter = "JSON Files|*.json";
            if (_pngImagesDialogSelecting.ShowDialog() == DialogResult.OK)
            {
                UIHelper.BlockAllControls(this);

                var fileName = _pngImagesDialogSelecting.FileName;
                _mainFileStream = new FileStream(fileName, FileMode.Open);
                _mainBackgroundWorker.DoWork += LoadJsonDataSet_DoWork;
                _mainBackgroundWorker.RunWorkerCompleted += LoadJsonDataSet_RunWorkerCompleted;
                _mainBackgroundWorker.RunWorkerAsync();
            }
        }

        private void LoadJsonDataSet_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_pngImagesDialogSelecting != null)
            {
                _pngImagesDialogSelecting.Dispose();
            }
            if (_mainFileStream != null)
            {
                _mainFileStream.Dispose();
            }
            _mainBackgroundWorker.DoWork -= LoadJsonDataSet_DoWork;
            _mainBackgroundWorker.RunWorkerCompleted -= LoadJsonDataSet_RunWorkerCompleted;

            _mainLogger.Log("Данные JSON по картинкам 28x28 успешно подгружены.", isShowMsg: true);
            UIHelper.EnableAllControls(this);
            UIHelper.ChangeStatusLabel(_loadingJSONDataStsLbl, true);
        }

        private void LoadJsonDataSet_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var serializer = new DataContractJsonSerializer(typeof(DataNumberDTO_28x28_Set[]));
            _dataNumberDTO_28x28_Set = (DataNumberDTO_28x28_Set[])serializer.ReadObject(_mainFileStream);
        }

        /// <summary>
        /// Установить характеристики простой трехслойной нейронной сети по-умолчанию
        /// </summary>
        private void _setDefaultPropertiesBtn_Click(object sender, EventArgs e)
        {
            var neural3NetworkProperties = new Neural3NetworkProperties(this, Neural3NetworkCreator);
            neural3NetworkProperties.SetInFormByDefault();
            _mainLogger.Log("Заданы параметры для нейросети по-умолчанию.", isShowMsg: false);
        }

        /// <summary>
        /// Отрисовывает нейронную сеть
        /// </summary>
        private void _drawNeuralNetworkBtn_Click(object sender, EventArgs e)
        {
            if (Neural3NetworkCreator == null)
            {
                _mainLogger.Log("Нейросеть не создана.", isShowMsg: true);
                return;
            }

            if (_painterForm != null)
            {
                _mainLogger.Log("Второе окно уже используется для отрисовки.", isShowMsg: true);
                return;
            }

            _painterForm = new PainterForm(Neural3NetworkCreator);
            _painterForm.FormClosed += _painterForm_FormClosed;
            _painterForm.Width = 1400;
            _painterForm.Height = 800;
            _painterForm.Show();
            _painterForm.DrawNeuralNetworkAsync();
        }

        private void _painterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _painterForm = null;
        }

        /// <summary>
        /// Отрисовывает данных картинок 28x28 пикселей
        /// </summary>
        private void _visualizationDataBtn_Click(object sender, EventArgs e)
        {
            if (_dataNumberDTO_28x28_Set == null)
            {
                _mainLogger.Log("Не были подгружены JSON данные картинок 28x28 pixels.", isShowMsg: true);
                return;
            }

            if (_painterForm != null)
            {
                _mainLogger.Log("Второе окно уже используется для отрисовки.", isShowMsg: true);
                return;
            }

            _painterForm = new PainterForm(_dataNumberDTO_28x28_Set);
            _painterForm.FormClosed += _painterForm_FormClosed;
            _painterForm.Width = 1400;
            _painterForm.Height = 800;
            _painterForm.Show();
            _painterForm.DrawImages28x28();
        }

        private void _generateJsonData28x28_Click(object sender, EventArgs e)
        {
            _generatingDataForm = new GeneratingDataForm();
            _generatingDataForm.Show();
        }

        private void _saveStateNeuroNetworkBtn_Click(object sender, EventArgs e)
        {
            if (Neural3NetworkCreator == null)
            {
                _mainLogger.Log("Нейросеть не создана.", isShowMsg: true);
                return;
            }

            var savedFileName = string.Empty;
            var exMessage = string.Empty;

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files|*.json";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var fs = saveFileDialog.OpenFile())
                    {
                        savedFileName = saveFileDialog.FileName;
                        var neural3NetworkSaver = new Neural3NetworkSaver(Neural3NetworkCreator);
                        neural3NetworkSaver.Save(fs, out exMessage);
                    }
                }
            }

            if (!string.IsNullOrEmpty(exMessage))
            {
                MessageBox.Show(exMessage);
                return;
            }

            if (!string.IsNullOrEmpty(savedFileName))
            {
                _mainLogger.Log($"Состояние нейросети сохранено в файл {savedFileName}", isShowMsg: true);
                UIHelper.ChangeStatusLabel(_savingStateNNStsLbl, true);
            }
        }

        private void _loadStateNeurolNetworkBtn_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    UIHelper.BlockAllControls(this);

                    var jsonFileName = openFileDialog.FileName;
                    _mainBackgroundWorker.DoWork += LoadStateNeurolNetwork_DoWork;
                    _mainBackgroundWorker.RunWorkerCompleted += LoadStateNeurolNetwork_RunWorkerCompleted;
                    _mainBackgroundWorker.RunWorkerAsync(jsonFileName);
                }
            }
        }

        private void LoadStateNeurolNetwork_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (e.Argument is string jsonFileName)
            {
                using (var fs = new FileStream(jsonFileName, FileMode.Open))
                {
                    var serializer = new DataContractJsonSerializer(typeof(Neural3NetworkCreator));
                    Neural3NetworkCreator = (Neural3NetworkCreator)serializer.ReadObject(fs);
                }
            }
            else
            {
                var msg = "Не найден путь к JSON файлу состояния простой нейронной сети.";
                _mainLogger.Log(msg, isShowMsg: true);
                throw new ArgumentException(msg);
            }
        }

        /// <summary>
        /// Установить характеристики простой трехслойной нейронной сети по-умолчанию
        /// </summary>
        private void LoadStateNeurolNetwork_RunWorkerCompleted(object sender, EventArgs e)
        {
            _mainBackgroundWorker.DoWork -= LoadStateNeurolNetwork_DoWork;
            _mainBackgroundWorker.RunWorkerCompleted -= LoadStateNeurolNetwork_RunWorkerCompleted;

            _neural3NetworkProperties = new Neural3NetworkProperties(this, Neural3NetworkCreator);
            _neural3NetworkProperties.SetInForm();

            _mainLogger.Log("Подгрузка JSON состояния трехслойной нейронной сети прошла успешна.", isShowMsg: true);
            UIHelper.EnableAllControls(this);
            UIHelper.ChangeStatusLabel(_loadingStateNNStsLbl, true);
            UIHelper.ChangeStatusLabel(_creatingNNStsLbl, true);
        }

        private void _checkNeuralNetworkBtn_Click(object sender, EventArgs e)
        {
            if (Neural3NetworkCreator == null)
            {
                _mainLogger.Log("Не создана трехслойная нейронная сеть.", isShowMsg: true);
                return;
            }

            if (Neural3NetworkTeacher == null)
            {
                _mainLogger.Log("Необходимо обучить нейронную сеть.", isShowMsg: true);
                return;
            }

            _checkerNNForm = new CheckerNNForm(Neural3NetworkCreator, Neural3NetworkTeacher);
            _checkerNNForm.Show();
        }

        /// <summary>
        ///  Установить характеристики простой трехслойной нейронной сети для обучения по-умолчанию
        /// </summary>
        private void _setDefaultTeacherPropertiesBtn_Click(object sender, EventArgs e)
        {
            _neural3NetworkTeacherProperties = new Neural3NetworkTeacherProperties(this);
            _neural3NetworkTeacherProperties.SetInFormByDefault();
            _mainLogger.Log("Заданы параметры для обучения по-умолчанию.", isShowMsg: false);
        }
    }
}