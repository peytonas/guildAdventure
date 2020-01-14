using System.Collections.Generic;
using guildAdventure.Project.Interfaces;

namespace guildAdventure.Project.Models
{
  public class Item : IItem
  {
    public IRoom Location { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Effect { get; set; }
    public int Accuracy { get; set; }
    public int Cooldown { get; set; }
    public Item(string name, string description, IRoom location, int effect, int accuracy, int cooldown)
    {
      Name = name;
      Description = description;
      Location = location;
      Effect = effect;
      Accuracy = accuracy;
      Cooldown = cooldown;
    }
  }
}
