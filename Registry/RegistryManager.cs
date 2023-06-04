using System.Diagnostics;
using System.Windows;

namespace ProcHacker
{
    internal static class RegistryManager
    {
        /// <summary>
        /// Overrides or just write a new Registry key using Powershell.
        /// </summary>
        /// <param name="_infos"></param>
        /// <returns>True if the key has successfully been wrote into the registry, False if not.</returns>
        public static bool OverWriteKey(Key _infos)
        {
            string _command = $"Set-ItemProperty {_infos.ToCommandString()}";
            Process _powerShell = PowerShellQuickStart(_command);
            _powerShell.Start();
            string _errors = _powerShell.StandardError.ReadToEnd();
            _powerShell.WaitForExit();
            if (!string.IsNullOrEmpty(_errors) || ReadKey(_infos) != _infos.Value.Trim())
            {
                OutputRegistryError(_errors + $" .{_infos.Value}. != \n.{ReadKey(_infos)}.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Read the specified Key in the Registry.
        /// </summary>
        /// <param Key="_readable"></param>
        /// <returns>The specified Key content stored in the Registry.</returns>
        public static string ReadKey(Key _readable)
        {
            string _command = $"Get-ItemProperty {_readable.ToGetString()}";
            Process _powerShell = PowerShellQuickStart(_command);
            _powerShell.Start();
            string _output = _powerShell.StandardOutput.ReadToEnd();
            string _errors = _powerShell.StandardError.ReadToEnd();
            _powerShell.WaitForExit();
            if (!(string.IsNullOrEmpty(_errors) || string.IsNullOrEmpty(_output)))
                OutputRegistryError($"Couldn't get any output or following error(s) was found:\n{_errors}");
            return _output.Split(':')[1].Split('\n')[0].Trim().Replace("PSPath", "");
        }

        /// <summary>
        /// Creates an instance of Powershell with the specified string Command.
        /// </summary>
        /// <param Command="_command"></param>
        /// <returns>That created instance of Powershell.</returns>
        static Process PowerShellQuickStart(string _command) =>
            new Process()
            {
                StartInfo =
                    new ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = $"Powershell -NoProfile -ExecutionPolicy Bypass -Command \'{_command}\'",
                        Verb = "runas",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        StandardOutputEncoding = System.Text.Encoding.UTF8,
                        StandardErrorEncoding = System.Text.Encoding.UTF8,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
            };

        /// <summary>
        /// Alias for a MessageBox that shows an error.
        /// </summary>
        /// <param String="_error"></param>
        private static void OutputRegistryError(string _error) => MessageBox.Show(_error, "Registry Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
