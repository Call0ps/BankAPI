using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankAPI.Database;
using BankAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Repositories
{
    public class UserRepositoryLocal : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepositoryLocal(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> All()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<bool> Remove(User user)
        {
            try
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> Insert(User user)
        {
            try
            {
                var result = await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<User> Get(string id)
        {
            return await _dbContext.Users.SingleAsync(u => u.Id == id);
        }

        public async Task<bool> Update(User user)
        {
            try
            {
                _dbContext.Users.Update(user);
                return await new Task<bool>(() => true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}