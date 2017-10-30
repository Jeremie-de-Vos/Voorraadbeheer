using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorraadbeheer_Grafische
{
    public partial class DATA
    {
        ///====================================<Variable>======================================================================================
        //Save - path - GetUserName
        public static string pcUserName = GetPCUsername() + "/";
        public static string SavePath_Art = @"C:\Users\" + pcUserName + "desktop\\Voorraad.txt";
        public static string SavePath_Medewerkers = @"C:\Users\" + pcUserName + "desktop\\Medewerkers.txt";
        public static string GetPCUsername()
        {
            string Usernamee = Environment.UserName;
            return Usernamee;
        }

        //Login Data
        public static int LoginID;
        public static int IDcounter = 20;
        public static int SelectedID;

        //List - Medewerkers/Artikellen
        public static List<Medewerker> Medewerkers = new List<Medewerker>();
        public static List<Artikel> Artikellen = new List<Artikel>();
        
        //Convert String to (Categorie/Function enum)
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
        public static Functie Func(string input)
        {
            if (input == "Magazijn")
                return Functie.Magazijn;
            else if (input == "Winkel")
                return Functie.Winkel;
            else if (input == "Admin")
                return Functie.Admin;
            else
                return Functie.error;
        }

        ///====================================<Hardcoded-data>================================================================================
        public static void Art_Rawdata()
        {
            Artikellen.Add(new Artikel(1, "Naam1", "Merk", Categorie.Straat, 40, 21, 10, 41, 41, "Maat", 500, "Laatst Gewijzigd", "Gewijzigd door"));
            Artikellen.Add(new Artikel(2, "Naam2", "Merk", Categorie.Straat, 40, 21, 10, 41, 41, "Maat", 500, "Laatst Gewijzigd", "Gewijzigd door"));
            Artikellen.Add(new Artikel(3, "Naam3", "Merk", Categorie.Straat, 40, 21, 10, 41, 41, "Maat", 500, "Laatst Gewijzigd", "Gewijzigd door"));
            Artikellen.Add(new Artikel(4, "Naam4", "Merk", Categorie.Straat, 40, 21, 10, 41, 41, "Maat", 500, "Laatst Gewijzigd", "Gewijzigd door"));
            Artikellen.Add(new Artikel(5, "Naam5", "Merk", Categorie.Straat, 40, 21, 10, 41, 41, "Maat", 500, "Laatst Gewijzigd", "Gewijzigd door"));
            Artikellen.Add(new Artikel(6, "Naam6", "Merk", Categorie.Straat, 40, 21, 10, 41, 41, "Maat", 500, "Laatst Gewijzigd", "Gewijzigd door"));
            Artikellen.Add(new Artikel(7, "Naam7", "Merk", Categorie.Straat, 40, 21, 10, 41, 41, "Maat", 500, "Laatst Gewijzigd", "Gewijzigd door"));
        }
        public static void Mede_Rawdata()
        {
            Medewerkers.Add(new Medewerker(1, "Jeremie", "Achternaam", ".@gmail.com", "Gelacht", Functie.Admin, "Admin", "1", "img path", 0681701360, "AanmaakDatum", "LaatstIngelogd", "LaatsteVersie"));

            Medewerkers.Add(new Medewerker(2, "Naam2", "Achternaam", ".@gmail.com", "Gelacht", Functie.Admin, "Admin", "w", "img path", 0681701360, "AanmaakDatum", "LaatstIngelogd", "LaatsteVersie"));
            Medewerkers.Add(new Medewerker(3, "Naam3", "Achternaam", ".@gmail.com", "Gelacht", Functie.Magazijn, "Magazijn", "w", "img path", 0681701360, "AanmaakDatum", "LaatstIngelogd", "LaatsteVersie"));
            Medewerkers.Add(new Medewerker(4, "Naam4", "Achternaam", ".@gmail.com", "Gelacht", Functie.Winkel, "Winkel", "w", "img path", 0681701360, "AanmaakDatum", "LaatstIngelogd", "LaatsteVersie"));

            Medewerkers.Add(new Medewerker(5, "Naam5", "Achternaam", ".@gmail.com", "Gelacht", Functie.Magazijn, "LoginNaam", "Wachtwoord", "img path", 0681701360, "AanmaakDatum", "LaatstIngelogd", "LaatsteVersie"));
            Medewerkers.Add(new Medewerker(6, "Naam6", "Achternaam", ".@gmail.com", "Gelacht", Functie.Magazijn, "LoginNaam", "Wachtwoord", "img path", 0681701360, "AanmaakDatum", "LaatstIngelogd", "LaatsteVersie"));
        }

        ///====================================<Save-Load>=====================================================================================
        //Save - load everything
        public static void Save_all()
        {
            Save_Artikellen(Artikellen);
            Save_Medewerkers(Medewerkers);
        }
        public static void Load_all()
        {
            Load_Artikellen();
            Load_Medewerkers();
        }

        //Save - Load (Artikellen)
        public static List<Artikel> Load_Artikellen()
        {
            //First clearing The list incase something is in there
            Artikellen.Clear();

            //Create new list
            List<Artikel> a = new List<Artikel>();
            foreach (var line in File.ReadLines(SavePath_Art))
            {
                //Split sentences when "," is in there
                List<String> indexes = line.Split(',').ToList<String>();

                //Add DATA to the new created list above here
                a.Add(new Artikel(
                    Int32.Parse(indexes[0]),        //Id
                    (indexes[1]),                   //Naam
                    (indexes[2]),                   //Merk
                    Cat((indexes[3])),              //Categorie

                    Int32.Parse(indexes[4]),        //inkoop
                    Int32.Parse(indexes[5]),        //btw
                    Int32.Parse(indexes[6]),        //winst
                    Int32.Parse(indexes[7]),        //inc btws
                    Int32.Parse(indexes[8]),        //ex btw

                    (indexes[9]),                   //maat
                    Int32.Parse(indexes[10]),       //voorraad

                    (indexes[11]),                  //Laatst gewijzigd
                    (indexes[12])                   //Gewijzigd door
                    ));
            }
            //Return the new List with all loaded data
            return a;
        }
        public static void Save_Artikellen(List<Artikel> voorraad)
        {
            //First clear the entire file so there will be no Duplications
            File.WriteAllText(SavePath_Art, String.Empty);
            using (TextWriter tw = new StreamWriter(SavePath_Art))
            {
                //Write a line with DATA foreach item in the list
                foreach (Artikel a in voorraad)
                    tw.WriteLine(
                        a.ID +","+ 
                        a.Naam + "," + 
                        a.Merk + "," +
                        a.Categorie + "," +
                        a.Inkoopprijs + "," +
                        a.BTW + "," +
                        a.Winst + "," +
                        a.Inc_btw + "," +
                        a.Ex_btw + "," +
                        a.Maat + "," +
                        a.Voorraad + "," +
                        a.LaatstGewijzigd + "," +
                        a.GewijzigdDoor
                        );
            }
        }
        
        //Save - Load (Medewerkers)
        public static List<Medewerker> Load_Medewerkers()
        {
            //First clearing The list incase something is in there
            Artikellen.Clear();

            //Create new list
            List<Medewerker> a = new List<Medewerker>();
            foreach (var line in File.ReadLines(SavePath_Medewerkers))
            {
                //Split sentences when "," is in there
                List<String> indexes = line.Split(',').ToList<String>();

                //Add DATA to the new created list above here
                a.Add(new Medewerker(
                    Int32.Parse(indexes[0]),        //Id
                    (indexes[1]),                   //Naam
                    (indexes[2]),                   //Achternaam
                    (indexes[3]),                   //email
                    (indexes[4]),                   //Geslacht
                    Func((indexes[5])),             //Functie

                    (indexes[6]),                   //LoginNaam
                    (indexes[7]),                   //Wachtwoord

                    (indexes[8]),                   //Pf_Path
                    Int32.Parse(indexes[9]),        //Telnr

                    (indexes[10]),                  //AanmaaktDatum
                    (indexes[11]),                  //LaatstIngelogd
                    (indexes[12])                   //LaatstVersie
                    ));
            }
            //Return the new List with all loaded data
            return a;
        }
        public static void Save_Medewerkers(List<Medewerker> voorraad)
        {
            //First clear the entire file so there will be no Duplications
            File.WriteAllText(SavePath_Medewerkers, String.Empty);
            using (TextWriter tw = new StreamWriter(SavePath_Medewerkers))
            {
                //Write a line with DATA foreach item in the list
                foreach (Medewerker a in voorraad)
                    tw.WriteLine(
                        a.ID + "," +
                        a.Naam + "," +
                        a.Achternaam + "," +
                        a.Email + "," +
                        a.Geslacht + "," +
                        a.Functie + "," +
                        a.LoginNaam + "," +
                        a.Wachtwoord + "," +
                        a.Pf_Path + "," +
                        a.Telnr + "," +
                        a.AanmaaktDatum + "," +
                        a.LaatstIngelogd + "," +
                        a.LaatstVersie
                        );
            }
        }
    }
}
///====================================<Lists>===========================================================================================
//Medewerkers
public enum Functie
{
    Winkel,
    Magazijn,
    Admin,
    error
}
public class Medewerker
{
    public int ID;
    public string Naam;
    public string Achternaam;
    public string Email;
    public string Geslacht;
    public Functie Functie;

    public string LoginNaam;
    public string Wachtwoord;

    public string Pf_Path;
    public int Telnr;

    public string AanmaaktDatum;
    public string LaatstIngelogd;
    public string LaatstVersie;

    public Medewerker(int id,string naam,string achternaam,string email,string geslacht,Functie functie,string loginNaam,string wachtwoord,string pf_Path,int telnr,string aanmaaktDatum,string laatstIngelogd,string laatstVersie)
    {
        ID = id;
        Naam = naam;
        Achternaam = achternaam;
        Email = email;
        Geslacht = geslacht;
        Functie = functie;

        LoginNaam = loginNaam;
        Wachtwoord = wachtwoord;

        Pf_Path = pf_Path;
        Telnr = telnr;

        AanmaaktDatum = aanmaaktDatum;
        LaatstIngelogd = laatstIngelogd;
        LaatstVersie = laatstVersie;
    }
}

//Artikellen
public enum Categorie
{
    Zaal,
    Straat,
    Veld,
    error
}
public class Artikel
{
    public int ID;
    public string Naam;
    public string Merk;
    public Categorie Categorie;

    //prijzen
    public int Inkoopprijs;
    public int BTW;
    public int Winst;
    public int Inc_btw;
    public int Ex_btw;

    public string Maat;
    public int Voorraad;

    public string LaatstGewijzigd;
    public string GewijzigdDoor;

    public Artikel(int iD,string naam,string merk,Categorie categorie,int inkoopprijs,int btw,int winst,int inc_btw,int ex_btw,string maat,int voorraad, string laatstGewijzigd, string gewijzigdDoor)
    {
        ID = iD;
        Naam = naam;
        Merk = merk;
        Categorie = categorie;
        Inkoopprijs = inkoopprijs;
        BTW = btw;
        Winst = winst;
        Inc_btw = inc_btw;
        Ex_btw = ex_btw;
        Maat = maat;
        Voorraad = voorraad;

        LaatstGewijzigd = laatstGewijzigd;
        GewijzigdDoor = gewijzigdDoor;
    }

}
