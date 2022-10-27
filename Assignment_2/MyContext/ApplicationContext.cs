using Assignment_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment_2.MyContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext():base("Sindesmos")
        {

        }


        public DbSet<Trainer> Trainers { get; set; }
    }
}