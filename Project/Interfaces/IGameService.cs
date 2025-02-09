using System.Collections.Generic;
using guildAdventure.Project.Models;

namespace guildAdventure.Project.Interfaces
{
  public interface IGameService
  {
    List<string> Messages { get; }
    void Setup(string playerName);

    void Reset();

    // #region Console Commands

    // //NOTE Stops the application
    void Quit();

    // //NOTE Should display a list of commands to the console
    void Help();

    // //NOTE Validate CurrentRoom.Exits contains the desired direction
    // //NOTE if it does change the CurrentRoom
    void Go(string direction);
    void GrabItem(string itemName);
    void Use(string itemName);
    // void GiveTo(string input);
    // void TakeFrom(string input);
    // void UseItem(string itemName);
    // //NOTE Print the list of items in the players inventory to the console
    void Inventory();
    // void AddToParty(string input);
    void Attack(string input);
    // void GameOver();
    // void ViewCharacter(string characterName);
    // void CharacterInventory(string characterName);
    // //NOTE Display the CurrentRoom Description, Exits, and Items
    void Look();
    void GameOver();

    // #endregion
  }
}