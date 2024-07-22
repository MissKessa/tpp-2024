using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace exam.run
{
    internal class Program
    {
        //Implement a new generator method.It returns a collection of 5 random PokemonType
        //instances (no repetitions in the collection of 5 instances are allowed). Those
        //instances should fulfill a requirement expressed as a parameter function
        static IEnumerable<PokemonType> generator(Predicate<PokemonType> p) { //my solution
            ISet <PokemonType> res = new HashSet<PokemonType>(); //maybe need to implement the Equals in PokemonType
            foreach (var pokemon in PokemonUtils.Pokemons) {
                if (p(pokemon))
                {
                    yield return pokemon;
                    res.Add(pokemon);
                }
                if (res.Count() == 5) yield break;
            }
        }

        static IEnumerable<PokemonType> randomGenerator(Predicate<PokemonType> p)
        { //my solution
            ISet<PokemonType> res = new HashSet<PokemonType>(); //maybe need to implement the Equals in PokemonType
            Random rnd = new Random();
            while (true) 
            {
                int pos=rnd.Next(0, PokemonUtils.Pokemons.Count());
                var pokemon = PokemonUtils.Pokemons.ElementAt(pos);

                if (p(pokemon)) {
                    yield return pokemon;
                    res.Add(pokemon);
                }
                if (res.Count() == 5) yield break;
            }
        }

        //In this solution the ElementType cannot be repeated
        //Random pokemon types with no repetition in the ElementType
        //Could not copy his whole solution so I left it commented
        //public static IEnumerable<PokemonType> MyGenerator(Predicate<PokemonType> pred) { //class solution
        //    Random rnd = new Random();
        //    ISet<ElementType> generated = new HashSet<ElementType>();
        //    var pokemons = PokemonUtils.Pokemons.Where((x)=>pred(x));
        //    for (int i = 0; i < 5; i++) {
        //        var candidates = pokemons.Where(p => p.Types.All(t => generated.Contains(t))).ToArray();
        //        var newPokemon = candidates.ElementAt(rnd.Next(candidates.Length));
        //        newPokemon.Types.Select(x => generated.Add).toList();
        //        yield return newPokemon;
        //    }
        //    yield break;
        //}

        static void Main(string[] args)
        {
            //Using this new generator, define an expression or method to generate PokemonTypes with ElementType not Water
            //Predicate<PokemonType> p = (x) => x.Types.Any(z => !z.Equals(ElementType.Water)); //== also valid
            Predicate<PokemonType> p = (x) => !x.Types.Contains(ElementType.Water);
            foreach (var pokemon in randomGenerator(p))
            {
                Console.Write("Pokemon {0}: elements ", pokemon.Name);
                foreach (var type in pokemon.Types)
                        Console.Write("{0} ", type);
                Console.WriteLine();
            }
            //He checked my solution and he gave it as correct right

            //Class program for class solution
            //Console.WriteLine(PokemonUtils.Pokemons.Count());
            //foreach (var p in MyGenerator(x=> x.Name.Length < 6))
        }

    }
}
