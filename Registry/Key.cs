namespace ProcHacker
{
    class Key
    {
        public string Name { get; private set; }
        public string Value { get; private set; }
        public string Path { get ; private set; }

        public Key(string _name, string _value, string _path)
        {
            Name    = _name;
            Value   = _value;
            Path    = _path;
        }

        public string ToCommandString() => $"-Path \"{Path}\" -Name \"{Name}\" -Value \"{Value}\"";
        public string ToGetString() => $"-Path \"{Path}\" -Name \"{Name}\"";
    }
}
