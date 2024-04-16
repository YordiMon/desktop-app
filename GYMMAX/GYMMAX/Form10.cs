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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter arch = new StreamWriter(archivo);
            arch.WriteLine("<html>INFORME DE USUARIOS<br><br>");
            arch.WriteLine("<table border=1 cellspacing=0>");
            arch.WriteLine("<tr><td>id_usuario</td><td>usuario</td><td>cuenta</td><td>clave</td><td>nivel</td><td>idioma</td></tr>");

            string connectionString = "datasource=localhost;port=3307;username=root;password=;database=gymmax;";
            string query = "select * from usuarios";
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
                        arch.WriteLine("<tr><td>" + reader.GetString(0) + "</td><td>" + reader.GetString(1) + "</td><td>" + reader.GetString(2) + "</td><td>" + reader.GetString(3) + "</td><td>" + reader.GetString(4) + "</td><td>" + reader.GetString(5) + "</td>");
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

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        string archivo = Directory.GetCurrentDirectory() + "\\informedeusuarios.html";

        private void Form10_Load(object sender, EventArgs e)
        {
            if (Form1.idioma == 2)
            {
                this.Text = "Users report";
                button1.Text = "Generate";
                button5.Text = "Exit";
            }

            if (Form1.nivel != 1)
            {
                MessageBox.Show("Acceso denegado");
                Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }
    }
}
