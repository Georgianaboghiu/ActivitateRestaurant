using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boghiu_Georgiana
{
    public partial class Meniuri
    {
      
        private String CategorieProduse; //mancare, desert, bautura
        private String[] DenumireProduse;
        private float[] pretProdus;
        private float[] cantitate;
        private bool vegetarian;

        public Meniuri(string c, string[] produse, float[] pret, bool tip, float[]cant)
        {
            this.CategorieProduse = c;
            this.vegetarian = tip;
            this.DenumireProduse = new string[produse.Length];
            this.pretProdus = new float[pret.Length];
            this.cantitate = new float[cant.Length];
            for (int i = 0; i < produse.Length; i++)
            {
                this.DenumireProduse[i] = produse[i];
               
            }
            for (int i = 0; i < produse.Length; i++)
                this.pretProdus[i] = pret[i];
            for (int i = 0; i < produse.Length; i++)
                this.cantitate[i] = cant[i];

        }

        public string Categorie
        {
            get { return this.CategorieProduse; }
            set { this.CategorieProduse = value; }
        }

        public bool Vegetarian
        {
            get { return this.vegetarian; }

        }

        public string[] Produse
        {
            get { return this.DenumireProduse; }
            set { this.DenumireProduse = value; }
        }

        public float[] Preturi
        {
            get { return this.pretProdus; }
            set { this.pretProdus = value; }
        }
        public float[] Cantitati
        {
            get { return this.cantitate; }
            set { this.cantitate = value; }
        }

        public override string ToString()
        {
            string result = null;
            result += "Meniul de " + this.Categorie + " are urmatorul continut: ";
            
            for (int i = 0; i < DenumireProduse.Length; i++)

                result += "produsul: " + this.DenumireProduse[i]+ " cu pretul de: " + this.pretProdus[i] + "lei are cantitatea de " +this.cantitate[i] ;
           return result;
        }



   

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < this.DenumireProduse.Length)
                {
                    return this.DenumireProduse[index];
                }
                else
                {
                    return null;
                }
            }
        }

    }



}

