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

namespace GYMMAX
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("id_insc", "id_insc");
            dataGridView1.Columns.Add("id_cliente", "id_cliente");
            dataGridView1.Columns.Add("id_plan", "id_plan");
            dataGridView1.Columns.Add("id_usuario", "id_usuario");
            dataGridView1.Columns.Add("fecha_reg", "fecha_reg");
            dataGridView1.Columns.Add("fecha_fin", "fecha_fin");
            dataGridView1.Columns.Add("costo", "costo");

            if (Form1.idioma == 2)
            {
                this.Text = "Inscriptions information";
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
            string query = "Select * from inscripciones where id_insc like '%" + textBox1.Text + "%' order by id_insc limit 20";
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
                        reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos.");
                }
                databaseConnection.Close();
                if (dataGridView1.Rows.Count == 20)
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
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3307;username=root;password=;database=gymmax;";
            string query = "insert into bitacora values(null,'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox8.Text + "', '" + textBox5.Text.Substring(6, 4) + textBox5.Text.Substring(3, 2) + textBox5.Text.Substring(0, 2)
                + textBox5.Text.Substring(11, 2) + textBox5.Text.Substring(14, 2) + textBox5.Text.Substring(17, 2) + "', '" + textBox6.Text.Substring(6, 4) + textBox6.Text.Substring(3, 2) + textBox6.Text.Substring(0, 2)
                + textBox6.Text.Substring(11, 2) + textBox6.Text.Substring(14, 2) + textBox6.Text.Substring(17, 2) + "', '" + textBox7.Text + "', 2)";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();

            DialogResult r = MessageBox.Show(
            "¿Simular falla?",
            "Transacción en proceso", MessageBoxButtons.YesNo);
            if (r == DialogResult.No)
            {
                string connectionStringg = "datasource=localhost;port=3307;username=root;password=;database=gymmax;";
                string queryy = "insert into inscripciones values(null,'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox8.Text + "', '" + textBox5.Text.Substring(6, 4) + textBox5.Text.Substring(3, 2) + textBox5.Text.Substring(0, 2)
                    + textBox5.Text.Substring(11, 2) + textBox5.Text.Substring(14, 2) + textBox5.Text.Substring(17, 2) + "', null, null)";
                MySqlConnection databaseConnectionn = new MySqlConnection(connectionStringg);
                MySqlCommand commandDatabasee = new MySqlCommand(queryy, databaseConnectionn);
                MySqlDataReader readerr;
                databaseConnectionn.Open();
                readerr = commandDatabasee.ExecuteReader();
                databaseConnectionn.Close();
                button1_Click(sender, e);

                MySqlConnection con = new MySqlConnection("datasource=localhost;port=3307;username=root;password=;database=gymmax;");
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                MySqlCommand queri = new MySqlCommand("select * from bitacora", con);
                MySqlDataReader data = queri.ExecuteReader();
                string d0 = "";
                if (data.Read())
                {
                    if (data.GetString(7) == "2")
                    {
                        d0 = data.GetString(0);
                    }
                    con.Close();
                    con.Open();
                    queri = new MySqlCommand($"delete from bitacora where id_bitacora = {d0}", con);
                    queri.ExecuteReader();
                }
                con.Close();

                return;
            } 
            else
            {
                Application.Exit();
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3307;username=root;password=;database=gymmax;";
            string query = "delete from inscripciones where id_insc=" + textBox2.Text;
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
            string query = "update inscripciones set id_cliente='"
                + textBox3.Text.Trim() + "', id_plan='"
                + textBox4.Text.Trim() + "', id_usuario='"
                + textBox8.Text.Trim() + "', fecha_reg='"
                + textBox5.Text.Substring(6, 4) + textBox5.Text.Substring(3, 2) + textBox5.Text.Substring(0, 2)
                + textBox5.Text.Substring(11, 2) + textBox5.Text.Substring(14, 2) + textBox5.Text.Substring(17, 2)
 + "' where id_insc=" + textBox2.Text;

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

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
        
        }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void textBox5_MouseLeave(object sender, EventArgs e)
        {
       
        }

        private void textBox6_MouseLeave(object sender, EventArgs e)
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
                //declara una variable de tipo entero
                int t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo entero
                    t = Convert.ToInt32(textBox3.Text);
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

        private void textBox4_Leave(object sender, EventArgs e)
        {
            //Verifica si el contenido del TextBox2 es diferente a vacío
            if (textBox4.Text != "")
            {
                //declara una variable de tipo entero
                int t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo entero
                    t = Convert.ToInt32(textBox4.Text);
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

        private void textBox5_Leave(object sender, EventArgs e)
        {
            //Verifica si el contenido del TextBox2 es diferente a vacío
            if (textBox5.Text != "")
            {
                //declara una variable de tipo DateTime
                DateTime t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo DateTime
                    t = Convert.ToDateTime(textBox5.Text);
                }
                //Si el codigo anterior da error, se ejecuta lo siguiente
                catch
                {
                    //Muestra un mensaje diciendo que el formato no es incorrecto
                    MessageBox.Show("El formato de fecha no es correcto", "Error de formato");
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
                //declara una variable de tipo DateTime
                DateTime t;
                //Intenta el código dentro
                try
                {
                    //Convierte el texto del TextBox2 a una variable de tipo DateTime
                    t = Convert.ToDateTime(textBox6.Text);
                }
                //Si el codigo anterior da error, se ejecuta lo siguiente
                catch
                {
                    //Muestra un mensaje diciendo que el formato no es incorrecto
                    MessageBox.Show("El formato de fecha no es correcto", "Error de formato");
                    //Vuelve al foco del TextBox2
                    textBox6.Focus();
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    Int64 m = Convert.ToInt64(textBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de formato.\nEl dato debe de ser entero.\n" + ex.Message);
                    textBox1.Focus();
                }
            } 

        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    Int64 m = Convert.ToInt64(textBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de formato.\nEl dato debe de ser entero.\n" + ex.Message);
                    textBox1.Focus();
                }
            }
        }
    }
}


