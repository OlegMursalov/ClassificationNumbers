namespace ClassificationNumbers.Forms
{
    partial class RightAnswerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this._resultNumN = new System.Windows.Forms.NumericUpDown();
            this._rightNumN = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this._updateWeightsNNBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._resultNumN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._rightNumN)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ответ нейросети";
            // 
            // _resultNumN
            // 
            this._resultNumN.Location = new System.Drawing.Point(149, 7);
            this._resultNumN.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._resultNumN.Name = "_resultNumN";
            this._resultNumN.Size = new System.Drawing.Size(120, 22);
            this._resultNumN.TabIndex = 2;
            // 
            // _rightNumN
            // 
            this._rightNumN.Location = new System.Drawing.Point(149, 35);
            this._rightNumN.Name = "_rightNumN";
            this._rightNumN.Size = new System.Drawing.Size(120, 22);
            this._rightNumN.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Правильный ответ";
            // 
            // _updateWeightsNNBtn
            // 
            this._updateWeightsNNBtn.Location = new System.Drawing.Point(15, 81);
            this._updateWeightsNNBtn.Name = "_updateWeightsNNBtn";
            this._updateWeightsNNBtn.Size = new System.Drawing.Size(254, 59);
            this._updateWeightsNNBtn.TabIndex = 5;
            this._updateWeightsNNBtn.Text = "Подправить веса нейросети";
            this._updateWeightsNNBtn.UseVisualStyleBackColor = true;
            this._updateWeightsNNBtn.Click += new System.EventHandler(this._updateWeightsNNBtn_Click);
            // 
            // RightAnswerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 186);
            this.Controls.Add(this._updateWeightsNNBtn);
            this.Controls.Add(this._rightNumN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._resultNumN);
            this.Controls.Add(this.label1);
            this.Name = "RightAnswerForm";
            this.Text = "Правильный ответ (цифры)";
            ((System.ComponentModel.ISupportInitialize)(this._resultNumN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._rightNumN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _resultNumN;
        private System.Windows.Forms.NumericUpDown _rightNumN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _updateWeightsNNBtn;
    }
}