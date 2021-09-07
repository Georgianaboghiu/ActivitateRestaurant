using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boghiu_Georgiana
{
   public partial class Ospatari:ICloneable, IComparable, IMedia1
    {
        private int id;
        private string nume;
        private string prenume;

        private DateTime data_angajare;
        private float salariu;
        private int nr;
        private int[] ore_suplimentare;

        public Ospatari(string n, string p, DateTime data, float sal, int nr, int[] ore, int id)
        {
            this.nume = n;
            this.prenume = p;


            this.data_angajare = data;
            this.salariu = sal;
            this.nr = nr;
            this.ore_suplimentare = new int[nr];
            this.id = id;

            for (int i = 0; i < nr; i++)
            {
                this.ore_suplimentare[i] = ore[i];
            }

        }

        public string Nume
        {
            get { return this.nume; }
            set { this.nume = value; }
        }

        public string Prenume
        {
            get { return this.prenume; }
            set { this.prenume = value; }
        }




        public float Salariu
        {
            get { return this.salariu; }
            set { this.salariu = value; }
        }

        public int Numar_zile

        {
            get { return this.nr; }
            set { this.nr = value; }
        }

        public int Id

        {
            get { return this.id; }
            set { this.id= value; }
        }

        public DateTime Data_angajare

        {
            get { return this.data_angajare; }
            set { this.data_angajare = value; }
        }


        public int[] OreSuplimentare
        {
            get { return this.ore_suplimentare; }
            set { this.ore_suplimentare = value; }
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }


        public object Clone()
        {
            Ospatari o = (Ospatari)this.MemberwiseClone();

            int[] Copie = (int[])this.ore_suplimentare.Clone();

            o.ore_suplimentare = Copie;

            return o;
        }

        public int CompareTo(object obj)
        {
            Ospatari o = (Ospatari)obj;

            if (this.salariu < o.salariu)
            {
                return -1;
            }
            else if (this.salariu > o.salariu)
            {
                return 1;
            }
            else
            {
                return string.Compare(this.nume, o.nume);
            }
        }


        public float CalculeazaMedie()
        {
            return (float)this;
        }

        public static explicit operator float(Ospatari o)
        {
           if (o.ore_suplimentare != null)
                {
                    int suma = 0;
                    for (int i = 0; i < o.ore_suplimentare.Length; i++)
                        suma += o.ore_suplimentare[i];
                    return (float)suma / o.ore_suplimentare.Length;
                }
                else
                    return 0;
            
        }

        public float Medie
        {
            get { return this.CalculeazaMedie(); }
        }



        public override string ToString()
        {
            string result = null;

            result += " Ospatarul " + this.nume + " " + this.prenume + " ,a fost angajat pe data de " + this.data_angajare + ", are salariul " + this.salariu
                + " si a lucrat urmatoarele ore suplimentare:";

            for (int i = 0; i < nr; i++)
                result += this.ore_suplimentare[i] + " ";



            return result;
        }


        public static Ospatari operator +(Ospatari o, int n)
        {
            int[] ore_noi = new int[o.nr + 1];

            for (int i = 0; i < o.nr; i++)
            {
                ore_noi[i] = o.ore_suplimentare[i];
            }

            ore_noi[ore_noi.Length - 1] = n;

            o.ore_suplimentare = ore_noi;

            return o;
        }

    }
}
