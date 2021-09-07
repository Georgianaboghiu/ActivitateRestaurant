using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Boghiu_Georgiana
{
    public partial class NotaDePlata : Form
    {
        public struct Comenzi
        {
            public string produs;
            public double pret;
        }
        const double TAX = 0.25;
        Comenzi comanda = new Comenzi();
        string nota = " Nota de plata:" + Environment.NewLine;
        static double subtotal;
        static double total;
        static double totalTaxe;
        static double sumaIncasata;
        static double rest;
        static double sumainc;

        public NotaDePlata()
        {
            InitializeComponent();
        }



        private void getValues(string Com)
        {
            comanda.produs = Com.Split('-')[0];
            comanda.pret = Convert.ToDouble(Com.Split('-')[1]);
            lstOutput.Items.Add("Pret: " + comanda.pret);
           
            nota += "\nProduse comandate: " + comanda.produs + "\nPret: " + comanda.pret.ToString() + "\n ";
            update();
        }
        private void update()
        {
            subtotal += comanda.pret;
            total += comanda.pret + (comanda.pret * TAX);

            totalTaxe += comanda.pret * TAX;
            lstOutput.Items.Clear();
            lstOutput.Items.AddRange(nota.Split('\n'));
            textBox2.Text+= "Nota de plata:" + Environment.NewLine  + Environment.NewLine+ "Produse comandate: " + comanda.produs
                + Environment.NewLine +"Pret: " + comanda.pret.ToString() + Environment.NewLine  + Environment.NewLine; ;
            lstOutput.Items.Add("Subtotal: " + subtotal.ToString());
            textBox2.Text+= "Subtotal: " + subtotal.ToString()+ Environment.NewLine;
            lstOutput.Items.Add("Tax: " + totalTaxe.ToString());
            textBox2.Text+= "Tax: " + totalTaxe.ToString()+ Environment.NewLine;
            lstOutput.Items.Add("Total: " + total.ToString());
            textBox2.Text += "Total: " + total.ToString() + Environment.NewLine;

        }

        private void cmbAperitive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == cmbAperitive)
                getValues(cmbAperitive.SelectedItem.ToString());
        }

       private void cmbFeluriPrincipale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == cmbFeluriPrincipale)
                getValues(cmbFeluriPrincipale.SelectedItem.ToString());
        }

        private void cmbDesert_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == cmbDesert)
                getValues(cmbDesert.SelectedItem.ToString());
        }

        private void cmbBauturi_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (sender == cmbBauturi)
                getValues(cmbBauturi.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sumainc = Convert.ToDouble(textBox1.Text);
            rest = sumainc - total;
            //lstOutput.Items.Add("Suma incasata: " + sumainc.ToString());
            textBox2.Text += "Suma incasata: " + sumainc.ToString() + Environment.NewLine;
            //lstOutput.Items.Add("Rest: " + rest.ToString());
            textBox2.Text+= "Rest: " + rest.ToString();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            

            e.Graphics.DrawString(textBox2.Text, new Font("Arial",
                  25, FontStyle.Bold), Brushes.Black, 100, 100);
            
        }

    

        private void button2_Click(object sender, EventArgs e)
        {
        

            PrintDocument doc = new PrintDocument();

            doc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            PrintPreviewDialog dlg = new PrintPreviewDialog();

            dlg.Document = doc;

            
            
                dlg.ShowDialog();
           
        }


       
    }
}
