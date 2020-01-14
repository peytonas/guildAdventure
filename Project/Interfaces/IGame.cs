using guildAdventure.Project.Models;

namespace guildAdventure.Project.Interfaces
{
  public interface IGame
  {
    IRoom CurrentRoom { get; set; }
    IPlayer CurrentPlayer { get; set; }
    ICharacter Character { get; set; }

    void Setup();
  }
}