using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Repositories;

using Models;
using Database;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AccountRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Account>> All()
    {
        return await _dbContext.Accounts.ToListAsync();
    }

    public async Task<List<Account>> AllByUser(Guid userId)
    {
        var all = await All();
        return all.FindAll(a => a.UserId == userId.ToString());
    }

    public async Task<Account?> Get(Guid accountId)
    {
        return await _dbContext.Accounts.FindAsync(accountId);
    }

    public async Task<bool> Insert(Account account)
    {
        try
        {
            await _dbContext.Accounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> Remove(Guid accountId)
    {
        var account = await _dbContext.Accounts.FindAsync(accountId);
        if (account == null)
        {
            throw new NullReferenceException("AccountRepository.Remove: couldn't find account");
        }

        try
        {
            _dbContext.Accounts.Remove(account);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<bool> Update(Account account)
    {
        try
        {
            _dbContext.Accounts.Update(account);
            return new Task<bool>(() => true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}