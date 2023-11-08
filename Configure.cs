using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Xml;
using System.Net.Sockets;
using System.Threading;

namespace Wazuh_Installer
{
    public partial class Configure : UserControl
    {
        bool newInstall = true;
        readonly string currDir = $"{Path.GetDirectoryName(Application.ExecutablePath)}";
        readonly string confPath = "C:\\Program Files (x86)\\ossec-agent\\ossec.conf";

        public Configure()
        {
            InitializeComponent();
        }

        private void Uninstall_Load(object sender, EventArgs e)
        {
            this.closeButton.Enabled = false;

            if (File.Exists(confPath))
            {
                newInstall = false;

                var xmlFile = File.ReadAllText(confPath);
                if (xmlFile.Contains("0.0.0.0"))
                {
                    newInstall = true;
                }
            }

            if (newInstall)
            {
                try
                {
                    string keyPath = Directory.GetFiles(currDir, "*.key")[0];
                    this.keyFilePath.Text = keyPath;
                }
                catch { this.keyFilePath.Text = ""; }

                try
                {
                    string certPath = Directory.GetFiles(currDir, "*.cert")[0];
                    this.certFilePath.Text = certPath;
                }
                catch { this.certFilePath.Text = ""; }

                try
                {
                    string ipPath = Directory.GetFiles(currDir, "manager-ip.txt")[0];
                    string ip = File.ReadAllText(ipPath);
                    this.ipTextBox.Text = ip;
                }
                catch { this.ipTextBox.Text = ""; }
            }
            else
            {
                XmlDocument doc = new();
                doc.Load(confPath);
                var root = doc.DocumentElement;

                if (root != null)
                {
                    var keyNode = root.SelectSingleNode("descendant::agent_key_path/text()");
                    var certNode = root.SelectSingleNode("descendant::agent_certificate_path/text()");
                    var ipNode = root.SelectSingleNode("descendant::address/text()");

                    if (keyNode != null)
                    {
                        this.keyFilePath.Text = keyNode.InnerText;
                    }

                    if (certNode != null)
                    {
                        this.certFilePath.Text = certNode.InnerText;
                    }

                    if (ipNode != null)
                    {
                        this.ipTextBox.Text = ipNode.InnerText;
                    }
                }
            }
        }

        private void UninstallButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to uninstall Wazuh?",
                "Confirm Uninstall",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }
            CancellationTokenSource uninstallToken = new();
            Thread loadingEffectThread = new(
                () => UninstallLoadingEffect(uninstallToken.Token)
                )
            {
                IsBackground = true
            };
            loadingEffectThread.Start();

            this.keyLabel.Visible = false;
            this.certLabel.Visible = false;
            this.ipLabel.Visible = false;
            this.keyFileChoose.Visible = false;
            this.certFileChoose.Visible = false;
            this.ipTextBox.Visible = false;
            this.keyFilePath.Visible = false;
            this.certFilePath.Visible = false;
            this.pingButton.Visible = false;
            this.portsButton.Visible = false;
            this.pingLabel.Visible = false;
            this.portsLabel.Visible = false;
            this.label1.Visible = false;
            this.managerLabel.Visible = false;
            this.applyButton.Visible = false;
            this.uninstallButton.Visible = false;

            string dataPath = $"{Path.GetDirectoryName(Application.ExecutablePath)}";
            //string msiName = new FileInfo(Directory.GetFiles(dataPath, "wazuh-agent-*.msi")[0]).Name;
            string[] msiFilePaths = Directory.GetFiles(currDir, "wazuh-agent-*.msi");
            string latestMsi = GetLatestMsiPath(msiFilePaths);
            string msiName = new FileInfo(latestMsi).Name;

            Process process = new();
            ProcessStartInfo startInfo = new()
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                CreateNoWindow = true,
                Arguments = "/c " +
                $"cd {dataPath} & " +
                $"net stop wazuh & " +
                $"msiexec.exe /x {msiName} /qn"
            };

            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            this.closeButton.Enabled = true;

            uninstallToken.Cancel();
            loadingEffectThread.Join();
            uninstallToken.Dispose();

            if (process.ExitCode == 0)
            {
                this.infoLabel.Text = "Wazuh is no longer installed.";

            }
            else
            {
                this.infoLabel.Text = "Wazuh failed to uninstall.";

            }
        }

        private void SetButton()
        {
            applyButton.Enabled =
                (keyFilePath.Text != "" || keyFilePath.Visible == false) &&
                (keyFilePath.Text.EndsWith(".key")) &&
                (certFilePath.Text != "" || certFilePath.Visible == false) &&
                (certFilePath.Text.EndsWith(".cert")) &&
                (ipTextBox.Text != "" || ipTextBox.Visible == false) &&
                (ValidateIPv4(ipTextBox.Text));
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new();
            Process restartWazuh = new();
            ProcessStartInfo restartWazuhInfo = new()
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                CreateNoWindow = true,
                Arguments = "/c net stop wazuh & net start wazuh"
            };

            this.applyButton.Enabled = false;
            doc.Load(confPath);

            var root = doc.DocumentElement;
            if (root == null) { return; }

            var ipNode = root.SelectSingleNode($"descendant::address/text()");
            if (ipNode == null) { return; }
            ipNode.Value = this.ipTextBox.Text;

            var keyNode = root.SelectSingleNode($"descendant::agent_key_path/text()");
            if (keyNode == null) { return; }
            keyNode.Value = this.keyFilePath.Text;

            var certNode = root.SelectSingleNode($"descendant::agent_certificate_path/text()");
            if (certNode == null) { return; }
            certNode.Value = this.certFilePath.Text;

            doc.Save(confPath);

            restartWazuh.StartInfo = restartWazuhInfo;
            restartWazuh.Start();
            restartWazuh.WaitForExit();

            Thread checkThread;
            checkThread = new Thread(new ThreadStart(CheckState))
            {
                IsBackground = true
            };
            checkThread.Start();
        }

        private void KeyFileChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog keyFileDialog = new()
            {
                Title = "Select Key",
                InitialDirectory = currDir,
                Filter = "KEY|*.key"
            };
            keyFileDialog.ShowDialog();
            if (keyFileDialog.FileName != "")
            {
                keyFilePath.Text = keyFileDialog.FileName;
            }
            else
            {
                keyFilePath.Text = null;
            }
        }

        private void CertFileChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog certFileDialog = new()
            {
                Title = "Select Cert",
                InitialDirectory = currDir,
                Filter = "CERT|*.cert"
            };
            certFileDialog.ShowDialog();
            if (certFileDialog.FileName != "")
            {
                certFilePath.Text = certFileDialog.FileName;
            }
            else
            {
                certFilePath.Text = null;
            }
        }

        private void PingButton_Click(object sender, EventArgs e)
        {
            Ping myPing = new();
            try
            {
                PingReply reply = myPing.Send(this.ipTextBox.Text, 1000);
                if (reply != null)
                {
                    this.pingLabel.ForeColor = Color.Green;
                    this.pingLabel.Text = "✔️";
                }
            }
            catch
            {
                this.pingLabel.ForeColor = Color.Red;
                this.pingLabel.Text = "❌";
            }
        }

        private void PortsButton_Click(object sender, EventArgs e)
        {
            using TcpClient tcpClient1 = new(), tcpClient2 = new();
            try
            {
                tcpClient1.Connect(this.ipTextBox.Text, 1514);
                tcpClient2.Connect(this.ipTextBox.Text, 1515);
                this.portsLabel.ForeColor = Color.Green;
                this.portsLabel.Text = "✔️";
                this.pingLabel.ForeColor = Color.Green;
                this.pingLabel.Text = "✔️";
            }
            catch (Exception)
            {
                this.portsLabel.ForeColor = Color.Red;
                this.portsLabel.Text = "❌";
            }
        }

        private void KeyFilePath_TextChanged(object sender, EventArgs e)
        {
            SetButton();
        }

        private void CertFilePath_TextChanged(object sender, EventArgs e)
        {
            SetButton();
        }

        private void IpTextBox_TextChanged(object sender, EventArgs e)
        {
            SetButton();
            this.pingLabel.Text = "";
            this.portsLabel.Text = "";
        }

        public void CheckState()
        {
            bool connectedToManager = false;
            this.label1.Text = "Agent registered: pending";
            this.managerLabel.Text = "";
            this.closeButton.Enabled = false;

            for (int i = 0; i < 15; ++i)
            {
                try
                {
                    if (File.Exists("C:\\Program Files (x86)\\ossec-agent\\wazuh-agent.state"))
                    {
                        var xmlFile = File.ReadAllText("C:\\Program Files (x86)\\ossec-agent\\wazuh-agent.state");
                        if (xmlFile.Contains("status='connected'"))
                        {
                            this.label1.Text = "Agent registered:";
                            this.managerLabel.ForeColor = Color.Green;
                            this.managerLabel.Text = "✔️";
                            this.closeButton.Enabled = true;
                            return;
                        }
                    }
                    Thread.Sleep(10000);
                } catch { }
            }
            if (!connectedToManager)
            {
                this.label1.Text = "Agent registered:";
                this.managerLabel.ForeColor = Color.Red;
                this.managerLabel.Text = "❌";
                this.closeButton.Enabled = false;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void KeyLabel_Click(object sender, EventArgs e)
        {

        }

        private void Configure_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (File.Exists("C:\\Program Files (x86)\\ossec-agent\\wazuh-agent.state"))
                {
                    var xmlFile = File.ReadAllText("C:\\Program Files (x86)\\ossec-agent\\wazuh-agent.state");
                    if (xmlFile.Contains("status='connected'"))
                    {
                        this.managerLabel.ForeColor = Color.Green;
                        this.managerLabel.Text = "✔️";
                        this.closeButton.Enabled = true;
                    }
                }
                else
                {
                    this.managerLabel.ForeColor = Color.Red;
                    this.managerLabel.Text = "❌";
                    this.closeButton.Enabled = false;
                }
            }
            else
            {
                this.managerLabel.ForeColor = Color.Red;
                this.managerLabel.Text = "❌";
                this.closeButton.Enabled = false;
            }
        }

        public static bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            return splitValues.All(r => byte.TryParse(r, out byte tempForParsing));
        }

        public void UninstallLoadingEffect(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                string baseString = "Wazuh is currently uninstalling";
                this.infoLabel.Text = $"{baseString}";
                Thread.Sleep(1000);
                this.infoLabel.Text = $"{baseString}.";
                Thread.Sleep(1000);
                this.infoLabel.Text = $"{baseString}..";
                Thread.Sleep(1000);
                this.infoLabel.Text = $"{baseString}...";
                Thread.Sleep(1000);
            }
        }

        static string GetLatestMsiPath(string[] files)
        {
            List<string> versionStrings = new();
            int hyphenIndex;
            string version;
            var versionObjects = new List<Version>();
            string latestVerNum;
            string latestMsiPath;

            string dirPath;
            dirPath = Path.GetDirectoryName(files[0]);

            foreach (string file in files)
            {
                version = Path.GetFileName(file);
                version = version.Substring(14);

                hyphenIndex = version.IndexOf("-");
                version = version.Substring(0, hyphenIndex);

                versionObjects.Add(new Version(version));
            }

            versionObjects.Sort();
            versionObjects.Reverse();
            foreach (Version v in versionObjects)
            {
                versionStrings.Add(v.ToString());
            }

            latestVerNum = versionStrings[0];
            latestMsiPath = files.FirstOrDefault(s => s.Contains(latestVerNum));

            return latestMsiPath;
        }
    }
}
