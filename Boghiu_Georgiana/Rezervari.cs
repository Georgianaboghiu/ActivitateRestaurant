using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boghiu_Georgiana
{
    public  class Rezervari
    {
       private string NumePersoana;
       private string PrenumePersoana;
       //private int nrLocuri;
       private int NrRezervare;
       private Mese masaRezervata;
       private DateTime dataRezervare;

        public Rezervari(string nume, string prenume,DateTime d, int nr, Mese masaRez)
        {
            this.NumePersoana = nume;
            this.PrenumePersoana = prenume;
            this.dataRezervare = d;
            this.NrRezervare = nr;
            this.masaRezervata = masaRez;
            this.dataRezervare = d;
            //this.nrLocuri = nrlocuri;
           
        }
        public string nume
        {
            get { return this.NumePersoana; }
            set { this.NumePersoana = value; }
        }

        public string prenume
        {
            get { return this.PrenumePersoana; }
            set { this.PrenumePersoana = value; }
        }

        public int nrRezervare
        {
            get { return this.NrRezervare; }
            set { this.NrRezervare = value; }
        }

        //public int NrLocuri
        //{
        //    get { return this.nrLocuri; }
        //    set { this.nrLocuri = value; }
        //}
        public DateTime DataRezervare
        {
            get { return this.dataRezervare; }
            set { this.dataRezervare = value; }
        }

        public Mese masa
        {
            get { return this.masaRezervata; }
            set { this.masaRezervata = value; }
        }


        public override string ToString()
        {
            string result = null;
            return result += "Rezervarea cu numarul " + this.nrRezervare +", Pe numele de "+this.NumePersoana+" "+this.PrenumePersoana+ " a fost facuta in data de "
                + this.dataRezervare +", este de "+ " si are " + this.masaRezervata;
        }
    }
}
