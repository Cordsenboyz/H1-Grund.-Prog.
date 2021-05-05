using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Rap_Finands
{
    /**
    Dette BANK PROGRAM ER LAVET af Konrad Sommer! Copy(c) Right All rights reserveret 2020
    idé og udtænkt af Anne Dam for Voldum Bank I/S
    Rap Finands
    **/
    class Program
    {
        public static string regiNummer = "4242";
        public static string dataFil = "bank_debug.json"; //Her ligger alt data i
        public static List<Konto> konti;
        static void Main(string[] args)
        {
            Console.WriteLine("Henter alt kontodata");
            Hent();
            if (konti.Count == 0) 
            {
                var k = Lavkonto();
                k.ejer = "Ejvind Møller";
                konti.Add(k);

                gemTrans(k,"Opsparing",100);
                gemTrans(konti[0],"Vandt i klasselotteriet",1000);
                gemTrans(konti[0],"Hævet til Petuniaer",-50);
                
                Gem();
            } else 
            {

            }
            Start();
            
        }
        static void Start() 
        {
            Console.WriteLine("Velkommen til Rap Finans af Konrad Sommer");
            Console.WriteLine("Hvad vil du gøre nu?");
            Console.WriteLine("1. Opret ny konto");
            Console.WriteLine("2. Hæv/sæt ind");
            Console.WriteLine("3. Se en oversigt");
            Console.WriteLine("0. Afslut");

            Console.Write(">");
            try
            {
                int valg = int.Parse(Console.ReadLine());

                switch (valg)
                {
                    case 1:
                        Opretkonto();
                        break;
                    case 2:
                        Oprettransaktion(Findkonto());
                        break;
                    case 3:
                        Udskrivkonto(Findkonto());
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("UGYLDIGT VALGT!!");
                        Console.ReadKey();
                        break;
                }
            }
            catch (Exception X)
            {
                Console.WriteLine(X);
                Console.ReadKey();
            }
            Console.Clear();
        }
        static Konto Findkonto() 
        {
            for (var i = 1; i <= konti.Count;i++)
            {
                Console.WriteLine(i+". "+konti[i-1].registreringsNr+" "+konti[i-1].kontoNr+" ejes af "+konti[i-1].ejer);
            }
            Console.WriteLine("Vælg et tal fra 1 til "+konti.Count);
            Console.Write(">");
            int tal = int.Parse(Console.ReadLine());
            if (tal < 1 || tal > konti.Count) 
            {
                Console.WriteLine("Ugyldigt valg");
                Console.Clear();
                return null;
            }
            return konti[tal-1];
        }
        static void Oprettransaktion(Konto k) 
        {
            Console.Write("Tekst: ");
            string tekst = Console.ReadLine();
            Console.Write("Beløb: ");
            try
            {
                float amount = float.Parse(Console.ReadLine());
                if (gemTrans(k, tekst, amount))
                {
                    Console.WriteLine("Transkationen blev gemt. Ny saldo på kontoen: " + findSaldo(k));
                    Gem();
                }
                else
                    Console.WriteLine("Transaktionen kunne ikke gemmes (Der var sikkert ikke penge nok på kontoen)");
            }
            catch (Exception X)
            {
                Console.WriteLine(X);
                Console.ReadKey();
            }
            Console.ReadKey();
            Start();
        }
        static Konto Opretkonto() 
        {
            Konto k = Lavkonto();
            Console.Write("Navn på kontoejer:");
            k.ejer = Console.ReadLine();
            Console.WriteLine("Konto oprettet!");
            konti.Add(k);
            Gem();
            return k;
        }
        public static Konto Lavkonto() 
        {
            return new Konto();
        }

        /*
        fed metode til at lave helt nye kontonumre ~Konrad
        */
        public static string lavEtKontoNummer() 
        {
            Random tilfael = new Random();
            string nr = tilfael.Next(1,9).ToString();
            for (var i = 1; i <= 9; i++) {
                nr = nr + tilfael.Next(0,9).ToString();
                if (i == 3) nr = nr + " ";
                if (i == 6) nr = nr + " ";
            }
            return nr;
        }
        static void Udskrivkonti() 
        {
            Console.WriteLine("================");
            foreach (Konto k in konti) 
            {
                Console.WriteLine(k.registreringsNr+" "+k.kontoNr+" ejes af "+k.ejer);
            }
        }
        static void Udskrivkonto(Konto k) 
        {
            Console.WriteLine("Konto for "+k.ejer+": "+k.registreringsNr+" "+k.kontoNr);
            Console.WriteLine("================");
            Console.WriteLine("Tekst\t\t\t\tBeløb\t\tSaldo");
            foreach (Transaktion t in k.transaktioner) 
            {
                Console.Write(t.tekst+"\t\t\t\t");
                Console.Write(t.amount+"\t\t");
                Console.WriteLine(t.saldo);
            }
            Console.WriteLine("================\n");
            Console.ReadKey();
        }
        
        public static bool gemTrans(Konto konto, string tekst, float beløb) 
        {
            var saldo = findSaldo(konto);
            if (beløb + saldo < 0) return false;
            var t = new Transaktion();
            t.tekst = tekst;
            t.amount = beløb;
            t.saldo = t.amount + saldo;
            t.dato = DateTime.Now;


            konto.transaktioner.Add(t);
            return true;
        }
        public static float findSaldo(Konto k) 
        {
            Transaktion seneste = new Transaktion();
            DateTime senesteDato = DateTime.MinValue;
            foreach(var t in k.transaktioner) 
            {
                if (t.dato > senesteDato) 
                {
                    senesteDato = t.dato;
                    seneste = t;
                }
            }
            return seneste.saldo;
        }
        public static void Gem() 
        {
            File.AppendAllText(dataFil,JsonConvert.SerializeObject(konti));
        }
        public static void Hent()
        {
            dataFil = "debug_bank.json"; //Debug - brug en anden datafil til debug ~Konrad
            if (File.Exists(dataFil)) 
            {
                string json = File.ReadAllText(dataFil);
                konti = JsonConvert.DeserializeObject<List<Konto>>(json);
            } else 
            {
                konti = new List<Konto>();
            }
        }
    }
}
/** 
Koden er lavet til undervisningbrug på TECHCOLLEGE
Voldum Bank og nævnte personer er fiktive.
~Simon Hoxer Bønding
**/
