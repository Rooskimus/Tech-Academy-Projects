using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetAdoptionTrackerMVC.Models
{
    public class Pet
    {
        public int ID { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Name { get; set; }
        public DateTime? AdoptionDate { get; set; }
        public int? AdopterID { get; set; }
        
        public virtual Adopter Adopter { get; set; }
    }
}