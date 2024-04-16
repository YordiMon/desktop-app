using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GYMMAX
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Focus();

            dataGridView1.Columns.Add("id_cliente", "id_cliente");
            dataGridView1.Columns.Add("cliente", "cliente");
            dataGridView1.Columns.Add("fecha_nac", "fecha_nac");

            if (Form1.idioma == 2)
            {
                this.Text = "Customers information";
                button1.Text = "Search";
                button2.Text = "Add";
                button3.Text = "Delete";
                button4.Text = "Update";
                button5.Text = "Exit";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains('%') || textBox1.Text.Contains('\'') || textBox1.Text.Contains('*')
                || textBox1.Text.Contains('#') || textBox1.Text.Contains('$') || textBox1.Text.Contains('=')
                || textBox1.Text.Contains('+') || textBox1.Text.Contains('-'))
            {
                MessageBox.Show("Proteccion contra SQL Inyection.\nNo se permiten caracteres especiales: %'*#$=+-");
                return;
            }
            string connectionString = "datasource=localhost;port=3307;username=root;password=;database=GYMMAX;";
            string query = "Select * from clientes where cliente like '%" + textBox1.Text + "%' order by cliente limit 10";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;

            dataGridView1.Rows.Clear();

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos.");
                }
                databaseConnection.Close();
                if (dataGridView1.Rows.Count == 10)
                {
                    MessageBox.Show("Demasiados registros encontrados.\nFavor de depurar la búsqueda.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3307;username=root;password=;database=gymmax;";
            string query = "insert into clientes values(null,'" + textBox3.Text + "', '" + textBox4.Text.Substring(6, 4) + textBox4.Text.Substring(3, 2) + textBox4.Text.Substring(0, 2)
                + textBox4.Text.Substring(11, 2) + textBox4.Text.Substring(14, 2) + textBox4.Text.Substring(17, 2) + "')";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3307;username=root;password=;database=gymmax;";
            string query = "delete from clientes where id_cliente=" + textBox2.Text;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();
            button1_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3307;username=root;password=;database=gymmax;";
            string query = "update clientes set cliente='"
                + textBox3.Text.Trim() + "', fecha_nac='"
                + textBox4.Text.Substring(6, 4) + textBox4.Text.Substring(3, 2) + textBox4.Text.Substring(0, 2)
                + textBox4.Text.Substring(11, 2) + textBox4.Text.Substring(14, 2) + textBox4.Text.Substring(17, 2) + "' where id_cliente=" + textBox2.Text;

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            button1_Click(sender, e);
        }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            //Verifica si el contenido del TextBox2 es diferente a vacío
            if (textBox2.Text != "")
            {
                //declara una variable de tipo entero
                int t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo entero
                    t = Convert.ToInt32(textBox2.Text);
                }
                //Si el codigo anterior da error, se ejecuta lo siguiente
                catch
                {
                    //Muestra un mensaje diciendo que el formato no es incorrecto
                    MessageBox.Show("El formato de numero no es correcto", "Error de formato");
                    //Vuelve al foco del TextBox2
                    textBox2.Focus();
                }

            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            //Verifica si el contenido del TextBox2 es diferente a vacío
            if (textBox3.Text != "")
            {
                //declara una variable de tipo string
                string t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo string
                    t = Convert.ToString(textBox3.Text);
                }
                //Si el codigo anterior da error, se ejecuta lo siguiente
                catch
                {
                    //Muestra un mensaje diciendo que el formato no es incorrecto
                    MessageBox.Show("El formato de texto alfabetico no es correcto", "Error de formato");
                    //Vuelve al foco del TextBox2
                    textBox3.Focus();
                }


            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            //Verifica si el contenido del TextBox2 es diferente a vacío
            if (textBox4.Text != "")
            {
                //declara una variable de tipo DateTime
                DateTime t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo DateTime
                    t = Convert.ToDateTime(textBox4.Text);
                }
                //Si el codigo anterior da error, se ejecuta lo siguiente
                catch
                {
                    //Muestra un mensaje diciendo que el formato no es incorrecto
                    MessageBox.Show("El formato de fecha no es correcto", "Error de formato");
                    //Vuelve al foco del TextBox2
                    textBox4.Focus();
                }


            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !ContieneSoloLetrasYEspacios(textBox1.Text))
            {
                MessageBox.Show("Error de formato, ingrese solo letras y espacios en el campo.");
                textBox1.Focus();
                return;
            }
        }

        private bool ContieneSoloLetrasYEspacios(string texto)
        {
            return Regex.IsMatch(texto, "^[a-zA-Z ]*$");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

    }
}

