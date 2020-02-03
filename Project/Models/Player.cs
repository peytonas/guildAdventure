using System.Collections.Generic;
using guildAdventure.Project.Interfaces;

namespace guildAdventure.Project.Models
{
  public class Player : IPlayer
  {
    public string Name { get; set; }
    public int Health { get; set; }
    public List<Item> Inventory { get; set; }
    public int Slots { get; set; }
    public Player(string name, int health, int slots)
    {
      Name = name;
      Health = health;
      Inventory = new List<Item>();
      Slots = slots;
    }
  }
}