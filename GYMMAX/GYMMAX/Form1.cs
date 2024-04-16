using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYMMAX
{

    public partial class Form1 : Form
    {
        /* Primero se declaran las siguientes variables en la forma 1, donde cuenta hace referencia al nombre de
        la cuenta del usuario, nivel hace referencia al rol del usuario e idioma hace referencia al lenguaje del usuario*/
        public static string cuenta="";
        public static int nivel= 0, idioma = 1;


        public Form1()
        {
            InitializeComponent();

            this.Resize += new EventHandler(Form1_Resize);

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void prestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Show();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void discosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void informeDePrestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void informeDeAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void informeDeDiscosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void reporteDeMaterialDidacticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void clientesPorPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void prestamosPorAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
        }

        private void prestamosPorDiscoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Show();
        }

        private void preferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.Show();
        }

        private void informeDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CentrarImagen();
        }


        /* Este codigo tambien va en la forma 1, dice que al cargar la forma uno muestre tambien la forma 2,
        que es donde se contiene el contenido del login */
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();

            label1.Text = Form1.cuenta;
            if (Form1.nivel == 1)
            {
                label1.Text = label1.Text + " (administrador)";
            }
            else
            {
                label1.Text = label1.Text + " (recepcionista)";
            }

            if (Form1.idioma == 2)
            {
                this.Text = "GYMMAX";
                this.archivoToolStripMenuItem.Text = "File";
                this.reportesToolStripMenuItem.Text = "Reports";
                this.preferenciasToolStripMenuItem.Text = "Preferences";
                this.salirToolStripMenuItem.Text = "Exit";
                this.informeDePrestamosToolStripMenuItem.Text = "Inscriptions report";
                this.informeDeAlumnosToolStripMenuItem.Text = "Customers report";
                this.informeDeDiscosToolStripMenuItem.Text = "Plans report";
                this.informeDeUsuariosToolStripMenuItem.Text = "Users report";
                this.reporteDeMaterialDidacticoToolStripMenuItem.Text = "General report";
                this.prestamosPorAlumnoToolStripMenuItem.Text = "Inscriptions by customer";
                this.prestamosPorDiscoToolStripMenuItem.Text = "Inscriptions by plan";
            }

            CentrarImagen();
        }

        private void CentrarImagen()
        {

            int anchoFormulario = this.Width;
            int altoFormulario = this.Height;
            int anchoImagen = pictureBox1.Width;
            int altoImagen = pictureBox1.Height;
            int x = (anchoFormulario - anchoImagen) / 2;
            int y = (altoFormulario - altoImagen) / 2;
            pictureBox1.Location = new System.Drawing.Point(x, y);
        }
    }
}
