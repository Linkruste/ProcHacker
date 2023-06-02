namespace ProcHacker
{
    internal class Key
    {
        public string Name { get; private set; }
        public string Value { get; private set; }
        public string Path { get ; private set; }

        public Key(string name, string value, string path)
        {
            Name = name;
            Value = value;
            Path = path;
        }

        public string ToCommandString() => $"-Path \"{Path}\" -Name \"{Name}\" -Value \"{Value}\"";
        public string ToGetString() => $"-Path \"{Path}\" -Name \"{Name}\"";
    }
}
