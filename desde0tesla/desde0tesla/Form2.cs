using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace desde0tesla
{
    public partial class Form2 : Form
    {
        private List<Tesla> listaTesla = new List<Tesla>(); //Lista de Teslas para que sea aplicada en el Form

        public Form2() //Configuracion del Form
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; //Codigo para que no se escriba en la Combo Box
        }

        private void button1_Click(object sender, System.EventArgs e) //Boton para cerrar pestaña
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            //TextBox Dueño
        }

        private void textBox3_TextChanged(object sender, System.EventArgs e)
        {
            //TextBox Año
        }

        private void textBox4_TextChanged(object sender, System.EventArgs e)
        {
            //TextBox Kilometros
        }

        private void textBox2_TextChanged(object sender, System.EventArgs e)
        {
            //TextBox Color
        }

        private void label1_Click(object sender, System.EventArgs e)
        {
            //Indicacion, para que sepan como completar el textbox
        }

        private bool ValidarDatosIngresados() //Codigo para que tire un message box cuando se ingresan mal los datos
        {
            //Aca se validan si se pusieron o no palabras en los textbox de Dueño y Color
            if (!ValidarTextBoxPalabras(textBox1.Text) || !ValidarTextBoxPalabras(textBox2.Text))
            {
                return false;
            }

            //Aca se validan si se pusieron o no numeros en los textbox de Año y Kilometros
            if (!ValidarTextBoxNumeros(textBox3.Text) || !ValidarTextBoxNumeros(textBox4.Text))
            {
                return false;
            }

            return true;
        }

        private bool ValidarTextBoxPalabras(string texto) //Evento booleano para que el sistema detecte si se ingreso o no palabras
        {
            return !string.IsNullOrEmpty(texto) && texto.All(c => char.IsLetter(c) || c == ' ');
        }

        private bool ValidarTextBoxNumeros(string texto) //Evento booleano para que el sistema detecte si se ingreso o no numeros
        {
            return !string.IsNullOrEmpty(texto) && texto.All(char.IsDigit);
        }

        private bool ValidarComboBoxSeleccionado(System.Windows.Forms.ComboBox comboBox) //Evento booleano para que el sistema detecte si se selecciono o no un modelo de la Combo Box
        {
            return comboBox1.SelectedItem != null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //Codigo para seleccionar el modelo de la ComboBox
        {
            string modeloSeleccionado = comboBox1.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e) //Boton para añadir Teslas con eventos privados
        {
            if (!ValidarDatosIngresados()) //Ciclo If Else para que el message box muestre un mensaje en base a los eventos de validacion
            {
                if (!ValidarTextBoxPalabras(textBox1.Text) || !ValidarTextBoxPalabras(textBox2.Text))
                {
                    MessageBox.Show("Error: Fíjese si ingresó mal los datos en las casillas de Dueño del Vehículo o Color. Solo se aceptan palabras.");
                }
                else if (!ValidarTextBoxNumeros(textBox3.Text) || !ValidarTextBoxNumeros(textBox4.Text))
                {
                    MessageBox.Show("Error: Fíjese si ingresó mal los datos en las casillas de Año o Kilometraje. Solo se aceptan valores numéricos.");
                }

                if (!ValidarComboBoxSeleccionado(comboBox1)) //Declaracion para que tire mensaje de error si no se selecciona un modelo en la Combo Box
                {
                    MessageBox.Show("Error: No ha seleccionado el Modelo del Tesla para que sea registrado.");
                    return;
                }
            }

            //Datos añadidos al Datagrid como columnas
            string dueño = textBox1.Text;
            int año = int.Parse(textBox3.Text);
            int kilometros = int.Parse(textBox4.Text);
            string color = textBox2.Text;
            string modelo = comboBox1.SelectedItem.ToString();

            //Nueva Lista que hereda la anterior lista Tesla y la completa con los datos ingresados
            Tesla nuevoTesla = new Tesla(año, dueño, kilometros, color, modelo);

            //Variables que serviran para sacar las cargas de bateria y porcentaje actual de la bateria
            int cargasDeBateria;
            int porcentajeBateriaActual;
            double resultado;

            if (modelo == "Model X") //Ciclo If Else ejecutandose si se cumple condicion (modelos Tesla) para que analice la autonomia y el service en base a los parametros de cada modelo
            {
                Tesla.ModelX teslaModelX = new Tesla.ModelX(0, "", 0, "");
                cargasDeBateria = kilometros / teslaModelX.Autonomia; //Cuenta para sacar cargas de la bateria
                resultado = teslaModelX.Autonomia - (kilometros % teslaModelX.Autonomia); // (1/2) Cuenta para sacar porcentaje actual de la bateria
                porcentajeBateriaActual = (int)((resultado * 100.0) / teslaModelX.Autonomia); // (2/2) Cuenta para sacar porcentaje actual de la bateria
            }
            else if (modelo == "Model S")
            {
                Tesla.ModelS teslaModelS = new Tesla.ModelS(0, "", 0, "");
                cargasDeBateria = kilometros / teslaModelS.Autonomia;
                resultado = teslaModelS.Autonomia - (kilometros % teslaModelS.Autonomia); // (1/2) Cuenta para sacar porcentaje actual de la bateria
                porcentajeBateriaActual = (int)((resultado * 100.0) / teslaModelS.Autonomia); // (2/2) Cuenta para sacar porcentaje actual de la bateria
            }
            else if (modelo == "Cybertruck")
            {
                Tesla.Cybertruck teslaCybertruck = new Tesla.Cybertruck(0, "", 0, "");
                cargasDeBateria = kilometros / teslaCybertruck.Autonomia; //Cuenta para sacar cargas de la bateria
                resultado = teslaCybertruck.Autonomia - (kilometros % teslaCybertruck.Autonomia); // (1/2) Cuenta para sacar porcentaje actual de la bateria
                porcentajeBateriaActual = (int)((resultado * 100.0) / teslaCybertruck.Autonomia); // (2/2) Cuenta para sacar porcentaje actual de la bateria
            }
            else
            {
                return;
            }

            nuevoTesla.CargasDeBateria = cargasDeBateria; //Añade la carga de la bateria al DataGrid
            nuevoTesla.PorcentajeBateriaActual = porcentajeBateriaActual; //Añade el porcentaje actual de la bateria al DataGrid
            listaTesla.Add(nuevoTesla); //Nueva lista con nuevos datos añadidos
            LoadDataGrid(); //Se carga al datagrid los nuevos datos
        }

        private void LoadDataGrid() //Evento para que se cargen los datos al Datagrid
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = listaTesla;
            var porcentajeBateriaColumn = dataGridView2.Columns["PorcentajeBateriaActual"];
            if (porcentajeBateriaColumn != null)
            {
                porcentajeBateriaColumn.DefaultCellStyle.Format = "0'%'"; //Añade el "%" al resultado de la ecuacion del porcentaje de la bateria actual
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Visualizacion de todos los Tesla
        }

        private void ActualizarDataGridView()
        {
            dataGridView2.Rows.Clear(); //Codigo para limpiar filas existentes

            foreach (Tesla tesla in listaTesla) //Busca los tesla junto a su informacion en base a este codigo
            {
                dataGridView2.Rows.Add(tesla.Dueño, tesla.Año, tesla.Kilometros, tesla.Color, tesla.Modelo);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Ciclo If para chequear si se selecciona una fila en el DataGrid
            if (dataGridView2.SelectedRows.Count > 0)
            {
                //Selecciona la fila desde la columna 0
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                //Busca la columna Dueño en el Datagrid
                string dueño = selectedRow.Cells["Dueño"].Value.ToString();

                //Busca el tesla en base a la variable dueño previamente definida por la lista
                Tesla tesla = listaTesla.FirstOrDefault(t => t.Dueño == dueño);

                //Chequea si se encontro la variable Tesla
                if (tesla != null)
                {
                    //Elimina el Tesla de la lista
                    listaTesla.Remove(tesla);

                    //Vuelve a mostrar los datos del DataGrid
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = listaTesla;
                }
            }
        }
        private void button4_Click_1(object sender, EventArgs e) //Boton para mostrar el Tesla mas viejo
        {
            MostrarTeslaMasViejo();
        }

        private void MostrarTeslaMasViejo()
        {
            //Verificar si la lista de Tesla no esta vacia
            if (listaTesla.Count > 0)
            {
                //Ordenar la lista de Tesla en base al año en orden ascendente
                List<Tesla> teslasOrdenados = listaTesla.OrderBy(t => t.Año).ToList();

                //Obtiene el Tesla mas viejo (el dato numerico menor)
                Tesla teslaMasViejo = teslasOrdenados.First();

                //Muestra los detalles del Tesla mas viejo (Año, Dueño, Kilometros y Color)
                MessageBox.Show($"Dueño: {teslaMasViejo.Dueño}\nAño: {teslaMasViejo.Año}\nKilometros: {teslaMasViejo.Kilometros}\nColor: {teslaMasViejo.Color}");
            }
            else
            { //Message Box por si no hay Teslas en la lista para evitar errores
                MessageBox.Show("Error: No hay ningun Tesla registrado en la lista.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Verifica si hay una fila seleccionada en el DataGridView
            if (dataGridView2.SelectedRows.Count > 0)
            {
                //Selecciona una fila en este caso la 0 para mostar el dato en base al Tesla de dicha fila
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                //Obtiene el dato ingresado de los kilometros de cada Tesla para usarlo como dato de ecuacion
                int kilometrosTesla = Convert.ToInt32(selectedRow.Cells["Kilometros"].Value);

                //Obtiene el modelo del Tesla para saber que parametros aplicar
                string modeloTesla = selectedRow.Cells["Modelo"].Value.ToString();

                //Se crea una lista para los chequeos asi la utiliza para indicar en el message box
                List<string> chequeosRealizados = new List<string>();

                //Ciclo If Else para aplicar diferentes datos y variables en base al modelo y los parametros preestabelcidos
                if (modeloTesla == "Model X")
                {
                    Tesla.ModelX teslaModelX = new Tesla.ModelX(0, "", kilometrosTesla, "");
                    int numServices = kilometrosTesla / teslaModelX.Service; //Division entre los kilometros ingresados del Tesla y los kiloemtros del service por defecto para sacar la cantidad de services que se hiciron
                    MessageBox.Show($"Tesla Model X - Kilómetros: {kilometrosTesla}, Services realizados: {numServices}"); //Message Box para mostrar los services del auto Tesla
                    chequeosRealizados.Add($"Chequeos realizados:");

                }
                else if (modeloTesla == "Model S")
                {
                    Tesla.ModelS teslaModelS = new Tesla.ModelS(0, "", kilometrosTesla, "");
                    int numServices = kilometrosTesla / teslaModelS.Service; //Division entre los kilometros ingresados del Tesla y los kilometros del service por defecto para sacar la cantidad de services que se hicieron
                    MessageBox.Show($"Tesla Model S - Kilómetros: {kilometrosTesla}, Services realizados: {numServices}"); //Message Box para mostrar los services del auto Tesla
                    chequeosRealizados.Add($"Chequeos realizados:");

                }
                else if (modeloTesla == "Cybertruck")
                {
                    Tesla.Cybertruck teslaCybertruck = new Tesla.Cybertruck(0, "", kilometrosTesla, "");
                    int numServices = kilometrosTesla / teslaCybertruck.Service; //Division entre los kilometros ingresados del Tesla y los kilometros del service por defecto para sacar la cantidad de services que se hicieron
                    MessageBox.Show($"Tesla Cybertruck - Kilómetros: {kilometrosTesla}, Services realizados: {numServices}"); //Message Box para mostrar los services del auto Tesla
                    chequeosRealizados.Add($"Chequeos realizados:");

                }
                
                //Nuevo ciclo If para comparar parametros y sacar los datos del chequeo
                if (kilometrosTesla >= ServiceTesla.ControlCinturones)
                {
                    chequeosRealizados.Add("- Control de Cinturones de Seguridad"); //Se añade los parametros a la lista de chequeos
                }

                if (kilometrosTesla >= ServiceTesla.ControlBaterias)
                {
                    chequeosRealizados.Add("- Control de Baterías"); //Se añade los parametros a la lista de chequeos
                }

                if (kilometrosTesla >= ServiceTesla.ControlNavegacion)
                {
                    chequeosRealizados.Add("- Control del Sistema de Navegación"); //Se añade los parametros a la lista de chequeos
                }

                if (kilometrosTesla >= ServiceTesla.ControlTraccion)
                {
                    chequeosRealizados.Add("- Control del Sistema de Tracción"); //Se añade los parametros a la lista de chequeos
                }

                if (kilometrosTesla >= ServiceTesla.ControlMotor)
                {
                    chequeosRealizados.Add("- Control del Motor"); //Se añade los parametros a la lista de chequeos
                }

                //Muetra el MessageBox con los chequeos realizados
                MessageBox.Show(string.Join("\n", chequeosRealizados));
            } 
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //No editar es una indicacion de la interfaz
        }
    }
}