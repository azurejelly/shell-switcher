using System.Diagnostics;

namespace switch_my_shell
{
    public partial class MainForm : Form
    {
        private SelectedShell selectedShell;

        public MainForm()
        {
            InitializeComponent();
            selectedShell = SelectedShell.None;
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

        private void apply_Click(object sender, EventArgs e)
        {
            var config = Program.CONFIG_FILE;
            if (config == null)
            {
                MessageBox.Show("Failed to read configuration. Exiting.", "Switch shell", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(-1);
                return;
            }

            var customShell = config.Read("customShellLocation");
            if (!File.Exists(customShell))
            {
                MessageBox.Show("Could not find custom shell. Exiting.", "Switch shell", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(-1);
                return;
            }

            string user = Environment.UserName;
            var sessionId = Process.GetCurrentProcess().SessionId;
            var customShellWithoutExt = Path.GetFileNameWithoutExtension(customShell);
            string[] targets = { customShellWithoutExt, "explorer" };

            foreach (Process process in Process.GetProcesses())
            {
                try
                {
                    if (targets.Contains(process.ProcessName) && process.SessionId == sessionId)
                    {
                        process.Kill();
                        process.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to kill matching process {process.ProcessName}: {ex.Message}", "Custom shell", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

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
                            MessageBox.Show("Failed to switch to default Windows shell as it is not present.", "Switch shell", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
