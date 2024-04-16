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
using MySql.Data.MySqlClient;

namespace GYMMAX
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter arch = new StreamWriter(archivo);
            arch.WriteLine("<html>REPORTE GENERAL<br><br>");
            arch.WriteLine("<table border=1 cellspacing=0>");
            arch.WriteLine("<tr><td>id_insc</td><td>id_cliente</td><td>cliente</td><td>id_plan</td><td>plan</td><td>precio</td><td>fecha_reg</td><td>fecha_fin</td></tr>");

            string connectionString = "datasource=localhost;port=3307;username=root;password=;database=gymmax;";
            string query = "SELECT i.id_insc, c.id_cliente, c.cliente, p.id_plan, p.plan, p.precio, i.fecha_reg, i.fecha_fin FROM inscripciones AS i INNER JOIN clientes AS c ON i.id_cliente = c.id_cliente INNER JOIN planes AS p ON i.id_plan = p.id_plan; ";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        arch.WriteLine("<tr><td>" + reader.GetString(0) + "</td><td>" + reader.GetString(1) + "</td><td>" + reader.GetString(2) + "</td><td>" + reader.GetString(3) + "</td><td>" + reader.GetString(4) + "</td><td>" + reader.GetString(5) + "</td><td>" + reader.GetString(6) + "</td><td>" + reader.GetString(7) + "</td>");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos.");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            arch.WriteLine("</table></html>");
            arch.Close();
            Uri dir = new Uri(archivo);
            webBrowser1.Url = dir;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Excel", "\"" + archivo + "\"");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword", "\"" + archivo + "\"");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome", "\"" + archivo + "\"");
        }

        string archivo = Directory.GetCurrentDirectory() + "\\reportegeneral.html";

        private void Form9_Load(object sender, EventArgs e)
        {
            if (Form1.idioma == 2)
            {
                this.Text = "General report";
                button1.Text = "Generate";
                button5.Text = "Exit";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }
    }
}
