using System;

namespace Proyecto1
{
    public class ClienteModel : PersonaModel
    {
        public bool esVip { get; }
        public ClienteModel(int edad, string nombre, List<MascotaModel> mascota, bool esVip) : base(edad, nombre, mascota)
        {
            this.esVip = esVip;
        }
    }
}

