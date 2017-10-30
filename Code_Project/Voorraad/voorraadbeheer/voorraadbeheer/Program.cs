using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voorraadbeheer
{
    class Program
    {
        ///====================================<Variable>=====================================
        //List - Artikellen
        public static List<Artikelen> art = new List<Artikelen>();

        //Login - Wachtwoord
        public static string ww ="1";
        public static string UserName;
        public static int Login_try = 3;

        //Key - Indentifier
        public static string Key_Indetifier = "#";
        public static string Key_Back = Key_Indetifier + 9.ToString();
        public static string Key_Menu = Key_Indetifier + 8.ToString();
        public static string Key_Emptypage = Key_Indetifier;

        //Path - Username
        public static string pcUserName = GetPCUsername()+"/";
        public static string SavePath = @"C:\Users\"+pcUserName+"desktop\\Voorraad.txt";
        //====================================================================================

        //Main
        static void Main(string[] args)
        {   //Check if save file exist
            if (File.Exists(SavePath))
                art = Load();
            else
                RawDATA();

            GetLogName();
        }
        public static void Menu()
        {
            Console.Clear();

            Console.WriteLine("Menu");
            Console.WriteLine("1. Voorraad bekijken");
            Console.WriteLine("2. Voorraad wijzigen");
            Console.WriteLine("3. Log uit");
            Console.WriteLine("4. sluit af");//not submenu

            Console.WriteLine("");
            Console.WriteLine("Typ nummer om te selecteren:");

            int choice;
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out choice))
            {
                if (choice > 4)
                    Console.WriteLine("Er is geen optie voor dat getal!");

                switch (choice)
                {
                    case 1:
                        FilterCategoriePanel(true, "Voorraad Bekijken");
                        break;
                    case 2:
                        GetID();
                        break;
                    case 3:
                        Save(art);
                        GetLogName();
                        break;
                    case 4:
                        Save(art);
                        Environment.Exit(0);
                        break;
                }
            }
            else
                Menu();
        }

        //Login-Wachtwoord
        public static void GetWW()
        {
            Console.Clear();
            Console.WriteLine("Welkom " + UserName);
            Console.WriteLine("Typ nu uw Wachtwoord in a.u.b.:");
            CheckWW(Console.ReadLine());
        }
        public static void GetLogName()
        {
            Console.Clear();

            Console.WriteLine("Welkom! login om verder te gaan.");
            Console.WriteLine("Typ nu uw Login naam in:");

            UserName = Console.ReadLine();
            GetWW();
        }
        public static void CheckWW(string Wachtwoord)
        {
            if (Login_try >= 1)
            {
                //ww
                if (Wachtwoord == ww)
                {
                    Login_try = 3;
                    Menu();
                }
                else
                {
                    Console.Clear();
                    Login_try -= 1;
                    Console.WriteLine("Verkeerde wachtwoord en naam combinatie. U kunt nog maar " + Login_try + " proberen.");
                    Console.WriteLine("Typ nu uw wachtwoord opnieuw in....");

                    string wwtry = Console.ReadLine();
                    CheckWW(wwtry);
                }
            }
            else
                Environment.Exit(0);
        }

        //Filtering-Collecting-Bekijken
        public static void FilterCategoriePanel(bool Bekijken, string FuncName)
        {
            //Set GUI
            Console.Clear();
            Console.WriteLine(FuncName + ":");
            Reminder();

            Console.WriteLine("Kies eerst een categorie:");
            Console.WriteLine("1. Zaal");
            Console.WriteLine("2. Straat");
            Console.WriteLine("3. Veld");

            Console.WriteLine("");
            Console.WriteLine("Typ nummer om te selecteren:");

            //Get key input - and call function
            int choice;
            string input = Console.ReadLine();

            if (input == Key_Menu)
                Menu();
            else
            if (input == Key_Back)
                GOBack("FilterCategorie");
            else
            if (Int32.TryParse(input, out choice))
            {
                if (choice >= 3)
                    Console.WriteLine("Er is geen optie voor dat getal!");

                switch (choice)
                {
                    case 1:
                        if (Bekijken)
                            CollectDATA(Categorie.Zaal);
                        break;
                    case 2:
                        CollectDATA(Categorie.Straat);
                        break;
                    case 3:
                        CollectDATA(Categorie.Veld); ;
                        break;
                }
            }
            else
                FilterCategoriePanel(Bekijken, FuncName);
        }
        public static void CollectDATA(Categorie choice)
        {
            //check if int
            //Check if ID exsists






            //Set Gui
            Console.Clear();
            Console.WriteLine(choice + ": ");
            Reminder();
            //Get - Set all Artikellen
            Console.WriteLine("{0,-5}{1,-10}{2,-10}{3, -10}{4, -10}", "ID:", "Naam:", "Merk:", "Maat:", "Voorraad:");

            for (int i = 0; i < art.Count; i++)
            {
                if (art[i].categorie == choice)
                {
                    Console.WriteLine("{0,-5}{1,-10}{2,-10}{3, -10}{4, -10}",
                        art[i].id,
                        art[i].Naam,
                        art[i].Merk,
                        art[i].Maat,
                        art[i].Voorraad);
                }
            }
            //Gui input
            Console.WriteLine();
            Console.WriteLine("Input:");

            //Get key input - and call function
            string input = Console.ReadLine();
            if (input != Key_Menu && input != Key_Back)
                CollectDATA(choice);
            else
            if (input == Key_Menu)
                Menu();
            else
            if (input == Key_Back)
                GOBack("CollectDATA");
        }

        //Wijzigen-Volgorde
        public static void GetID()
        {
            //Set Gui
            Console.Clear();
            Console.WriteLine("Wijzigen:");
            Reminder();
            Console.WriteLine("Voer voer ID nr in:");

            //Get key input - and call function
            int choice;
            string input = Console.ReadLine();

            if (input == Key_Menu)
                Menu();
            else
            if (input == Key_Back)
                GOBack("GetID");
            else
            if (Int32.TryParse(input, out choice))
            {
                Console.Clear();
                FilterID(choice, "Wijzigen");
            }
            else
                GetID();
        }
        public static void FilterID(int ID, string curState)
        {
            //Set Gui
            Console.Clear();
            Console.WriteLine(curState + ": ");

            Console.WriteLine();
            Console.WriteLine("Reminder:");
            Console.WriteLine("Druk "+Key_Emptypage+" om pagina te legen!");
            Console.WriteLine("Druk " + Key_Menu + " om naar Menu te gaan!");
            Console.WriteLine("Druk " + Key_Back + " om terug te gaan!");
            SetIDinfo(ID);
        }
        public static void SetIDinfo(int ID)
        {
            //Set Gui
            Console.WriteLine();
            Console.WriteLine("Now:");
            Console.WriteLine("{0,-5}{1,-10}{2,-10}{3, -10}{4, -10}", "ID:", "Naam:", "Merk:", "Maat:", "Voorraad:");

            //Set - Get Artikellen
            for (int i = 0; i < art.Count; i++)
            {
                if (art[i].id == ID)
                {
                    Console.WriteLine("{0,-5}{1,-10}{2,-10}{3, -10}{4, -10}",
                        art[i].id,
                        art[i].Naam,
                        art[i].Merk,
                        art[i].Maat,
                        art[i].Voorraad);
                }
            }
            Wijzig(ID);
            Console.Read();
        }
        public static void Wijzig(int ID)
        { 
            Console.WriteLine();
            Console.Write("Input:");

            //Get key input - and call function
            string input = Console.ReadLine();
            if (input != "")
            {
                int choice;
                if (Int32.TryParse(input, out choice))
                {
                    //Get and show result
                    for (int i = 0; i < art.Count; i++)
                    {
                        if (art[i].id == ID)
                        {
                            //Calculate Output
                            int Output = art[i].Voorraad += Int32.Parse(input);

                            if (Output <= -1)
                            {
                                //if it is lower then 0
                                Console.WriteLine();
                                Console.WriteLine("De voorraad zal staan op " + Output + " maar dat is niet toegestaan!");
                                Wijzig(ID);
                            }
                            else
                            {
                                //Change has been accepted
                                Console.WriteLine(Output);
                                SetIDinfo(ID);
                            }
                        }
                    }
                }
                else
                if (input != Key_Back && input != Key_Menu && input != Key_Indetifier)
                {
                    Console.WriteLine("Er is geen keuze van deze categorie");
                    Wijzig(ID);
                }
                else
                if (input == Key_Back)
                    GOBack("Wijzigen");
                else
                if (input == Key_Menu)
                    Menu();
                else
                if (input == Key_Indetifier)
                    FilterID(ID, "Wijzigen");
            }
            else
                FilterID(ID, "Wijzigen");
        }

        //General
        public static void Reminder()
        {
            //Set riminders (Gui)
            Console.WriteLine();
            Console.WriteLine("Reminder:");
            Console.WriteLine("Druk "+Key_Menu+" om naar Menu te gaan!");
            Console.WriteLine("Druk "+Key_Back+" om terug te gaan!");
            Console.WriteLine();
        }
        public static void RawDATA()
        {
            Random rnd = new Random();
            //straat
            art.Add(new Artikelen("Straat1", "Merk", 1, Categorie.Straat, rnd.Next(40, 130), rnd.Next(40, 130), rnd.Next(40, 130), rnd.Next(40, 60)));
            art.Add(new Artikelen("Straat2", "Merk", 2, Categorie.Straat, rnd.Next(40, 130), rnd.Next(40, 130), rnd.Next(40, 130), rnd.Next(40, 60)));

            //zaal
            art.Add(new Artikelen("Zaal1", "Merk", 3, Categorie.Zaal, rnd.Next(40, 130), rnd.Next(40, 130), rnd.Next(40, 130), rnd.Next(40, 60)));
            art.Add(new Artikelen("Zaal2", "Merk", 4, Categorie.Zaal, rnd.Next(40, 130), rnd.Next(40, 130), rnd.Next(40, 130), rnd.Next(40, 60)));

            //Veld
            art.Add(new Artikelen("Veld1", "Merk", 5, Categorie.Veld, rnd.Next(40, 130), rnd.Next(40, 130), rnd.Next(40, 130), rnd.Next(40, 60)));
            art.Add(new Artikelen("Veld2", "Merk", 6, Categorie.Veld, rnd.Next(40, 130), rnd.Next(40, 130), rnd.Next(40, 130), rnd.Next(40, 60)));

            Console.WriteLine("Items added");
        }
        public static string GetPCUsername()
        {
            string Usernamee = Environment.UserName;
            return Usernamee;
        }
        public static void GOBack(string CurState)
        {
            //Bekijken path
            if (CurState == "FilterCategorie")
                Menu();
            if (CurState == "CollectDATA")
                FilterCategoriePanel(true, "Voorraad bekijken");

            //Bekijken path
            if (CurState == "GetID")
                Menu();
            if (CurState == "Wijzigen")
                GetID();
        }

        //Saving-Loading
        public static List<Artikelen> Load()
        {
            //First clearing The list incase something is in there
            art.Clear();

            //Create new list
            List<Artikelen> a = new List<Artikelen>();
            foreach (var line in File.ReadLines(SavePath))
            {
                //Split sentences when "," is in there
                List<String> indexes = line.Split(',').ToList<String>();

                //Add DATA to the new created list above here
                a.Add(new Artikelen((indexes[0]), (indexes[1]), Int32.Parse(indexes[2]),Cat((indexes[3])), Int32.Parse(indexes[4]), float.Parse(indexes[5]), float.Parse(indexes[6]),Int32.Parse(indexes[7])));
            }
            //Return the new List with all loaded data
            return a;
        }
        public static void Save(List<Artikelen> voorraad)
        {
            //First clear the entire file so there will be no Duplications
            File.WriteAllText(SavePath, String.Empty);
            using (TextWriter tw = new StreamWriter(SavePath))
            {
                //Write a line with DATA foreach item in the list
                foreach (Artikelen a in voorraad)
                    tw.WriteLine(a.Naam + "," + a.Merk + "," + a.id + "," + a.categorie + "," + a.Voorraad + "," + a.prijs_Ex_btw + "," + a.prijs_inc_btw + "," + a.Maat);
            }
        }

        //String--->Categorie.type
        public static Categorie Cat(string input)
        {
            if (input == "Zaal")
                return Categorie.Zaal;
            else if (input == "Straat")
                return Categorie.Straat;
            else if (input == "Veld")
                return Categorie.Veld;
            else
                return Categorie.error;
        }
    }
}
        //====================================<List - Enum>==================================
public enum Categorie
{
    Zaal,
    Straat,
    Veld,
    error
}
public class Artikelen
{
    public string Naam;
    public string Merk;
    public int id;
    public Categorie categorie;
    public int Voorraad;
    public float prijs_Ex_btw;
    public float prijs_inc_btw;
    public int Maat;

    public Artikelen(string naam1, string merk1, int id1, Categorie cat1, int voorraad1, float prijsinc1, float prijsex1, int maat1)
    {
        Naam = naam1;
        Merk = merk1;
        id = id1;
        categorie = cat1;
        Voorraad = voorraad1;
        prijs_inc_btw = prijsinc1;
        prijs_Ex_btw = prijsex1;
        Maat = maat1;
    }
}

//Voorraad bekijken | menu->FilterCat->CollectDATA
//Voorraad wijzigen | menu->GetID->FilterID->SetIDinfo->Wijzigen
//Log out           | menu->GetloginName
//Exit              | menu->Environment.exit(0);