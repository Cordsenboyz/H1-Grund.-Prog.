using System;
using System.Collections.Generic;
namespace Rap_Finands 
{
    class Konto 
    {
        public string registreringsNr;
        public string kontoNr;
        public string ejer;
        public List<Transaktion> transaktioner;
        public Konto() 
        {
            transaktioner = new List<Transaktion>();
            registreringsNr = Program.regiNummer; //Sæt registreringsnummer på kontoen!
            kontoNr = Program.lavEtKontoNummer(); //Lav et nyt (tilfældigt shh!) kontonummer
        }  
    }
}
/** 
Koden er lavet til undervisningbrug på TECHCOLLEGE
Voldum Bank og nævnte personer er fiktive.
~Simon Hoxer Bønding
**/