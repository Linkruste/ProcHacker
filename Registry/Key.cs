using System.Collections.Generic;

namespace ProcHacker
{
    class Key
    {
        /// <summary>
        /// Enum storing all keys relative to KeyPath Dictionnary.
        /// </summary>
        public enum KeyType
        {
            ProcessorName
        }
        /// <summary>
        /// With the key's type name, finds the real key location in registry. Usage: <code>KeyPath["KeyType.ProcessorName"]</code>
        /// This feature exists in case more Keys could be modified in the future.
        /// </summary>
        public static Dictionary<KeyType, string> KeyPath { get; private set; } = new Dictionary<KeyType, string>()
        {
            { KeyType.ProcessorName, "HKLM:/HARDWARE/DESCRIPTION/System/CentralProcessor/0" }
        };

        /// <summary>
        /// The key's name.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The key's value.
        /// </summary>
        public string Value { get; private set; }
        /// <summary>
        /// The Registry path to get to the key.
        /// </summary>
        public string Path { get ; private set; }

        /// <summary>
        /// Returns a new Key.
        /// </summary>
        /// <param Path="_path"></param>
        /// <param Name="_name"></param>
        /// <param Value="_value"></param>
        public Key(string _path, string _name, string _value="")
        {
            Name    = _name;
            Value   = _value;
            Path    = _path;
        }

        /// <summary>
        /// Escapes all characters to avoid conflict with Microsoft PowerShell.
        /// </summary>
        /// <param Command="_command"></param>
        /// <returns>A formatted command for Microsoft Powershell.</returns>
        string FormatForPowerShell(string _command) => _command.Replace(" ", "` ").Replace("(", "`(").Replace(")", "`)").Replace("@", "`@").Replace("[", "`[").Replace("]", "`]").Replace("{", "`{").Replace("}", "`}");
        /// <summary>
        /// Transforms the Key into a string Powershell command to set the Registry key.
        /// </summary>
        /// <returns>The key part of the command to set the registry key.</returns>
        public string ToCommandString() => $"-Path \"{Path}\" -Name \"{Name}\" -Value \"{FormatForPowerShell(Value)}\"";
        /// <summary>
        /// Transforms the Key into a string to get the Registry key.
        /// </summary>
        /// <returns>The key part of the command to get the registry key.</returns>
        public string ToGetString() => $"-Path \"{Path}\" -Name \"{Name}\"";
    }
}
