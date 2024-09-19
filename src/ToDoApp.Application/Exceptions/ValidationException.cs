using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IReadOnlyDictionary<string, string[]> errorDictionary) : base("one or more validation error occured")
        {
            Errors = errorDictionary;
        }
        public IReadOnlyDictionary<string, string[]> Errors { get; set; }
    }
}
