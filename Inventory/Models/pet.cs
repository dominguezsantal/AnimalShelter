using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Inventory.Models
{
    public class Pet
    {
      public int PetId { get; set; }
      public string Name { get; set; }
      public int Quantity { get; set; }

      public int PetsCollectionId { get; set; }
      public virtual PetsCollection PetsCollection { get; set; }
    }
  public static List<Pet> GetAll()
    {
      List<Pet> allPet = new List<Pet> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM Pet;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
          int PetId = rdr.GetInt32(0);
          string PetDescription = rdr.GetString(1);
          Item newPet = new Pet(PetDescription, PetId);
          allPet.Add(newPet);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allPet;
    }

    public static void ClearAll()
    {
    }
    public static Pet Find(int searchId)
    {
      // Temporarily returning placeholder item to get beyond compiler errors until we refactor to work with database.
      Item placeholderPet = new Pet("placeholder pet");
      return placeholderPet;
    }
}