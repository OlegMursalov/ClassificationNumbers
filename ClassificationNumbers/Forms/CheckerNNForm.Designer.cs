namespace ClassificationNumbers.Forms
{
    partial class CheckerNNForm
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
            if (_paramsDrawEditor != null)
            {
                _paramsDrawEditor.Dispose();
            }

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
            this._mainPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this._checkNNBtn = new System.Windows.Forms.Button();
            this._clearEditorBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _mainPictureBox
            // 
            this._mainPictureBox.BackColor = System.Drawing.Color.White;
            this._mainPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._mainPictureBox.Location = new System.Drawing.Point(12, 32);
            this._mainPictureBox.Name = "_mainPictureBox";
            this._mainPictureBox.Size = new System.Drawing.Size(433, 406);
            this._mainPictureBox.TabIndex = 0;
            this._mainPictureBox.TabStop = false;
            this._mainPictureBox.MouseMove += _mainPictureBox_MouseMove;
            this._mainPictureBox.Paint += _mainPictureBox_Paint;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Простой графический редактор";
            // 
            // _checkNNBtn
            // 
            this._checkNNBtn.Location = new System.Drawing.Point(451, 32);
            this._checkNNBtn.Name = "_checkNNBtn";
            this._checkNNBtn.Size = new System.Drawing.Size(155, 69);
            this._checkNNBtn.TabIndex = 6;
            this._checkNNBtn.Text = "Классифицировать изображение";
            this._checkNNBtn.UseVisualStyleBackColor = true;
            this._checkNNBtn.Click += new System.EventHandler(this._checkNNBtn_Click);
            // 
            // _clearEditorBtn
            // 
            this._clearEditorBtn.Location = new System.Drawing.Point(451, 107);
            this._clearEditorBtn.Name = "_clearEditorBtn";
            this._clearEditorBtn.Size = new System.Drawing.Size(154, 69);
            this._clearEditorBtn.TabIndex = 7;
            this._clearEditorBtn.Text = "Очистить редактор";
            this._clearEditorBtn.UseVisualStyleBackColor = true;
            this._clearEditorBtn.Click += new System.EventHandler(this._clearEditorBtn_Click);
            // 
            // CheckerNNForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 450);
            this.Controls.Add(this._clearEditorBtn);
            this.Controls.Add(this._checkNNBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._mainPictureBox);
            this.Name = "CheckerNNForm";
            this.Text = "Окно проверки работы нейронной сети";
            ((System.ComponentModel.ISupportInitialize)(this._mainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _mainPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _checkNNBtn;
        private System.Windows.Forms.Button _clearEditorBtn;
    }
}