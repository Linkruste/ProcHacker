using System.Diagnostics;
using System.Windows;

namespace ProcHacker
{
    internal static class RegistryManager
    {
        public static bool OverWriteKey(Key _infos)
        {
            string _command = $"Set-ItemProperty {_infos.ToCommandString()}";
            Process _powerShell = PowerShellQuickStart(_command);
            _powerShell.Start();
            string _errors = _powerShell.StandardError.ReadToEnd();
            _powerShell.WaitForExit();
            if (!string.IsNullOrEmpty(_errors))
            {
                OutputRegistryError(_errors);
                return false;
            }
            return true;
        }

        public static string ReadKey(Key _readable)
        {
            string _command = $"Set-ItemProperty {_readable.ToGetString()}";
            Process _powerShell = PowerShellQuickStart(_command);
            _powerShell.Start();
            string _output = _powerShell.StandardOutput.ReadToEnd();
            string _errors = _powerShell.StandardError.ReadToEnd();
            _powerShell.WaitForExit();
            if (!( string.IsNullOrEmpty(_errors) && string.IsNullOrEmpty(_output)))
                OutputRegistryError($"Couldn't get any output or following error(s) was found:\n{_errors}");
            return _output;
        }

        static Process PowerShellQuickStart(string _command) => 
            new Process()
            {
                StartInfo =
                    new ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = $"{_command}",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
            };

        private static void OutputRegistryError(string _error) => MessageBox.Show(_error, "Registry Error");
    }
}
