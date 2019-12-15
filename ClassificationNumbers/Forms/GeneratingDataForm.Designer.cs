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
            this._selectImages28x28Btn = new System.Windows.Forms.Button();
            this._mainRichTxb = new System.Windows.Forms.RichTextBox();
            this._generateJSONDataBtn = new System.Windows.Forms.Button();
            this._statusDataLbl = new System.Windows.Forms.Label();
            this._statusSelectImgLbl = new System.Windows.Forms.Label();
            this._saveDataJsonInFileBtn = new System.Windows.Forms.Button();
            this._statusSaveLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _selectImages28x28Btn
            // 
            this._selectImages28x28Btn.Location = new System.Drawing.Point(12, 12);
            this._selectImages28x28Btn.Name = "_selectImages28x28Btn";
            this._selectImages28x28Btn.Size = new System.Drawing.Size(129, 69);
            this._selectImages28x28Btn.TabIndex = 0;
            this._selectImages28x28Btn.Text = "Выбрать картинки 28x28";
            this._selectImages28x28Btn.UseVisualStyleBackColor = true;
            this._selectImages28x28Btn.Click += new System.EventHandler(this._selectImages28x28Btn_Click);
            // 
            // _mainRichTxb
            // 
            this._mainRichTxb.Location = new System.Drawing.Point(12, 87);
            this._mainRichTxb.Name = "_mainRichTxb";
            this._mainRichTxb.Size = new System.Drawing.Size(776, 319);
            this._mainRichTxb.TabIndex = 1;
            this._mainRichTxb.Text = "";
            // 
            // _generateJSONDataBtn
            // 
            this._generateJSONDataBtn.Location = new System.Drawing.Point(147, 12);
            this._generateJSONDataBtn.Name = "_generateJSONDataBtn";
            this._generateJSONDataBtn.Size = new System.Drawing.Size(129, 69);
            this._generateJSONDataBtn.TabIndex = 2;
            this._generateJSONDataBtn.Text = "Генерировать JSON";
            this._generateJSONDataBtn.UseVisualStyleBackColor = true;
            this._generateJSONDataBtn.Click += new System.EventHandler(this._generateJSONDataBtn_Click);
            // 
            // _statusDataLbl
            // 
            this._statusDataLbl.AutoSize = true;
            this._statusDataLbl.BackColor = System.Drawing.Color.Firebrick;
            this._statusDataLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._statusDataLbl.Location = new System.Drawing.Point(417, 63);
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
            this._statusSelectImgLbl.Location = new System.Drawing.Point(417, 38);
            this._statusSelectImgLbl.Name = "_statusSelectImgLbl";
            this._statusSelectImgLbl.Size = new System.Drawing.Size(158, 17);
            this._statusSelectImgLbl.TabIndex = 4;
            this._statusSelectImgLbl.Text = "Картинки  не выбраны";
            // 
            // _saveDataJsonInFileBtn
            // 
            this._saveDataJsonInFileBtn.Location = new System.Drawing.Point(282, 12);
            this._saveDataJsonInFileBtn.Name = "_saveDataJsonInFileBtn";
            this._saveDataJsonInFileBtn.Size = new System.Drawing.Size(129, 69);
            this._saveDataJsonInFileBtn.TabIndex = 5;
            this._saveDataJsonInFileBtn.Text = "Сохранить JSON в файл";
            this._saveDataJsonInFileBtn.UseVisualStyleBackColor = true;
            this._saveDataJsonInFileBtn.Click += new System.EventHandler(this._saveDataJsonInFileBtn_Click);
            // 
            // _statusSaveLbl
            // 
            this._statusSaveLbl.AutoSize = true;
            this._statusSaveLbl.BackColor = System.Drawing.Color.Firebrick;
            this._statusSaveLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._statusSaveLbl.Location = new System.Drawing.Point(12, 409);
            this._statusSaveLbl.Name = "_statusSaveLbl";
            this._statusSaveLbl.Size = new System.Drawing.Size(130, 17);
            this._statusSaveLbl.TabIndex = 7;
            this._statusSaveLbl.Text = "JSON не сохранен";
            // 
            // GeneratingDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 439);
            this.Controls.Add(this._statusSaveLbl);
            this.Controls.Add(this._saveDataJsonInFileBtn);
            this.Controls.Add(this._statusSelectImgLbl);
            this.Controls.Add(this._statusDataLbl);
            this.Controls.Add(this._generateJSONDataBtn);
            this.Controls.Add(this._mainRichTxb);
            this.Controls.Add(this._selectImages28x28Btn);
            this.Name = "GeneratingDataForm";
            this.Text = "Генерация JSON данных из картинок для тренировки нейросети";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _selectImages28x28Btn;
        private System.Windows.Forms.RichTextBox _mainRichTxb;
        private System.Windows.Forms.Button _generateJSONDataBtn;
        private System.Windows.Forms.Label _statusDataLbl;
        private System.Windows.Forms.Label _statusSelectImgLbl;
        private System.Windows.Forms.Button _saveDataJsonInFileBtn;
        private System.Windows.Forms.Label _statusSaveLbl;
    }
}