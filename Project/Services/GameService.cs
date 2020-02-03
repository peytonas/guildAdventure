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
      Console.ForegroundColor = ConsoleColor.Green;
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
      //       TypeLine(@"
      // It is 3070 AE. You and your companions survive in a world of scorched earth, techno-mysticism, and blood. 
      // Whispers tell of a power source that has been abused for centuries...
      // If left unchecked, this abuse will continue to the destruction of your world... 
      // The future is in your hands...");
      Console.WriteLine(@"
It is 3070 AE. You and your companions survive in a world of scorched earth, techno-mysticism, and blood. 
Whispers tell of a power source that has been abused for centuries...
If left unchecked, this abuse will continue to the destruction of your world... 
The future is in your hands...");
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

        case "h":
        case "help":
          Help();
          break;
        case "go":
          Go(option);
          break;
        case "i":
        case "inventory":
          Inventory();
          break;
        case "l":
        case "look":
          Look();
          break;
        case "s":
        case "search":
          Search();
          break;
        case "take":
          GrabItem(option);
          break;
        case "use":
          Use(option);
          break;
        case "d":
        case "drop":
          DropItem(option);
          break;
        case "attack":
          Attack(option);
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
      _game.CurrentPlayer.Inventory.Clear();
      _game.Setup();
    }
    public void Help()
    {
      Messages.Add("Type:\ngo + north, south, east, west: travel in specified direction\n(i)nventory: checks your inventory\n(l)ook: repeats location and room description\n(s)earch: searches the immediate area for hints\ntake + item name: grabs item found in current room\n(d)rop + item name: drops specified item in inventory\nuse + item name: uses an item in your inventory\nreset/yes: starts game over at beginning\n(q)/no: quits application");
    }
    public void Look()
    {
      string current = _game.CurrentRoom.Name;
      string desc = _game.CurrentRoom.Description;
      Messages.Add($"You're still {current}. {desc}");
    }
    public void Search()
    {
      if (_game.CurrentRoom.Items.Count == 0)
      {
        Messages.Add("Nothing to be found here...");
        return;
      }
      else
      {
        Messages.Add(@"
After looking around you find:
      ");
        foreach (Item i in _game.CurrentRoom.Items)
        {
          Messages.Add($" {i.Name}: \n{i.Description}");
        }
      }
    }
    public void Attack(string input)
    {

    }
    public void Use(string input)
    {
      if (_game.CurrentRoom.Name == "in the Badlands")
      {
        foreach (Item i in _game.CurrentPlayer.Inventory)
        {
          if (i.Name.ToLower() == "mysterium")
          {
            Console.WriteLine(@"
After some negotiation at gunpoint, you offer the tribesmen your mysterium.
Their leader snatches it from you, inspects it, and removes his mask...
'If you are able to continue to offer such valuable resources, our victory would be all but certain.'
An uneasy alliance has been brokered. Best hope you can find more of that stuff, but for now...
 __   __  _______  __   __    _     _  ___   __    _ 
|  | |  ||       ||  | |  |  | | _ | ||   | |  |  | |
|  |_|  ||   _   ||  | |  |  | || || ||   | |   |_| |
|       ||  | |  ||  |_|  |  |       ||   | |       |
|_     _||  |_|  ||       |  |       ||   | |  _    |
  |   |  |       ||       |  |   _   ||   | | | |   |
  |___|  |_______||_______|  |__| |__||___| |_|  |__|
            ");
            Environment.Exit(0);
          }
        }
      }
    }
    public void Inventory()
    {
      Messages.Add("Inventory:");
      for (int i = 0; i < _game.CurrentPlayer.Inventory.Count; i++)
      {
        Messages.Add($"{_game.CurrentPlayer.Inventory[i].Name}");
      }
    }

    public void GrabItem(string itemName)
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
      }
      else if (i.Name != null && _game.CurrentRoom.Name == "at Headquarters")
      {
        _game.CurrentRoom.Items.Remove(i);
        _game.CurrentPlayer.Inventory.Add(i);
        _game.CurrentPlayer.Slots--;
        Messages.Add($"You grab your trusty {i.Name}.");
      }
      else
      {
        Messages.Add("There's no " + itemName + " here...");
      }
    }
    public void DropItem(string itemName)
    {
      Item i = new Item(null, null, null, 0, 0, 0);
      foreach (Item item in _game.CurrentPlayer.Inventory)
      {
        if (item.Name == itemName)
        {
          i = item;
        }
      }
      _game.CurrentPlayer.Inventory.Remove(i);
      _game.CurrentRoom.Items.Add(i);
      _game.CurrentPlayer.Slots++;
      Messages.Add($"Dropped your {i.Name}");
    }
    public void Go(string direction)
    {
      string from = _game.CurrentRoom.Name;
      _game.CurrentRoom = _game.CurrentRoom.Go(direction);
      string to = _game.CurrentRoom.Name;
      string desc = _game.CurrentRoom.Description;
      int inv = _game.CurrentPlayer.Inventory.Count;
      Item i = _game.CurrentPlayer.Inventory.Find(x => x.Name == "mysterium");
      if (from == to)
      {
        Messages.Add("Some hero you are...Let's get moving.");
        return;
      };
      if (to == "at The Foundry")
      {
        Console.WriteLine(@"
You should know better than to wander around downtown without backup.
The royal guard spotted you three blocks away and had you in their crosshairs as soon as you made it downtown.
Without so much as a hint...
        ");
        GameOver();
      }
      if (to == "in the Badlands" && i == null)
      {
        Console.WriteLine(@"
You shouldn't have come out here with nothing to bargain with.
The tribes find you immediately and quickly determine your worth.
  ");
        GameOver();
      }
      else if (to == "in the Badlands")
      {
        Messages.Add(@"
You can't shake the feeling you're being watched.
After wandering for a few miles, you've sprung an ambush and the tribes have you surrounded...
Good thing you've got that mysterium to offer!
");
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
    public void GameOver()
    {
      Console.WriteLine(@"
▓██   ██▓ ▒█████   █    ██    ▓█████▄  ██▓▓█████ ▓█████▄ 
 ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒██▀ ██▌▓██▒▓█   ▀ ▒██▀ ██▌
  ▒██ ██░▒██░  ██▒▓██  ▒██░   ░██   █▌▒██▒▒███   ░██   █▌
  ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░▓█▄   ▌░██░▒▓█  ▄ ░▓█▄   ▌
  ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░▒████▓ ░██░░▒████▒░▒████▓ 
   ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒▓  ▒ ░▓  ░░ ▒░ ░ ▒▒▓  ▒ 
 ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░ ▒  ▒  ▒ ░ ░ ░  ░ ░ ▒  ▒ 
 ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░     ░ ░  ░  ▒ ░   ░    ░ ░  ░ 
 ░ ░         ░ ░     ░           ░     ░     ░  ░   ░    
 ░ ░                           ░                  ░      
");
      Environment.Exit(0);
    }
  }
}