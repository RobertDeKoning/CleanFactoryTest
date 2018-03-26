using ConsoleApp1.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public abstract class ValidatorBase
    {
        internal List<IErrors> Errors { get; set; }
        internal List<string> FileErrors { get; set; }
        public ValidatorBase()
        {
            Errors = new List<IErrors>();
            FileErrors = new List<string>();
        }
    }
}
