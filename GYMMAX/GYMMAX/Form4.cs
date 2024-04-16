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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Focus();

            dataGridView1.Columns.Add("id_plan", "id_plan");
            dataGridView1.Columns.Add("plan", "plan");
            dataGridView1.Columns.Add("descripcion", "descripcion");
            dataGridView1.Columns.Add("duracion", "duracion");
            dataGridView1.Columns.Add("precio", "precio");

            if (Form1.idioma == 2)
            {
                this.Text = "Plans information";
                button1.Text = "Search";
                button2.Text = "Add";
                button3.Text = "Delete";
                button4.Text = "Update";
                button5.Text = "Exit";
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
            string query = "Select * from planes where plan like '%" + textBox1.Text + "%' order by id_plan limit 10";
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
                        dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4));
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

        string anterior = "";
        int ren = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            anterior = textBox6.Text;
            ren = e.RowIndex;
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3307;username=root;password=;database=gymmax;";
            string query = "insert into planes values(null,'" + textBox3.Text + "', '" + textBox4.Text + "' , '" + textBox5.Text + "', '" + textBox6.Text + "')";
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
            string query = "delete from planes where id_plan=" + textBox2.Text;
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
            string query = "update planes set plan='"
                + textBox3.Text.Trim() + "', descripcion='"
                + textBox4.Text.Trim() + "', duracion='"
                + textBox5.Text.Trim() + "', precio='"
                + textBox6.Text.Trim() + "' where id_plan=" + textBox2.Text + " and precio = " + anterior;

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            double n = 0, cant = 0, res = 0;
            try
            {
                databaseConnection.Open();
                n = commandDatabase.ExecuteNonQuery();
                if (n == 0)
                {
                    MessageBox.Show("Concurrencia");
                    cant = Convert.ToDouble(textBox6.Text) - Convert.ToDouble(anterior);
                    button1_Click(sender, e); //Buscar
                    textBox6.Text = dataGridView1.Rows[ren].Cells[4].Value.ToString();
                    res = Convert.ToDouble(textBox6.Text) + cant;
                    anterior = textBox6.Text;
                    textBox6.Text = res.ToString();
                    button4_Click(sender, e); //Modificar
                    button1_Click(sender, e); //Buscar
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            button1_Click(sender, e); //Buscar
    
    }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void textBox5_MouseLeave(object sender, EventArgs e)
        {
            

            
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
           
            }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
            
            }

        private void textBox6_MouseLeave(object sender, EventArgs e)
        {
            
            }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            //Verifica si el contenido del TextBox2 es diferente a vacío
            if (textBox3.Text != "")
            {
                //declara una variable de tipo entero
                string t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo entero
                    t = Convert.ToString(textBox3.Text);
                }
                //Si el codigo anterior da error, se ejecuta lo siguiente
                catch
                {
                    //Muestra un mensaje diciendo que el formato no es incorrecto
                    MessageBox.Show("El formato de numero no es correcto", "Error de formato");
                    //Vuelve al foco del TextBox2
                    textBox3.Focus();
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            //Verifica si el contenido del TextBox2 es diferente a vacío
            if (textBox2.Text != "")
            {
                //declara una variable de tipo string
                int t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo string
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

        private void textBox5_Leave(object sender, EventArgs e)
        {
            //Verifica si el contenido del TextBox2 es diferente a vacío
            if (textBox5.Text != "")
            {
                //declara una variable de tipo string
                int t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo string
                    t = Convert.ToInt32(textBox5.Text);
                }
                //Si el codigo anterior da error, se ejecuta lo siguiente
                catch
                {
                    //Muestra un mensaje diciendo que el formato no es incorrecto
                    MessageBox.Show("El formato de numero no es correcto", "Error de formato");
                    //Vuelve al foco del TextBox2
                    textBox5.Focus();
                }
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            //Verifica si el contenido del TextBox2 es diferente a vacío
            if (textBox6.Text != "")
            {
                //declara una variable de tipo string
                double t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo string
                    t = Convert.ToDouble(textBox6.Text);
                }
                //Si el codigo anterior da error, se ejecuta lo siguiente
                catch
                {
                    //Muestra un mensaje diciendo que el formato no es incorrecto
                    MessageBox.Show("El formato de moneda no es correcto", "Error de formato");
                    //Vuelve al foco del TextBox2
                    textBox6.Focus();
                }
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            //Verifica si el contenido del TextBox2 es diferente a vacío
            if (textBox4.Text != "")
            {
                //declara una variable de tipo entero
                string t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo entero
                    t = Convert.ToString(textBox4.Text);
                }
                //Si el codigo anterior da error, se ejecuta lo siguiente
                catch
                {
                    //Muestra un mensaje diciendo que el formato no es incorrecto
                    MessageBox.Show("El formato de numero no es correcto", "Error de formato");
                    //Vuelve al foco del TextBox2
                    textBox4.Focus();
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !ContieneSoloLetrasEspaciosNumeros(textBox1.Text))
            {
                MessageBox.Show("Error de formato, ingrese solo letras, espacios o numeros en el campo.");
                textBox1.Focus();
                return;
            }
        }
        
        private bool ContieneSoloLetrasEspaciosNumeros(string texto)
        {
            return Regex.IsMatch(texto, "^[a-zA-Z. 0-9 ]*$");
        }
    }
}
