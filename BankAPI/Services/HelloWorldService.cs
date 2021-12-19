using System.Collections.Generic;
using BankAPI.Models;
using BankAPI.Repositories;
using System;

namespace BankAPI.Services;

public interface IHelloWorldService
{
    MyClass HelloWorld();
}

public class HelloWorldService : IHelloWorldService
{
    private IHelloWorldRepo helloWorldRepo;

    public HelloWorldService(IHelloWorldRepo helloWorldRepo)
    {
        this.helloWorldRepo = helloWorldRepo;
    }

    public MyClass HelloWorld()
    {
        return new MyClass()
        {
            Accounts = helloWorldRepo.Accounts(),
            Users = helloWorldRepo.Users()
        };
    }
}

public class MyClass
{
    public List<Account> Accounts { get; set; }
    public List<User> Users { get; set; }
}