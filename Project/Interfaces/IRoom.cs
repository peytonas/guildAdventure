using System.Collections.Generic;

namespace guildAdventure.Project.Interfaces
{
  public interface IRoom
  {
    string Name { get; set; }
    string Description { get; set; }
    List<IItem> Items { get; set; }
    Dictionary<string, IRoom> Exits { get; set; }
    // bool Blocked { get; set; }
    IRoom Go(string direction);
  }
}