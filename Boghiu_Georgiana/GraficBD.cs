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
    public partial class GraficBD : Form
    {
        Graphics g;
        Bitmap bmp;
        string connString;

        double[] vect = new double[100];

        int nrElem = 0;
        double[] vector = new double[100];
        const int margine = 10;
        bool vb = false;
        Font font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
        Color culoare = Color.Blue;

        public GraficBD()
        {
            InitializeComponent();
            bmp = new Bitmap(panel1.Width, panel1.Height);
            g = Graphics.FromImage(bmp);
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Proiect.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            OleDbDataAdapter adaptor = new OleDbDataAdapter("SELECT * FROM meniuri", conexiune);

            DataSet ds = new DataSet();
            adaptor.Fill(ds, "meniuri");

            DataTable tabela = ds.Tables["meniuri"];

            DataRow[] rows = tabela.Select("Tip = 'vegetarian'");
            int nrm = 0;
            foreach (DataRow linie in rows)
            {
                nrm++;
            }

            DataRow[] rowsf = tabela.Select("Tip = 'nevegetarian'");
            int nrf = 0;
            foreach (DataRow linie in rowsf)
            {
                nrf++;
            }
            int t = nrf + nrm;

            float x = (360 * nrf) / t; 
            float y = (360 * nrm) / t; 

            Pen pen = new Pen(Color.Black, 3);
            Rectangle rec = new Rectangle(40, 40, 300, 150);
            Brush br = new SolidBrush(Color.LightPink);
            Brush br1 = new SolidBrush(Color.Blue);
            g.DrawEllipse(pen, rec);
            g.FillPie(br, rec, 0, x);
            g.FillPie(br1, rec, x, y);

            g.DrawString("nevegetarian", new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
               new SolidBrush(Color.Black), new Point(270, 220));

            g.DrawString("vegetarian", new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
               new SolidBrush(Color.Black), new Point(270, 20));

            panel1.Invalidate();


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);

        }
    }
}
