using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace desde0tesla
{
    public class SpaceX //Se crea la clase SpaceX para poder ingresar los datos solicitados
    {
        public int Año { get; set; }
        public string Dueño { get; set; }
        public int HorasDeVuelo { get; set; } //HDV
        public string Color { get; set; }
        public string Modelo { get; set; }
        public int CargasDeCombustible { get; set; } //Creado para la ecuacion de CargasDeCombustible (HDV/SpaceX.Modelo.Service)
        public int PorcentajeCombustibleActual { get; set; } //Creado para la ecuacion de PorcentajeCombustibleActual (Dos ecuaciones)


        public SpaceX(int año, string dueño, int horasdevuelo, string color, string modelo) //Lista SpaceX con los datos que contiene
        {
            Año = año;
            Dueño = dueño;
            HorasDeVuelo = horasdevuelo;
            Color = color;
            Modelo = modelo;
        }
    }

    public static class SpaceXModels
    {
        public static List<string> ModelosSpaceX { get; } = new List<string>() //Lista para el Combo Box y para igualar las subclases de modelos con los datos de la Combo Box
        {
            "Starship",
            "Falcon 9"
        };
    }

    public class Starship : SpaceX //Subclase con los parametros en base al modelo Starship
    {
        public Starship(int año, string dueño, int horasdevuelo, string color) : base(año, dueño, horasdevuelo, color, "Starship") //"Starship" puesto para que sea igualado al dato de la Combo Box
        {
            Autonomia = 500;
            Service = 1000;
            ControlNavegacion = 500;
            ControlPropulsion = 1000;
        }

        public int Autonomia { get; }
        public int Service { get; }
        public int ControlNavegacion { get; }
        public int ControlPropulsion { get; }
    }

    public class Falcon9 : SpaceX //Subclase con los parametros en base al modelo Falcon 9
    {
        public Falcon9(int año, string dueño, int horasdevuelo, string color) : base(año, dueño, horasdevuelo, color, "Falcon 9") //"Falcon 9" puesto para que sea igualado al dato de la Combo Box
        {
            Autonomia = 200;
            Service = 400;
            ControlNavegacion = 200;
            ControlPropulsion = 400;
        }

        public int Autonomia { get; }
        public int Service { get; }
        public int ControlNavegacion { get; }
        public int ControlPropulsion { get; }
    }
}

