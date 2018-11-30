using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetAdoptionTrackerMVC.Models
{
    public class Adopter
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public virtual List<Pet> AdoptedPets { get; set; }
    }
}