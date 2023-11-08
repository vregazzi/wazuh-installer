namespace Wazuh_Installer
{
    partial class Error
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            closeButton = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 41);
            label2.MaximumSize = new Size(458, 0);
            label2.MinimumSize = new Size(458, 0);
            label2.Name = "label2";
            label2.Size = new Size(458, 15);
            label2.TabIndex = 1;
            label2.Text = "Not able to find MSI installer.";
            // 
            // closeButton
            // 
            closeButton.Location = new Point(404, 356);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 2;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // Error
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(closeButton);
            Controls.Add(label2);
            MaximumSize = new Size(500, 400);
            MinimumSize = new Size(500, 400);
            Name = "Error";
            Size = new Size(500, 400);
            Load += Error_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button closeButton;
    }
}
