using ConsoleApp1.Enum;
using ConsoleApp1.Models;
using ConsoleApp1.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers.Interfaces
{
    interface IValidator
    {
        bool CanValidateTemplate(FileTemplate fileTemplate);
        (bool isFileValid, List<string> fileErrors) ValidateFile(string filename);
        IEnumerable<T> GetAndValidateRecords<T>(string filename) where T : ISample;

        IEnumerable<TResult> EnrichValidRecords<TSample, TResult>(IEnumerable<TSample> validRecords) where TSample : ISample  where TResult : TSample, IResult;

        IEnumerable<T> GetInvalidRecords<T>() where T : IErrors;



    }
}
