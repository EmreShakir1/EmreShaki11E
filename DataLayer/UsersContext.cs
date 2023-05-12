using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class UsersContext: IDb<User, int>
    {
        private readonly EmreShakir11eDbContext dbContext;

        public UsersContext(EmreShakir11eDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(User item)
        {
            try
            {
                dbContext.Users.Add(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int key)
        {
            try
            {
                dbContext.Users.Remove(Read(key));
                dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                var a = dbContext.Users;
                if (useNavigationalProperties)
                {
                    a.Include(a => a.Friends).Include(a=> a.Interests);
                }
                return a.FirstOrDefault(a => a.Id == key);
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        public IEnumerable<User> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                var a = dbContext.Users;
                if (useNavigationalProperties)
                {
                    a.Include(a => a.Friends).Include(a => a.Interests);
                }
                return a.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(User item)
        {
            try
            {
                dbContext.Users.Update(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
