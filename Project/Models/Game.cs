using System;
using guildAdventure.Project.Interfaces;

namespace guildAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }

    public IPlayer CurrentPlayer { get; set; }
    //     public ICharacter Character { get; set; }
    //     public IGuild Guild { get; set; }
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
      Room D = new Room("at The Dump", @"
Not a pleasant place, but there's always something to find.", false);
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
      B.Exits.Add("west", D);
      D.Exits.Add("east", B);
      DT.Exits.Add("north", B);
      DT.Exits.Add("south", TF);
      TF.Exits.Add("north", DT);

      //NOTE initializes player
      Player ps = new Player("peyton", 100, 3);
      // Guild DO = new Guild("Dead Orbit", "");
      // Guild RD = new Guild("Royal Guard", "");
      //NOTE initializes character
      // Character a1 = new Character("alpha", 100, @"   An assassin bot you hijacked a few years back. Loyal...ish.", DO, 3);
      // Character ga = new Character("gamma", 150, @"   Your loyal, bio-enhanced hound.", DO, 2);
      // Character rg = new Character("a royal guard", 250, @"   Don't be fooled by the robes, he's hiding armor made from that metal you found earlier.", RD, 0);
      //NOTE initializes items 
      //REVIEW (1st number = effect, 2nd number = accuracy/chance of success, 3rd number = cooldown/reload)
      Item cm = new Item("claymore", @"   An enormous sword, outfitted with plasma tech.", HQ, 45, 85, 3);
      Item wm = new Item("war_machine", @"    1,500 RPM with electrically charged rounds.", HQ, 80, 33, 0);
      Item rpg = new Item("rpg", @"   A rocket propelled grenade launcher. Ear protection recommended.", HQ, 70, 66, 7);
      Item sr = new Item("sniper_rifle", @"   Accurate to 400 yards, rounds explode on contact.", HQ, 120, 85, 10);
      Item hp = new Item("potion", @"   Increases your health.", HQ, 15, 100, 0);
      Item mm = new Item("mysterium", @"    Mystery metal. You'll need to find someone who knows where this came from...", D, 0, 0, 0);
      //NOTE assign items to rooms
      HQ.Items.Add(cm);
      HQ.Items.Add(wm);
      HQ.Items.Add(rpg);
      HQ.Items.Add(sr);
      HQ.Items.Add(hp);
      HQ.Items.Add(hp);
      HQ.Items.Add(hp);
      D.Items.Add(mm);
      //NOTE assign characters to rooms

      //NOTE assign characters to guild
      // DO.Party.Add(a1);
      // DO.Party.Add(ga);
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