using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boghiu_Georgiana
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void rezervareToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Rezervare obj1 = new Rezervare();
            obj1.ShowDialog();
        }

        private void meniuriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Meniu obj2 = new Meniu();
            obj2.ShowDialog();
        }

        private void notaDePlataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotaDePlata obj3 = new NotaDePlata();
            obj3.ShowDialog();
        }

        private void dateAngajatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ospatar obj4 = new Ospatar();
            obj4.ShowDialog();
        }
    }
}
