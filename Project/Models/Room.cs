using System;
using System.Collections.Generic;
using guildAdventure.Project.Interfaces;

namespace guildAdventure.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IItem> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }
    public bool Blocked { get; set; }

    public void AddExit(IRoom room)
    {
      Exits.Add(room.Name, room);
    }
    public IRoom Go(string direction)
    {
      if (Exits.ContainsKey(direction))
      {
        return Exits[direction];
      }
      return this;
    }
    public Room(string name, string description, bool blocked)
    {
      Name = name;
      Description = description;
      Items = new List<IItem>();
      Exits = new Dictionary<string, IRoom>();
      Blocked = blocked;
    }
  }
}