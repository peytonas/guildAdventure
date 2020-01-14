using System;
using guildAdventure.Project.Interfaces;

namespace guildAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }

    public IPlayer CurrentPlayer { get; set; }
    public ICharacter Character { get; set; }
    //NOTE Make rooms here...
    public void Setup()
    {
      // NOTE initializes rooms
      Room BL = new Room("in the Badlands", @"
Fire has razed all the regions north of the city, you'd best be prepared...
      ", false);
      Room HQ = new Room("at Headquarters", @"
This is your home base. Come here to rest, plan, or store inventory for later.", false);
      Room B = new Room("in The Borders", @"
The city has been quiet for a few years now, but you'll need to move quickly. You never know who's watching...
      ", false);
      Room DT = new Room("Downtown", @"
Silence reigns. Ash, soot, and crumbled remains surround The Foundry, bellowing smoke as it has since time immemorial...
The first living things you've seen in the city stand ahead: two heavily armored guards, intent on your demise...
      ", false);
      Room TF = new Room("at The Foundry", @"
The guards block your way, it's either them or you...
      ", false);

      //NOTE initializes relationships between rooms
      BL.Exits.Add("south", HQ);
      HQ.Exits.Add("north", BL);
      HQ.Exits.Add("south", B);
      B.Exits.Add("north", HQ);
      B.Exits.Add("south", DT);
      DT.Exits.Add("north", B);
      DT.Exits.Add("south", TF);
      TF.Exits.Add("north", DT);

      //NOTE initializes player
      Player ps = new Player("peyton", 100, 3);
      //NOTE initializes character
      Character a1 = new Character("alpha", 100, @"An assassin bot you hijacked a few years back. Loyal...ish.", HQ, 3);
      Character rg = new Character("royal guard", 250, @"Don't be fooled by the robes, they're hiding armor made from that metal you found earlier.", TF, 0);
      //NOTE initializes items 
      //REVIEW (1st number = effect, 2nd number = accuracy/chance of success, 3rd number = cooldown/reload)
      Item cm = new Item("claymore", @"
    An enormous sword, outfitted with plasma tech.", HQ, 45, 85, 3);
      Item wm = new Item("war machine", @"
    1,500 RPM with electrically charged rounds.", HQ, 80, 33, 0);
      Item rpg = new Item("rpg", @"
    A rocket propelled grenade launcher. Ear protection recommended.", HQ, 70, 66, 7);
      Item sr = new Item("sniper rifle", @"
    Accurate to 400 yards, rounds explode on contact.", HQ, 120, 85, 10);
      Item hp = new Item("potion", @"Increases your health.", HQ, 15, 100, 0);
      //NOTE assign items to rooms
      HQ.Items.Add(cm);
      HQ.Items.Add(wm);
      HQ.Items.Add(rpg);
      HQ.Items.Add(sr);
      HQ.Items.Add(hp);
      HQ.Items.Add(hp);
      HQ.Items.Add(hp);
      //NOTE assign characters to rooms
      HQ.Characters.Add(a1);
      TF.Characters.Add(rg);
      TF.Characters.Add(rg);
      //NOTE starting point
      CurrentRoom = HQ;
    }
    public Game()
    {
      CurrentPlayer = new Player("peyton", 100, 3);
      Setup();
    }
  }
}