using System.Collections.Generic;
using guildAdventure.Project.Models;

namespace guildAdventure.Project.Interfaces
{
  public interface ICharacter
  {
    // IGuild Guild { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    int Health { get; set; }
    int Slots { get; set; }
    List<Item> Inventory { get; set; }
  }
}