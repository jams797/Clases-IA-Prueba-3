using System;
namespace Proyecto1
{
	public class PersonaModel
	{
		public int edad { get; }
		public string nombre { get; }
		public List<MascotaModel> mascota { get; }


		public PersonaModel(int edad, string nombre, List<MascotaModel> mascota)
		{
			this.edad = edad;
            this.nombre = nombre;
			this.mascota = mascota;
        }
		/*
		public string getNombre()
		{
			return this.nombre;
		}

        public int getEdad()
        {
            return this.edad;
        }*/

		public bool esMayorEdad()
		{
			return edad >= 18;
		}
    }
}

