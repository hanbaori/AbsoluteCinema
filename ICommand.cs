using System;

namespace AbsoluteCinema
{
    interface ICommand
    {
        string Key { get; }
        string Description { get; }
        Role RequiredRole { get; }
        void Execute();
    }
}
