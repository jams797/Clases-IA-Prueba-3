using System;
namespace Ejercicio2
{
	public class PersonaModel
	{
        public string nombre { get; }
        public int edad { get; }
		public string id { get; }
        public double sueldo { get; }
        public PersonaModel(string nombre, int edad, double sueldo)
		{
            this.id = Guid.NewGuid().ToString();
            this.nombre = nombre;
			this.edad = edad;
			this.sueldo = sueldo;
		}
	}
}

