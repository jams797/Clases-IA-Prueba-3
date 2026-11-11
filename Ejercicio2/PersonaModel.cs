using System;
namespace Ejercicio2
{
	public class PersonaModel
	{
        public string nombre { get; }
        public int edad { get; }
        public PersonaModel(string nombre, int edad)
		{
			this.nombre = nombre;
			this.edad = edad;
		}
	}
}

