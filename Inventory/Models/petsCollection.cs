using System.Collections.Generic;

namespace Inventory.Models
{
    public class Collection
    {
        public PetsCollection()
        {
            this.Pet = new HashSet<Pet>();
        }

        public int PetId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Pet> Pet { get; set; }
    }
}