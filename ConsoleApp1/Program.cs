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
            var validator = validatorFactory.Create(FileTemplate.CanonPs001);
            var filename = "CanonPs001.csv";
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
            var records = validator.GetAndValidateRecords<Sample001>(filename);
            var enrichedrecords = validator.EnrichValidRecords<Sample001, Result001>(records);

        }

        private static Container GetRegisteredContainer()
        {
            Container container = new Container();

            container.Register<IValidatorFactory, ValidatorFactory>();
            container.RegisterCollection<IValidator>
                      (new Assembly[] { Assembly.GetExecutingAssembly() });

            container.Verify();

            return container;
        }
    }
}
