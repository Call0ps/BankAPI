using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankAPI.Models;

namespace BankAPI.Repositories;

public interface IAccountRepository
{
    public Task<List<Account>> All();
    public Task<List<Account>> AllByUser(Guid userId);
    public Task<Account?> Get(Guid accountId);
    public Task<bool> Insert(Account account);
    public Task<bool> Remove(Guid accountId);
    public Task<bool> Update(Account account);
}