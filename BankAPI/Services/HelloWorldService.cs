using BankAPI.Repositories;

namespace BankAPI.Services
{
    public class HelloWorldService
    {
        private readonly HelloWorldRepo helloWorldRepo = new();

        public string HelloWorld()
        {
            return helloWorldRepo.HelloWorld;
        }
    }
}