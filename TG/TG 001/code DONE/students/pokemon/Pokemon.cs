using System;
using System.Collections.Generic;

namespace exam
{
    public enum ElementType
    {
        Normal,
        Grass,
        Fire,
        Water,
        Ground,
        Electric,
        Rock,
        Steel,
        Ice,
        Flying,
        Poison,
        Bug,
        Fairy,
        Fighting,
        Psychic,
        Ghost,
        Dragon,
        None //Special value
    }
    public class PokemonType
    {
        uint id;
        public uint Id { get { return id; } }
        string name;
        public string Name { get { return name; } }
        ElementType[] types;
        public ElementType[] Types { get { return types; } }

        public PokemonType(uint id, string name, ElementType[] types)
        {
            this.id = id;
            this.name = name;
            this.types = types;
        }
    }
    
}
