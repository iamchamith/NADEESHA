namespace App.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Pluto : DbContext
    {
        public Pluto()
            : base("name=Pluto")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<InventoryInfomation> InventoryInfomations { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Labour> Labours { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleJob> VehicleJobs { get; set; }
        public virtual DbSet<VehicleJobTaskItem> VehicleJobTaskItems { get; set; }
        public virtual DbSet<VehicleJobTaskLabour> VehicleJobTaskLabours { get; set; }
        public virtual DbSet<VehicleJobTask> VehicleJobTasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.CustomerMessage)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.AdmitUserName)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.VehicleNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Nic)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.UserEmale)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<InventoryInfomation>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Discription)
                .IsUnicode(false);

            modelBuilder.Entity<Labour>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Labour>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Labour>()
                .Property(e => e.Nic)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.TaskName)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Discription)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Nic)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.VehicleID)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.EngineNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.ChassiNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleJob>()
                .Property(e => e.VehicleNumber)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleJob>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleJobTaskItem>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleJobTaskLabour>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleJobTask>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);
        }
    }
}
