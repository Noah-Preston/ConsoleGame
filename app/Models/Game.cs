using escape_corona.Interfaces;

namespace escape_corona.Models
{
  class Game : IGame
  {
    public IPlayer CurrentPlayer { get; set; }
    public IRoom CurrentRoom { get; set; }

    ///<summary>Initalizes data and establishes relationships</summary>
    public Game()
    {
      // NOTE ALL THESE VARIABLES ARE REMOVED AT THE END OF THIS METHOD
      // We retain access to the objects due to the linked list


      // NOTE Create all rooms
      Room bathroom = new Room("Bathroom", @"It's like a warzone in here the walls are absolutely covered and theres no chance of cleaning this without military grade cleaning equipment");
      Room kitchen = new Room("Kitchen", "You see your phone laying on the counter");
      Room hallway = new Room("Front Hall", "The front door is right in front of you nows your chance to escape");
      Room laundryRoom = new Room("Laundry Room", "Fido the family dog looks up at you and due to his heightened sense of smell immediately passes out hopefully hes ok there seems to be a small key on the washing machine");
      EndRoom porch = new EndRoom("Porch", "The breeze passes across your feces covered body as you inhale fresh air", true, "You can start to try to recover from this incident and move on with your life though it may take years");
      EndRoom diningRoom = new EndRoom("Dining Room", "The entire family looks up at you including the dog taking in the spectacle that is your crispy outer shell of poo", false, "You immediately die of shame as the family starts to vomit nonstop");


      // NOTE Create all Items
      Item phone = new Item("Phone", "the brand new Iphone 34");
      Item key = new Item("Key", "this key is for the front door in the hallway");

      // NOTE Make Room Relationships
      bathroom.Exits.Add("east", kitchen);
      kitchen.Exits.Add("west", bathroom);
      kitchen.Exits.Add("north", laundryRoom);
      laundryRoom.Exits.Add("south", kitchen);
      laundryRoom.Exits.Add("north", hallway);
      kitchen.Exits.Add("east", diningRoom);
      hallway.Exits.Add("south", laundryRoom);
      hallway.AddLockedRoom(key, "west", porch);
      porch.Exits.Add("east", hallway);


      // NOTE put Items in Rooms
      kitchen.Items.Add(phone);
      laundryRoom.Items.Add(key);


      CurrentRoom = bathroom;
    }
  }
}