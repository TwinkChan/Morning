﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Morning.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GarmentFactoryEntities : DbContext
    {
        public static GarmentFactoryEntities _context;
        public GarmentFactoryEntities()
            : base("name=GarmentFactoryEntities")
        {
        }
    
        public static GarmentFactoryEntities GetContext()
        {
            if (_context == null)
                _context = new GarmentFactoryEntities();
            return _context;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Cloths> Cloths { get; set; }
        public DbSet<Fittings> Fittings { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<UserHistory> UserHistory { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
