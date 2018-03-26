using ConsoleApp1.Enum;
using ConsoleApp1.Helpers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Helpers
{
    internal class ValidatorFactory : IValidatorFactory
    {
        private readonly IEnumerable<IValidator> _processors;

        public ValidatorFactory(IEnumerable<IValidator> processors)
        {
            _processors = processors;
        }

        public IValidator Create(FileTemplate fileTemplate)
        {
            return _processors.Single(item => item.CanValidateTemplate(fileTemplate));
        }
    }
}
