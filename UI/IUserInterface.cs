using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbsoluteCinema.UI;

namespace AbsoluteCinema
{
    interface IUserInterface
    {
        void Output(string text, TitleColor title);
        string Input();
    }
}
