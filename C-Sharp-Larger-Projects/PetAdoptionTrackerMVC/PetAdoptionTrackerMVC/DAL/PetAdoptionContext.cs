using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetAdoptionTrackerMVC.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PetAdoptionTrackerMVC.DAL
{
    public class PetAdoptionContext : DbContext
    {
        public PetAdoptionContext() : base("PetAdoptionContext") // This constructor passes in the name of our connection string.
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Adopter> Adopters { get; set; }
    }
}