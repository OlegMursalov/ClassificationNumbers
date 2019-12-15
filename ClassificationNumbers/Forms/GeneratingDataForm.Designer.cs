namespace ClassificationNumbers.Forms
{
    partial class GeneratingDataForm
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
            this._selectImages28x28 = new System.Windows.Forms.Button();
            this._mainRichTxb = new System.Windows.Forms.RichTextBox();
            this._generateJSONData = new System.Windows.Forms.Button();
            this._statusDataLbl = new System.Windows.Forms.Label();
            this._statusSelectImgLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _selectImages28x28
            // 
            this._selectImages28x28.Location = new System.Drawing.Point(12, 12);
            this._selectImages28x28.Name = "_selectImages28x28";
            this._selectImages28x28.Size = new System.Drawing.Size(129, 69);
            this._selectImages28x28.TabIndex = 0;
            this._selectImages28x28.Text = "Выбрать картинки 28x28";
            this._selectImages28x28.UseVisualStyleBackColor = true;
            this._selectImages28x28.Click += new System.EventHandler(this._selectImages28x28_Click);
            // 
            // _mainRichTxb
            // 
            this._mainRichTxb.Location = new System.Drawing.Point(12, 87);
            this._mainRichTxb.Name = "_mainRichTxb";
            this._mainRichTxb.Size = new System.Drawing.Size(776, 351);
            this._mainRichTxb.TabIndex = 1;
            this._mainRichTxb.Text = "";
            // 
            // _generateJSONData
            // 
            this._generateJSONData.Location = new System.Drawing.Point(147, 12);
            this._generateJSONData.Name = "_generateJSONData";
            this._generateJSONData.Size = new System.Drawing.Size(129, 69);
            this._generateJSONData.TabIndex = 2;
            this._generateJSONData.Text = "Генерировать JSON";
            this._generateJSONData.UseVisualStyleBackColor = true;
            this._generateJSONData.Click += new System.EventHandler(this._generateJSONData_Click);
            // 
            // _statusDataLbl
            // 
            this._statusDataLbl.AutoSize = true;
            this._statusDataLbl.BackColor = System.Drawing.Color.Firebrick;
            this._statusDataLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._statusDataLbl.Location = new System.Drawing.Point(282, 63);
            this._statusDataLbl.Name = "_statusDataLbl";
            this._statusDataLbl.Size = new System.Drawing.Size(186, 17);
            this._statusDataLbl.TabIndex = 3;
            this._statusDataLbl.Text = "Данные не сгенерированы";
            // 
            // _statusSelectImgLbl
            // 
            this._statusSelectImgLbl.AutoSize = true;
            this._statusSelectImgLbl.BackColor = System.Drawing.Color.Firebrick;
            this._statusSelectImgLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._statusSelectImgLbl.Location = new System.Drawing.Point(282, 37);
            this._statusSelectImgLbl.Name = "_statusSelectImgLbl";
            this._statusSelectImgLbl.Size = new System.Drawing.Size(158, 17);
            this._statusSelectImgLbl.TabIndex = 4;
            this._statusSelectImgLbl.Text = "Картинки  не выбраны";
            // 
            // GeneratingDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._statusSelectImgLbl);
            this.Controls.Add(this._statusDataLbl);
            this.Controls.Add(this._generateJSONData);
            this.Controls.Add(this._mainRichTxb);
            this.Controls.Add(this._selectImages28x28);
            this.Name = "GeneratingDataForm";
            this.Text = "Генерация JSON данных из картинок для тренировки нейросети";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _selectImages28x28;
        private System.Windows.Forms.RichTextBox _mainRichTxb;
        private System.Windows.Forms.Button _generateJSONData;
        private System.Windows.Forms.Label _statusDataLbl;
        private System.Windows.Forms.Label _statusSelectImgLbl;
    }
}