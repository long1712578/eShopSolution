﻿using eShopSolution.Data.Configuration;
using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace eShopSolution.Data.EF
{
    public class EShopDBContext : DbContext
    {
        public EShopDBContext(DbContextOptions options) : base(options)
        {

        }
        //Neu chung ta API fluent theo cach Configuratin thi phai override OnmodelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppconfigConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguaration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguaration());
            modelBuilder.ApplyConfiguration(new ContactConfiguaration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguaration());
            modelBuilder.ApplyConfiguration(new OrderConfiguaratuion());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguaration());
            modelBuilder.ApplyConfiguration(new ProductConfiguaration());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfiguaration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguaration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguaration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
           // base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTranslations> CategoryTranslations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductTranslations> ProductTranslations { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        //public DbSet<Slide> Slides { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
