using System;
namespace Proyecto1
{
	public class MascotaModel
	{
        public enum TipoMascota
        {
            Perro,
            Gato
        };

        public string nombre { get; }
        public TipoMascota tipo { get; }
        public MascotaModel(string nombre, TipoMascota tipo)
		{
			this.nombre = nombre;
            this.tipo = tipo;
        }
	}
}

