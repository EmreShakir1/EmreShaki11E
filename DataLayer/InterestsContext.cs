using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class InterestsContext : IDb<Interest, int>
    {
        private readonly EmreShakir11eDbContext dbContext;
        public InterestsContext(EmreShakir11eDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Interest item)
        {
            try
            {
                dbContext.Interests.Add(item);
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
                dbContext.Interests.Remove(Read(key));
                dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Interest Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                var a = dbContext.Interests;
                if (useNavigationalProperties)
                {
                    a.Include(a => a.Users).Include(a=>a.Region);
                }
                return a.FirstOrDefault(a => a.Id == key);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Interest> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                var a = dbContext.Interests;
                if (useNavigationalProperties)
                {
                    a.Include(a => a.Users).Include(a => a.Region);
                }
                return a.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Interest item)
        {
            try
            {
                dbContext.Interests.Update(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
