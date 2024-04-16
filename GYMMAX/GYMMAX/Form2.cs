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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        /* Se declara la siguiente variable, funcionará para contear los intentos fallidos
        que lleva el usuario al intentar ingresar al sistema */
        int contador = 0;

        private void button5_Click(object sender, EventArgs e)
        { 
            Close();
        }

        //Evento que ocurre al presionar el botón "cancelar"
        private void button2_Click(object sender, EventArgs e)
        {
            //Se cierra la aplicación
            Application.Exit();
        }

        //Evento que ocurre al cerrar el formulario
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* Si la variable "cuenta" del formulario uno está vacía, entonces
            se cerrará la aplicación */
            if (Form1.cuenta == "") Application.Exit();
        }

        //Evento que ocurre al presionar el botón "ingresar"
        private void button1_Click(object sender, EventArgs e)
        {
            //Se declara una variable string con el contenido necesario para hacer referencia a la base de datos
            string connectionString = "datasource=localhost;port=3307;username=root;password=;database=gymmax;";
            /* Se declara una variable string con la consulta necesaria para seleccionar el nivel y el idioma
            del usuario de la tabla de usuarios, donde la cuenta es el texto ingresado al textbox1 y la clave
            es el texto ingresado al textbox2 */
            string query = "Select nivel, idioma from usuarios where cuenta='"
                + textBox1.Text + "' and clave=md5('"
                + textBox2.Text + "')";
            //Crea una nueva conexión a la base de datos con la variable "connectionString"
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            //Crea un comando ejecutable en la base de datos con la variable "query" y en la base de datos anterior
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            //Crea un lector de la base de datos
            MySqlDataReader reader;
            //Intenta el codigo dentro del try
            try
            {
                //Abre conexion con la base de datos
                databaseConnection.Open();
                //Ejecuta el comando antes creado
                reader = commandDatabase.ExecuteReader();
                //Si la consulta ejecutada con el comando tiene renglones, ejecuta el siguiente codigo
                if (reader.HasRows)
                {
                    //Mientras el lector lea el resultado dev la consulta, ejecuta el siguiente codigo
                    while (reader.Read())
                    {
                        //La variable "cuenta" del formulario uno será el contenido del textbox1
                        Form1.cuenta = textBox1.Text;
                        //La variable "nivel" del formulario uno será el nivel que encuentre la consulta
                        Form1.nivel = Convert.ToInt16(reader.GetString(0));
                        //La variable "idioma" del formulario uno será el idioma que encuentre la consulta
                        Form1.idioma = Convert.ToInt16(reader.GetString(1));
                        //Se cierra el formulario
                        Close();
                    }
                }
                //Si la condición no se cumple, se ejecuta el siguiente codigo
                else
                {
                    //Muestra el mensaje "Cuenta o contraseña incorrecta."
                    MessageBox.Show("Cuenta o contraseña incorrecta.");
                    //Se le suma una unidad al contador
                    contador++;
                    //Si el contador llega a la tercera unidad o intento, la aplicación se cerrará
                    if (contador > 2) Application.Exit();
                }
                //Se cierra la conexión a la base de datos
                databaseConnection.Close();
            }
            //Si el contenido dentro del try da error, se ejecuta el siguiente codigo
            catch (Exception ex)
            {
                //Muestra un mensaje con el error
                MessageBox.Show(ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            // BITACORA
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
            MySqlCommand query = new MySqlCommand("select * from bitacora", con);
            MySqlDataReader data = query.ExecuteReader();
            string d0 = "", d1, d2, d3, d4, d5, d6;
            if (data.Read())
            {
                if (data.GetString(7) == "2")
                {
                    d0 = data.GetString(0);
                    d1 = data.GetString(1);
                    d2 = data.GetString(2);
                    d3 = data.GetString(3);
                    d4 = data.GetString(4);

                    con.Close();
                    con.Open();
                    query = new MySqlCommand($"insert into inscripciones values(null, {d1}, {d2}, {d3}, (SELECT fecha_reg FROM bitacora WHERE id_bitacora = {d0}), null, null)", con);
                    query.ExecuteReader();
                }
                con.Close();
                con.Open();
                query = new MySqlCommand($"delete from bitacora where id_bitacora = {d0}", con);
                query.ExecuteReader();
            }
            con.Close();
        }
    }
}
