using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace GYMMAX
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        string archivo = Directory.GetCurrentDirectory() + "\\inscripcionesporcliente.html";

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter arch = new StreamWriter(archivo);
            arch.WriteLine("<html>INSCRIPCIONES POR CLIENTE<br><br>");
            arch.WriteLine("<table border=1 cellspacing=0>");
            arch.WriteLine("<tr><td>cliente</td><td>veces</td></tr>");

            string connectionString = "datasource=localhost;port=3307;username=root;password=;database=gymmax;";
            string query = "SELECT c.cliente, COUNT(i.id_cliente) AS inscripciones FROM clientes AS c LEFT JOIN inscripciones AS i ON c.id_cliente = i.id_cliente GROUP BY c.id_cliente, c.cliente; ";
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
                        arch.WriteLine("<tr><td>" + reader.GetString(0) + "</td><td>" + reader.GetString(1) + "</td>");
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
            System.Diagnostics.Process.Start("Chrome", "\"" + archivo + "\"");
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            if (Form1.idioma == 2)
            {
                this.Text = "Inscriptions by customer";
                button1.Text = "Generate";
                button5.Text = "Exit";
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }
    }
}
