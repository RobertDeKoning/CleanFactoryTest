using ConsoleApp1.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers.Interfaces
{
    interface IValidatorFactory
    {
        IValidator Create(string filename);
    }
}
