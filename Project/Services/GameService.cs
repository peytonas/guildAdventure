using System;
using System.Collections.Generic;
using guildAdventure.Project.Interfaces;
using guildAdventure.Project.Models;

namespace guildAdventure.Project
{
  public class GameService : IGameService
  {
    private bool playing = true;

    private IGame _game { get; set; }
    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }
    public void Setup(string playerName)
    {
      Console.WriteLine("SETUP");
    }
    public void Run()
    {
      Reset();
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine(@"
       (                              )             )   (     (    (         
 )\ )         (       *   )  ( /(     (    ( /(   )\ )  )\ ) )\ )      
(()/(   (     )\    ` )  /(  )\())  ( )\   )\()) (()/( (()/((()/( (    
 /(_))  )\ ((((_)(   ( )(_))((_)\   )((_) ((_)\   /(_)) /(_))/(_)))\   
(_))_  ((_) )\ _ )\ (_(_())  _((_) ((_)_ __ ((_) (_))_|(_)) (_)) ((_)  
 |   \ | __|(_)_\(_)|_   _| | || |  | _ )\ \ / / | |_  |_ _|| _ \| __| 
 | |) || _|  / _ \    | |   | __ |  | _ \ \ V /  | __|  | | |   /| _|  
 |___/ |___|/_/ \_\   |_|   |_||_|  |___/  |_|   |_|   |___||_|_\|___| 
                                                                       
      ");
      TypeLine(@"
It is 3070 AE. You and your companions survive in a world of scorched earth, techno-mysticism, and blood. 
Whispers tell of a power source that has been abused for centuries...
If left unchecked, this abuse will continue to the destruction of your world... 
The future is in your hands...");
      //       Console.WriteLine(@"
      // It is 3070 AE. You and your companions survive in a world of scorched earth, techno-mysticism, and blood. 
      // Whispers tell of a power source that has been abused for centuries...
      // If left unchecked, this abuse will continue to the destruction of your world... 
      // The future is in your hands...");
      Print();
      while (playing)
      {
        GetUserInput();
        Update();
      }
    }
    private void Update()
    {
      Console.Clear();
      foreach (string message in Messages)
      {
        Console.WriteLine(message);
      }
      Messages.Clear();
    }
    public void GetUserInput()
    {
      Console.WriteLine(@"
What's your plan?
(type 'h' or 'help' for help)
");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      Console.Clear();
      switch (command)
      {
        // case "use":
        //   UseItem(option);
        //   break;
        case "t":
        case "take":
          TakeItem(option);
          break;
        case "s":
        case "search":
          Search();
          break;
        case "i":
        case "inventory":
          Inventory();
          break;
        case "v":
        case "view":
          ViewCharacter(option);
          break;
        case "h":
        case "help":
          Help();
          break;
        case "l":
        case "look":
          Look();
          break;
        case "g":
        case "give":
          GiveItem(option);
          break;
        case "go":
          Go(option);
          break;
        case "reset":
        case "yes":
          Run();
          break;
        case "no":
        case "q":
        case "quit":
        case "exit":
        case "close":
          Environment.Exit(0);
          break;
      }
    }
    public void Print()
    {
      foreach (string message in Messages)
      {
        Messages.Add(message);
      }
    }
    public void Reset()
    {
      // _game.CurrentPlayer.Inventory.Clear();
      // if (_game.CurrentRoom.Name != "north")
      // {
      //   _game.Setup();
      // }
    }
    public void Help()
    {
      Messages.Add("Type:\ngo + north, south, east, west: travel in specified direction\n(l)ook: repeats location and room description\n(s)earch: searches the immediate area for hints\ntake + item name: takes item found in current room\n(g)ive + character name + item name = gives character specified item\n(i)nventory: checks your inventory\n(v)iew + character name: views character stats/inventory\nuse + item name: uses an item in your inventory\nreset/yes: starts game over at beginning\n(q)/no: quits application");
    }
    public void Look()
    {
      string current = _game.CurrentRoom.Name;
      string desc = _game.CurrentRoom.Description;
      Messages.Add($"You're still {current}. {desc}");
    }
    public void Search()
    {
      if (_game.CurrentRoom.Items.Count == 0 && _game.CurrentRoom.Characters.Count == 0)
      {
        Messages.Add("Nothing to be found here...");
        return;
      }
      else
      {

        Messages.Add(@"
After looking around you find:
      ");
        foreach (Character c in _game.CurrentRoom.Characters)
        {
          Messages.Add($" {c.Name} is here. \n{c.Description}");
          Messages.Add($" Health: {c.Health} \n");
        }
        foreach (Item i in _game.CurrentRoom.Items)
        {
          Messages.Add($" {i.Name}: \n{i.Description}");
          Messages.Add($" {i.Effect} \n");
        }
      }
    }
    public void Inventory()
    {
      Messages.Add("Inventory:");
      for (int i = 0; i < _game.CurrentPlayer.Inventory.Count; i++)
      {
        Messages.Add($"{_game.CurrentPlayer.Inventory[i].Name}: {_game.CurrentPlayer.Inventory[i].Effect}");
      }
    }
    public void ViewCharacter(string characterName)
    {
      foreach (Character character in _game.CurrentRoom.Characters)
      {
        if (character.Name == characterName)
        {
          Messages.Add($" Name: {character.Name}");
          Messages.Add($" {character.Description}");
          Messages.Add($" HP: {character.Health}");
          Messages.Add($" Inventory: ");
          foreach (Item item in character.Inventory)
          {
            Messages.Add($" {item.Name}, {item.Effect} ");
          }
        }
      }
    }
    public void TakeItem(string itemName)
    {
      Item i = new Item(null, null, null, 0, 0, 0);
      foreach (Item item in _game.CurrentRoom.Items)
      {
        if (item.Name == itemName)
        {
          i = item;
        }
      }
      if (_game.CurrentPlayer.Slots == 0)
      {
        Messages.Add("You don't have room to carry that. Drop something or move on...");
      }
      else if (i.Name != null && _game.CurrentRoom.Name != "at Headquarters")
      {
        _game.CurrentRoom.Items.Remove(i);
        _game.CurrentPlayer.Inventory.Add(i);
        _game.CurrentPlayer.Slots--;
        Messages.Add($"You're not sure how this could help, but better safe than sorry! You grab the {i.Name} and take it with you...");
        Messages.Add($"{i.Effect} damage");
      }
      else if (i.Name != null && _game.CurrentRoom.Name == "at Headquarters")
      {
        _game.CurrentRoom.Items.Remove(i);
        _game.CurrentPlayer.Inventory.Add(i);
        _game.CurrentPlayer.Slots--;
        Messages.Add($"You grab your trusty {i.Name}.");
        Messages.Add($"{i.Effect}");
      }
      else
      {
        Messages.Add("There's no " + itemName + " here...");
      }
    }
    public void GiveItem(string input)
    {
      Console.WriteLine(input);
      var inputs = input.Split(' ');
      Character c = new Character(null, 0, null, _game.CurrentRoom, 3);
      foreach (Character character in _game.CurrentRoom.Characters)
      {
        if (character.Name == inputs[0])
        {
          c = character;
        }
      }
      Item i = new Item(null, null, null, 0, 0, 0);
      foreach (Item item in _game.CurrentPlayer.Inventory)
      {
        if (item.Name == inputs[1])
        {
          i = item;
        }
      }
      if (c.Slots == 0)
      {
        Messages.Add("They don't have room to carry that. They'll need to drop something or move on...");
      }
      else if (i.Name != null && _game.CurrentRoom.Name != "at Headquarters")
      {
        _game.CurrentPlayer.Inventory.Remove(i);
        c.Inventory.Add(i);
        _game.CurrentPlayer.Slots++;
        c.Slots--;
        Messages.Add($"You hand off the {i.Name} to {c.Name} and hope they know what to do with it...");
      }
      else if (i.Name != null && _game.CurrentRoom.Name == "at Headquarters")
      {
        _game.CurrentPlayer.Inventory.Remove(i);
        c.Inventory.Add(i);
        _game.CurrentPlayer.Slots++;
        c.Slots--;
        Messages.Add($"You grab your trusty {i.Name} and toss it to {c.Name}");
        Messages.Add($"{i.Effect}");
      }
      else
      {
        Messages.Add("You don't have a " + inputs[1] + " to give " + c.Name + ".");
      }
    }
    public void Go(string direction)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      string from = _game.CurrentRoom.Name;
      _game.CurrentRoom = _game.CurrentRoom.Go(direction);
      string to = _game.CurrentRoom.Name;
      string desc = _game.CurrentRoom.Description;
      int inv = _game.CurrentPlayer.Inventory.Count;
      if (from == to)
      {
        Messages.Add("Some hero you are...Let's get moving.");
        return;
      }
      else
      {
        Messages.Add("You're " + _game.CurrentRoom.Name + ".");
        Messages.Add(_game.CurrentRoom.Description);
      }
    }
    public void Quit()
    {
      Environment.Exit(0);
    }
    static void TypeLine(string line)
    {
      for (int i = 0; i < line.Length; i++)
      {
        Console.Write(line[i]);
        System.Threading.Thread.Sleep(50); // Sleep for 150 milliseconds
      }
    }
  }
}