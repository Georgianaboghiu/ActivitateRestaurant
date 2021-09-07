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

namespace Boghiu_Georgiana
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
           this.BackgroundImage = Properties.Resources.imagine31;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //if (textBox1.Text == "Georgiana" || textBox2.Text == "terog")
            //{
            //    MessageBox.Show("Te-ai logat cu succes");


            //    Form2 obj1 = new Form2();
            //    obj1.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Invalid Username Or Password.");
            //}

            OleDbConnection conexiune = new OleDbConnection("Provider =Microsoft.ACE.OLEDB.12.0 ; Data Source =User1.accdb");
            OleDbCommand cmd = new OleDbCommand();
            int i = 0;
            if (textBox1.Text == "")
                errorProvider1.SetError(textBox1, " introduceti un nume de utilizator");
            else
            if (textBox2.Text == "")
                errorProvider1.SetError(textBox2, " introduceti parola");
            else
                try
                {
                    cmd = new OleDbCommand("select count(*) from users where users='" + textBox1.Text + "'AND password='" + textBox2.Text + "'", conexiune);
               if(conexiune.State==ConnectionState.Closed)
                    {
                        conexiune.Open();
                        i = (int)cmd.ExecuteScalar();

                    }

                    conexiune.Close();
                    if(i>0)
                    {
                        Form2 obj = new Form2();
                        this.Hide();
                        obj.Show();
                    }
                    else
                    {
                        MessageBox.Show("utilizator sau parola gresita");
                    }
                
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = ""; 
            
        }
    }
}
