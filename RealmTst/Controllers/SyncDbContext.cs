﻿using System.Data.Entity;
using RealmSync.Model;
using RealmTst.Migrations;

namespace RealmTst.Controllers
{
    public class SyncDbContext : DbContext
    {
        static SyncDbContext()
        {
            //System.Data.Entity.Database.SetInitializer<SyncDbContext>(new MigrateDatabaseToLatestVersion<SyncDbContext, Configuration>());
            System.Data.Entity.Database.SetInitializer<SyncDbContext>(new DropCreateDatabaseIfModelChanges<SyncDbContext>());
        }

        public DbSet<ChatMessage> ChatMessages { get; set; }
        //public DbSet<ToDoItem> ToDoItems { get; set; }
        //public DbSet<Project> Projects { get; set; }
    }
}