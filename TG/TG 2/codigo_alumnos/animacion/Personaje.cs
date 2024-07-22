using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Lab12.Modelo
{
    public class Personaje
    {
		public string Nombre { get; set; }
		public bool EsAnimal { get; set; }
		public bool Habla { get; set; }

		public override string ToString()
		{
			return string.Format("[Personaje: {0} Animal? {1}, Habla? {2}]", this.Nombre, this.EsAnimal, this.Habla);
		}
	}
}
