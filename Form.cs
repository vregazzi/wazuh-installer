using System.Diagnostics;
using System.DirectoryServices;

namespace Wazuh_Installer
{
    public partial class Form : System.Windows.Forms.Form
    {
        bool wazuhInstalled = false;
        string[] msiFilePaths;
        string msiPath = "";
        string currDir = "";
        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            currDir = $"{Path.GetDirectoryName(Application.ExecutablePath)}";
            this.error.Visible = false;
            this.config.Visible = false;

            try
            {
                msiFilePaths = Directory.GetFiles(currDir, "wazuh-agent-*.msi");
                //msiPath = Directory.GetFiles(currDir, "wazuh-agent-*.msi")[0];
                msiPath = GetLatestMsiPath(msiFilePaths);
            }
            catch
            {
                this.NextButton.Visible = false;
                this.error.Visible = true;
                return;
            }

            if (File.Exists("C:\\Program Files (x86)\\ossec-agent\\wazuh-agent.exe"))
            {
                this.welcomeLabel.Text =
                    "Wazuh is already installed. " +
                    "Click \"Configure\" below to edit its configuration settings or uninstall.";
                wazuhInstalled = true;
                this.NextButton.Text = "Configure";
            }
            else
            {
                this.welcomeLabel.Text =
                    "Click \"Install\" below to install Wazuh. " +
                    "Once installation is finished, you will be taken to a configuration page.";
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            this.welcomeLabel.Text = "";
            this.NextButton.Visible = false;
            if (!wazuhInstalled)
            {
                CancellationTokenSource installToken = new();
                Thread loadingEffectThread = new(
                    () => InstallLoadingEffect(installToken.Token)
                    )
                {
                    IsBackground = true
                };
                loadingEffectThread.Start();
                Install_Wazuh();
                installToken.Cancel();
                loadingEffectThread.Join();
                installToken.Dispose();

                this.welcomeLabel.Text = "";
            }
            this.config.Visible = true;
        }

        private void Install_Wazuh()
        {
            string msiName = Path.GetFileName(msiPath);
            string dirPath = Path.GetDirectoryName(msiPath);
            string command = $"/c cd \"{dirPath}\" & .\\{msiName} /q WAZUH_MANAGER=\"0.0.0.0\" WAZUH_REGISTRATION_KEY=\"x\" WAZUH_REGISTRATION_CERTIFICATE=\"x\" & NET START WazuhSvc";
            Process secretProcess = new();
            ProcessStartInfo secretStartInfo = new()
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                CreateNoWindow = true,
                Arguments = command
            };

            secretProcess.StartInfo = secretStartInfo;
            secretProcess.Start();
            secretProcess.WaitForExit();
        }

        private void Error_Load(object sender, EventArgs e)
        {

        }

        private void Config_Load(object sender, EventArgs e)
        {

        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }
        public void InstallLoadingEffect(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                string baseString = "Wazuh is now installing";
                this.welcomeLabel.Text = $"{baseString}";
                Thread.Sleep(1000);
                this.welcomeLabel.Text = $"{baseString}.";
                Thread.Sleep(1000);
                this.welcomeLabel.Text = $"{baseString}..";
                Thread.Sleep(1000);
                this.welcomeLabel.Text = $"{baseString}...";
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

        private void error_Load_1(object sender, EventArgs e)
        {

        }
    }
}