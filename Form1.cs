using System.Configuration;
using System.Diagnostics;

namespace switch_my_shell
{
    public partial class Form1 : Form
    {
        private SelectedShell selectedShell;

        public Form1()
        {
            InitializeComponent();
        }

        private void customShell_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultShell.Checked && sender is Button)
            {
                defaultShell.Checked = false;
            }

            selectedShell = SelectedShell.Custom;
        }

        private void defaultShell_CheckedChanged(object sender, EventArgs e)
        {
            if (customShell.Checked && sender is Button)
            {
                customShell.Checked = false;
            }

            selectedShell = SelectedShell.Default;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            var config = Program.CONFIG_FILE;
            if (config == null)
            {
                MessageBox.Show("Failed to read custom shell location", "Switch shell", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(-1);
                return;
            }

            var customShell = config.Read("customShellLocation");
            if (!File.Exists(customShell))
            {
                MessageBox.Show("Failed to find custom shell", "Switch shell", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(-1);
                return;
            }

            // i couldn't do this with regular APIs so here goes nothing (im tired (its 3 am))
            string user = Environment.UserName;
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c taskkill /f /fi \"USERNAME eq " + user + "\" /im " + customShell
                + " & taskkill /f /fi \"USERNAME eq " + user + "\" /im explorer.exe";

            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            switch (selectedShell)
            {
                case SelectedShell.Custom:
                    {
                        Process.Start(customShell);
                        MessageBox.Show("Switched to your preferred custom shell.", "Switch shell", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Environment.Exit(0);
                        break;
                    }
                case SelectedShell.Default:
                    {
                        string defShell = @"C:\Windows\explorer.exe";

                        if (!File.Exists(defShell))
                        {
                            MessageBox.Show("Cannot switch to default Windows shell as it is not present.", "Switch shell", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        Process.Start(defShell);
                        MessageBox.Show("Switched to the default Windows shell.", "Switch shell", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("You must select one of the two shell types.", "Switch shell", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
            }
        }

        public enum SelectedShell
        {
            None,
            Custom,
            Default
        }
    }
}
