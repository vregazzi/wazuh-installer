namespace Wazuh_Installer
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            error = new Error();
            config = new Configure();
            NextButton = new Button();
            infoLabel = new Label();
            welcomeLabel = new Label();
            SuspendLayout();
            // 
            // error
            // 
            error.Location = new Point(-8, -31);
            error.MaximumSize = new Size(500, 400);
            error.MinimumSize = new Size(500, 400);
            error.Name = "error";
            error.Size = new Size(500, 400);
            error.TabIndex = 0;
            error.Load += error_Load_1;
            // 
            // config
            // 
            config.Location = new Point(-8, -31);
            config.MaximumSize = new Size(500, 400);
            config.MinimumSize = new Size(500, 400);
            config.Name = "config";
            config.Size = new Size(500, 400);
            config.TabIndex = 2;
            config.Load += Config_Load;
            // 
            // NextButton
            // 
            NextButton.Location = new Point(397, 326);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(75, 23);
            NextButton.TabIndex = 3;
            NextButton.Text = "Install";
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += NextButton_Click;
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Location = new Point(13, 10);
            infoLabel.MaximumSize = new Size(458, 0);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(0, 15);
            infoLabel.TabIndex = 40;
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Location = new Point(12, 10);
            welcomeLabel.MaximumSize = new Size(458, 0);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(0, 15);
            welcomeLabel.TabIndex = 41;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 361);
            Controls.Add(welcomeLabel);
            Controls.Add(infoLabel);
            Controls.Add(NextButton);
            Controls.Add(error);
            Controls.Add(config);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(500, 400);
            MinimumSize = new Size(500, 400);
            Name = "Form";
            Text = "Wazuh Installer";
            FormClosing += Form_FormClosing;
            Load += Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Error error;
        private Configure config;
        private Button NextButton;
        private Label infoLabel;
        private Label welcomeLabel;
    }
}