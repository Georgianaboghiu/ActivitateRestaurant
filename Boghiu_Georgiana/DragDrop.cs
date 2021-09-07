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
    public partial class DragDrop : Form
    {
        public int y = 10;
        List<Meniuri> listaMeniu = new List<Meniuri>();

        public DragDrop(List<Meniuri>lista)
        {
            InitializeComponent();
            //string[] produse = { "Supa","Friptura","Salata"};
            //float[] pret = { 15, 25, 12 };
            //float[] cantitati = { 200, 300, 150 };
            //Meniuri m = new Meniuri("Mancare", produse, pret, false, cantitati);

            //string[] produse1 = { "Tort", "Tiramisu", "Placinta" };
            //float[] pret1 = { 15, 12, 12 };
            //float[] cantitati1 = { 200, 300, 150 };
            //Meniuri m1 = new Meniuri("Desert", produse1, pret1, false, cantitati1);

            //string[] produse2 = { "Cola", "Apa", "Cafea" };
            //float[] pret2 = { 10, 5, 12 };
            //float[] cantitati2 = { 250, 200, 350 };
            //Meniuri m2 = new Meniuri("Bauturi", produse2, pret2, false, cantitati2);


            //listaMeniu.Add(m);
            //listaMeniu.Add(m1);
            //listaMeniu.Add(m2);
            listaMeniu = lista;
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.DoDragDrop(textBox1.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Meniuri m in listaMeniu)
            {

                listBox1.Items.Add(m);

            }
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string text = e.Data.GetData(typeof(string)).ToString();

            listBox1.Items.Add(text);
            string[] produse = { text };
            float[] pret = { 10 };
            float[] cantitate = { 100 };
            Meniuri m = new Meniuri(text, produse, pret, true, cantitate);

            listaMeniu.Add(m);


            if (e.Effect == DragDropEffects.Move)
            {
                textBox1.Clear();
            }
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            if (((e.KeyState & 8) == 8) && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                e.Effect = DragDropEffects.Copy;
            else if (((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))
                e.Effect = DragDropEffects.Move;
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.DoDragDrop(listBox1.SelectedItem, DragDropEffects.Copy | DragDropEffects.Move);
        }


    }
}
