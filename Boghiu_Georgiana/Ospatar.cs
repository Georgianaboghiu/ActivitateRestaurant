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
using System.Data.Common;
using System.Data.OleDb;

namespace Boghiu_Georgiana
{
    public partial class Ospatar : Form
    {
        string connString;
        
        public Ospatar()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Proiect.accdb";

        }

        

        private void tbSalariu_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int salariu = Convert.ToInt32(tbSalariu.Text);
                if (salariu < 1000)
                    MessageBox.Show("Salariul trebuie sa fie mai mare de 1000 de lei");
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbOreSuplimentare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
             !char.IsControl(e.KeyChar) && e.KeyChar != ',')
                e.Handled = true;
        }





       

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                textBox1.Text = sr.ReadToEnd();
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

                sw.WriteLine(textBox1.Text);
                textBox1.Clear();


                foreach (ListViewItem itm in listView1.Items)
                {
                    sw.WriteLine(textBox1.Text.Split(';'));
                    sw.WriteLine("ID : " + itm.Text);
                    sw.WriteLine("luni: " + itm.SubItems[1].Text);
                    sw.WriteLine("Marti:" + itm.SubItems[2].Text);
                    sw.WriteLine("Miercuri: " + itm.SubItems[3].Text);
                    sw.WriteLine("Joi: " + itm.SubItems[4].Text);
                    sw.WriteLine("Vineri: " + itm.SubItems[5].Text);
                    sw.WriteLine("Sambata: " + itm.SubItems[6].Text);
                    sw.WriteLine("Duminica: " + itm.SubItems[7].Text);
                }

                sw.Close();
                fs.Close();
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tbSalariu.Text == "")
                errorProvider1.SetError(tbSalariu, "Introduceti salariul brut!");




            try
            {

                int salariu_brut = Convert.ToInt32(tbSalariu.Text.ToString());
                float CAS = (float)(10.5 / 100 * salariu_brut);
                float CASS = (float)(5.5 / 100 * salariu_brut);
                float salariu_impozabil = salariu_brut - CAS - CASS;
                float impozit_salariu = (float)(salariu_impozabil * 16.1 / 100);
                float salariu_net = salariu_impozabil - impozit_salariu;
                tbSalariuNet.Text = salariu_net.ToString();
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                errorProvider1.Clear();
                tbSalariu.Clear();

            }
        }

        

       

        private void button4_Click(object sender, EventArgs e)
        {

            if (tbNume.Text == "")
                errorProvider1.SetError(tbNume, "Introduceti numele!");
            else
               if (tbPrenume.Text == "")
                errorProvider1.SetError(tbPrenume, "Introduceti Prenumele!");
            else
                   if (tbData.Text == "")
                errorProvider1.SetError(tbData, "Introduceti data de angajare!");

            else
                   if (tbSalariu.Text == "")
                errorProvider1.SetError(tbSalariu, "Introduceti salariul!");
            else
                   if (tbZile.Text == "")
                errorProvider1.SetError(tbZile, "Introduceti numarul de zile in care ati lucrat suplimentar");

            else
                   if (tbOreSuplimentare.Text == "")
                errorProvider1.SetError(tbOreSuplimentare, "Introduceti orele suplimentare lucrate!");
            else
           if (Convert.ToInt32(tbSalariu.Text) < 1000)
                MessageBox.Show("Salariul trebuie sa fie mai mare de 1000 de lei");

            else
            {

                OleDbConnection conexiune = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =Proiect.accdb");

                try
                {
                    conexiune.Open();

                    OleDbCommand comanda = new OleDbCommand();
                    comanda.Connection = conexiune;

                    comanda.CommandText = "SELECT MAX(ID) FROM ospatari";
                    int id = Convert.ToInt32(comanda.ExecuteScalar());
                    //int id=0;

                    comanda.CommandText = "INSERT INTO ospatari VALUES(?,?,?,?,?)";
                    comanda.Parameters.Add("ID", OleDbType.Integer).Value = id + 100;
                    comanda.Parameters.Add("nume", OleDbType.Char, 20).Value = tbNume.Text;
                    comanda.Parameters.Add("prenume", OleDbType.Char, 20).Value = tbPrenume.Text;
                    comanda.Parameters.Add("dataAngajare", OleDbType.Char, 10).Value = tbData.Text;


                    comanda.Parameters.Add("salariu", OleDbType.Integer).Value = Convert.ToInt32(tbSalariu.Text);
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
                    errorProvider1.Clear();
                    conexiune.Close();
                    tbNume.Clear();
                    tbPrenume.Clear();
                    tbData.Clear();
                    tbSalariu.Clear();
                    //tbSalariu.Clear();
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);

            try
            {

                conexiune.Open();

                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                comanda.CommandText = "SELECT MAX(ID) FROM oreSuplimentare";
                int id = Convert.ToInt32(comanda.ExecuteScalar());
                string[] ore_suplimentarex = tbOreSuplimentare.Text.Split(',');

                //comanda.CommandText = "SELECT MAX(ID) FROM oreSuplimentare";
                comanda.CommandText = "INSERT INTO oreSuplimentare VALUES(?,?,?,?,?,?,?,?)";
                // int id = Convert.ToInt32(comanda.ExecuteScalar());


                comanda.Parameters.Add("ID", OleDbType.Integer).Value = id + 100;
                comanda.Parameters.Add("luni", OleDbType.Integer).Value = Convert.ToInt32(ore_suplimentarex[0]);
                comanda.Parameters.Add("marti", OleDbType.Integer).Value = Convert.ToInt32(ore_suplimentarex[1]);
                comanda.Parameters.Add("miercuri", OleDbType.Integer).Value = Convert.ToInt32(ore_suplimentarex[2]);
                comanda.Parameters.Add("joi", OleDbType.Integer).Value = Convert.ToInt32(ore_suplimentarex[3]);
                comanda.Parameters.Add("vineri", OleDbType.Integer).Value = Convert.ToInt32(ore_suplimentarex[4]);
                comanda.Parameters.Add("sambata", OleDbType.Integer).Value = Convert.ToInt32(ore_suplimentarex[5]);
                comanda.Parameters.Add("duminica", OleDbType.Integer).Value = Convert.ToInt32(ore_suplimentarex[6]);
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
                tbOreSuplimentare.Clear();
                tbZile.Clear();
                tbSalariu.Clear();
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {

            //connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Proiect.accdb";

            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                //OleDbCommand comanda = new OleDbCommand("SELECT * FROM clienti", conexiune);
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT * FROM ospatari";

                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {

                    textBox1.Text +="ID: "+ reader["ID"].ToString() + "ospatorul cu numele " + reader["nume"].ToString() + reader["prenume"].ToString() + " s-a angajat la data de" +
reader["dataAngajare"].ToString() + " are salariul de " + reader["salariu"].ToString() +";"+ Environment.NewLine;

                    
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

        private void button7_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
               
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT * FROM oreSuplimentare";

                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem itm = new ListViewItem(reader["ID"].ToString());
                    itm.SubItems.Add(reader["luni"].ToString());
                    itm.SubItems.Add(reader["marti"].ToString());
                    itm.SubItems.Add(reader["miercuri"].ToString());
                    itm.SubItems.Add(reader["joi"].ToString());
                    itm.SubItems.Add(reader["vineri"].ToString());
                    itm.SubItems.Add(reader["sambata"].ToString());
                    itm.SubItems.Add(reader["duminica"].ToString());
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
    }
}
