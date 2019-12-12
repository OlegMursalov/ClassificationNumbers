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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._amountInputNeuronsTxb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._amountHiddenNeuronsTxb = new System.Windows.Forms.TextBox();
            this._amountOutputNeuronsTxb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._alphaTxb = new System.Windows.Forms.TextBox();
            this._createNeuralNetworkBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this._minWeightTxb = new System.Windows.Forms.TextBox();
            this._maxWeightTxb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(953, 658);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // _amountInputNeuronsTxb
            // 
            this._amountInputNeuronsTxb.Location = new System.Drawing.Point(985, 33);
            this._amountInputNeuronsTxb.Name = "_amountInputNeuronsTxb";
            this._amountInputNeuronsTxb.Size = new System.Drawing.Size(148, 22);
            this._amountInputNeuronsTxb.TabIndex = 1;
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
            // _amountHiddenNeuronsTxb
            // 
            this._amountHiddenNeuronsTxb.Location = new System.Drawing.Point(985, 91);
            this._amountHiddenNeuronsTxb.Name = "_amountHiddenNeuronsTxb";
            this._amountHiddenNeuronsTxb.Size = new System.Drawing.Size(148, 22);
            this._amountHiddenNeuronsTxb.TabIndex = 4;
            // 
            // _amountOutputNeuronsTxb
            // 
            this._amountOutputNeuronsTxb.Location = new System.Drawing.Point(987, 152);
            this._amountOutputNeuronsTxb.Name = "_amountOutputNeuronsTxb";
            this._amountOutputNeuronsTxb.Size = new System.Drawing.Size(148, 22);
            this._amountOutputNeuronsTxb.TabIndex = 6;
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
            // _alphaTxb
            // 
            this._alphaTxb.Location = new System.Drawing.Point(987, 214);
            this._alphaTxb.Name = "_alphaTxb";
            this._alphaTxb.Size = new System.Drawing.Size(148, 22);
            this._alphaTxb.TabIndex = 8;
            // 
            // _createNeuralNetworkBtn
            // 
            this._createNeuralNetworkBtn.Location = new System.Drawing.Point(987, 327);
            this._createNeuralNetworkBtn.Name = "_createNeuralNetworkBtn";
            this._createNeuralNetworkBtn.Size = new System.Drawing.Size(148, 78);
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
            // _minWeightTxb
            // 
            this._minWeightTxb.Location = new System.Drawing.Point(985, 278);
            this._minWeightTxb.Name = "_minWeightTxb";
            this._minWeightTxb.Size = new System.Drawing.Size(67, 22);
            this._minWeightTxb.TabIndex = 11;
            // 
            // _maxWeightTxb
            // 
            this._maxWeightTxb.Location = new System.Drawing.Point(1068, 278);
            this._maxWeightTxb.Name = "_maxWeightTxb";
            this._maxWeightTxb.Size = new System.Drawing.Size(67, 22);
            this._maxWeightTxb.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1705, 682);
            this.Controls.Add(this._maxWeightTxb);
            this.Controls.Add(this._minWeightTxb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._createNeuralNetworkBtn);
            this.Controls.Add(this._alphaTxb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._amountOutputNeuronsTxb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._amountHiddenNeuronsTxb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._amountInputNeuronsTxb);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Classification numbers - neural network";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox _amountInputNeuronsTxb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _amountHiddenNeuronsTxb;
        private System.Windows.Forms.TextBox _amountOutputNeuronsTxb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _alphaTxb;
        private System.Windows.Forms.Button _createNeuralNetworkBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _minWeightTxb;
        private System.Windows.Forms.TextBox _maxWeightTxb;
    }
}

