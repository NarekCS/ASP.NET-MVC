using AutoLotDALEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDALEF.Repos
{
   public class CustomerRepo : BaseRepo<Customer>, IRepo<Customer>
    {
        public CustomerRepo()
        {
            Table = Context.Customers;
        }
        public int Delete(int id)
        {
            Context.Entry(new Inventory() { CarId = id }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new Inventory() { CarId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
