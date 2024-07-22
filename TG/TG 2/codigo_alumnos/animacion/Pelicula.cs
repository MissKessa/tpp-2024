using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Lab12.Modelo
{
	public class Pelicula
	{
		public string Nombre { get; private set; }
		public bool Saga { get; private set; }
		public IList<Personaje> Personajes { get; private set; }

		public Pelicula(string nombre, IList<Personaje> personajes, bool saga = false)
		{
			this.Nombre = nombre;
			this.Personajes = personajes;
			this.Saga = saga;
		}

		public override string ToString()
		{
			return string.Format("[Pelicula: {0} Saga? {1}, con {2} personajes]", this.Nombre, this.Saga, this.Personajes.Count);
		}
	}
}
