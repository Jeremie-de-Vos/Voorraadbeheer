using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voorraadbeheer_Grafische;

namespace voorraadbeheer
{
    class Program
    {
        ///====================================<Variable>=====================================
        //List - Artikellen
        //public static List<Artikelen> art = new List<Artikelen>();

        //Login - Wachtwoord
        public static string ww;
        public static string UserName;

        public static int Maxlogintry = 3;
        public static int Currlogintry = 1;

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
            if (File.Exists(DATA.SavePath_Art))
                DATA.Artikellen = DATA.Load_Artikellen();
            //DATA.Artikellen = DATA.Load_Artikellen();
            else
                DATA.Art_Rawdata();
            //Medewerkers
            if (File.Exists(DATA.SavePath_Medewerkers))
                DATA.Medewerkers = DATA.Load_Medewerkers();
            else
                DATA.Mede_Rawdata();

            GetLogName();
        }

        //Login-Wachtwoord
        public static void GetLogName()
        {
            Console.Clear();

            Console.WriteLine("Welkom! login om verder te gaan.");
            Console.WriteLine("Typ nu uw Login naam in:");
            UserName = Console.ReadLine();
            for (int i = 0; i < DATA.Medewerkers.Count; i++)
            {
                if (UserName == DATA.Medewerkers[i].LoginNaam)
                {
                    GetWW();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Deze login naam bestaat niet");
                    Console.WriteLine("Druk een knop om verder te gaan!");
                    Console.ReadKey();
                    GetLogName();
                }
            }
        }
        public static void GetWW()
        {
            Console.Clear();
            Console.WriteLine("Welkom " + UserName);
            Console.WriteLine("Typ nu uw Wachtwoord in a.u.b.:");
            ww = Console.ReadLine();
            CheckLogin();
        }
        public static void CheckLogin()
        {
            bool tst = true;
            for (int i = 0; i < DATA.Medewerkers.Count; i++)
            {
                //Check login naam + wachtwoord
                if (UserName == DATA.Medewerkers[i].LoginNaam && ww == DATA.Medewerkers[i].Wachtwoord)
                {
                    Menu();
                }
                else
                    tst = false;
            }
            if (Currlogintry >= Maxlogintry + 1 && !tst)
            {
                Console.WriteLine("Wachtwoord fout.\nEr is te vaak geprobeerd in te loggen");
                Environment.Exit(0);
            }
            else
            {
                Currlogintry++;
                Console.WriteLine("Geen juiste combinatie! U kunt nog (" + (Maxlogintry - Currlogintry + 1) + ") keer proberen");
                Console.WriteLine("Druk een knop om verder te gaan!");
                Console.ReadKey();
                GetLogName();
            }
        }

        //Menu
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
                        FilterCategoriePanel(true, "Voorraad Bekijken");//
                        break;
                    case 2:
                        GetID();
                        break;
                    case 3:
                        DATA.Save_Artikellen(DATA.Artikellen);
                        GetLogName();
                        break;
                    case 4:
                        DATA.Save_Artikellen(DATA.Artikellen);
                        Environment.Exit(0);
                        break;
                }
            }
            else
                Menu();
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
                            CollectDATA(Art_Categorie.Zaal);
                        break;
                    case 2:
                        CollectDATA(Art_Categorie.Straat);
                        break;
                    case 3:
                        CollectDATA(Art_Categorie.Veld); ;
                        break;
                }
            }
            else
                FilterCategoriePanel(Bekijken, FuncName);
        }
        public static void CollectDATA(Art_Categorie choice)
        {
            //Set Gui
            Console.Clear();
            Console.WriteLine(choice + ": ");
            Reminder();
            //Get - Set all Artikellen
            Console.WriteLine("{0,-5}{1,-10}{2,-10}{3, -10}{4, -10}", "ID:", "Naam:", "Merk:", "Maat:", "Voorraad:");

            for (int i = 0; i < DATA.Artikellen.Count; i++)
            {
                if (DATA.Artikellen[i].Categorie == choice)
                {
                    Console.WriteLine("{0,-5}{1,-10}{2,-10}{3, -10}{4, -10}",
                        DATA.Artikellen[i].ID,
                        DATA.Artikellen[i].Naam,
                        DATA.Artikellen[i].Merk,
                        DATA.Artikellen[i].Maat,
                        DATA.Artikellen[i].Voorraad);
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
            for (int i = 0; i < DATA.Artikellen.Count; i++)
            {
                if (DATA.Artikellen[i].ID == ID)
                {
                    Console.WriteLine("{0,-5}{1,-10}{2,-10}{3, -10}{4, -10}",
                        DATA.Artikellen[i].ID,
                        DATA.Artikellen[i].Naam,
                        DATA.Artikellen[i].Merk,
                        DATA.Artikellen[i].Maat,
                        DATA.Artikellen[i].Voorraad);
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
                    for (int i = 0; i < DATA.Artikellen.Count; i++)
                    {
                        if (DATA.Artikellen[i].ID == ID)
                        {
                            //Calculate Output
                            int Output = DATA.Artikellen[i].Voorraad += Int32.Parse(input);

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
    }
}

//Voorraad bekijken | menu->FilterCat->CollectDATA
//Voorraad wijzigen | menu->GetID->FilterID->SetIDinfo->Wijzigen
//Log out           | menu->GetloginName
//Exit              | menu->Environment.exit(0);