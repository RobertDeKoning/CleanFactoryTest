using ConsoleApp1.Enum;
using ConsoleApp1.Helpers.Interfaces;
using ConsoleApp1.Models;
using ConsoleApp1.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Helpers
{
    internal class NullValidator : ValidatorBase, IValidator
    {
        public bool CanValidateTemplate(FileTemplate fileTemplate)
        {
            return fileTemplate == FileTemplate.None;
        }

        public IEnumerable<IResult> EnrichValidRecords<TSample, TResult>(IEnumerable<ISample> validRecords)
            where TSample : ISample
            where TResult : IResult, TSample
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IErrors> GetInvalidRecords()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISample> GetRecords<TSample>(string filename) where TSample : ISample
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISample> GetValidRecords<TSample>(IEnumerable<TSample> records) where TSample : ISample
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IResult> TrySaveRecordsToDb<TResult>(IEnumerable<TResult> validRecords) where TResult : IResult
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IResult> ValidateEnrichedRecords<TResult>(IEnumerable<TResult> validRecords) where TResult : IResult
        {
            throw new NotImplementedException();
        }

        public (bool isFileValid, List<string> fileErrors) ValidateFile(string filename)
        {
            return (false, new List<string> { "Unknown filename convention." });
        }
    }
}
