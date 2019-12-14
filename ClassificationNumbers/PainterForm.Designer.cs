namespace ClassificationNumbers
{
    partial class PainterForm
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
            this._mainPanel = new System.Windows.Forms.Panel();
            this._mainPictureBox = new System.Windows.Forms.PictureBox();
            this._mainProgressBar = new System.Windows.Forms.ProgressBar();
            this._mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _mainPanel
            // 
            this._mainPanel.AutoScroll = true;
            this._mainPanel.Controls.Add(this._mainPictureBox);
            this._mainPanel.Location = new System.Drawing.Point(12, 12);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.Size = new System.Drawing.Size(1731, 713);
            this._mainPanel.TabIndex = 1;
            // 
            // _mainPictureBox
            // 
            this._mainPictureBox.Location = new System.Drawing.Point(0, 0);
            this._mainPictureBox.Name = "_mainPictureBox";
            this._mainPictureBox.Size = new System.Drawing.Size(2000, 20000);
            this._mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._mainPictureBox.TabIndex = 0;
            this._mainPictureBox.TabStop = false;
            // 
            // _mainProgressBar
            // 
            this._mainProgressBar.Location = new System.Drawing.Point(12, 731);
            this._mainProgressBar.Name = "_mainProgressBar";
            this._mainProgressBar.Size = new System.Drawing.Size(1731, 23);
            this._mainProgressBar.TabIndex = 3;
            // 
            // PainterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1755, 761);
            this.Controls.Add(this._mainProgressBar);
            this.Controls.Add(this._mainPanel);
            this.Name = "PainterForm";
            this.Text = "Отображение";
            this._mainPanel.ResumeLayout(false);
            this._mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mainPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel _mainPanel;
        internal System.Windows.Forms.PictureBox _mainPictureBox;
        private System.Windows.Forms.ProgressBar _mainProgressBar;
    }
}