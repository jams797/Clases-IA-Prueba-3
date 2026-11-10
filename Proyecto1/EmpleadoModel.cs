using System;

namespace Proyecto1
{
    public class EmpleadoModel : PersonaModel
    {
        public double sueldo { get; }
        public EmpleadoModel(int edad, string nombre, List<MascotaModel> mascota, double sueldo) : base(edad, nombre, mascota)
        {
            this.sueldo = sueldo;
        }

        static public void calcularProceso(double sueldo)
        {
            if (sueldo >= 480)
            {
                Console.WriteLine("Mayor al basico");
            } else
            {
                Console.WriteLine("Menor al basico");
            }
        }

    }



}

