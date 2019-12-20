namespace ClassificationNumbers.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);

            if (_pngImagesDialogSelecting != null)
            {
                _pngImagesDialogSelecting.Dispose();
            }
            if (_mainFileStream != null)
            {
                _mainFileStream.Dispose();
            }
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._createNeuralNetworkBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._amountInputNeuronsN = new System.Windows.Forms.NumericUpDown();
            this._amountHiddenNeuronsN = new System.Windows.Forms.NumericUpDown();
            this._amountOutputNeuronsN = new System.Windows.Forms.NumericUpDown();
            this._minWeightN = new System.Windows.Forms.NumericUpDown();
            this._maxWeightN = new System.Windows.Forms.NumericUpDown();
            this._funcActivationsList = new System.Windows.Forms.ListBox();
            this._LearnBtn = new System.Windows.Forms.Button();
            this._loadJsonDataSetBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this._setDefaultPropertiesBtn = new System.Windows.Forms.Button();
            this._drawNeuralNetworkBtn = new System.Windows.Forms.Button();
            this._mainBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this._visualizationDataBtn = new System.Windows.Forms.Button();
            this._generateJsonData28x28 = new System.Windows.Forms.Button();
            this._saveStateNeuroNetworkBtn = new System.Windows.Forms.Button();
            this._loadStateNeurolNetworkBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this._mainLoggerLstBx = new System.Windows.Forms.ListBox();
            this._loadingStateNNStsLbl = new System.Windows.Forms.Label();
            this._loadingJSONDataStsLbl = new System.Windows.Forms.Label();
            this._creatingNNStsLbl = new System.Windows.Forms.Label();
            this._savingStateNNStsLbl = new System.Windows.Forms.Label();
            this._learningNNStsLbl = new System.Windows.Forms.Label();
            this._checkNeuralNetworkBtn = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this._setDefaultTeacherPropertiesBtn = new System.Windows.Forms.Button();
            this._alphaN = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._amountInputNeuronsN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._amountHiddenNeuronsN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._amountOutputNeuronsN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._minWeightN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._maxWeightN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._alphaN)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Кол-во входных узлов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Кол-во скрытых узлов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Кол-во выходных узлов";
            // 
            // _createNeuralNetworkBtn
            // 
            this._createNeuralNetworkBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._createNeuralNetworkBtn.Location = new System.Drawing.Point(91, 440);
            this._createNeuralNetworkBtn.Name = "_createNeuralNetworkBtn";
            this._createNeuralNetworkBtn.Size = new System.Drawing.Size(324, 46);
            this._createNeuralNetworkBtn.TabIndex = 9;
            this._createNeuralNetworkBtn.Text = "Создать трехслойную нейросеть";
            this._createNeuralNetworkBtn.UseVisualStyleBackColor = false;
            this._createNeuralNetworkBtn.Click += new System.EventHandler(this._createNeuralNetworkBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Диапазон весов";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Функция активации";
            // 
            // _amountInputNeuronsN
            // 
            this._amountInputNeuronsN.Location = new System.Drawing.Point(95, 77);
            this._amountInputNeuronsN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._amountInputNeuronsN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._amountInputNeuronsN.Name = "_amountInputNeuronsN";
            this._amountInputNeuronsN.Size = new System.Drawing.Size(148, 22);
            this._amountInputNeuronsN.TabIndex = 15;
            this._amountInputNeuronsN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _amountHiddenNeuronsN
            // 
            this._amountHiddenNeuronsN.Location = new System.Drawing.Point(268, 77);
            this._amountHiddenNeuronsN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._amountHiddenNeuronsN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._amountHiddenNeuronsN.Name = "_amountHiddenNeuronsN";
            this._amountHiddenNeuronsN.Size = new System.Drawing.Size(148, 22);
            this._amountHiddenNeuronsN.TabIndex = 16;
            this._amountHiddenNeuronsN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _amountOutputNeuronsN
            // 
            this._amountOutputNeuronsN.Location = new System.Drawing.Point(95, 132);
            this._amountOutputNeuronsN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._amountOutputNeuronsN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._amountOutputNeuronsN.Name = "_amountOutputNeuronsN";
            this._amountOutputNeuronsN.Size = new System.Drawing.Size(148, 22);
            this._amountOutputNeuronsN.TabIndex = 17;
            this._amountOutputNeuronsN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _minWeightN
            // 
            this._minWeightN.DecimalPlaces = 2;
            this._minWeightN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._minWeightN.Location = new System.Drawing.Point(137, 211);
            this._minWeightN.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this._minWeightN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._minWeightN.Name = "_minWeightN";
            this._minWeightN.Size = new System.Drawing.Size(106, 22);
            this._minWeightN.TabIndex = 19;
            this._minWeightN.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // _maxWeightN
            // 
            this._maxWeightN.DecimalPlaces = 2;
            this._maxWeightN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._maxWeightN.Location = new System.Drawing.Point(137, 241);
            this._maxWeightN.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this._maxWeightN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._maxWeightN.Name = "_maxWeightN";
            this._maxWeightN.Size = new System.Drawing.Size(106, 22);
            this._maxWeightN.TabIndex = 20;
            this._maxWeightN.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // _funcActivationsList
            // 
            this._funcActivationsList.FormattingEnabled = true;
            this._funcActivationsList.ItemHeight = 16;
            this._funcActivationsList.Items.AddRange(new object[] {
            "None",
            "y = 1 / (1 + e^(-x))"});
            this._funcActivationsList.Location = new System.Drawing.Point(268, 132);
            this._funcActivationsList.Name = "_funcActivationsList";
            this._funcActivationsList.Size = new System.Drawing.Size(150, 132);
            this._funcActivationsList.TabIndex = 21;
            // 
            // _LearnBtn
            // 
            this._LearnBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._LearnBtn.Location = new System.Drawing.Point(422, 492);
            this._LearnBtn.Name = "_LearnBtn";
            this._LearnBtn.Size = new System.Drawing.Size(323, 105);
            this._LearnBtn.TabIndex = 22;
            this._LearnBtn.Text = "Начать обучение";
            this._LearnBtn.UseVisualStyleBackColor = false;
            this._LearnBtn.Click += new System.EventHandler(this._LearnBtn_Click);
            // 
            // _loadJsonDataSetBtn
            // 
            this._loadJsonDataSetBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._loadJsonDataSetBtn.Location = new System.Drawing.Point(421, 327);
            this._loadJsonDataSetBtn.Name = "_loadJsonDataSetBtn";
            this._loadJsonDataSetBtn.Size = new System.Drawing.Size(324, 58);
            this._loadJsonDataSetBtn.TabIndex = 23;
            this._loadJsonDataSetBtn.Text = "Подгрузить JSON данные 28x28";
            this._loadJsonDataSetBtn.UseVisualStyleBackColor = false;
            this._loadJsonDataSetBtn.Click += new System.EventHandler(this._loadJsonDataSetBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.LightBlue;
            this.label7.Location = new System.Drawing.Point(92, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(226, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "Характеристики нейронной сети";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "Мин.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(91, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Макс.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.LightBlue;
            this.label10.Location = new System.Drawing.Point(91, 296);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(207, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "Управление нейронной сетью";
            // 
            // _setDefaultPropertiesBtn
            // 
            this._setDefaultPropertiesBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._setDefaultPropertiesBtn.Location = new System.Drawing.Point(92, 388);
            this._setDefaultPropertiesBtn.Name = "_setDefaultPropertiesBtn";
            this._setDefaultPropertiesBtn.Size = new System.Drawing.Size(324, 46);
            this._setDefaultPropertiesBtn.TabIndex = 28;
            this._setDefaultPropertiesBtn.Text = "Установить нейросети характеристики по-умолчанию";
            this._setDefaultPropertiesBtn.UseVisualStyleBackColor = false;
            this._setDefaultPropertiesBtn.Click += new System.EventHandler(this._setDefaultPropertiesBtn_Click);
            // 
            // _drawNeuralNetworkBtn
            // 
            this._drawNeuralNetworkBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._drawNeuralNetworkBtn.Location = new System.Drawing.Point(421, 388);
            this._drawNeuralNetworkBtn.Name = "_drawNeuralNetworkBtn";
            this._drawNeuralNetworkBtn.Size = new System.Drawing.Size(323, 46);
            this._drawNeuralNetworkBtn.TabIndex = 29;
            this._drawNeuralNetworkBtn.Text = "Отрисовать нейросеть";
            this._drawNeuralNetworkBtn.UseVisualStyleBackColor = false;
            this._drawNeuralNetworkBtn.Click += new System.EventHandler(this._drawNeuralNetworkBtn_Click);
            // 
            // _visualizationDataBtn
            // 
            this._visualizationDataBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._visualizationDataBtn.Location = new System.Drawing.Point(421, 440);
            this._visualizationDataBtn.Name = "_visualizationDataBtn";
            this._visualizationDataBtn.Size = new System.Drawing.Size(323, 46);
            this._visualizationDataBtn.TabIndex = 30;
            this._visualizationDataBtn.Text = "Визуализировать данные";
            this._visualizationDataBtn.UseVisualStyleBackColor = false;
            this._visualizationDataBtn.Click += new System.EventHandler(this._visualizationDataBtn_Click);
            // 
            // _generateJsonData28x28
            // 
            this._generateJsonData28x28.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._generateJsonData28x28.Location = new System.Drawing.Point(92, 563);
            this._generateJsonData28x28.Name = "_generateJsonData28x28";
            this._generateJsonData28x28.Size = new System.Drawing.Size(324, 64);
            this._generateJsonData28x28.TabIndex = 31;
            this._generateJsonData28x28.Text = "Сгенерировать JSON данные по картинкам 28x28";
            this._generateJsonData28x28.UseVisualStyleBackColor = false;
            this._generateJsonData28x28.Click += new System.EventHandler(this._generateJsonData28x28_Click);
            // 
            // _saveStateNeuroNetworkBtn
            // 
            this._saveStateNeuroNetworkBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._saveStateNeuroNetworkBtn.Location = new System.Drawing.Point(92, 635);
            this._saveStateNeuroNetworkBtn.Name = "_saveStateNeuroNetworkBtn";
            this._saveStateNeuroNetworkBtn.Size = new System.Drawing.Size(324, 55);
            this._saveStateNeuroNetworkBtn.TabIndex = 32;
            this._saveStateNeuroNetworkBtn.Text = "Сохранить состояние нейросети";
            this._saveStateNeuroNetworkBtn.UseVisualStyleBackColor = false;
            this._saveStateNeuroNetworkBtn.Click += new System.EventHandler(this._saveStateNeuroNetworkBtn_Click);
            // 
            // _loadStateNeurolNetworkBtn
            // 
            this._loadStateNeurolNetworkBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._loadStateNeurolNetworkBtn.Location = new System.Drawing.Point(92, 327);
            this._loadStateNeurolNetworkBtn.Name = "_loadStateNeurolNetworkBtn";
            this._loadStateNeurolNetworkBtn.Size = new System.Drawing.Size(323, 55);
            this._loadStateNeurolNetworkBtn.TabIndex = 34;
            this._loadStateNeurolNetworkBtn.Text = "Подгрузить состояние нейросети";
            this._loadStateNeurolNetworkBtn.UseVisualStyleBackColor = false;
            this._loadStateNeurolNetworkBtn.Click += new System.EventHandler(this._loadStateNeurolNetworkBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.LightBlue;
            this.label11.Location = new System.Drawing.Point(91, 709);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 17);
            this.label11.TabIndex = 35;
            this.label11.Text = "Логирование";
            // 
            // _mainLoggerLstBx
            // 
            this._mainLoggerLstBx.FormattingEnabled = true;
            this._mainLoggerLstBx.ItemHeight = 16;
            this._mainLoggerLstBx.Location = new System.Drawing.Point(94, 741);
            this._mainLoggerLstBx.Name = "_mainLoggerLstBx";
            this._mainLoggerLstBx.Size = new System.Drawing.Size(653, 132);
            this._mainLoggerLstBx.TabIndex = 37;
            // 
            // _loadingStateNNStsLbl
            // 
            this._loadingStateNNStsLbl.AutoSize = true;
            this._loadingStateNNStsLbl.BackColor = System.Drawing.Color.DarkRed;
            this._loadingStateNNStsLbl.ForeColor = System.Drawing.Color.White;
            this._loadingStateNNStsLbl.Location = new System.Drawing.Point(60, 346);
            this._loadingStateNNStsLbl.Name = "_loadingStateNNStsLbl";
            this._loadingStateNNStsLbl.Size = new System.Drawing.Size(26, 17);
            this._loadingStateNNStsLbl.TabIndex = 38;
            this._loadingStateNNStsLbl.Text = "No";
            // 
            // _loadingJSONDataStsLbl
            // 
            this._loadingJSONDataStsLbl.AutoSize = true;
            this._loadingJSONDataStsLbl.BackColor = System.Drawing.Color.DarkRed;
            this._loadingJSONDataStsLbl.ForeColor = System.Drawing.Color.White;
            this._loadingJSONDataStsLbl.Location = new System.Drawing.Point(751, 348);
            this._loadingJSONDataStsLbl.Name = "_loadingJSONDataStsLbl";
            this._loadingJSONDataStsLbl.Size = new System.Drawing.Size(26, 17);
            this._loadingJSONDataStsLbl.TabIndex = 39;
            this._loadingJSONDataStsLbl.Text = "No";
            // 
            // _creatingNNStsLbl
            // 
            this._creatingNNStsLbl.AutoSize = true;
            this._creatingNNStsLbl.BackColor = System.Drawing.Color.DarkRed;
            this._creatingNNStsLbl.ForeColor = System.Drawing.Color.White;
            this._creatingNNStsLbl.Location = new System.Drawing.Point(59, 455);
            this._creatingNNStsLbl.Name = "_creatingNNStsLbl";
            this._creatingNNStsLbl.Size = new System.Drawing.Size(26, 17);
            this._creatingNNStsLbl.TabIndex = 40;
            this._creatingNNStsLbl.Text = "No";
            // 
            // _savingStateNNStsLbl
            // 
            this._savingStateNNStsLbl.AutoSize = true;
            this._savingStateNNStsLbl.BackColor = System.Drawing.Color.DarkRed;
            this._savingStateNNStsLbl.ForeColor = System.Drawing.Color.White;
            this._savingStateNNStsLbl.Location = new System.Drawing.Point(60, 654);
            this._savingStateNNStsLbl.Name = "_savingStateNNStsLbl";
            this._savingStateNNStsLbl.Size = new System.Drawing.Size(26, 17);
            this._savingStateNNStsLbl.TabIndex = 41;
            this._savingStateNNStsLbl.Text = "No";
            // 
            // _learningNNStsLbl
            // 
            this._learningNNStsLbl.AutoSize = true;
            this._learningNNStsLbl.BackColor = System.Drawing.Color.DarkRed;
            this._learningNNStsLbl.ForeColor = System.Drawing.Color.White;
            this._learningNNStsLbl.Location = new System.Drawing.Point(751, 536);
            this._learningNNStsLbl.Name = "_learningNNStsLbl";
            this._learningNNStsLbl.Size = new System.Drawing.Size(26, 17);
            this._learningNNStsLbl.TabIndex = 42;
            this._learningNNStsLbl.Text = "No";
            // 
            // _checkNeuralNetworkBtn
            // 
            this._checkNeuralNetworkBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._checkNeuralNetworkBtn.Location = new System.Drawing.Point(421, 603);
            this._checkNeuralNetworkBtn.Name = "_checkNeuralNetworkBtn";
            this._checkNeuralNetworkBtn.Size = new System.Drawing.Size(322, 87);
            this._checkNeuralNetworkBtn.TabIndex = 43;
            this._checkNeuralNetworkBtn.Text = "Проверить нейросеть";
            this._checkNeuralNetworkBtn.UseVisualStyleBackColor = false;
            this._checkNeuralNetworkBtn.Click += new System.EventHandler(this._checkNeuralNetworkBtn_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.LightBlue;
            this.label15.Location = new System.Drawing.Point(437, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(321, 17);
            this.label15.TabIndex = 50;
            this.label15.Text = "Характеристики для обучения нейронной сети";
            // 
            // _setDefaultTeacherPropertiesBtn
            // 
            this._setDefaultTeacherPropertiesBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._setDefaultTeacherPropertiesBtn.Location = new System.Drawing.Point(91, 492);
            this._setDefaultTeacherPropertiesBtn.Name = "_setDefaultTeacherPropertiesBtn";
            this._setDefaultTeacherPropertiesBtn.Size = new System.Drawing.Size(324, 65);
            this._setDefaultTeacherPropertiesBtn.TabIndex = 51;
            this._setDefaultTeacherPropertiesBtn.Text = "Установить парметры для обучения по-умолчанию";
            this._setDefaultTeacherPropertiesBtn.UseVisualStyleBackColor = false;
            this._setDefaultTeacherPropertiesBtn.Click += new System.EventHandler(this._setDefaultTeacherPropertiesBtn_Click);
            // 
            // _alphaN
            // 
            this._alphaN.DecimalPlaces = 2;
            this._alphaN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._alphaN.Location = new System.Drawing.Point(440, 77);
            this._alphaN.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this._alphaN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._alphaN.Name = "_alphaN";
            this._alphaN.Size = new System.Drawing.Size(148, 22);
            this._alphaN.TabIndex = 18;
            this._alphaN.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(437, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Коэффициент обучения";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 960);
            this.Controls.Add(this._setDefaultTeacherPropertiesBtn);
            this.Controls.Add(this.label15);
            this.Controls.Add(this._checkNeuralNetworkBtn);
            this.Controls.Add(this._learningNNStsLbl);
            this.Controls.Add(this._savingStateNNStsLbl);
            this.Controls.Add(this._creatingNNStsLbl);
            this.Controls.Add(this._loadingJSONDataStsLbl);
            this.Controls.Add(this._loadingStateNNStsLbl);
            this.Controls.Add(this._mainLoggerLstBx);
            this.Controls.Add(this.label11);
            this.Controls.Add(this._loadStateNeurolNetworkBtn);
            this.Controls.Add(this._saveStateNeuroNetworkBtn);
            this.Controls.Add(this._generateJsonData28x28);
            this.Controls.Add(this._visualizationDataBtn);
            this.Controls.Add(this._drawNeuralNetworkBtn);
            this.Controls.Add(this._setDefaultPropertiesBtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._loadJsonDataSetBtn);
            this.Controls.Add(this._LearnBtn);
            this.Controls.Add(this._funcActivationsList);
            this.Controls.Add(this._maxWeightN);
            this.Controls.Add(this._minWeightN);
            this.Controls.Add(this._alphaN);
            this.Controls.Add(this._amountOutputNeuronsN);
            this.Controls.Add(this._amountHiddenNeuronsN);
            this.Controls.Add(this._amountInputNeuronsN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._createNeuralNetworkBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Neurol Network Trainer (3 layers)";
            ((System.ComponentModel.ISupportInitialize)(this._amountInputNeuronsN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._amountHiddenNeuronsN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._amountOutputNeuronsN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._minWeightN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._maxWeightN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._alphaN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button _createNeuralNetworkBtn;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.NumericUpDown _amountInputNeuronsN;
        internal System.Windows.Forms.NumericUpDown _amountHiddenNeuronsN;
        internal System.Windows.Forms.NumericUpDown _amountOutputNeuronsN;
        internal System.Windows.Forms.NumericUpDown _minWeightN;
        internal System.Windows.Forms.NumericUpDown _maxWeightN;
        internal System.Windows.Forms.ListBox _funcActivationsList;
        internal System.Windows.Forms.Button _LearnBtn;
        internal System.Windows.Forms.Button _loadJsonDataSetBtn;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Button _setDefaultPropertiesBtn;
        internal System.Windows.Forms.Button _drawNeuralNetworkBtn;
        private System.ComponentModel.BackgroundWorker _mainBackgroundWorker;
        internal System.Windows.Forms.Button _visualizationDataBtn;
        internal System.Windows.Forms.Button _generateJsonData28x28;
        internal System.Windows.Forms.Button _saveStateNeuroNetworkBtn;
        internal System.Windows.Forms.Button _loadStateNeurolNetworkBtn;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox _mainLoggerLstBx;
        private System.Windows.Forms.Label _loadingStateNNStsLbl;
        private System.Windows.Forms.Label _loadingJSONDataStsLbl;
        private System.Windows.Forms.Label _creatingNNStsLbl;
        private System.Windows.Forms.Label _savingStateNNStsLbl;
        private System.Windows.Forms.Label _learningNNStsLbl;
        internal System.Windows.Forms.Button _checkNeuralNetworkBtn;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Button _setDefaultTeacherPropertiesBtn;
        internal System.Windows.Forms.NumericUpDown _alphaN;
        internal System.Windows.Forms.Label label4;
    }
}

