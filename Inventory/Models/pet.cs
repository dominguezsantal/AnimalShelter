namespace Inventory.Models
{
  public class Pet
  {
    public int PetId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

    public int PetId { get; set; }
    public virtual PetsCollection PetsCollection { get; set; }
  }
}