// --- Spaceship Console Game --- //

// Save Value Order:
// shipname
// captain
// health
// ammo
// fuel
// score
// location
// systemlocation


// To Mr Kanganas: Please look at the Changelog.sav for full changes between the C# and Python versions.
namespace SpaceshipConsole
{
    #region Usings
    using System.IO;
    using System;
    #endregion

    class Program : Random
    {
        #region Variable Declarations
        static string systemlocation = "";
        static string location = "";
        static string filepath = "";
        static string shipname = "";
        static string captain = "";
        static int life = 10;
        static int ammo = 20;
        static int fuel = 15;
        static int score = 0;
        static int maxHp = 0;
        static bool fighting = false;
        static string[] letters = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m" };
        static string[] ships = { "the Quarren Harbinger", "Torment", "the Inferno", "Transpar - The Best Transport System in the Galaxy!", "the Neutron-Beast", "the Coura Ranger" };
        static string[] desc = { "miniscule", "tiny", "small", "medium sized", "large", "big", "giant", "huge", "colossal", "gargantuan", "titanic", "mammoth" };
        static string[] description = { "scary", "brightly coloured", "destructive", "red", "circular", "spherical" };
        static bool AskForCreds = true;
        static bool seenCorellia = false;
        static bool seenBespin = false;
        static int specialhp;
        static bool seenspecialship;
        #endregion

        // Functions
        public static void Print(string words = "")
        {
            // Write the parameter into the console.
            Console.Write(words+"\n");
        }

        public static void SaveGame(string savefile, int life, int ammo, int fuel, int score, string location, string systemlocation)
        {
            Print("Saving Game...");
            if (savefile == "")
            {
                savefile = @"C:\ProgramData\SpaceshipConsole\savefile.sav";
            }
            if (!savefile.EndsWith(".sav"))
            {
                savefile += ".sav";
            }
            string message = shipname.Trim() + "\n" + captain.Trim() + "\n" + str(life).Trim() + "\n" + str(ammo).Trim() + "\n" + str(fuel).Trim() + "\n" + str(score).Trim() + "\n" + location.Trim() + "\n" + systemlocation.Trim();
            string showMessage = "Shipname: " + shipname.Trim() + "\nCaptain: " + captain.Trim() + "\nLife: " + str(life).Trim() + "\nAmmo: " + str(ammo).Trim() + "\nFuel: " + str(fuel).Trim() + "\nScore: " + str(score).Trim() + "\nLocation: " + location.Trim() + "\nSystem Location: " + systemlocation.Trim();
            Print(showMessage);
            string fullycodedmessage = "";
            for (int i = 0; i < message.Length; i++)
            {
                int letterASCIINumber = char.ConvertToUtf32(message, i);
                int codedLetterASCIINumber = letterASCIINumber + 12;
                fullycodedmessage += str(codedLetterASCIINumber)+"\n";
            }
            //StreamWriter file = File.AppendAllText(@"C:\ProgramData\savefile.sav");
            File.WriteAllText(savefile, fullycodedmessage);
            Sleep(0.75);
            Print("Game Saved.");
        }

        // Allow for different types of parameters.
        public static int Sleep(double Seconds)
        {
            Seconds *= 1000;
            Thread.Sleep((int)Seconds);
            return (int)Seconds;
        }
        public static int Sleep(int Seconds)
        {
            Seconds *= 1000;
            Thread.Sleep((int)Seconds);
            return (int)Seconds;
        }
        public static int Sleep(float Seconds)
        {
            Seconds *= 1000;
            Thread.Sleep((int)Seconds);
            return (int)Seconds;
        }

        // Read the input given by the player.
        public static string Input(string words = "")
        {
            Console.Write(words);
            string input = Console.ReadLine();
            input ??= "";
            return input;
        }

        public static bool Leaveplanet(string location)
        {
            string leave = Input("Do you want to leave " + location + "? (y/n) ");
            if (leave == "y") {
                Print("Leaving planet....");
                Sleep(2);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Lifecheck(int life)
        {
            if (life < 1)
            {
                Sleep(1);
                Print("You have lost all of your health.");
                Sleep(0.5);
                Print("It was an honour serving you Captain " + captain + ".");
                Sleep(1);
                Print("BOOM");
                Sleep(3);
                File.Delete(filepath);
                Print("Saved Game.");
                Sleep(2);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void EnterPass(string password)
        {
            string pAttempt = Input("Enter the password: ");
            while (pAttempt != password)
            {
                Print("Password incorrect");
                pAttempt = Input("Enter the password: ");
            }
            Print("Password correct. Welcome to " + shipname + ", Captain " + captain + ". I hope you enjoy your stay at " + location + ".");
        }

        public static void Showlocation()
        {
            Print("\n");
            Print(shipname + " is currently visiting " + location + ".");
            Print("\n");
        }

        public static string str(int integer)
        {
            return integer.ToString();
        }

        public static void ShowScore(int points)
        {
            Print("You now have a score of " + str(points) + ".");
        }
        public static void Main()
        {
            if (!Directory.Exists(@"C:\ProgramData\SpaceshipConsole")) Directory.CreateDirectory(@"C:\ProgramData\SpaceshipConsole");
            if (!File.Exists(@"C:\ProgramData\SpaceshipConsole\README.MD"))
            {
                File.WriteAllText(@"C:\ProgramData\SpaceshipConsole\README.MD", @"
To use the spaceship console game, you have to do the following:

- Write a password in the password.txt file. (or leave it empty if you want an empty password.)
- Open the Spaceship Console.exe file.
- When prompted to load a game, press 'y' for yes, or 'n' for no.
- Leave the file path blank for the already generated save file.
- If you didn't load a save, when prompted for the password, enter the text that was entered in the password.txt file.
- The various options you can use are now shown. Select from the different options.
- Enjoy playing!

To view the spaceship console game's code:
- Open the Program.cs file with Visual Studio, Visual Studio Code, or a plain text editor.
- Here you can view all code in the spaceship console game.
- Alternatively, you could open the project file (Spaceship Console 2.csproj) with Visual Studio.

To edit the save.sav file:
- Open the file with a plain text editor. You will find multiple lines of numbers.
- Every number is a character converted to ASCII, and then added by 12.
- To decode it, subtract 12 from each line, and put it through an ASCII decoder.
- To add a new character, encode it, and put it on the line where you want the character to be.
- Do not add or delete any numbers that equal 22, as this is a newline character, and could mess with the code.


Some info on the options of the ship:


Travel To Another Planet (a):
You can change the planet you are flying over, so that when you land on a planet, the effect changes.

Land On Planet (b):
You can land on a planet. Each planet will do a different effect.

Fire Blasters (c):
You can shoot your blasters at a ship. The type, size, and name of the ship is randomised each time you choose
this option. The health and damage you will take from the ship also changes. Sometimes you will come across boss
ships, and sometimes you will destroy ships in one hit. You can also retreat, but take the risk of taking up to
2 more damage.

Open Airlock (d):
Every time you open the airlock, there is a small chance that an alien will board your ship. Sometimes the alien
fixes stuff on the ship, but sometimes it attacks.

Self-Destruct (e):
A pretty self-explanatory option. This option allows you to self destruct the ship, and end the game.

Show Location (f):
This shows the planet you are flying over, and which sector you are in.

Show Health (g):
Shows your health.

Show Ammo (h):
Shows your ammo.

Show Fuel (i):
Shows your fuel.

Show Score (j):
Shows your score.

Show All Stats (k):
Shows all available stats.

Save Game (l):
Saves the game to a path that can be custom set, or be default. (by leaving blank)

Exit Game (exit):
Exits the game.

Thanks for playing the Spaceship Console Game!

Next time you boot up the game, this text will not appear,
but you can view it at C:\ProgramData\SpaceshipConsole2\README.MD");
                string Instructions = File.ReadAllText(@"C:\ProgramData\SpaceshipConsole\README.MD");
                Print(Instructions);
                Print("\n\nPlease scroll up to the top of the window.");
            }
            Start:
            int loc = getRandInt(0, 11);
            if (loc == 0) location = "Earth"; systemlocation = "Solar System";
            if (loc == 1) location = "Kamino"; systemlocation = "Abrion Sector";
            if (loc == 2) location = "Geonosis"; systemlocation = "Thanium Sector";
            if (loc == 3) location = "Mustafar"; systemlocation = "Atravis Sector";
            if (loc == 4) location = "Yavin 4"; systemlocation = "Gordian Sector";
            if (loc == 5) location = "Ahch-To"; systemlocation = "Unknown Regions";
            if (loc == 6) location = "Corellia"; systemlocation = "Outer Rim";
            if (loc == 7) location = "Mandalore"; systemlocation = "Outer Rim";
            if (loc == 8) location = "Bespin"; systemlocation = "Anoat Sector";
            if (loc == 9) location = "Coruscant"; systemlocation = "Core Worlds";
            if (loc == 10) location = "Duro"; systemlocation = "Core Worlds";
            if (loc == 11) location = "Tython"; systemlocation = "Inner Core";
            filepath = Input("What is the path of the file you want to save/load to?\n(Enter save path, eg. C:/Users/"+Environment.UserName+"/Documents/mysavegamename.sav)\nKeep blank for default location, although it may overwrite an existing save. ");
            
            // Mainline
            if (Input("Would you like to load the game? (y/n) ") == "y")
            {
                AskPath:
                string savefilePath = filepath;
                if (savefilePath == "")
                {
                    savefilePath = @"C:\ProgramData\SpaceshipConsole\savefile.sav";
                }
                if (!savefilePath.EndsWith(".sav"))
                {
                    Print("That is not a valid file path. It must be a .sav file.");
                    goto AskPath;
                }
                try
                {
                    File.ReadAllLines(savefilePath);
                }
                catch (Exception e)
                {
                    Print("AN ERROR HAS OCCURRED: "+e+"\n\n\n\n\n\n\nThis error probably was caused by the following: \n\n- Your savegame not existing in the folder\n- Your savegame being corrupted\n- Typing the path incorrectly.\n");
                    goto Start;
                }
                string[] message = File.ReadAllLines(savefilePath);
                int intMessage = 0;
                string decodedMessage = "";
                string letterASCIINumber = "";
                for (int i = 0; i < message.Length; i++)
                {
                    try
                    {
                        intMessage = int.Parse(message[i]);
                    }
                    catch (Exception e)
                    {
                        Print("Save file corrupted or deleted. Error: " + e.Message);
                    }
                    intMessage -= 12;
                    try
                    {
                        letterASCIINumber = char.ConvertFromUtf32(intMessage);
                    }
                    catch (Exception e)
                    {
                        Print("Cannot convert to string. Error: " + e.Message);
                    }
                    decodedMessage += letterASCIINumber;
                }
                Print(decodedMessage);
                string[] messageInLines = decodedMessage.Split('\n');
                shipname = messageInLines[0];
                captain = messageInLines[1];
                try
                {
                    life = int.Parse(messageInLines[2]);
                    ammo = int.Parse(messageInLines[3]);
                    fuel = int.Parse(messageInLines[4]);
                    score = int.Parse(messageInLines[5]);
                }
                catch
                {
                    // do nothing
                }
                location = messageInLines[6];
                systemlocation = messageInLines[7];
                AskForCreds = false;
                if (life < 2)
                {
                    if (life == 1)
                    {
                        Print("Warning: You have 1 life left.");
                    }
                    else
                    {
                        Print("You have no lives left.\nIf you think this is an error, contact the developer on https://bubkis.me");
                    }
                }
                if (ammo < 3)
                {
                    Print("Warning: You are running low on ammo. (Ammo = "+str(ammo)+")");
                }
                if (fuel < 3)
                {
                    if (fuel > 0)
                    {
                        Print("Warning: You are running low on fuel. (Fuel = " + str(fuel) + ")");
                    }
                    else
                    {
                        Print("You have no fuel.\nIf you think this is an error, contact the developer on https://bubkis.me");
                    }
                }
            }
            
            if (!File.Exists(Environment.CurrentDirectory + @"\password.txt"))
            {
                File.Create(Environment.CurrentDirectory + @"\password.txt");
                Thread.Sleep(2000);
            }
            try
            {
                // try to see if the password file is there.
                File.ReadAllText(Environment.CurrentDirectory + @"\password.txt");
            }
            catch (Exception)
            {
                Print("Initialized the password system. Please restart the game.");
                return;
            }
            // if it is there, get the password.
            string password = File.ReadAllText(Environment.CurrentDirectory + @"\password.txt");
            if (AskForCreds)
            {
                Print("Please enter your credentials:");
                shipname = Input("What would you like the name of your star ship to be? ");
                captain = Input("What is your name? ");
                EnterPass(password);
            }
            Showlocation();
            Print();
            chooseAction(location, life, systemlocation, fuel, ammo, score);
            Print("Would you like to restart? (y/n) ");
            string restart = Input();
            if (restart == "y")
            {
                loc = getRandInt(0, 11);
                if (loc == 0) location = "Earth"; systemlocation = "Solar Sector";
                if (loc == 1) location = "Kamino"; systemlocation = "Abrion Sector";
                if (loc == 2) location = "Geonosis"; systemlocation = "Thanium Sector";
                if (loc == 3) location = "Mustafar"; systemlocation = "Atravis Sector";
                if (loc == 4) location = "Yavin 4"; systemlocation = "Gordian Sector";
                if (loc == 5) location = "Ahch-To"; systemlocation = "Unknown Regions";
                if (loc == 6) location = "Corellia"; systemlocation = "Outer Rim";
                if (loc == 7) location = "Mandalore"; systemlocation = "Outer Rim";
                if (loc == 8) location = "Bespin"; systemlocation = "Anoat Sector";
                if (loc == 9) location = "Coruscant"; systemlocation = "Core Worlds";
                if (loc == 10) location = "Duro"; systemlocation = "Core Worlds";
                if (loc == 11) location = "Tython"; systemlocation = "Inner Core";
                life = 10;
                ammo = 20;
                fuel = 15;
                score = 0;
                Print("Please enter your credentials:");
                shipname = Input("What would you like the name of your star ship to be? ");
                captain = Input("What is your name? ");
                Showlocation();
                chooseAction(location, life, systemlocation, fuel, ammo, score);
            }
        }

        public static int getRandInt(int minimum, int maximum)
        {
            Random random = new();
            return random.Next(minimum, maximum + 1);
        }

        public static void chooseAction(string location, int life, string systemlocation, int fuel, int ammo, int score)
        {
            if (Lifecheck(life)) return;
            string choice = "";
            while (choice != "exit") {
                Print("What would you like to do, " + captain + "?");
                Sleep(0.25);
                Print("\n");
                Sleep(0.25);
                Print("a. Travel to another planet");
                Sleep(0.25);
                Print("b. Land on planet");
                Sleep(0.25);
                Print("c. Fire blasters");
                Sleep(0.25);
                Print("d. Open airlock");
                Sleep(0.25);
                Print("e. Self-destruct");
                Sleep(0.25);
                Print("f. Show location");
                Sleep(0.25);
                Print("g. Show health");
                Sleep(0.25);
                Print("h. Show ammo");
                Sleep(0.25);
                Print("i. Show fuel");
                Sleep(0.25);
                Print("j. Show score");
                Sleep(0.25);
                Print("k. Show all stats");
                Sleep(0.25);
                Print("l. Save game");
                Sleep(0.25);
                Print("To exit the game, type 'exit'.");
                Sleep(0.25);
                Print("\n");
                Sleep(1);
                choice = Input("Enter your choice: ");
                Sleep(1);
                if (choice == "a")
                {
                    if (fuel < 1) {
                        Print("You cannot move, you are out of fuel.");
                        Sleep(1);
                        return;
                    }
                    Print("Where would you like to go?"); Sleep(0.25);
                    Print("You can go to the following places:"); Sleep(0.25);
                    Print(""); Sleep(0.25);
                    Print(""); Sleep(0.25);
                    Print("a. Earth - Solar System"); Sleep(0.25);
                    Print("b. Kamino - Abrion Sector"); Sleep(0.25);
                    Print("c. Geonosis - Thanium Sector"); Sleep(0.25);
                    Print("d. Mustafar - Atravis Sector"); Sleep(0.25);
                    Print("e. Yavin 4 - Gordian Sector"); Sleep(0.25);
                    Print("f. Ahch-To - Unknown Regions"); Sleep(0.25);
                    Print("g. Corellia - Outer Rim"); Sleep(0.25);
                    Print("h. Mandalore - Outer Rim"); Sleep(0.25);
                    Print("i. Bespin - Anoat Sector"); Sleep(0.25);
                    Print("j. Coruscant - Core Worlds"); Sleep(0.25);
                    Print("k. Duro - Core Worlds"); Sleep(0.25);
                    Print("l. Tython - Inner Core"); Sleep(0.25);
                    Print(""); Sleep(0.25);
                    Print(""); Sleep(0.25);
                    string destination = Input("Enter your choice: "); Sleep(0.25);
                    if (destination != location) {
                        fuel -= 1;
                        if (destination == "a")
                        {
                            Print("Leaving " + location);
                            Sleep(5);
                            Print("Arrived at Earth...");
                            location = "Earth";
                            systemlocation = "Solar System";
                            Sleep(1);
                        }
                        else if (destination == "b")
                        {
                            Print("Leaving " + location);
                            Sleep(5);
                            Print("Arrived at Kamino...");
                            location = "Kamino";
                            systemlocation = "Abrion Sector";
                            Sleep(1);
                        }
                        else if (destination == "c")
                        {
                            Print("Leaving " + location);
                            Sleep(5);
                            Print("Arrived at Geonosis...");
                            location = "Geonosis";
                            systemlocation = "Arkanis Sector";
                            Sleep(1);
                        }
                        else if (destination == "d")
                        {
                            Print("Leaving " + location);
                            Sleep(5);
                            Print("Arrived at Mustafar...");
                            location = "Mustafar";
                            systemlocation = "Anoat Sector";
                            Sleep(1);
                        }
                        else if (destination == "e")
                        {
                            Print("Leaving " + location);
                            Sleep(5);
                            Print("Arrived at Yavin 4...");
                            location = "Yavin 4";
                            systemlocation = "Gordian Sector";
                            Sleep(1);
                        }
                        else if (destination == "f")
                        {
                            Print("Leaving " + location);
                            Sleep(5);
                            Print("Arrived at Ahch-To...");
                            location = "Ahch-To";
                            systemlocation = "Unknown Regions";
                            Sleep(1);
                        }
                        else if (destination == "g")
                        {
                            Print("Leaving " + location);
                            Sleep(5);
                            Print("Arrived at Corellia...");
                            location = "Corellia";
                            systemlocation = "Outer Rim";
                            Sleep(1);
                        }
                        else if (destination == "h")
                        {
                            Print("Leaving " + location);
                            Sleep(5);
                            Print("Arrived at Mandalore...");
                            location = "Mandalore";
                            systemlocation = "Outer Rim";
                            Sleep(1);
                        }
                        else if (destination == "i")
                        {
                            Print("Leaving " + location);
                            Sleep(5);
                            Print("Arrived at Bespin...");
                            location = "Bespin";
                            systemlocation = "Anoat Sector";
                            Sleep(1);
                        }
                        else if (destination == "j")
                        {
                            Print("Leaving " + location);
                            Sleep(5);
                            Print("Arrived at Coruscant...");
                            location = "Coruscant";
                            systemlocation = "Core Worlds";
                            Sleep(1);
                        }
                        else if (destination == "k")
                        {
                            Print("Leaving " + location);
                            Sleep(5);
                            Print("Arrived at Duro...");
                            location = "Duro";
                            systemlocation = "Core Worlds";
                            Sleep(1);
                        }
                        else if (destination == "l")
                        {
                            Print("Leaving " + location);
                            Sleep(5);
                            Print("Arrived at Tython...");
                            location = "Tython";
                            systemlocation = "Inner Core";
                            Sleep(1);
                        }
                        Print("You now have " + str(fuel) + " uses of fuel.");
                        Sleep(1);
                    }
                    else
                    {
                        Print("That is not a valid choice. Going back to main menu.");
                        Sleep(1);
                    }
                }
                else if (choice == "b")
                {
                    if (fuel < 1)
                    {
                        Print("You cannot move, you are out of fuel.");
                        Sleep(1);
                        return;
                    }

                    fuel -= 1;
                    Print("You are landing on " + location + ", in the " + systemlocation + "....");
                    Sleep(2);
                    if (location == "Earth")
                    {
                        Earth:
                        Sleep(1);
                        Print("You have arrived on Earth, a green planet filled with life.");
                        string tankrefill = Input("Repair ship? ");
                        if (tankrefill == "y")
                        {
                            Sleep(1);
                            if (life < 10)
                            {
                                life = 10;
                                Print("Ship has been completely repaired and fixed.");
                                Print("You now have " + str(life) + " health.");
                            }
                            else
                            {
                                Sleep(1);
                                Print("Your ship is already functional.");
                                Print("You know what they say: 'If it ain't broken, don't fix it.'");
                                Sleep(1);
                            }
                            if (!Leaveplanet(location)) goto Earth;
                        }
                        else
                        {
                            Print("There is nothing to do on this planet.");
                            Sleep(2);
                            if (!Leaveplanet(location)) goto Earth;
                        }
                    }
                    else if (location == "Kamino")
                    {
                        Kamino:
                        Sleep(1);
                        Print("You have arrived on Kamino, the cold, wet planet that is void of life.");
                        string tankrefill = Input("Clean spaceship with mineral rich water? (y/n) ");
                        if (tankrefill == "y")
                        {
                            Sleep(1);
                            Print("Spaceship cleaned.");
                            life += 1;
                            Print("You now have " + str(life) + " health.");
                            Print("Leaving planet.");
                        }
                        SaveGame(filepath, life, ammo, fuel, score, location, systemlocation);
                        if (!Leaveplanet(location)) goto Kamino;
                    }
                    else if (location == "Geonosis")
                    {
                        Geonosis:
                        Sleep(1);
                        Print("You have arrived on Geonosis, a hot, desolate plain.");
                        string refuelammo = Input("Would you like to refuel your ammunition with sharp rocks? (y/n) ");
                        if (refuelammo == "y")
                        {
                            ammo += 5;
                            Print("You now have " + str(ammo) + " ammo.");
                        }
                        else
                        {
                            Print("Resting on Geonosis...");
                            Sleep(2);
                            life += 1;
                            Print("Your ship now has " + str(life) + " health.");
                            Sleep(1);
                        }
                        SaveGame(filepath, life, ammo, fuel, score, location, systemlocation);
                        if (!Leaveplanet(location)) goto Geonosis;
                    }
                    else if (location == "Mustafar")
                    {
                        Mustafar:
                        Sleep(1);
                        Print("Arriving on Mustafar. Mustafar is a very hot lava planet.");
                        Sleep(0.5);
                        Print("Being this close to the searing heat can warp the metal of spaceships.");
                        Sleep(1);
                        life -= 1;
                        Print("You now have " + str(life) + " health.");
                        Sleep(0.5);
                        string lava = Input("Would you like to collect lava for fuel? (y/n) ");
                        if (lava == "y")
                        {
                            Print("Restocking fuel...");
                            fuel += 5;
                            Sleep(0.5);
                            if (!Leaveplanet(location)) goto Mustafar;
                        }
                        else
                        {
                            if (!Leaveplanet(location)) goto Mustafar;
                        }
                        SaveGame(filepath, life, ammo, fuel, score, location, systemlocation);
                    }
                    else if (location == "Yavin 4")
                    {
                        Yavin4:
                        Print("You explore for a bit and find some credits lying around.");
                        score += 10;
                        ShowScore(score);
                        SaveGame(filepath, life, ammo, fuel, score, location, systemlocation);
                        if (!Leaveplanet(location)) goto Yavin4;
                    }
                    else if (location == "Ahch-To")
                    {
                        AhchTo:
                        Print("While finding a place to land on Ahch-To, you see a large island dotted on the horizon, towering over the seemingly endless ocean.");
                        Sleep(1.5);
                        Print("On the island, you see small stony, cobbled huts.");
                        SaveGame(filepath, life, ammo, fuel, score, location, systemlocation);
                        if (!Leaveplanet(location)) goto AhchTo;
                    }
                    else if (location == "Corellia")
                    {
                        Corellia:
                        Print("Corellia is a backwater planet filled with the most vile criminals and organisations in the galaxy.");
                        Sleep(1.5);
                        if (!seenCorellia)
                        {
                            Print("Before even landing, you see a group of people with blasters firing at what looks like a giant white mastiff.");
                            Sleep(0.75);
                            Print("As you get closer, you can see what looks like thick, shiny white tenticles protruding from the giant beast's head.");
                            Sleep(1.25);
                            Print("You touch down a few metres away, and as you open the door you hear someone call those dogs 'Corellian Hounds'.");
                            Print("As you step out of the ship, one of the hounds runs up to you, and growls.");
                            Sleep(1.25);
                            if (Input("Would you like to shoot at it? (y/n) ") == "y")
                            {
                                Print("You grab your blaster from your holster with amazing speed and shoot the hound square in the face.");
                                Sleep(1.25);
                                Print("Someone says, \"Hey, you! How did you do that?! What's your name?\"");
                                Sleep(1);
                                Print("You say, \"I am " + captain + ", and I drive " + shipname + "\"");
                                score += 10;
                                ShowScore(score);
                                SaveGame(filepath, life, ammo, fuel, score, location, systemlocation);
                            }
                            else
                            {
                                Print("The Corellian Hound attacks.");
                                Sleep(0.5);
                                Print("You dodge out of the way and lock it in your ship.");
                                life -= 1;
                                if (Lifecheck(life)) return;
                                Print("While trying to get out, the hound opens a hatch on the top of the ship, and jumps off.");
                                Sleep(0.75);
                                Print("It doesn't survive the fall.");
                                score += 10;
                                ShowScore(score);
                                SaveGame(filepath, life, ammo, fuel, score, location, systemlocation);
                            }
                            seenCorellia = true;
                        }
                        else
                        {
                            Print("Luckily, the place is empty.");
                            Print("You find some gear and tools around the place, and put them in your ship.");
                            score += 20;
                            ShowScore(score);
                        }
                        if (!Leaveplanet(location)) goto Corellia;
                    }
                    else if (location == "Mandalore")
                    {
                        Mandalore:
                        Print("You have landed on the wreckage of Mandalore.");
                        if (!Leaveplanet(location)) goto Mandalore;
                    }
                    else if (location == "Bespin")
                    {
                        Bespin:
					    Print("You touch down on a landing pad seemingly floating on the clouds that smother this planet.");
					    Sleep(1.5);
					    Print("The air is thin up here, and you feel a little light-headed.");
					    Sleep(1);
                        if (!seenBespin)
                        {
                            Print("A strange man wearing a gold and blue cape calls out to you. \"Hey, you there! How are ya doing? Have a good trip?\"");
                            string _tempInput = Input("Would you like to accept his welcome, or would you like to attack? (a/b) ");
                            if (_tempInput == "a")
                            {
                                Print("You accept his welcome graciously, and he asks for the payment for landing on his landing pad.");
                                _tempInput = Input("Would you like to pay him, or deny his payment? (a/b) ");
                                if (_tempInput == "a")
                                {
                                    Print("You pay him 120 points.");
                                    score -= 120;
                                    ShowScore(score);
                                }
                                else
                                {
                                    Print("You are forced to leave the planet.");
                                }
                            }
                            else
                            {
                                Print("You attack the caped figure, and he expertly dodges your reckless move.");
                                Print("Your ship is hit multiple times by the figure's blaster, and it takes some damage.");
                                life -= 4;
                                if (Lifecheck(life)) return;
                                Print("You now have "+life+" health.");
                                Sleep(1);
                                Print("You elbow him in the face, and he is knocked out cold.");
                                if (Input("Would you like to throw him off the edge of the platform? (y/n) ") == "y")
                                {
                                    Print("He is hastily thrown off the platform, to the surface of the planet hundreds of metres below.");
                                    Sleep(1);
                                    Print("Far down you hear a loud scream, suddenly stopping with a sickening crunch far below.");
                                    score += 200;
                                    Print("While exploring a small part of the city, you find some credits.");
                                    ShowScore(score);
                                    SaveGame(filepath, life, ammo, fuel, score, location, systemlocation);
                                }
                                else
                                {
                                    score += 200;
                                    Print("While exploring a small part of the city, you find some credits.");
                                    ShowScore(score);
                                    Sleep(1);
                                    Print("When walking back to the ship, you see the caped man again. He has vandilised and damaged your ship.");
                                    shipname += letters[getRandInt(0, 25)];
                                    shipname += letters[getRandInt(0, 25)];
                                    shipname += letters[getRandInt(0, 25)];
                                    shipname += letters[getRandInt(0, 25)];
                                    shipname += letters[getRandInt(0, 25)];
                                    Print("Your ship's name now reads as " + shipname + ".");
                                    Sleep(1);
                                    Print("It is badly vandilised and cannot be repaired.");
                                    Sleep(2);
                                    life -= 2;
                                    Print("Your ship has also taken extensive damage.");
                                    if (Lifecheck(life)) return;
                                    SaveGame(filepath, life, ammo, fuel, score, location, systemlocation);
                                }
                            }
                            seenBespin = true;
                            Print("You leave the planet.");
                        }
                        else
                        {
                            Print("You see that the whole city has been burned and destroyed. There is nowhere to land.");
                            Print("You are forced to leave the planet.");
                            if (!Leaveplanet(location)) goto Bespin;
                        }
                    }
                    else if (location == "Coruscant")
                    {
                        Coruscant:
                        Print("You land on the ");
                        if (!Leaveplanet(location)) goto Coruscant;
                    }
                    else if (location == "Duro")
                    {
                        Duro:
                        Print("You land on the watery but busy world of Duro.");
                        string originalShipname = shipname;
                        shipname += letters[getRandInt(0, 26)];
                        shipname += letters[getRandInt(0, 26)];
                        shipname += letters[getRandInt(0, 26)];
                        shipname += letters[getRandInt(0, 26)];
                        shipname += letters[getRandInt(0, 26)];
                        Print("Your ship was vandilised. Its name now reads as " + shipname + ".");
                        Sleep(0.5);
                        SaveGame(filepath, life, ammo, fuel, score, location, systemlocation);
                        Sleep(1);
                        Print("You can pay 30 points to repair it.");
                        string Repair = Input("Would you like to repair your ship?\nIf you do not repair it now, you won't be able to repair it later. (y/n) ");
                        if (Repair == "y")
                        {
                            score -= 30;
                            Sleep(0.75);
                            ShowScore(score);
                            shipname = originalShipname;
                        }
                        Print("There is a blue-skinned Duro waving at " + shipname + ". \n\"Hey, you! Yeah! You! Move your darn ship, or I'll kill ya!\"");
                        if (Input("Do you want to:\na. Run him over.\nb. Move the ship.\n\nChoice: ") == "a")
                        {
                            Print("The Duro dies with a sickening squelch.");
                            score += 20;
                            ShowScore(score);
                        }
                        else
                        {
                            Print("You move out of the way, but the Duro picks up a rocket launcher and shoots at " + shipname + ".");
                            life -= 2;
                            if (Lifecheck(life)) return;
                            score -= 5;
                            Sleep(1);
                            Print("Would you like to shoot");
                        }
                        if (!Leaveplanet(location)) goto Duro;
                    }
                    else if (location == "Tython")
                    {
                        Tython:
                        Print("You try to land on Tython, evading gravity wells and spinning asteroids.");
                        Sleep(0.5);
                        life -= 1;
                        if (Lifecheck(life)) return;
                        int tempRandInt = getRandInt(0, 2);
                        if (tempRandInt > 1)
                        {
                            Print("You successfully land on Tython. You use the untouched materials to fix your ship, improve it, and you fill up your fuel.");
                            fuel += 6;
                            life += 3;
                            ammo += 2;
                            Sleep(0.5);
                        }
                        else
                        {
                            Print("You fail to land on Tython.");
                            string tryAgain = Input("Would you like to try again?");
                            if (tryAgain == "y") goto Tython;
                            else
                            {
                                Print("You leave the Inner Core.");
                                Sleep(0.5);
                            }
                        }
                        if (!Leaveplanet(location)) goto Tython;
                    }
                    else
                    {
                        Print("How did you manage to get to a planet that isn't on the list???");
                        Print("No cheating.");
                        ShowScore(score);
                        Print("You now have " + str(fuel) + " uses of fuel.");
                        Sleep(1);
                        File.Delete(filepath);
                        Print("Congrats, your save is deleted.");
                        return;
                    }
                }
                // Fire Blasters
                else if (choice == "c")
                {
                    int randythingship = getRandInt(0, 5);
                    int randythingdesc = getRandInt(0, 11);
                    int randomthingdescription = getRandInt(0, 5);
                    int uniqueship = getRandInt(0, 999);
                    if (uniqueship < 11)
                    {
                        Print("A circular, speeding ship called The Millennium Falcon zooms past.");
                        seenspecialship = true;
                        specialhp = 7;
                        maxHp = 7;
                    }
                    else if (uniqueship == 11)
                    {
                        Print("Kylo Ren's TIE Silencer streaks across the sky. The sound of two full powered ram jets get louder as it starts to turn back...");
                        seenspecialship = true;
                        specialhp = 4;
                        maxHp = 4;
                    }
                    else if (uniqueship > 11 && uniqueship < 100)
                    {
                        Print("An inquisitor's TIE Advanced slows down next to you.");
                        seenspecialship = true;
                        specialhp = 5;
                        maxHp = 5;
                    }
                    else if (uniqueship > 99 && uniqueship < 151)
                    {
                        Print("Darth Vader's TIE Advanced speeds past you, and you feel a deathly chill envelop you...");
                        seenspecialship = true;
                        specialhp = 10;
                        maxHp = 10;
                    }
                    else if (uniqueship > 150 && uniqueship < 200)
                    {
                        if (location == "Yavin 4")
                        {
                            Print("The Death Star rises above the horizon of Yavin 4, and over 2100 turbolasers lock onto you.");
                            Sleep(1);
                            Print("BOOM");
                            Sleep(1);
                            File.Delete(filepath);
                            return;
                        }
                        else
                        {
                            Print("You see Darth Vader's Executioner, the largest and most powerful star ship in the galaxy.");
                            seenspecialship = true;
                            specialhp = 12;
                            maxHp = 12;
                        }
                    }
                    else
                    {
                        Print("There is a " + desc[randythingdesc] + ", " + description[randomthingdescription] + " spaceship called " + ships[randythingship]);
                        Sleep(1);
                        string shoot = Input("Do you still wish to engage? (y/n) ");
                        if (shoot == "y")
                        {
                            if (seenspecialship)
                            {
                                Print("Blasters ready.");
                                Sleep(1);
                                if (Lifecheck(life)) return;
                                while (specialhp > 0)
                                {
                                    shoot = Input("Would you like to shoot? (y/n) ");
                                    if (Lifecheck(life)) return;
                                    if (shoot == "y")
                                    {
                                        ammo -= 1;
                                        if (specialhp > 1) Print("You have hit the ship. It is not destroyed.");
                                        if (specialhp < 2) Print("You have destroyed the enemy ship.");
                                        specialhp -= 1;
                                        Sleep(0.5);
                                        Print("You now have " + str(ammo) + " ammo.");
                                        Sleep(1);
                                        if (specialhp > 0)
                                        {
                                            Print("It shoots back at you.");
                                            life -= 1;
                                            Print("You now have " + str(life) + " health.");
                                            if (Lifecheck(life)) return;
                                        }
                                    }
                                    else
                                    {
                                        int hits = getRandInt(0, 2);
                                        specialhp = 0;
                                        fighting = false;
                                        if (hits == 0)
                                        {
                                            Print("You get away safely.");
                                        }
                                        else if (hits == 1)
                                        {
                                            Print("You retreat, but take another hit from the ship.");
                                            life -= 1;
                                            Print("You now have " + str(life) + " health.");
                                            if (Lifecheck(life)) return;
                                        }
                                        else
                                        {
                                            Print("You take two more damage from the enemy ship.");
                                            life -= 2;
                                            Print("You now have " + str(life) + " health.");
                                            if (Lifecheck(life)) return;
                                        }
                                    }
                                }
                                if (fighting)
                                {
                                    int amount = 100 * maxHp;
                                    score += amount;
                                    ShowScore(score);
                                    if (Lifecheck(life)) return;
                                }
                            }
                            else
                            {
                                Print("Blasters ready.");
                                Sleep(1);
                                if (Lifecheck(life)) return;
                                int shipHp = getRandInt(1, 2);
                                int scoreOnKill = 20;
                                shipHp += randythingdesc;
                                scoreOnKill += randythingdesc + 3;
                                if (shipHp > 2)
                                {
                                    shipHp -= 2;
                                }
                                if (randomthingdescription == 0)
                                {
                                    shipHp += 2;
                                    scoreOnKill += 10;
                                }
                                if (randomthingdescription == 2)
                                {
                                    shipHp += 1;
                                    scoreOnKill += 5;
                                }
                                shipHp -= 1;
                                scoreOnKill += shipHp;
                                if (shipHp < 1)
                                {
                                    Print("You have destroyed the enemy ship.");
                                    ammo -= 1;
                                    Print("You now have " + str(ammo) + " ammo.");
                                    score += scoreOnKill;
                                    ShowScore(score);
                                }
                                else
                                {
                                    Print("The ship is hit, but not destroyed.");
                                    bool killed = false;
                                    if (ammo < 1)
                                    {
                                        Print("You have no ammo left.");
                                        Print("You have been destroyed by the other ship.");
                                        return;
                                    }
                                    ammo -= 1;
                                    Print("You now have " + str(ammo) + " ammo.");
                                    while (killed == false)
                                    {
                                        Print("It shoots back! You are hit!");
                                        life -= 1;
                                        Print("You have " + str(life) + " health left.");
                                        if (Lifecheck(life)) return;
                                        string retreat = Input("Do you want to stay and shoot again? (y/n) ");
                                        if (retreat == "y")
                                        {
                                            Sleep(1);
                                            shipHp -= 1;
                                            if (shipHp < 1)
                                            {
                                                Print("You have destroyed the enemy ship.");
                                                score += scoreOnKill;
                                                ShowScore(score);
                                                killed = true;
                                                ammo -= 1;
                                                Print("You now have " + str(ammo) + " ammo.");
                                            }
                                            else
                                            {
                                                Print("The ship is hit, but not destroyed.");
                                                if (ammo < 1)
                                                {
                                                    Print("You have no ammo left.");
                                                    Print("You have been destroyed by the other ship.");
                                                    return;
                                                }
                                                ammo -= 1;
                                                Print("You now have " + str(ammo) + " ammo.");
                                            }
                                        }
                                        else
                                        {
                                            Sleep(1);
                                            int randomRetreatDamage = getRandInt(0, 3);
                                            Print("You retreat, but take "+str(randomRetreatDamage)+" damage on the way out.");
                                            killed = true;
                                            if (Lifecheck(life)) return;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Sleep(1);
                            int randomRetreatDamage = getRandInt(0, 3);
                            Print("You leave, but take " + str(randomRetreatDamage) + " on the way out.");
                            if (Lifecheck(life)) return;
                        }
                    }
                }
                // Open Airlock;
                else if (choice == "d")
                {
                    Print("Opening airlock");
                    Sleep(3);
                    Print("Airlock open");
                    Sleep(1);
                    if (getRandInt(1, 4) > 2)
                    {
                        Print("An alien has tried to board!");
                        string enter = Input("Do you want to allow it to enter? (y/n) ");
                        if (enter == "y")
                        {
                            int attack = getRandInt(0, 1);
                            if (attack == 0)
                            {
                                Print("The alien has attacked!");
                                Print("Airlock breached.");
                                Print("Threat neutralised.");
                                life -= 1;
                                Print("Closing airlock");
                                Sleep(3);
                                Print("Airlock closed");
                                Sleep(1);
                                Print("You now have " + str(life) + " health.");
                                Sleep(1);
                            }
                            else
                            {
                                Print("The alien is grateful, and decides to repay you by fixing your ship!");
                                life += 1;
                                Print("Closing airlock");
                                Sleep(3);
                                Print("Airlock closed");
                                Sleep(1);
                                Print("You now have " + str(life) + " health.");
                                Sleep(1);
                            }
                        }
                        else
                        {
                            Print("Airlock breached.");
                            Print("Alien has been sucked into outer space.");
                            Print("There has been no damage to the ship.");
                            Print("Closing airlock");
                            Sleep(3);
                            Print("Airlock closed");
                            Sleep(1);
                        }
                    }
                    else
                    {
                        Print("There is nothing near the airlock.");
                        Print("Closing airlock");
                        Sleep(3);
                        Print("Airlock closed");
                        Sleep(1);
                    }
                }
                else if (choice == "e")
                {
                    string Confirm = Input("Are you sure you want the ship to self-destruct? (y/n)");
                    if (Confirm == "y")
                    {
                        Print("The ship will self-destruct in");
                        Print("3");
                        Sleep(1);
                        Print("2");
                        Sleep(1);
                        Print("1");
                        Sleep(1);
                        Print("Goodbye, Captain " + captain + ". It was an honour serving you.");
                        Sleep(2);
                        Print("BOOM");
                        Print("Saving Game...");
                        File.Delete(filepath);
                        for (int i = 0; i < 200; i++)
                        {
                            Print(".");
                            Sleep(0.05);
                            Print("..");
                            Sleep(0.05);
                            Print("...");
                            Sleep(0.05);
                            Print("..");
                            Sleep(0.05);
                        }
                        Sleep(0.5);
                        Print("Deleted Save.");
                        return;
                    }
                    else
                    {
                        Print("Self Destruct has been canceled.");
                        Print("\n");
                        Sleep(1);
                    }
                }
                // Show Location;
                else if (choice == "f")
                {
                    Print("Hello Captain " + captain + ", you are on the planet " + location + ", in the " + systemlocation);
                    Sleep(1);
                }
                //Show Health;
                else if (choice == "g")
                {
                    Print("You have " + str(life) + " health.");
                    Sleep(1);
                }
                // Show Ammo;
                else if (choice == "h")
                {
                    Print("You have " + str(ammo) + " ammo.");
                    Sleep(1);
                }
                // Show Fuel;
                else if (choice == "i")
                {
                    Print("You have " + str(fuel) + " uses of fuel.");
                    Sleep(1);
                }
                // Show Score;
                else if (choice == "j")
                {
                    Print("You have a score of " + str(score) + ".");
                }
                // Show Stats;
                else if (choice == "k")
                {
                    Print("You have " + str(life) + " health.");
                    Sleep(0.25);
                    Print("You have " + str(ammo) + " ammo.");
                    Sleep(0.25);
                    Print("You have " + str(fuel) + " uses of fuel.");
                    Sleep(0.25);
                    Print("You have " + str(score) + " points.");
                    Sleep(1);
                }
                else if (choice == "l")
                {
                    SaveGame(filepath, life, ammo, fuel, score, location, systemlocation);
                }
                // Exit;
                else if (choice == "exit")
                {
                    Print("Exiting...");
                    Sleep(2);
                    return;
                }
                // Throw Error;
                else
                {
                    Print("Invalid Input. Please select a, b, c, d, e, f, g, h, i, j, k, or l.");
                    Sleep(1);
                }
            }
        }
    }
}