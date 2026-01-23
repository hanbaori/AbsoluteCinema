using System;

namespace AbsoluteCinema
{
    class ConsoleCommand
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public Role Role { get; set; }
        public Action ConsoleAction { get; set; }

        public ConsoleCommand(string Key, string Value, Role Role, Action ConsoleAction)
        {
            this.Key = Key;
            this.Value = Value;
            this.Role = Role;
            this.ConsoleAction = ConsoleAction;
        }
    }
}
