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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("id_usuario", "id_usuario");
            dataGridView1.Columns.Add("usuario", "usuario");
            dataGridView1.Columns.Add("cuenta", "cuenta");
            dataGridView1.Columns.Add("clave", "clave");
            dataGridView1.Columns.Add("nivel", "nivel");
            dataGridView1.Columns.Add("idioma", "idioma");

            if (Form1.nivel != 1)
            {
                MessageBox.Show("Acceso denegado");
                Close();
            }

            if (Form1.idioma == 2)
            {
                this.Text = "Users information";
                button1.Text = "Search";
                button2.Text = "Add";
                button3.Text = "Delete";
                button4.Text = "Update";
                button5.Text = "Exit";
                button6.Text = "Reset password";
            }

            textBox1.Focus();
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
            string query = "Select * from usuarios where usuario like '%" + textBox1.Text + "%' order by id_usuario limit 10";
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
                        reader.GetString(3), reader.GetString(4), reader.GetString(5));
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3307;username=root;password=;database=gymmax;";
            string query = "insert into usuarios values(null,'" + textBox3.Text + "', '" + textBox4.Text + "' , md5('" + textBox5.Text + "'), '" + textBox6.Text + "', '" + textBox7.Text + "')";
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
            string query = "delete from usuarios where id_usuario=" + textBox2.Text;
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
            string query = "update usuarios set usuario='"
                + textBox3.Text.Trim() + "', cuenta='"
                + textBox4.Text.Trim() + "', clave='"
                + textBox5.Text.Trim() + "', nivel='"
                + textBox6.Text.Trim() + "', idioma='"
                + textBox7.Text.Trim() + "' where id_usuario=" + textBox2.Text;

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

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
        }

        private void textBox6_MouseLeave(object sender, EventArgs e)
        {
        }

        private void textBox7_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void textBox5_MouseLeave(object sender, EventArgs e)
        {
            //Verifica si el contenido del TextBox2 es diferente a vacío
            if (textBox5.Text != "")
            {
                //declara una variable de tipo string
                string t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo string
                    t = Convert.ToString(textBox5.Text);
                }
                //Si el codigo anterior da error, se ejecuta lo siguiente
                catch
                {
                    //Muestra un mensaje diciendo que el formato no es incorrecto
                    MessageBox.Show("El formato de texto alfanumerico no es correcto", "Error de formato");
                    //Vuelve al foco del TextBox2
                    textBox5.Focus();
                }
            }

        }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
           

        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
           

        }

        //Evento que se ejecuta al dar click al boton "reiniciar contraseña"
        private void button6_Click(object sender, EventArgs e)
        {
            //Se declara una variable string con el contenido necesario para hacer referencia a la base de datos
            string connectionString = "datasource=localhost;port=3307;username=root;password=;database=gymmax;";
            /* Se declara una variable string con la consulta necesaria para modificar el campo clave de la tabla usuarios
                   donde id_usuario sea igual al contenido del textbox2 */
            string query = "update usuarios set clave=md5('" + textBox4.Text
                + "') where id_usuario=" + textBox2.Text;
            //Crea una nueva conexión a la base de datos con la variable "connectionString"
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            //Crea un comando ejecutable en la base de datos con la variable "query" y en la base de datos anterior
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            //Variable de tipo entero llamada "reader"
            int reader;
            //Intenta ejecutar el codigo dentro
            try
            {
                //Abre conexion a la base de datos
                databaseConnection.Open();
                //La variable reader equivale al comando antes creado y lo ejecuta
                reader = commandDatabase.ExecuteNonQuery();
                //Si la variable "reader" es igual a 0, ejecuta el codigo dentro
                if (reader != 0)
                {
                    //Muestra el siguiente mensaje
                    MessageBox.Show("Ha sido restablecida la contraseña del usuario.");
                }
                //Si la variable "reader" no es igual a 0
                else
                {
                    //Muestra el siguiente mensaje
                    MessageBox.Show("Ocurrió un problema al modificar la contraseña del usuario.");
                }
                //Se cierra la conexion a la base d edatos
                databaseConnection.Close();
            }
            //Si el codigo dentro del try marca erroro, se ejecuta el codigo denytro
            catch (Exception ex)
            {
                //Muestra un mensaje con el error
                MessageBox.Show(ex.Message);
            }
            //Llama al evento que ocurre al dar click al boton "buscar"
            button1_Click(sender, e);
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
                    MessageBox.Show("El formato de texto alfabetico no es correcto", "Error de     formato");
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
                //declara una variable de tipo string
                string t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo string
                    t = Convert.ToString(textBox4.Text);
                }
                //Si el codigo anterior da error, se ejecuta lo siguiente
                catch
                {
                    //Muestra un mensaje diciendo que el formato no es incorrecto
                    MessageBox.Show("El formato de texto alfabetico no es correcto", "Error de     formato");
                    //Vuelve al foco del TextBox2
                    textBox4.Focus();
                }
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {

            //Verifica si el contenido del TextBox2 es diferente a vacío
            if (textBox6.Text != "")
            {
                //declara una variable de tipo entero
                int t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo entero
                    t = Convert.ToInt32(textBox6.Text);
                }
                //Si el codigo anterior da error, se ejecuta lo siguiente
                catch
                {
                    //Muestra un mensaje diciendo que el formato no es incorrecto
                    MessageBox.Show("El formato de numero no es correcto", "Error de formato");
                    //Vuelve al foco del TextBox2
                    textBox6.Focus();
                }

            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            //Verifica si el contenido del TextBox2 es diferente a vacío
            if (textBox7.Text != "")
            {
                //declara una variable de tipo entero
                int t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo entero
                    t = Convert.ToInt32(textBox7.Text);
                }
                //Si el codigo anterior da error, se ejecuta lo siguiente
                catch
                {
                    //Muestra un mensaje diciendo que el formato no es incorrecto
                    MessageBox.Show("El formato de numero no es correcto", "Error de formato");
                    //Vuelve al foco del TextBox2
                    textBox7.Focus();
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
    }
}

