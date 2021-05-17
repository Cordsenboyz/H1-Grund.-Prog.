using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Grundlæggende_Programmering_Aflevering
{
    class Firma : SQLconnection
    {
        protected string adresse;
        protected string navn;


        private List<Vare> varer;       

        public Firma()
        {
            varer = new List<Vare>();
        }
        public List<Vare> Varer
        {
            get
            {
                return varer;
            }
        }
        //Adds an ITEM to the database using the Insert method in SQLconnection
        //Tries to replace , with . in the price because if there is a , in the database it cannot display the , in the Console
        //Also we can't write . to begin with because the convert to double removes the . from the variable
        public void AddVare(Vare P)
        {
            varer.Add(P);
            string pris = P.Pris.ToString().Replace(",", ".");
            string query = $"INSERT INTO Vare (navn, pris, stock) VALUES ('{P.Navn}','{pris}','{P.Antal}')";
            Insert(query);
        }
        public string Navn
        {
            get
            {
                return navn;
            }
            set
            {
                if (value != ""  || value !=null)
                     navn = value;

                else
                    throw new Exception("Fejl");

            }
        }
        public string Adresse
        {
            get
            {
                return adresse;
            }
            set
            {

                if (value != "" || value != null)
                   adresse = value;

                else
                    throw new Exception("Fejl");
            }
        }
    }

    class Lager 
    {
        string adresse;
        string navn;

        public string Navn
        {
            get
            {
                return navn;
            }
            set
            {
                if (value != "" || value != null)
                    navn = value;

                else
                    throw new Exception("Fejl");

            }
        }
        public string Adresse
        {
            get
            {
                return adresse;
            }
            set
            {
       
                if (value != "" || value != null)
                    adresse = value;
                
                else
                    throw new Exception("Fejl");
            }
        }
    }
    class Vare : SQLconnection
    {
        protected int id;
        protected string navn;
        protected double pris;
        protected int antal;
        protected List<Placering> placering;

        public Vare(string navn, double pris, int antal)
        {
            this.navn = navn;
            this.pris = pris;
            this.antal = antal;
        }
        private Vare(int id, string navn, double pris, int antal)
        {
            this.id = id;
            this.navn = navn;
            this.pris = pris;
            this.antal = antal;
        }
        public Vare Get(int id)
        {

            DataTable dataTable = new DataTable();
            string placeringQuery = $"SELECT * FROM Placering WHERE id = {id}";
            dataTable = Select(placeringQuery);
            foreach (DataRow row in dataTable.Rows)
            {
                return new Vare(Convert.ToInt32(row.ItemArray[0]), row.ItemArray[1].ToString(), Convert.ToDouble(row.ItemArray[2]), Convert.ToInt32(row.ItemArray[3]));
            }
            return null;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Navn
        {
            get
            {
                return navn;
            }
            set
            {
                if (value != "" || value != null)
                    navn = value;

                else
                    throw new Exception("Fejl");

            }
        }
        public double Pris
        {
            get
            {
                return pris;
            }
            set
            {
                pris = value;
            }
        }
        public int Antal
        {
            get
            {
                return antal;
            }
            set
            {
                antal = value;
            }
        }
        public List<Placering> Placering
        {
            get
            {
                return placering;
            }
            set
            {
                placering = value;
            }
        }
    }
    class Placering : SQLconnection
    {
        protected int id;
        protected string hylde;
        protected string plads;
        protected Vare vare;

        public Placering(string hylde, string plads, Vare vare)
        {
            this.hylde = hylde;
            this.plads = plads;
            this.vare = vare;
        }
        private Placering(int id,string hylde, string plads, Vare vare)
        {
            this.id = id;
            this.hylde = hylde;
            this.plads = plads;
            this.vare = vare;
        }

        public Placering Get(int id)
        {
            DataTable dataTable = new DataTable();
            string placeringQuery = $"SELECT * FROM Placering WHERE id = {id}";
            dataTable = Select(placeringQuery);
            foreach (DataRow row in dataTable.Rows)
            {
                return new Placering(Convert.ToInt32(row.ItemArray[0]), row.ItemArray[1].ToString(), row.ItemArray[2].ToString(), Vare.Get(Convert.ToInt32(row.ItemArray[3])));
            }
            return null;
        }

        public Vare Vare
        {
            get
            {
                return vare;
            }
            set
            {
                vare = value;
            }
        }
        public string Hylde
        {
            get
            {
                return hylde;
            }
            set
            {
                if (value != "" || value != null)
                    hylde = value;

                else
                    throw new Exception("Fejl");

            }
        }
        public string Plads
        {
            get
            {
                return plads;
            }
            set
            {
                if (value != "" || value != null)
                    plads = value;

                else
                    throw new Exception("Fejl");

            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }


}
