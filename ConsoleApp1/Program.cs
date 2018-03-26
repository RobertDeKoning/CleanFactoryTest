using ConsoleApp1.Data.Repository;
using ConsoleApp1.Data.Repository.Interfaces;
using ConsoleApp1.Enum;
using ConsoleApp1.Helpers;
using ConsoleApp1.Helpers.Interfaces;
using ConsoleApp1.Models;
using SimpleInjector;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = GetRegisteredContainer();
            var validatorFactory = container.GetInstance<IValidatorFactory>();
                        
            var filename = "Canon001.csv";
            var validator = validatorFactory.Create(filename);

            (bool isFileValid, List<string> errors) = validator.ValidateFile(filename);
            if (!isFileValid)
            {
                // Write error file
                using (var writer = new StreamWriter("ErrorFile.txt", false, new UTF8Encoding(true)))
                {
                    writer.WriteLine(string.Join("\r\n",errors));
                }
                return;
            }
            var records = validator.GetRecords<Sample001>(filename);
            var validRecords = validator.GetValidRecords(records);
            var validEnrichedRecords = validator.EnrichValidRecords<Sample001, Result001>(validRecords);
            validEnrichedRecords = validator.ValidateEnrichedRecords(validEnrichedRecords);
            validEnrichedRecords = validator.TrySaveRecordsToDb(validEnrichedRecords);

            var invalidRecords = validator.GetInvalidRecords();


        }

        private static Container GetRegisteredContainer()
        {
            Container container = new Container();

            container.Register<IValidatorFactory, ValidatorFactory>();
            container.RegisterCollection<IValidator>
                      (new Assembly[] { Assembly.GetExecutingAssembly() });
            container.Register<IRepository, Repository>();


            container.Verify();

            return container;
        }
    }
}
