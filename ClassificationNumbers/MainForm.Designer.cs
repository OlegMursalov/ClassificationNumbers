namespace ClassificationNumbers
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
            this.label4 = new System.Windows.Forms.Label();
            this._createNeuralNetworkBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._amountInputNeuronsN = new System.Windows.Forms.NumericUpDown();
            this._amountHiddenNeuronsN = new System.Windows.Forms.NumericUpDown();
            this._amountOutputNeuronsN = new System.Windows.Forms.NumericUpDown();
            this._alphaN = new System.Windows.Forms.NumericUpDown();
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
            ((System.ComponentModel.ISupportInitialize)(this._amountInputNeuronsN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._amountHiddenNeuronsN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._amountOutputNeuronsN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._alphaN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._minWeightN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._maxWeightN)).BeginInit();
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Коэффициент обучения";
            // 
            // _createNeuralNetworkBtn
            // 
            this._createNeuralNetworkBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._createNeuralNetworkBtn.Location = new System.Drawing.Point(94, 345);
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
            this.label5.Location = new System.Drawing.Point(92, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Диапазон весов";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(267, 163);
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
            // _alphaN
            // 
            this._alphaN.DecimalPlaces = 2;
            this._alphaN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._alphaN.Location = new System.Drawing.Point(268, 132);
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
            // _minWeightN
            // 
            this._minWeightN.DecimalPlaces = 2;
            this._minWeightN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._minWeightN.Location = new System.Drawing.Point(137, 185);
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
            this._maxWeightN.Location = new System.Drawing.Point(137, 215);
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
            "y = 1 / (1 + e^x)"});
            this._funcActivationsList.Location = new System.Drawing.Point(268, 185);
            this._funcActivationsList.Name = "_funcActivationsList";
            this._funcActivationsList.Size = new System.Drawing.Size(150, 52);
            this._funcActivationsList.TabIndex = 21;
            // 
            // _LearnBtn
            // 
            this._LearnBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._LearnBtn.Location = new System.Drawing.Point(95, 449);
            this._LearnBtn.Name = "_LearnBtn";
            this._LearnBtn.Size = new System.Drawing.Size(323, 46);
            this._LearnBtn.TabIndex = 22;
            this._LearnBtn.Text = "Начать обучение";
            this._LearnBtn.UseVisualStyleBackColor = false;
            this._LearnBtn.Click += new System.EventHandler(this._LearnBtn_Click);
            // 
            // _loadJsonDataSetBtn
            // 
            this._loadJsonDataSetBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._loadJsonDataSetBtn.Location = new System.Drawing.Point(94, 397);
            this._loadJsonDataSetBtn.Name = "_loadJsonDataSetBtn";
            this._loadJsonDataSetBtn.Size = new System.Drawing.Size(324, 46);
            this._loadJsonDataSetBtn.TabIndex = 23;
            this._loadJsonDataSetBtn.Text = "Подгрузить JSON данные для тренировки ";
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
            this.label8.Location = new System.Drawing.Point(92, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "Мин.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(91, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Макс.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.LightBlue;
            this.label10.Location = new System.Drawing.Point(91, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(207, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "Управление нейронной сетью";
            // 
            // _setDefaultPropertiesBtn
            // 
            this._setDefaultPropertiesBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._setDefaultPropertiesBtn.Location = new System.Drawing.Point(94, 293);
            this._setDefaultPropertiesBtn.Name = "_setDefaultPropertiesBtn";
            this._setDefaultPropertiesBtn.Size = new System.Drawing.Size(324, 46);
            this._setDefaultPropertiesBtn.TabIndex = 28;
            this._setDefaultPropertiesBtn.Text = "Установить характеристики по-умолчанию";
            this._setDefaultPropertiesBtn.UseVisualStyleBackColor = false;
            this._setDefaultPropertiesBtn.Click += new System.EventHandler(this._setDefaultPropertiesBtn_Click);
            // 
            // _drawNeuralNetworkBtn
            // 
            this._drawNeuralNetworkBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._drawNeuralNetworkBtn.Location = new System.Drawing.Point(95, 501);
            this._drawNeuralNetworkBtn.Name = "_drawNeuralNetworkBtn";
            this._drawNeuralNetworkBtn.Size = new System.Drawing.Size(323, 46);
            this._drawNeuralNetworkBtn.TabIndex = 29;
            this._drawNeuralNetworkBtn.Text = "Отрисовать нейросеть";
            this._drawNeuralNetworkBtn.UseVisualStyleBackColor = false;
            this._drawNeuralNetworkBtn.Click += new System.EventHandler(this._drawNeuralNetworkBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 579);
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
            ((System.ComponentModel.ISupportInitialize)(this._alphaN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._minWeightN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._maxWeightN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button _createNeuralNetworkBtn;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.NumericUpDown _amountInputNeuronsN;
        internal System.Windows.Forms.NumericUpDown _amountHiddenNeuronsN;
        internal System.Windows.Forms.NumericUpDown _amountOutputNeuronsN;
        internal System.Windows.Forms.NumericUpDown _alphaN;
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
    }
}

