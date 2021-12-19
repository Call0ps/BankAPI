using System.Collections.Generic;
using BankAPI.Database;
using BankAPI.Models;

namespace BankAPI.Repositories;

public interface IHelloWorldRepo
{
    List<Account> Accounts();
    List<User> Users();
}

public class HelloWorldRepo : IHelloWorldRepo
{
    public HelloWorldRepo(IAccountRepository aRep, IUserRepository uRep)
    {
        _uR = uRep;
        _aR = aRep;
    }

    private IAccountRepository _aR;
    private IUserRepository _uR;

    public List<Account> Accounts()
    {
        return _aR.All().Result;
    }

    public List<User> Users()
    {
        return _uR.All().Result;
    }

    public string HelloWorld { get; set; }
}