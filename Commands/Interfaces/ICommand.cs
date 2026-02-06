using System;

namespace AbsoluteCinema.Commands.Interfaces
{
    interface ICommand
    {
        string Key { get; }
        string Description { get; }
        Role RequiredRole { get; }
        void Execute();
    }
}
