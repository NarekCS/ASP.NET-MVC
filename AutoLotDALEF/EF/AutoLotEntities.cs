namespace AutoLotDALEF.EF
{
    using AutoLotDALEF.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.Infrastructure.Interception;
    using System.Data.Entity.Infrastructure;
    using AutoLotDALEF.Interception;
    using System.Data.Entity.Core.Objects;

    public class AutoLotEntities : DbContext
    {
        // Your context has been configured to use a 'AutoLotEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AutoLotDALEF.EF.AutoLotEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AutoLotEntities' 
        // connection string in the application configuration file.
        public AutoLotEntities()
            : base("name=AutoLotConnection")//("Data Source=DESKTOP-6BGVH06;Initial Catalog=TEST;Integrated Security=True;Pooling=False")
        {
            //  DbInterception.Add(new ConsoleWriterInterceptor());
            //DatabaseLogger.StartLogging();
            //DbInterception.Add(DatabaseLogger);
            ObjectContext context = (this as IObjectContextAdapter).ObjectContext;
            context.SavingChanges += OnSavingChanges;

        }

        private void OnSavingChanges(object sender, EventArgs e)
        {
            ObjectContext context = sender as ObjectContext;
            if (context == null) return;
            foreach(ObjectStateEntry item in context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
            {
                 Inventory entity = item.Entity as Inventory;
                    if(entity?.Color == "Red")
                    {
                        item.RejectPropertyChanges(nameof(entity.Color));
                    }
                
            }
        }

        //static readonly DatabaseLogger DatabaseLogger = new DatabaseLogger("sqllog.txt", true);
        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}