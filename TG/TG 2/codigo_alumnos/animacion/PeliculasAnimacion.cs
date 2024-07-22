using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Lab12.Modelo
{
	public class PeliculasAnimacion
	{
		public IList<Personaje> Personajes { get { return personajes; } }
		public IList<Pelicula> Peliculas { get { return peliculas; } }

		static PeliculasAnimacion()
		{
			ResetModel();
		}

		static void ResetModel()
		{
			personajes = new List<Personaje>()
			{
				new Personaje() { Nombre = "Simba", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Nala", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Pumba", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Timón", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Zazú", EsAnimal = true, Habla = true },

				new Personaje() { Nombre = "Bella", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Bestia", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Lumiere", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Chip", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Din Don", EsAnimal = false, Habla = true },

				new Personaje() { Nombre = "Ariel", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Sebastián", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Flounder", EsAnimal = true, Habla = true },

				new Personaje() { Nombre = "Nemo", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Dory", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Marlin", EsAnimal = true, Habla = true },

				new Personaje() { Nombre = "Woody", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Buzz", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Jessie", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Señor Portato", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Lotso", EsAnimal = true, Habla = true },

				new Personaje() { Nombre = "Russel", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Carl Fredricksen", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Dug", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Kevin", EsAnimal = true, Habla = false },

				new Personaje() { Nombre = "Wall-E", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "EVA", EsAnimal = false, Habla = true },

				new Personaje() { Nombre = "Tiana", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Naveen", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Ray", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Louis", EsAnimal = true, Habla = true },

				new Personaje() { Nombre = "Vaiana", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Maui", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Hei hei", EsAnimal = true, Habla = false },
				new Personaje() { Nombre = "Pua", EsAnimal = true, Habla = false },
				new Personaje() { Nombre = "Te Fiti", EsAnimal = false, Habla = false },

				new Personaje() { Nombre = "Elsa", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Anna", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Kristoff", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Sven", EsAnimal = true, Habla = false },
				new Personaje() { Nombre = "Olaf", EsAnimal = false, Habla = true },

				new Personaje() { Nombre = "Rayo McQueen", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Mate", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Sally", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Doc Hudson", EsAnimal = false, Habla = true },

				new Personaje() { Nombre = "Gru", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Agnes", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Doc Margo", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Edith", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Stuard", EsAnimal = false, Habla = false },
				new Personaje() { Nombre = "Dave", EsAnimal = false, Habla = true },
				new Personaje() { Nombre = "Bob", EsAnimal = false, Habla = true },

				new Personaje() { Nombre = "Manny", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Diego", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Sid", EsAnimal = true, Habla = true },
				new Personaje() { Nombre = "Scrat", EsAnimal = true, Habla = false }
			};

			peliculas = new List<Pelicula>()
			{
				new Pelicula("El rey Leon", personajes.GetRange(0, 5), true),
				new Pelicula("La bella y la bestia", personajes.GetRange(5, 5), true),
				new Pelicula("La sirenita", personajes.GetRange(10, 3), true),
				new Pelicula("Buscando a Nemo", personajes.GetRange(13, 3)),
				new Pelicula("Toy Story", personajes.GetRange(16, 5), true),
				new Pelicula("Up", personajes.GetRange(21, 4)),
				new Pelicula("Wall-e", personajes.GetRange(25, 2)),
				new Pelicula("Tiana y el sapo", personajes.GetRange(27, 4)),
				new Pelicula("Vaiana", personajes.GetRange(31, 5)),
				new Pelicula("Frozen", personajes.GetRange(36, 5)),
				new Pelicula("Cars", personajes.GetRange(41, 4), true),
				new Pelicula("Gru", personajes.GetRange(45, 7), true),
				new Pelicula("Ice Age", personajes.GetRange(52, 4), true)
			};
		}

		private static List<Personaje> personajes;
		private static List<Pelicula> peliculas;

		
	}
}

