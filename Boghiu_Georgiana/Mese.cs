using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boghiu_Georgiana
{
    public partial class Mese
    {
       private int nrMasa;
       private int nrScaune;
      


        public Mese(int nrScaune, int nr)
        {
            this.nrScaune = nrScaune;

            this.nrMasa = nr;
           

        }
        public int NrScaune
        {
            get { return this.nrScaune; }
            set { this.nrScaune = value; }
        }
       

        public int NrMasa
        {
            get { return this.nrMasa; }
            set { this.nrMasa = value; }
        }

        public override string ToString()
        {
            string rezultat = null;

            rezultat += "masa cu numarul " + this.nrMasa + " are "+this.nrScaune+" scaune ";
           

            return rezultat;
        }

        public static Mese operator ++(Mese m)
        {
            m++;

            return m;
        }

    }
}
