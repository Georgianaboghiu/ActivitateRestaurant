using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Boghiu_Georgiana
{
    public partial class MeniuBD : Form
    {
        string connString;
        public MeniuBD()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Proiect.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();

                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                comanda.CommandText = "SELECT MAX(ID) FROM meniuri";
                int id = Convert.ToInt32(comanda.ExecuteScalar());

                comanda.CommandText = "INSERT INTO meniuri VALUES(?,?,?,?,?,?)";
                comanda.Parameters.Add("ID", OleDbType.Integer).Value = id + 100;
                comanda.Parameters.Add("NumeProdus", OleDbType.Char, 20).Value = tbNume.Text;
                comanda.Parameters.Add("Pret", OleDbType.Integer).Value = (float)Convert.ToDouble(tbPret.Text);
                comanda.Parameters.Add("Cantitate", OleDbType.Integer).Value = (float)Convert.ToDouble(tbCant.Text);
                comanda.Parameters.Add("Categorie", OleDbType.Char, 20).Value = cbCateg.Text;
                
               
                comanda.Parameters.Add("Tip", OleDbType.Char, 10).Value = cbTip.Text;
            
                comanda.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
                tbNume.Clear();
                tbCant.Clear();
                tbPret.Clear();
                cbTip.Text = "";
                cbCateg.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
              
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT * FROM meniuri";

                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem itm = new ListViewItem(reader["Categorie"].ToString());
                    itm.SubItems.Add(reader["Tip"].ToString());
                    itm.SubItems.Add(reader["NumeProdus"].ToString());
                    itm.SubItems.Add(reader["Pret"].ToString());
                    itm.SubItems.Add(reader["Cantitate"].ToString());
                
                    listView1.Items.Add(itm);
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
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
                string r = null;
                foreach (ListViewItem itm in listView1.Items)
                {
                    r = " Categorie; " + itm.Text;

                    r += "Tip  " + itm.SubItems[1].Text + " nume produs:  " + itm.SubItems[2].Text + 
                        " pret:  " + itm.SubItems[3].Text + " cantitate: " + itm.SubItems[4].Text +Environment.NewLine;

                    sw.WriteLine(r);
                }

              
                sw.Close();
                fs.Close();




            }
        }

        private void deseneazaGraficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraficBD obj = new GraficBD();
            obj.ShowDialog();
        }
    }
}
