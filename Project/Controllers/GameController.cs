using System;
using System.Collections.Generic;
using guildAdventure.Project.Interfaces;
using guildAdventure.Project.Models;

namespace guildAdventure.Project.Controllers
{
  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();
    public void Run()
    {
      _gameService.Run();
    }
    public void GetUserInput()
    {
      _gameService.GetUserInput();
    }
  }
}