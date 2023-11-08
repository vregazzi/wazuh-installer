namespace Wazuh_Installer
{
    partial class Configure
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
            uninstallButton = new Button();
            closeButton = new Button();
            infoLabel = new Label();
            keyLabel = new Label();
            keyFilePath = new TextBox();
            keyFileChoose = new Button();
            certFileChoose = new Button();
            certFilePath = new TextBox();
            certLabel = new Label();
            ipStatusLabel = new Label();
            ipLabel = new Label();
            ipTextBox = new TextBox();
            applyButton = new Button();
            label1 = new Label();
            managerLabel = new Label();
            portsLabel = new Label();
            pingLabel = new Label();
            portsButton = new Button();
            pingButton = new Button();
            SuspendLayout();
            // 
            // uninstallButton
            // 
            uninstallButton.Location = new Point(21, 356);
            uninstallButton.Name = "uninstallButton";
            uninstallButton.Size = new Size(75, 23);
            uninstallButton.TabIndex = 2;
            uninstallButton.Text = "Uninstall";
            uninstallButton.UseVisualStyleBackColor = true;
            uninstallButton.Click += UninstallButton_Click;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(404, 356);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 33;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Location = new Point(21, 41);
            infoLabel.MaximumSize = new Size(458, 0);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(455, 30);
            infoLabel.TabIndex = 39;
            infoLabel.Text = "This is the Wazuh configuration page. Below, you can choose the key, cert, and ip. Alternatively, you can also uninstall.";
            // 
            // keyLabel
            // 
            keyLabel.AutoSize = true;
            keyLabel.Location = new Point(21, 87);
            keyLabel.Name = "keyLabel";
            keyLabel.Size = new Size(29, 15);
            keyLabel.TabIndex = 40;
            keyLabel.Text = "Key:";
            keyLabel.Click += KeyLabel_Click;
            // 
            // keyFilePath
            // 
            keyFilePath.Location = new Point(56, 84);
            keyFilePath.Name = "keyFilePath";
            keyFilePath.Size = new Size(328, 23);
            keyFilePath.TabIndex = 41;
            keyFilePath.TextChanged += KeyFilePath_TextChanged;
            // 
            // keyFileChoose
            // 
            keyFileChoose.Location = new Point(404, 84);
            keyFileChoose.Name = "keyFileChoose";
            keyFileChoose.Size = new Size(75, 23);
            keyFileChoose.TabIndex = 42;
            keyFileChoose.Text = "Browse";
            keyFileChoose.UseVisualStyleBackColor = true;
            keyFileChoose.Click += KeyFileChoose_Click;
            // 
            // certFileChoose
            // 
            certFileChoose.Location = new Point(404, 129);
            certFileChoose.Name = "certFileChoose";
            certFileChoose.Size = new Size(75, 23);
            certFileChoose.TabIndex = 45;
            certFileChoose.Text = "Browse";
            certFileChoose.UseVisualStyleBackColor = true;
            certFileChoose.Click += CertFileChoose_Click;
            // 
            // certFilePath
            // 
            certFilePath.Location = new Point(56, 129);
            certFilePath.Name = "certFilePath";
            certFilePath.Size = new Size(328, 23);
            certFilePath.TabIndex = 47;
            certFilePath.TextChanged += CertFilePath_TextChanged;
            // 
            // certLabel
            // 
            certLabel.AutoSize = true;
            certLabel.Location = new Point(21, 132);
            certLabel.Name = "certLabel";
            certLabel.Size = new Size(32, 15);
            certLabel.TabIndex = 46;
            certLabel.Text = "Cert:";
            // 
            // ipStatusLabel
            // 
            ipStatusLabel.AutoSize = true;
            ipStatusLabel.Location = new Point(56, 174);
            ipStatusLabel.Name = "ipStatusLabel";
            ipStatusLabel.Size = new Size(0, 15);
            ipStatusLabel.TabIndex = 50;
            // 
            // ipLabel
            // 
            ipLabel.AutoSize = true;
            ipLabel.Location = new Point(21, 177);
            ipLabel.Name = "ipLabel";
            ipLabel.Size = new Size(20, 15);
            ipLabel.TabIndex = 49;
            ipLabel.Text = "IP:";
            // 
            // ipTextBox
            // 
            ipTextBox.Location = new Point(56, 171);
            ipTextBox.Name = "ipTextBox";
            ipTextBox.Size = new Size(150, 23);
            ipTextBox.TabIndex = 48;
            ipTextBox.TextChanged += IpTextBox_TextChanged;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(309, 356);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(75, 23);
            applyButton.TabIndex = 51;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += Apply_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 220);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 52;
            label1.Text = "Agent registered:";
            // 
            // managerLabel
            // 
            managerLabel.AutoSize = true;
            managerLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            managerLabel.Location = new Point(139, 214);
            managerLabel.Name = "managerLabel";
            managerLabel.Size = new Size(0, 25);
            managerLabel.TabIndex = 53;
            // 
            // portsLabel
            // 
            portsLabel.AutoSize = true;
            portsLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            portsLabel.Location = new Point(242, 169);
            portsLabel.Name = "portsLabel";
            portsLabel.Size = new Size(0, 25);
            portsLabel.TabIndex = 57;
            // 
            // pingLabel
            // 
            pingLabel.AutoSize = true;
            pingLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            pingLabel.Location = new Point(366, 169);
            pingLabel.Name = "pingLabel";
            pingLabel.Size = new Size(0, 25);
            pingLabel.TabIndex = 56;
            // 
            // portsButton
            // 
            portsButton.Location = new Point(276, 171);
            portsButton.Name = "portsButton";
            portsButton.Size = new Size(79, 23);
            portsButton.TabIndex = 55;
            portsButton.Text = "Check Ports";
            portsButton.UseVisualStyleBackColor = true;
            portsButton.Click += PortsButton_Click;
            // 
            // pingButton
            // 
            pingButton.Location = new Point(404, 171);
            pingButton.Name = "pingButton";
            pingButton.Size = new Size(75, 23);
            pingButton.TabIndex = 54;
            pingButton.Text = "Ping";
            pingButton.UseVisualStyleBackColor = true;
            pingButton.Click += PingButton_Click;
            // 
            // Configure
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(portsLabel);
            Controls.Add(pingLabel);
            Controls.Add(portsButton);
            Controls.Add(pingButton);
            Controls.Add(managerLabel);
            Controls.Add(label1);
            Controls.Add(applyButton);
            Controls.Add(ipStatusLabel);
            Controls.Add(ipLabel);
            Controls.Add(ipTextBox);
            Controls.Add(certFilePath);
            Controls.Add(certLabel);
            Controls.Add(certFileChoose);
            Controls.Add(keyFileChoose);
            Controls.Add(keyFilePath);
            Controls.Add(keyLabel);
            Controls.Add(infoLabel);
            Controls.Add(closeButton);
            Controls.Add(uninstallButton);
            MaximumSize = new Size(500, 400);
            MinimumSize = new Size(500, 400);
            Name = "Configure";
            Size = new Size(500, 400);
            Load += Uninstall_Load;
            VisibleChanged += Configure_VisibleChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button uninstallButton;
        private Button closeButton;
        private Label infoLabel;
        private Label keyLabel;
        private TextBox keyFilePath;
        private Button keyFileChoose;
        private Button certFileChoose;
        private TextBox certFilePath;
        private Label certLabel;
        private Label ipStatusLabel;
        private Label ipLabel;
        private TextBox ipTextBox;
        private Button applyButton;
        private Label label1;
        private Label managerLabel;
        private Label portsLabel;
        private Label pingLabel;
        private Button portsButton;
        private Button pingButton;
    }
}
