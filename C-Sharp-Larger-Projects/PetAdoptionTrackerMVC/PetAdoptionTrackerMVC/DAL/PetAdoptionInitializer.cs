using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PetAdoptionTrackerMVC.Models;

namespace PetAdoptionTrackerMVC.DAL
{
    public class PetAdoptionInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PetAdoptionContext>
    {
        protected override void Seed(PetAdoptionContext context)
        {
            var adopters = new List<Adopter>
            {
                new Adopter {ID=1, FirstName="Troy", LastName="McClure", EmailAddress="youmayknowmefromsuchemailsas@thisone.com"},
                new Adopter {ID=2, FirstName="Zapp", LastName="Brannigan", EmailAddress="thespiritiswilling@snoosnoo.com"},
                new Adopter {ID=3, FirstName="NFN", LastName="Data", EmailAddress="curious@commanderdata.com"},
                new Adopter {ID=4, FirstName="Dog", LastName="TheBountyHunter", EmailAddress="heartofgold@bountyhunters.com"},
            };

            adopters.ForEach(a => context.Adopters.Add(a));
            context.SaveChanges();

            var pets = new List<Pet>
            {
                new Pet {Species="Dog", Breed="Daschund", Name="Noodles", AdopterID=1, AdoptionDate=DateTime.Parse("2018-01-15")},
                new Pet {Species="Dog", Breed="Doberman", Name="Spanky", AdopterID=4, AdoptionDate=DateTime.Parse("2018-06-08")},
                new Pet {Species="Dog", Breed="Chihuahua", Name="Captian Quivers", AdopterID=1, AdoptionDate=DateTime.Parse("2018-03-11")},
                new Pet {Species="Dog", Breed="Black Lab", Name="Buck"},
                new Pet {Species="Dog", Breed="Bull Dog", Name="Stumpy"},
                new Pet {Species="Cat", Breed="Scottish Fold", Name="Spot", AdopterID=3, AdoptionDate=DateTime.Parse("2018-09-24")},
                new Pet {Species="Cat", Breed="Maine Coon ", Name="Boss"},
                new Pet {Species="Cat", Breed="Sphinx", Name="Anubis"},
                new Pet {Species="Cat", Breed="American Shorthair", Name="Stubbs", AdopterID=2, AdoptionDate=DateTime.Parse("2018-01-15")},
                new Pet {Species="Green Iguana", Breed="N/A", Name="Tokage"}
            };

            pets.ForEach(p => context.Pets.Add(p));
            context.SaveChanges();
        }
    }
}