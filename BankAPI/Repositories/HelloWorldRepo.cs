using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Repositories
{
    public class HelloWorldRepo
    {
        public HelloWorldRepo()
        {
            this.HelloWorld = "Hello World";
        }

        public string HelloWorld { get; set; }
    }
}