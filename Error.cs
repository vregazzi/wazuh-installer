namespace Wazuh_Installer
{
    public partial class Error : UserControl
    {
        public Error()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Error_Load(object sender, EventArgs e)
        {

        }
    }
}
