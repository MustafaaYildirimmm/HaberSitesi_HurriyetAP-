﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.Entity
{
    public class NewsPaperContext:DbContext
    {
        public NewsPaperContext():base("Server=.;Database=News;User Id=mistik;Password=1234")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<HaberSitesiBitirmeProjesi.Entity.Role> Roles { get; set; }
    }
}
