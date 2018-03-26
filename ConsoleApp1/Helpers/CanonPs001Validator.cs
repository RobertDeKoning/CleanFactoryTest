using System.Collections.Generic;
using System.IO;
using System.Text;
using AutoMapper;
using ConsoleApp1.Data.Repository.Interfaces;
using ConsoleApp1.Enum;
using ConsoleApp1.Helpers.Interfaces;
using ConsoleApp1.Models;
using ConsoleApp1.Models.Interfaces;
using CsvHelper;

namespace ConsoleApp1.Helpers
{
    internal class CanonPs001Validator : ValidatorBase, IValidator
    {
        private IRepository _repository;
        
        public CanonPs001Validator(IRepository repository) : base()
        {
            _repository = repository;
        }


        public bool CanValidateTemplate(FileTemplate fileTemplate)
        {
            return fileTemplate == FileTemplate.CanonPs001;
        }

        public IEnumerable<IResult> EnrichValidRecords<TSample, TResult>(IEnumerable<ISample> validRecords) where TSample : ISample where TResult : IResult, TSample
        {
            var result = new List<Result001>();
            foreach (var validRecord in validRecords)
            {
                var enrichedRecord = Mapper.Map<Result001>(validRecord);
                enrichedRecord.ExtraField001 = "Canon001";

                result.Add(enrichedRecord);
                

            }
            return result;
        }

        public IEnumerable<ISample> GetRecords<TSample>(string filename) where TSample : ISample
        {
            using (var csvReader = new CsvReader(new StreamReader(filename)))
            {
                csvReader.Configuration.RegisterClassMap(typeof(TSample));
                csvReader.Configuration.Encoding = new UTF8Encoding(true);
                csvReader.Configuration.Delimiter = "|";
                csvReader.Configuration.HasHeaderRecord = true;
                while (csvReader.Read())
                {
                    yield return csvReader.GetRecord<Sample001>();
                }
            }
        }

        public IEnumerable<IErrors> GetInvalidRecords()
        {
            return Errors;
        }

        public IEnumerable<IResult> TrySaveRecordsToDb<TResult>(IEnumerable<TResult> validRecords) where TResult : IResult
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IResult> ValidateEnrichedRecords<TResult>(IEnumerable<TResult> validRecords) where TResult : IResult
        {
            return new List<Result001>();
        }

        public (bool isFileValid, List<string> fileErrors) ValidateFile(string filename)
        {
            return (true, null);
        }

        public IEnumerable<ISample> GetValidRecords<TSample>(IEnumerable<TSample> records) where TSample : ISample
        {
            var result = new List<ISample>();
            foreach (var record in records as IEnumerable<Sample001>)
            {
                if (string.IsNullOrEmpty(record.Email))
                {

                }

            }
            return result;
        }
    }
}
