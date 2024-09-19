using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public string Name { get; set; }
        public object Key { get; set; }
        public NotFoundException( string name, object key) : base ($"Entity \"{name}\" ({key}) was not foud.")
        {
            Name = name;
            Key = key;  
        }

        public NotFoundException(string message) : base(message) { }
    }
}
