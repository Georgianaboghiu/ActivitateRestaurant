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
    public partial class GraficD : Form
    {
        const int marg = 10;
        bool vb = false;
        Color culoare = Color.Blue;
        Font font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
        
        List<Meniuri> listaMeniu = new List<Meniuri>();
        public GraficD(List<Meniuri> lista)
        {
            InitializeComponent();
            listaMeniu = lista;
        }

        private void GraficD_Paint(object sender, PaintEventArgs e)
        {
            

            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 3);
            Rectangle rec = new Rectangle(50, 50, 300, 300);
            Brush br = new SolidBrush(Color.LightPink);
            Brush br1 = new SolidBrush(Color.Blue);
            Brush br2 = new SolidBrush(Color.Red);
            g.DrawEllipse(pen, rec);
            int i = 0, d = 0;
            foreach (Meniuri m in listaMeniu)
            {
                if (m.Vegetarian == true)
                    // i++;
                    i = m.Produse.Length;


                if (m.Vegetarian == false)

                {
                    //d++;
                    d = m.Produse.Length;
                }
            }

            int s = i + d;

            float x = (360 * i) / s; 
            float y = (360 * d) / s;
           

            g.DrawEllipse(pen, rec);
            g.FillPie(br, rec, 0, x);
            
            g.FillPie(br1, rec, x, y);


            g.DrawString("Preparate nevegetariene", new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
               new SolidBrush(Color.Black), new Point(400, 100));

            g.DrawString("Preparate vegetariene", new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
               new SolidBrush(Color.Black), new Point(400, 200));

           

        }
    }
}
