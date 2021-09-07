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
using System.Data.OleDb;

namespace Boghiu_Georgiana
{
    public partial class Rezervare : Form
    {
        string connString;
      
        public Rezervare()
        {
            
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Proiect.accdb";

        }

      
        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                //button1.Text = sr.ReadToEnd();

                textBox1.Text = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbNume.Clear();
            tbPrenume.Clear();
         
            tbNrRezervare.Clear();
            tbNumarMasa.Clear();
            tbNumarScaune.Clear();
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
                     r = " Numar Rezervare " + itm.Text;
                    
                    r += "Nume:  " + itm.SubItems[1].Text + " Prenume:  " + itm.SubItems[2].Text + " Data:  " + itm.SubItems[3].Text + " Numar locuri:  " + itm.SubItems[4].Text +
                      " Numar masa:  " + itm.SubItems[4].Text+Environment.NewLine;
                   
                    sw.WriteLine(r);
                }
                
                //sw.WriteLine(textBox1.Text);
                textBox1.Clear();
                sw.Close();
                fs.Close();




            }
        }

      

        private void tbNrRezervare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
               !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void schimbaCuloareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                contextMenuStrip1.SourceControl.BackColor = dlg.Color;
        }

        private void schimbaFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                contextMenuStrip1.SourceControl.Font = dlg.Font;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                //OleDbCommand comanda = new OleDbCommand("SELECT * FROM clienti", conexiune);
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT * FROM Rezervare";

                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem itm = new ListViewItem(reader["NumarRezervare"].ToString());
                    itm.SubItems.Add(reader["Nume"].ToString());
                    itm.SubItems.Add(reader["Prenume"].ToString());
                    itm.SubItems.Add(reader["Data"].ToString());
                    itm.SubItems.Add(reader["NumarLocuri"].ToString());
                    itm.SubItems.Add(reader["NumarMasa"].ToString());
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

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);

            if (tbNrRezervare.Text == "")
                errorProvider1.SetError(tbNume, "Introduceti numarul rezervarii!");
            else
           if (tbNume.Text == "")
                errorProvider1.SetError(tbNume, "Introduceti numele!");
            else
               if (tbPrenume.Text == "")
                errorProvider1.SetError(tbPrenume, "Introduceti Prenumele!");
            else
                   if (tbData.Text == "")
                errorProvider1.SetError(tbData, "Introduceti data rezervarii!");
            else
           if (tbNumarMasa.Text == "")
                errorProvider1.SetError(tbNume, "Introduceti numarul mesei!");
            else
               if (tbNumarScaune.Text == "")
                errorProvider1.SetError(tbNume, "Introduceti numarul de scaune!");
          
            else

                try
            {
                conexiune.Open();

                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                comanda.CommandText = "SELECT MAX(NumarRezervare) FROM Rezervare";
                int id = Convert.ToInt32(comanda.ExecuteScalar());

                comanda.CommandText = "INSERT INTO Rezervare VALUES(?,?,?,?,?,?)";
                comanda.Parameters.Add("NumarRezervare", OleDbType.Integer).Value = id + 100;
                comanda.Parameters.Add("Nume", OleDbType.Char, 20).Value = tbNume.Text;
                comanda.Parameters.Add("Prenume", OleDbType.Char, 20).Value = tbPrenume.Text;
                comanda.Parameters.Add("Data", OleDbType.Char, 10).Value = tbData.Text;
                comanda.Parameters.Add("NumarLocuri", OleDbType.Char, 10).Value = tbNumarScaune.Text;
                comanda.Parameters.Add("NumarMasa", OleDbType.Integer).Value = Convert.ToInt32(tbNumarMasa.Text);
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
                tbPrenume.Clear();
                tbData.Clear();
                tbNrRezervare.Clear();
                tbNumarMasa.Clear();
                    tbNumarScaune.Clear();
                    
            }
        }

        private void stergeRezervareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            OleDbCommand comanda = new OleDbCommand();


            try
            {
                conexiune.Open();
                foreach (ListViewItem itm in listView1.Items)
                {
                    if (itm.Selected)
                    {

                        int id = Convert.ToInt32(itm.SubItems[0].Text);
                        comanda.CommandText = "DELETE FROM Pariuri where NumarRezervare=" + id;
                        comanda.Connection = conexiune;
                        comanda.ExecuteNonQuery();
                    }

                }
                foreach (ListViewItem eachItem in listView1.SelectedItems)
                {
                    listView1.Items.Remove(eachItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
            listView1.Items.Clear();
            //button4_Click(sender, e);
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            OleDbCommand comanda = new OleDbCommand();


            try
            {
                conexiune.Open();
                foreach (ListViewItem itm in listView1.Items)
                {
                    if (itm.Selected)
                    {

                        int id = Convert.ToInt32(itm.SubItems[0].Text);
                        comanda.CommandText = "DELETE FROM Rezervare where NumarRezervare=" + id;
                        comanda.Connection = conexiune;
                        comanda.ExecuteNonQuery();
                        itm.Remove();
                    }

                }
                //foreach (ListViewItem eachItem in listView1.SelectedItems)
                //{
                //    listView1.Items.Remove(eachItem);
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
          
            //button4_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
           
            conexiune.Open();
            OleDbCommand comanda = new OleDbCommand();
            comanda.Connection = conexiune;
            //cmd.CommandType = CommandType.Text;
            comanda.CommandText = "update Rezervare set Data='" + textBox2.Text + "'where Data='" + tbData.Text + "'";
            comanda.ExecuteNonQuery();
            conexiune.Close();
            MessageBox.Show(" modificare realizata");
        
        }
    }
}
