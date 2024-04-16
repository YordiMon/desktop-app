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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Español");
            comboBox1.Items.Add("Inglés");
            if (Form1.idioma == 2) comboBox1.SelectedIndex = 1;
            else comboBox1.SelectedIndex = 0;

            if (Form1.idioma == 2)
            {
                this.Text = "Preferences";
                button1.Text = "Accept";
                button2.Text = "Cancel";
            }
        }


        //Evento que se ejecuta al dar click al boton "aceptar"
        private void button1_Click(object sender, EventArgs e)
        {
            //Si el contenido del textbox1 está vacío, se ejecuta el codigo dentro
            if (textBox1.Text == "")
            {
                //Muestra un mensaje que dice "debes proporcionar la contraseña actual"
                MessageBox.Show("Debes proporcionar la contraseña actual");
                //El foco vuelve al textbox1
                textBox1.Focus();
            }
            //Si el contenido del textbox1 no esta vacio, se ejecuta el codigo dentro
            else
            {
                //Si el contenido del textbox2 es igual al del textbox3, se ejecuta el codigo dentro
                if (textBox2.Text == textBox3.Text)
                {
                    //Si el contenido del textbox2 está vacío, se ejecuta el codigo dentro
                    if (textBox2.Text == "")
                    {
                        //El contenido del textbox2 y textbox1 seran iguales
                        textBox2.Text = textBox1.Text;
                    }
                    //Se declara una variable string con el contenido necesario para hacer referencia a la base de datos
                    string connectionString = "datasource=localhost;port=3307;username=root;password=;database=gymmax;";
                    /* Se declara una variable string con la consulta necesaria para modificar el campo clave e idioma de la tabla usuarios
                    donde la cuenta sea igual a la variable "cuenta" de la forma uno y la clave sea igual al contenido del textbox1*/
                    string query = "update usuarios set clave=md5('" + textBox2.Text
                        + "'), idioma=" + (comboBox1.SelectedIndex + 1).ToString()
                        + " where cuenta='" + Form1.cuenta + "' and clave=md5('"
                        + textBox1.Text + "')";
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
                        if (reader == 0)
                        {
                            //Muestra un mensaje que dice "la contraseña actual es incorrecta"
                            MessageBox.Show("La contraseña actual es incorrecta.");
                        }
                        //Si la variable "reader" no es igual a 0, ejecuta el codigo dentro
                        else
                        {
                            //Muestra el siguiente mensaje
                            MessageBox.Show("Cambios de la contraseña e idioma se realizaron con éxito. Es necesario reinciar para visualizar los cambios");
                            //La variable "idioma" de la forma uno, será igual al item seleccionado del combobox +1
                            Form1.idioma = comboBox1.SelectedIndex + 1;
                            //Se cierra la forma
                            Close();
                        }
                        //Se cierra la conexion con la base de datos
                        databaseConnection.Close();
                    }
                    //Si el codigo dentro del try marca error, ejecuta el codigo dentro
                    catch (Exception ex)
                    {
                        //Muestra un mensaje con el error
                        MessageBox.Show(ex.Message);
                    }
                }
                //Si el contenido del textbox2 no es igual al del textbox3, se ejecuta el codigo dentro
                else
                {
                    //Muestra un mensaje que dice "confirmacion de la contraseña no valida"
                    MessageBox.Show("Confirmación de la contraseña no válida");
                    //Vuelve el foco al textbox3
                    textBox3.Focus();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
