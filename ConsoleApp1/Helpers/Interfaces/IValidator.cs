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
        IEnumerable<ISample> GetRecords<TSample>(string filename) where TSample : ISample;

        IEnumerable<ISample> GetValidRecords<TSample>(IEnumerable<TSample> records) where TSample : ISample;

        IEnumerable<IResult> EnrichValidRecords<TSample, TResult>(IEnumerable<ISample> validRecords) where TSample : ISample  where TResult : TSample, IResult;

        IEnumerable<IResult> ValidateEnrichedRecords<TResult>(IEnumerable<TResult> validRecords) where TResult : IResult;

        IEnumerable<IResult> TrySaveRecordsToDb<TResult>(IEnumerable<TResult> validRecords) where TResult : IResult;

        IEnumerable<IErrors> GetInvalidRecords();


    }
}
