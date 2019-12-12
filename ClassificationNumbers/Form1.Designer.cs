namespace ClassificationNumbers
{
    partial class Form1
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
            this._mainPictureBox = new System.Windows.Forms.PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)(this._mainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._amountInputNeuronsN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._amountHiddenNeuronsN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._amountOutputNeuronsN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._alphaN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._minWeightN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._maxWeightN)).BeginInit();
            this.SuspendLayout();
            // 
            // _mainPictureBox
            // 
            this._mainPictureBox.BackColor = System.Drawing.Color.AntiqueWhite;
            this._mainPictureBox.Location = new System.Drawing.Point(12, 12);
            this._mainPictureBox.Name = "_mainPictureBox";
            this._mainPictureBox.Size = new System.Drawing.Size(953, 658);
            this._mainPictureBox.TabIndex = 0;
            this._mainPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(982, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Кол-во входных узлов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(982, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Кол-во скрытых узлов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(984, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Кол-во выходных узлов";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(984, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Коэффициент обучения";
            // 
            // _createNeuralNetworkBtn
            // 
            this._createNeuralNetworkBtn.Location = new System.Drawing.Point(985, 463);
            this._createNeuralNetworkBtn.Name = "_createNeuralNetworkBtn";
            this._createNeuralNetworkBtn.Size = new System.Drawing.Size(150, 78);
            this._createNeuralNetworkBtn.TabIndex = 9;
            this._createNeuralNetworkBtn.Text = "Создать трехслойную нейросеть";
            this._createNeuralNetworkBtn.UseVisualStyleBackColor = true;
            this._createNeuralNetworkBtn.Click += new System.EventHandler(this._createNeuralNetworkBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(984, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Диапазон весов";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(984, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Функция активации";
            // 
            // _amountInputNeuronsN
            // 
            this._amountInputNeuronsN.Location = new System.Drawing.Point(985, 32);
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
            this._amountHiddenNeuronsN.Location = new System.Drawing.Point(985, 91);
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
            this._amountOutputNeuronsN.Location = new System.Drawing.Point(985, 152);
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
            this._alphaN.Location = new System.Drawing.Point(987, 214);
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
            this._minWeightN.Location = new System.Drawing.Point(987, 278);
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
            this._minWeightN.Size = new System.Drawing.Size(75, 22);
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
            this._maxWeightN.Location = new System.Drawing.Point(1068, 278);
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
            this._maxWeightN.Size = new System.Drawing.Size(67, 22);
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
            this._funcActivationsList.Location = new System.Drawing.Point(985, 350);
            this._funcActivationsList.Name = "_funcActivationsList";
            this._funcActivationsList.Size = new System.Drawing.Size(150, 84);
            this._funcActivationsList.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1705, 682);
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
            this.Controls.Add(this._mainPictureBox);
            this.Name = "Form1";
            this.Text = "Classification numbers - neural network";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._mainPictureBox)).EndInit();
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

        private System.Windows.Forms.PictureBox _mainPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _createNeuralNetworkBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown _amountInputNeuronsN;
        private System.Windows.Forms.NumericUpDown _amountHiddenNeuronsN;
        private System.Windows.Forms.NumericUpDown _amountOutputNeuronsN;
        private System.Windows.Forms.NumericUpDown _alphaN;
        private System.Windows.Forms.NumericUpDown _minWeightN;
        private System.Windows.Forms.NumericUpDown _maxWeightN;
        private System.Windows.Forms.ListBox _funcActivationsList;
    }
}

