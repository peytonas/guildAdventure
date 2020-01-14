using System.Collections.Generic;
using guildAdventure.Project.Interfaces;

namespace guildAdventure.Project.Models
{
  public class Character : ICharacter
  {
    public IRoom Location { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Health { get; set; }
    public int Slots { get; set; }
    public List<Item> Inventory { get; set; }
    public Character(string name, int health, string description, IRoom location, int slots)
    {
      Name = name;
      Health = health;
      Description = description;
      Inventory = new List<Item>();
      Location = location;
      Slots = slots;
    }
  }
}