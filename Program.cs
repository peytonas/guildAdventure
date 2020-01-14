using System;
using guildAdventure.Project;
using guildAdventure.Project.Controllers;

namespace guildAdventure
{
  class Program
  {
    static void Main(string[] args)
    {
      new GameController().Run();
    }
  }
}
