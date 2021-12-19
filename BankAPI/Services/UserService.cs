using System;
using System.Collections.Generic;
using BankAPI.Models;
using BankAPI.Repositories;
using System.Threading.Tasks;

namespace BankAPI.Services;

public interface IUserService
{
    /// <summary>
    /// Creates a user 
    /// </summary>
    /// <param name="email">User email</param>
    /// <returns>Created User object</returns>
    Task<bool> Create(string email);

    Task<List<User>> GetAll();
    Task<bool> Insert(User user);
    Task<bool> ChangeEmail(string id, string emailChange);
    Task<User> Get(string id);
    Task<bool> Remove(string id);
    Task<User> GetUser(string id);
    Task<Account> CreateAccount(AccountCreationRequest account);
}

public class UserService : IUserService
{
    public UserService(IUserRepository userRepository, IAccountRepository accountRepository)
    {
        _userRepository = userRepository;
        _accountRepository = accountRepository;
    }

    private readonly IUserRepository _userRepository;
    private readonly IAccountRepository _accountRepository;

    /// <summary>
    /// Creates a user 
    /// </summary>
    /// <param name="email">User email</param>
    /// <returns>Created User object</returns>
    public async Task<bool> Create(string email)
    {
        return await _userRepository.Insert(new User(email));
    }

    public async Task<List<User>> GetAll()
    {
        return await _userRepository.All();
    }

    public async Task<bool> Insert(User user)
    {
        var s = await GetAll();
        return s.Find(u => u.Equals(user)) == null && _userRepository.Insert(user).Result;
    }

    public async Task<bool> ChangeEmail(string id, string emailChange)
    {
        var user = await GetUser(id);
        return user?.SetNewEmail(emailChange) ?? false;
    }

    public async Task<User> Get(string id) => await GetUser(id);
    public async Task<bool> Remove(string id) => await _userRepository.Remove(await GetUser(id));

    public async Task<User> GetUser(string id) => await _userRepository.Get(id);

    public async Task<Account> CreateAccount(AccountCreationRequest account)
    {
        // var accId = account.UserId;
        try
        {
            var acc = new Account(0.0, 0.0)
            {
                UserId = account.UserId
            };
            await _accountRepository.Insert(acc);
            return acc;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}