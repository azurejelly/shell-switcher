using System.Configuration;
using System.Diagnostics;
using switch_my_shell.Utils;

namespace switch_my_shell
{
    internal static class Program
    {
        public static readonly IniFile CONFIG_FILE = new IniFile(Directory.GetCurrentDirectory() + @"\settings.ini");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (CONFIG_FILE.KeyExists("customShellLocation"))
            {
                var loc = CONFIG_FILE.Read("customShellLocation").ToString();
                if (File.Exists(loc))
                {
                    Application.Run(new MainForm());
                    return;
                }
            }

            var res = MessageBox.Show(
                "No custom shell has been specified or is available. You will now be asked for one.",
                "Switch shell",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information
            );

            if (res == DialogResult.Cancel)
            {
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "Executable files (*.exe)|*.exe";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("No custom shell was selected. Exiting.", "Switch shell", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            // I suppose the return value of File#exists(...) in this context
            // should always be true, but we're doing this just in case
            if (!File.Exists(openFileDialog.FileName))
            {
                MessageBox.Show("The selected file does not exist.", "Switch shell", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                CONFIG_FILE.Write("customShellLocation", openFileDialog.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to save app settings. Exiting.", "Switch shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new MainForm());
        }
    }
}