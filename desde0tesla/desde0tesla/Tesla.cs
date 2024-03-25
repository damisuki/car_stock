using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desde0tesla
{
    public class Tesla //Se crea la clase Tesla para poder ingresar los datos solicitados
    {
        public int Año { get; set; }
        public string Dueño { get; set; }
        public int Kilometros { get; set; }
        public string Color { get; set; }
        public string Modelo { get; set; }
        public int CargasDeBateria { get; set; } //Creado para la ecuacion de CargasDeBateria (KM/Tesla.Modelo.Service)
        public int PorcentajeBateriaActual { get; set; } //Creado para la ecuacion de PorcentajeBateriaActual (Dos ecuaciones)

        public static List<string> ModelosTesla { get; } = new List<string>() //Lista para el Combo Box y para igualar las subclases de modelos con los datos de la Combo Box
        {
        "Model X",
        "Model S",
        "Cybertruck"
        };

        public Tesla(int año, string dueño, int kilometros, string color, string modelo) //Lista Tesla con los datos que contiene
        {
            Año = año;
            Dueño = dueño;
            Kilometros = kilometros;
            Color = color;
            Modelo = modelo;
        }

        public class ModelX : Tesla //Subclase con los parametros en base al modelo X
        {
            public ModelX(int año, string dueño, int kilometros, string color) : base(año, dueño, kilometros, color, "Model X") //"Model X" puesto para que sea igualado al dato de la Combo Box
            {
                
                Autonomia = 560;
                Asientos = 7;
                Service = 1000;
            }

            public int Autonomia { get; }
            public int Asientos { get; }
            public int Service { get; }
        }

        public class ModelS : Tesla //Subclase con los parametros en base al modelo S
        {
            public ModelS(int año, string dueño, int kilometros, string color) : base(año, dueño, kilometros, color, "Model S") //"Model S" puesto para que sea igualado al dato de la Combo Box
            {

                Autonomia = 650;
                Asientos = 5;
                Service = 2000;
            }

            public int Autonomia { get; }
            public int Asientos { get; }
            public int Service { get; }
        }

        public class Cybertruck : Tesla //Subclase con los parametros en base al Cybertruck
        {
            public Cybertruck(int año, string dueño, int kilometros, string color) : base(año, dueño, kilometros, color, "Cybertruck") //"Cybertruck" puesto para que sea igualado al dato de la Combo Box
            {

                Autonomia = 800;
                Asientos = 6;
                Service = 3000;
            }

            public int Autonomia { get; }
            public int Asientos { get; }
            public int Service { get; }
        }
    }
}