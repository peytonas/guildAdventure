using System.Collections.Generic;
using guildAdventure.Project.Models;

namespace guildAdventure.Project.Interfaces
{
  public interface IPlayer
  {
    string Name { get; set; }
    int Health { get; set; }
    int Slots { get; set; }
    List<Item> Inventory { get; set; }
  }
}