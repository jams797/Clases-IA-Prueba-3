using System;
namespace Ejercicio2
{
	public class PersonaModel
	{
        public string nombre { get; }
        public int edad { get; }
		public string id { get; }
        public PersonaModel(string nombre, int edad)
		{
            this.id = Guid.NewGuid().ToString();
            this.nombre = nombre;
			this.edad = edad;
		}
	}
}

