namespace AccessibilityProject
{
    partial class Display
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
            this.components = new System.ComponentModel.Container();
            this.formImageBox = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.formImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // formImageBox
            // 
            this.formImageBox.Location = new System.Drawing.Point(12, 12);
            this.formImageBox.Name = "formImageBox";
            this.formImageBox.Size = new System.Drawing.Size(960, 540);
            this.formImageBox.TabIndex = 2;
            this.formImageBox.TabStop = false;
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 600);
            this.Controls.Add(this.formImageBox);
            this.Name = "Display";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.formImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox formImageBox;
    }
}

