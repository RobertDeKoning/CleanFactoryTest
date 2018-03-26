using ConsoleApp1.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class Error001 : Sample001, IErrors
    {
        public string ErrorMessage { get; set; }
    }
}
