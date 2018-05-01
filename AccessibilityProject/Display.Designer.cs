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
            this.headLabel = new System.Windows.Forms.Label();
            this.backLabel = new System.Windows.Forms.Label();
            this.leftArmLabel = new System.Windows.Forms.Label();
            this.rightArmLabel = new System.Windows.Forms.Label();
            this.leftLegLabel = new System.Windows.Forms.Label();
            this.rightLegLabel = new System.Windows.Forms.Label();
            this.leftFootLabel = new System.Windows.Forms.Label();
            this.rightFootLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.mainTextBox = new System.Windows.Forms.TextBox();
            this.countHeadLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.formImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // formImageBox
            // 
            this.formImageBox.Location = new System.Drawing.Point(12, 12);
            this.formImageBox.Name = "formImageBox";
            this.formImageBox.Size = new System.Drawing.Size(640, 360);
            this.formImageBox.TabIndex = 2;
            this.formImageBox.TabStop = false;
            // 
            // headLabel
            // 
            this.headLabel.AutoSize = true;
            this.headLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headLabel.Location = new System.Drawing.Point(672, 22);
            this.headLabel.Name = "headLabel";
            this.headLabel.Size = new System.Drawing.Size(66, 24);
            this.headLabel.TabIndex = 3;
            this.headLabel.Text = "Head: ";
            // 
            // backLabel
            // 
            this.backLabel.AutoSize = true;
            this.backLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backLabel.Location = new System.Drawing.Point(672, 58);
            this.backLabel.Name = "backLabel";
            this.backLabel.Size = new System.Drawing.Size(61, 24);
            this.backLabel.TabIndex = 4;
            this.backLabel.Text = "Back: ";
            // 
            // leftArmLabel
            // 
            this.leftArmLabel.AutoSize = true;
            this.leftArmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftArmLabel.Location = new System.Drawing.Point(672, 93);
            this.leftArmLabel.Name = "leftArmLabel";
            this.leftArmLabel.Size = new System.Drawing.Size(89, 24);
            this.leftArmLabel.TabIndex = 5;
            this.leftArmLabel.Text = "Left Arm: ";
            // 
            // rightArmLabel
            // 
            this.rightArmLabel.AutoSize = true;
            this.rightArmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightArmLabel.Location = new System.Drawing.Point(672, 127);
            this.rightArmLabel.Name = "rightArmLabel";
            this.rightArmLabel.Size = new System.Drawing.Size(103, 24);
            this.rightArmLabel.TabIndex = 6;
            this.rightArmLabel.Text = "Right Arm: ";
            // 
            // leftLegLabel
            // 
            this.leftLegLabel.AutoSize = true;
            this.leftLegLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftLegLabel.Location = new System.Drawing.Point(672, 160);
            this.leftLegLabel.Name = "leftLegLabel";
            this.leftLegLabel.Size = new System.Drawing.Size(86, 24);
            this.leftLegLabel.TabIndex = 7;
            this.leftLegLabel.Text = "Left Leg: ";
            // 
            // rightLegLabel
            // 
            this.rightLegLabel.AutoSize = true;
            this.rightLegLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightLegLabel.Location = new System.Drawing.Point(672, 193);
            this.rightLegLabel.Name = "rightLegLabel";
            this.rightLegLabel.Size = new System.Drawing.Size(100, 24);
            this.rightLegLabel.TabIndex = 8;
            this.rightLegLabel.Text = "Right Leg: ";
            // 
            // leftFootLabel
            // 
            this.leftFootLabel.AutoSize = true;
            this.leftFootLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftFootLabel.Location = new System.Drawing.Point(672, 226);
            this.leftFootLabel.Name = "leftFootLabel";
            this.leftFootLabel.Size = new System.Drawing.Size(92, 24);
            this.leftFootLabel.TabIndex = 9;
            this.leftFootLabel.Text = "Left Foot: ";
            // 
            // rightFootLabel
            // 
            this.rightFootLabel.AutoSize = true;
            this.rightFootLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightFootLabel.Location = new System.Drawing.Point(672, 259);
            this.rightFootLabel.Name = "rightFootLabel";
            this.rightFootLabel.Size = new System.Drawing.Size(106, 24);
            this.rightFootLabel.TabIndex = 10;
            this.rightFootLabel.Text = "Right Foot: ";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(672, 567);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(70, 24);
            this.statusLabel.TabIndex = 11;
            this.statusLabel.Text = "Status: ";
            // 
            // mainTextBox
            // 
            this.mainTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.mainTextBox.Location = new System.Drawing.Point(12, 378);
            this.mainTextBox.Multiline = true;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.ReadOnly = true;
            this.mainTextBox.Size = new System.Drawing.Size(640, 210);
            this.mainTextBox.TabIndex = 14;
            // 
            // countHeadLabel
            // 
            this.countHeadLabel.AutoSize = true;
            this.countHeadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countHeadLabel.Location = new System.Drawing.Point(672, 527);
            this.countHeadLabel.Name = "countHeadLabel";
            this.countHeadLabel.Size = new System.Drawing.Size(70, 24);
            this.countHeadLabel.TabIndex = 15;
            this.countHeadLabel.Text = "Count: ";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLabel.Location = new System.Drawing.Point(742, 520);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(29, 31);
            this.countLabel.TabIndex = 16;
            this.countLabel.Text = "0";
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 600);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.countHeadLabel);
            this.Controls.Add(this.mainTextBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.rightFootLabel);
            this.Controls.Add(this.leftFootLabel);
            this.Controls.Add(this.rightLegLabel);
            this.Controls.Add(this.leftLegLabel);
            this.Controls.Add(this.rightArmLabel);
            this.Controls.Add(this.leftArmLabel);
            this.Controls.Add(this.backLabel);
            this.Controls.Add(this.headLabel);
            this.Controls.Add(this.formImageBox);
            this.Name = "Display";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.formImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox formImageBox;
        private System.Windows.Forms.Label headLabel;
        private System.Windows.Forms.Label backLabel;
        private System.Windows.Forms.Label leftArmLabel;
        private System.Windows.Forms.Label rightArmLabel;
        private System.Windows.Forms.Label leftLegLabel;
        private System.Windows.Forms.Label rightLegLabel;
        private System.Windows.Forms.Label leftFootLabel;
        private System.Windows.Forms.Label rightFootLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox mainTextBox;
        private System.Windows.Forms.Label countHeadLabel;
        private System.Windows.Forms.Label countLabel;
    }
}

