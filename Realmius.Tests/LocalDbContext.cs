﻿////////////////////////////////////////////////////////////////////////////
//
// Copyright 2017 Rubius
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
////////////////////////////////////////////////////////////////////////////

using System.Data.Entity;
using Realmius.Server.Configurations;
using Realmius.Server.Models;
using Realmius.Tests.Server;
using Realmius.Tests.Server.Models;

namespace Realmius.Tests
{
    public class LocalDbContext : ChangeTrackingDbContext
    {
        static LocalDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<LocalDbContext>());
        }

        public DbSet<DbSyncObject> DbSyncObjects { get; set; }
        public DbSet<UnknownSyncObjectServer> UnknownSyncObjectServers { get; set; }
        public DbSet<DbSyncObjectWithIgnoredFields> DbSyncObjectWithIgnoredFields { get; set; }
        public DbSet<IdIntObject> IdIntObjects { get; set; }
        public DbSet<IdIntAutogeneratedObject> IdIntAutogeneratedObjects { get; set; }
        public DbSet<IdGuidObject> IdGuidObjects { get; set; }
        public DbSet<UploadTests.IntFieldSentAsStringObject> IntFieldSentAsStringObjects { get; set; }
        public DbSet<RefSyncObject> RefSyncObjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RefSyncObject>().HasMany(x => x.References).WithMany();
        }
    }
}