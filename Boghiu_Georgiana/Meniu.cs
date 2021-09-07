using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Data.OleDb;

namespace Boghiu_Georgiana
{
    public partial class Meniu : Form
    {
        List<Meniuri> listaMeniu = new List<Meniuri>();
        Meniuri m;
        string connString;
        public Meniu()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cbVeg.Text=="")
                errorProvider1.SetError(cbVeg, "Introduceti tipul!");
            else
            if (tbProduse.Text == "")
                errorProvider1.SetError(tbProduse, "Introduceti preturile!");
            else
                if (tbPreturi.Text == "")
                errorProvider1.SetError(tbPreturi, "Introduceti preturile!");
            try
            {
                string categorie = comboBoxCateg.Text;

                

                string[] Produsex = tbProduse.Text.Split(';');
                string[] produse = new string[Produsex.Length];

                for (int i = 0; i < Produsex.Length; i++)
                    produse[i] = Produsex[i];


                string[] Preturix = tbPreturi.Text.Split(';');
                float[] preturi = new float[Preturix.Length];

                for (int i = 0; i < Preturix.Length; i++)
                    preturi[i] = Convert.ToInt32(Preturix[i]);

                string[] Cantx = tbCant.Text.Split(';');
                float[] cantitati = new float[Cantx.Length];

                for (int i = 0; i < Cantx.Length; i++)
                    cantitati[i] = Convert.ToInt32(Cantx[i]);

                bool vegetarian = Convert.ToBoolean(cbVeg.Text);
               // bool veg = radioButton1.Checked;
                //Meniuri
                    m = new Meniuri(categorie, produse, preturi, vegetarian, cantitati);
                listaMeniu.Add(m);
                MessageBox.Show(m.ToString());



                listView1.Items.Clear();
                for (int i = 0; i < m.Produse.Length; i++)
                {
                    ListViewItem item = new ListViewItem(produse[i]);
                    item.SubItems.Add(Convert.ToString(preturi[i]));
                    item.SubItems.Add(Convert.ToString(cantitati[i]));
                    listView1.Items.Add(item);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                errorProvider1.Clear();
                tbProduse.Clear();
                tbPreturi.Clear();
              
            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbProduse.Clear();
            tbPreturi.Clear();
            
          
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                //button1.Text = sr.ReadToEnd();

                tbText.Text = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg1 = new SaveFileDialog();
            dlg1.Filter = "(*.txt)|*.txt";
            if (dlg1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dlg1.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(tbText.Text);
                tbText.Clear();
                sw.Close();
                fs.Close();
            }
        }

        private void afisareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbText.Clear();
            foreach (Meniuri m in listaMeniu)
                tbText.Text += m.ToString() + Environment.NewLine;
        }

        private void deseneazaGraficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraficD obj1 = new GraficD(listaMeniu);
            obj1.ShowDialog();
        }


        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            e.Graphics.DrawString(tbText.Text, new Font("Arial",
              10, FontStyle.Bold), Brushes.Black, 50, 100);

        }


        private void printare(object sender, PrintPageEventArgs e)
        {
            Graphics graf = e.Graphics;
            var spatii = new StringBuilder();
            spatii.Append(' ', 10);
            SolidBrush sb = new SolidBrush(Color.Blue);
            Pen pen = new Pen(Color.Blue);
            Font font = new Font(FontFamily.GenericSansSerif, 10);
            String Veg;

            if (cbVeg.Text == Convert.ToString("true"))
            {
             Veg = "Vegetarian";
            }
            else
            {
                Veg = "Nevegetarian";
            }

            String sir = "Meniul din categoria de " + comboBoxCateg.Text + "  De tipul " +  Veg +" are continutul: ";
            graf.DrawString(sir, font, sb, 10, 10);

            graf.DrawLine(pen, 0, 26, 450, 26);
            graf.DrawString("Denumire preparat", font, sb, 10, 29);
            graf.DrawString("Pret", font, sb, 130, 29);
            graf.DrawString("Cantitate", font, sb, 220, 29);
            graf.DrawLine(pen, 0, 45, 300, 45);

            int y = 48;
            int xDen = 10;
            int xPret = 130;
            int xCant = 220;
            string[] Produsex = tbProduse.Text.Split(';');

            string[] Preturix = tbPreturi.Text.Split(';');
           
            string[] Cantx = tbCant.Text.Split(';');


            for (int i = 0; i < Produsex.Length; i++)
            {
                graf.DrawString(Produsex[i], font, sb, xDen, y);
                graf.DrawString(Convert.ToString(Preturix[i]), font, sb, xPret, y);
                graf.DrawString(Convert.ToString(Cantx[i]), font, sb, xCant, y);
                y += 16;
                graf.DrawLine(pen, 0, y, 300, y);
                y += 3;
            }

        }

            private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.printare);
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void trimiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DragDrop obj = new DragDrop(listaMeniu);
            obj.ShowDialog();
        }

      
    }
}
