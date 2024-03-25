using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace desde0tesla
{
    public partial class Form3 : Form
    {
        private List<SpaceX> listaSpaceX = new List<SpaceX>(); //Lista de SpaceX para que sea aplicada en el Form

        public Form3() //Configuracion del Form
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; //Codigo para que no se escriba en la Combo Box
        }

        private void Form3_Load(object sender, EventArgs e) //Evento para cargar en el Datagrid los datos de la lista SpaceX
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.Columns.Add("Dueño", "Dueño");
            dataGridView2.Columns.Add("Año", "Año");
            dataGridView2.Columns.Add("HorasDeVuelo", "Horas de Vuelo");
            dataGridView2.Columns.Add("Color", "Color");
            dataGridView2.Columns.Add("Modelo", "Modelo");
            dataGridView2.Columns.Add("CargasDeCombustible", "CargasDeCombustible");
            dataGridView2.Columns.Add("PorcentajeCombustibleActual", "PorcentajeCombustibleActual");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Textbox de Horas de Vuelo
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //No editar es una indicacion de la interfaz
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //No editar es una indicacion de la interfaz
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //No editar es una indicacion de la interfaz
        }

        private void button2_Click(object sender, EventArgs e) //Boton para añadir SpaceX con eventos privados
        {
            //Datos añadidos al Datagrid como columnas
            string dueño = textBox1.Text;
            int año = int.Parse(textBox3.Text);
            int horasDeVuelo = int.Parse(textBox4.Text);
            string color = textBox2.Text;
            string modelo = comboBox1.SelectedItem.ToString();

            SpaceX spacex = new SpaceX(año, dueño, horasDeVuelo, color, modelo); //Nueva Lista que hereda la anterior lista SpaceX y la completa con los datos ingresados

            //Variables que serviran para sacar las cargas de combustible y porcentaje actual del combustible
            int cargasDeCombustible;
            int porcentajeCombustibleActual;
            double resultado;

            if (modelo == "Starship") //Ciclo If Else ejecutandose si se cumple condicion (modelos SpaceX) para que analice la autonomia y el service en base a los parametros de cada modelo
            {
                Starship spacexStarship = new Starship(0, "", horasDeVuelo, "");
                cargasDeCombustible = horasDeVuelo / spacexStarship.Autonomia; //Cuenta para sacar cargas del combustible
                resultado = horasDeVuelo - (cargasDeCombustible * spacexStarship.Autonomia); // (1/2) Cuenta para sacar porcentaje actual del combustible
                porcentajeCombustibleActual = 100 - (int)((resultado / spacexStarship.Autonomia) * 100); // (2/2) Cuenta para sacar porcentaje actual del combustible
            }
            else if (modelo == "Falcon 9")
            {
                Falcon9 spacexFalcon9 = new Falcon9(0, "", horasDeVuelo, ""); 
                cargasDeCombustible = horasDeVuelo / spacexFalcon9.Autonomia; //Cuenta para sacar cargas del combustible
                resultado = horasDeVuelo - (cargasDeCombustible * spacexFalcon9.Autonomia); // (1/2) Cuenta para sacar porcentaje actual del combustible
                porcentajeCombustibleActual = 100 - (int)((resultado / spacexFalcon9.Autonomia) * 100); // (2/2) Cuenta para sacar porcentaje actual del combustible
            }
            else
            {
                return;
            }

            spacex.CargasDeCombustible = cargasDeCombustible; //Añade la carga de combustibles al DataGrid
            spacex.PorcentajeCombustibleActual = porcentajeCombustibleActual; //Añade el porcentaje actual del combustible al DataGrid
            listaSpaceX.Add(spacex); //Nueva lista con nuevos datos añadidos
            ActualizarDataGridView(); //Se carga al datagrid los nuevos datos

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //Codigo para seleccionar el modelo de la ComboBox
        {
            string modeloSeleccionado = comboBox1.SelectedItem.ToString();
        }

        private void LoadDataGrid() //Evento para que se cargen los datos al Datagrid
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = listaSpaceX;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Visualizacion de todos los SpaceX
        }

        private void ActualizarDataGridView()
        {
            dataGridView2.Rows.Clear(); //Codigo para limpiar filas existentes

            foreach (SpaceX spacex in listaSpaceX) //Busca los SpaceX junto a su informacion en base a este codigo
            {
                dataGridView2.Rows.Add(spacex.Dueño, spacex.Año, spacex.HorasDeVuelo, spacex.Color, spacex.Modelo, spacex.CargasDeCombustible, spacex.PorcentajeCombustibleActual);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Ciclo If para chequear si se selecciona una fila en el DataGrid
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Selecciona la fila desde la columna 0
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                // Obtiene el índice de la fila seleccionada
                int rowIndex = selectedRow.Index;

                // Elimina la fila seleccionada del DataGridView
                dataGridView2.Rows.RemoveAt(rowIndex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Verifica si hay una fila seleccionada en el DataGridView
            if (dataGridView2.SelectedRows.Count > 0)
            {
                //Selecciona una fila en este caso la 0 para mostar el dato en base al SpaceX de dicha fila
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                //Obtiene el dato ingresado de las Horas de Vuelo de cada SpaceX para usarlo como dato de ecuacion
                int horasDeVueloSpaceX = Convert.ToInt32(selectedRow.Cells["HorasDeVuelo"].Value);

                //Obtiene el modelo del SpaceX para saber que parametros aplicar
                string modeloSpaceX = selectedRow.Cells["Modelo"].Value.ToString();

                //Se crea una lista para los chequeos asi la utiliza para indicar en el message box
                List<string> chequeosRealizados = new List<string>();

                //Ciclo If Else para aplicar diferentes datos y variables en base al modelo y los parametros preestabelcidos
                if (modeloSpaceX == "Starship")
                {
                    Starship starship = new Starship(0, "", horasDeVueloSpaceX, "");
                    int numServices = horasDeVueloSpaceX / starship.Service; //Division entre los kilometros ingresados del SpaceX y las Horas de Vuelo del service por defecto para sacar la cantidad de services que se hicieron
                    MessageBox.Show($"SpaceX Starship - Horas de Vuelo: {horasDeVueloSpaceX}, Services realizados: {numServices}"); //Message Box para mostrar los services de la nave SpaceX
                    chequeosRealizados.Add($"Chequeos realizados:");
                }
                else if (modeloSpaceX == "Falcon 9")
                {
                    Falcon9 falcon9 = new Falcon9(0, "", horasDeVueloSpaceX, "");
                    int numServices = horasDeVueloSpaceX / falcon9.Service; //Division entre los kilometros ingresados del SpaceX y las Horas de Vuelo del service por defecto para sacar la cantidad de services que se hicieron
                    MessageBox.Show($"SpaceX Falcon 9 - Horas de Vuelo: {horasDeVueloSpaceX}, Services realizados: {numServices}"); //Message Box para mostrar los services de la nave SpaceX
                    chequeosRealizados.Add($"Chequeos realizados:");
                }

                //Nuevo ciclo If para comparar parametros y sacar los datos del chequeo
                if (horasDeVueloSpaceX >= ServiceSpaceX.ControlNavegacion)
                {
                    chequeosRealizados.Add("- Control de Navegación"); //Se añade los parametros a la lista de chequeos
                }

                if (horasDeVueloSpaceX >= ServiceSpaceX.ControlPropulsion) //Se añade los parametros a la lista de chequeos
                {
                    chequeosRealizados.Add("- Control de Propulsión");
                }

                //Muetra el MessageBox con los chequeos realizados
                MessageBox.Show(string.Join("\n", chequeosRealizados));
            }
        }

        private void button1_Click(object sender, EventArgs e) //Boton para cerrar pestaña
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Textbox de Dueño
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Textbox de Año
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Textbox de Color
        }
    }
}
