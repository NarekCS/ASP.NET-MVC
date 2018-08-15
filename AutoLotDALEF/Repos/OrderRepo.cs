using AutoLotDALEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDALEF.Repos
{
    class OrderRepo : BaseRepo<Order>, IRepo<Order>
    {
        public OrderRepo()
        {
            Table = Context.Orders;
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
