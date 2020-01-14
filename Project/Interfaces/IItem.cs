using System.Collections.Generic;

namespace guildAdventure.Project.Interfaces
{
  public interface IItem
  {
    IRoom Location { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    int Effect { get; set; }
    int Accuracy { get; set; }
    int Cooldown { get; set; }
  }
}