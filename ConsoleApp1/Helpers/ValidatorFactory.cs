﻿using ConsoleApp1.Enum;
using ConsoleApp1.Helpers.Interfaces;
using System;
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

        public IValidator Create(string filename)
        {
            var fileTemplate = GetFileTemplate(filename);
            return _processors.Single(item => item.CanValidateTemplate(fileTemplate));
        }

        private FileTemplate GetFileTemplate(string filename)
        {
            var result = FileTemplate.None;
            if (filename.StartsWith("CANON001", StringComparison.OrdinalIgnoreCase))
            {
                result = FileTemplate.CanonPs001;
            }
            else if (filename.StartsWith("CANON002", StringComparison.OrdinalIgnoreCase))
            {
                result = FileTemplate.CanonPs002;
            }
            else if (filename.StartsWith("CANON003", StringComparison.OrdinalIgnoreCase))
            {
                result = FileTemplate.CanonPs003;
            }
            else if (filename.StartsWith("CANON004", StringComparison.OrdinalIgnoreCase))
            {
                result = FileTemplate.CanonPs004;
            }
            return result;
        }
    }
}
