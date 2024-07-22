using System;
using System.Collections.Generic;
using System.Linq;

namespace exam
{

    public static class PokemonUtils
    { 

        private static PokemonType[] pokemons = null;
        public static IEnumerable<PokemonType> Pokemons { get { return pokemons; } }

        public static void InitializePokemons()
        {
            IList<PokemonType> gen1 = new List<PokemonType>();
            gen1.Add(new PokemonType(0, "Egg", new ElementType[] { ElementType.None }));
            gen1.Add(new PokemonType(1, "Bulbasaur", new ElementType[] { ElementType.Grass, ElementType.Poison }));
            gen1.Add(new PokemonType(2, "Ivysaur", new ElementType[] { ElementType.Grass, ElementType.Poison }));
            gen1.Add(new PokemonType(3, "Venusaur", new ElementType[] { ElementType.Grass, ElementType.Poison }));
            gen1.Add(new PokemonType(4, "Charmander", new ElementType[] { ElementType.Fire }));
            gen1.Add(new PokemonType(5, "Charmeleon", new ElementType[] { ElementType.Fire }));
            gen1.Add(new PokemonType(6, "Charizard", new ElementType[] { ElementType.Fire, ElementType.Flying }));
            gen1.Add(new PokemonType(7, "Squirtle", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(8, "Wartortle", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(9, "Blastoise", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(0, "Caterpie", new ElementType[] { ElementType.Bug }));
            gen1.Add(new PokemonType(11, "Metapod", new ElementType[] { ElementType.Bug }));
            gen1.Add(new PokemonType(12, "Butterfree", new ElementType[] { ElementType.Bug, ElementType.Flying }));
            gen1.Add(new PokemonType(13, "Weedle", new ElementType[] { ElementType.Bug, ElementType.Poison }));
            gen1.Add(new PokemonType(14, "Kakuna", new ElementType[] { ElementType.Bug, ElementType.Poison }));
            gen1.Add(new PokemonType(15, "Beedrill", new ElementType[] { ElementType.Bug, ElementType.Poison }));
            gen1.Add(new PokemonType(16, "Pidgey", new ElementType[] { ElementType.Normal, ElementType.Flying }));
            gen1.Add(new PokemonType(17, "Pidgeotto", new ElementType[] { ElementType.Normal, ElementType.Flying }));
            gen1.Add(new PokemonType(18, "Pidgeot", new ElementType[] { ElementType.Normal, ElementType.Flying }));
            gen1.Add(new PokemonType(19, "Rattata", new ElementType[] { ElementType.Normal }));
            gen1.Add(new PokemonType(20, "Raticate", new ElementType[] { ElementType.Normal }));
            gen1.Add(new PokemonType(21, "Spearow", new ElementType[] { ElementType.Normal, ElementType.Flying }));
            gen1.Add(new PokemonType(22, "Fearow", new ElementType[] { ElementType.Normal, ElementType.Flying }));
            gen1.Add(new PokemonType(23, "Ekans", new ElementType[] { ElementType.Poison }));
            gen1.Add(new PokemonType(24, "Arbok", new ElementType[] { ElementType.Poison }));
            gen1.Add(new PokemonType(25, "Pikachu", new ElementType[] { ElementType.Electric }));
            gen1.Add(new PokemonType(26, "Raichu", new ElementType[] { ElementType.Electric }));
            gen1.Add(new PokemonType(27, "Sandshrew", new ElementType[] { ElementType.Ground }));
            gen1.Add(new PokemonType(28, "Sandslash", new ElementType[] { ElementType.Ground }));
            gen1.Add(new PokemonType(29, "Nidoran_Female", new ElementType[] { ElementType.Poison }));
            gen1.Add(new PokemonType(30, "Nidorina", new ElementType[] { ElementType.Poison }));
            gen1.Add(new PokemonType(31, "Nidoqueen", new ElementType[] { ElementType.Poison, ElementType.Ground }));
            gen1.Add(new PokemonType(32, "Nidoran_Male", new ElementType[] { ElementType.Poison }));
            gen1.Add(new PokemonType(33, "Nidorino", new ElementType[] { ElementType.Poison }));
            gen1.Add(new PokemonType(34, "Nidoking", new ElementType[] { ElementType.Poison, ElementType.Ground }));
            gen1.Add(new PokemonType(35, "Clefairy", new ElementType[] { ElementType.Fairy }));
            gen1.Add(new PokemonType(36, "Clefable", new ElementType[] { ElementType.Fairy }));
            gen1.Add(new PokemonType(37, "Vulpix", new ElementType[] { ElementType.Fire }));
            gen1.Add(new PokemonType(38, "Ninetales", new ElementType[] { ElementType.Fire }));
            gen1.Add(new PokemonType(39, "Jigglypuff", new ElementType[] { ElementType.Normal, ElementType.Fairy }));
            gen1.Add(new PokemonType(40, "Wigglytuff", new ElementType[] { ElementType.Normal, ElementType.Fairy }));
            gen1.Add(new PokemonType(41, "Zubat", new ElementType[] { ElementType.Poison, ElementType.Flying }));
            gen1.Add(new PokemonType(42, "Golbat", new ElementType[] { ElementType.Poison, ElementType.Flying }));
            gen1.Add(new PokemonType(43, "Oddish", new ElementType[] { ElementType.Grass, ElementType.Poison }));
            gen1.Add(new PokemonType(44, "Gloom", new ElementType[] { ElementType.Grass, ElementType.Poison }));
            gen1.Add(new PokemonType(45, "Vileplume", new ElementType[] { ElementType.Grass, ElementType.Poison }));
            gen1.Add(new PokemonType(46, "Paras", new ElementType[] { ElementType.Bug, ElementType.Grass }));
            gen1.Add(new PokemonType(47, "Parasect", new ElementType[] { ElementType.Bug, ElementType.Grass }));
            gen1.Add(new PokemonType(48, "Venonat", new ElementType[] { ElementType.Bug, ElementType.Poison }));
            gen1.Add(new PokemonType(49, "Venomoth", new ElementType[] { ElementType.Bug, ElementType.Poison }));
            gen1.Add(new PokemonType(50, "Diglett", new ElementType[] { ElementType.Ground }));
            gen1.Add(new PokemonType(51, "Dugtrio", new ElementType[] { ElementType.Ground }));
            gen1.Add(new PokemonType(52, "Meowth", new ElementType[] { ElementType.Normal }));
            gen1.Add(new PokemonType(53, "Persian", new ElementType[] { ElementType.Normal }));
            gen1.Add(new PokemonType(54, "Psyduck", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(55, "Golduck", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(56, "Mankey", new ElementType[] { ElementType.Fighting }));
            gen1.Add(new PokemonType(57, "Primeape", new ElementType[] { ElementType.Fighting }));
            gen1.Add(new PokemonType(58, "Growlithe", new ElementType[] { ElementType.Fire }));
            gen1.Add(new PokemonType(59, "Arcanine", new ElementType[] { ElementType.Fire }));
            gen1.Add(new PokemonType(60, "Poliwag", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(61, "Poliwhirl", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(62, "Poliwrath", new ElementType[] { ElementType.Water, ElementType.Fighting}));
            gen1.Add(new PokemonType(63, "Abra", new ElementType[] {ElementType.Psychic}));
            gen1.Add(new PokemonType(64, "Kadabra", new ElementType[] {ElementType.Psychic}));
            gen1.Add(new PokemonType(65, "Alakazam", new ElementType[] { ElementType.Psychic }));
            gen1.Add(new PokemonType(66, "Machop", new ElementType[] { ElementType.Fighting }));
            gen1.Add(new PokemonType(67, "Machoke", new ElementType[] { ElementType.Fighting }));
            gen1.Add(new PokemonType(68, "Machamp", new ElementType[] { ElementType.Fighting }));
            gen1.Add(new PokemonType(69, "Bellsprout", new ElementType[] { ElementType.Grass, ElementType.Poison }));
            gen1.Add(new PokemonType(70, "Weepinbell", new ElementType[] { ElementType.Grass, ElementType.Poison }));
            gen1.Add(new PokemonType(71, "Victreebel", new ElementType[] { ElementType.Grass, ElementType.Poison }));
            gen1.Add(new PokemonType(72, "Tentacool", new ElementType[] { ElementType.Water, ElementType.Poison }));
            gen1.Add(new PokemonType(73, "Tentacruel", new ElementType[] { ElementType.Water, ElementType.Poison }));
            gen1.Add(new PokemonType(74, "Geodude", new ElementType[] { ElementType.Rock, ElementType.Ground }));
            gen1.Add(new PokemonType(75, "Graveler", new ElementType[] { ElementType.Rock, ElementType.Ground }));
            gen1.Add(new PokemonType(76, "Golem", new ElementType[] { ElementType.Rock, ElementType.Ground }));
            gen1.Add(new PokemonType(77, "Ponyta", new ElementType[] { ElementType.Fire }));
            gen1.Add(new PokemonType(78, "Rapidash", new ElementType[] { ElementType.Fire }));
            gen1.Add(new PokemonType(79, "Slowpoke", new ElementType[] { ElementType.Water, ElementType.Psychic }));
            gen1.Add(new PokemonType(80, "Slowbro", new ElementType[] { ElementType.Water, ElementType.Psychic }));
            gen1.Add(new PokemonType(81, "Magnemite", new ElementType[] { ElementType.Electric, ElementType.Steel }));
            gen1.Add(new PokemonType(82, "Magneton", new ElementType[] { ElementType.Electric, ElementType.Steel }));
            gen1.Add(new PokemonType(83, "Farfetch’d", new ElementType[] { ElementType.Normal, ElementType.Flying }));
            gen1.Add(new PokemonType(84, "Doduo", new ElementType[] { ElementType.Normal, ElementType.Flying }));
            gen1.Add(new PokemonType(85, "Dodrio", new ElementType[] { ElementType.Normal, ElementType.Flying }));
            gen1.Add(new PokemonType(86, "Seel", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(87, "Dewgong", new ElementType[] { ElementType.Water, ElementType.Ice }));
            gen1.Add(new PokemonType(88, "Grimer", new ElementType[] { ElementType.Poison }));
            gen1.Add(new PokemonType(89, "Muk", new ElementType[] { ElementType.Poison }));
            gen1.Add(new PokemonType(90, "Shellder", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(91, "Cloyster", new ElementType[] { ElementType.Water, ElementType.Ice }));
            gen1.Add(new PokemonType(92, "Gastly", new ElementType[] { ElementType.Ghost, ElementType.Poison }));
            gen1.Add(new PokemonType(93, "Haunter", new ElementType[] { ElementType.Ghost, ElementType.Poison }));
            gen1.Add(new PokemonType(94, "Gengar", new ElementType[] { ElementType.Ghost, ElementType.Poison }));
            gen1.Add(new PokemonType(95, "Onix", new ElementType[] { ElementType.Rock, ElementType.Ground }));
            gen1.Add(new PokemonType(96, "Drowzee", new ElementType[] { ElementType.Psychic }));
            gen1.Add(new PokemonType(97, "Hypno", new ElementType[] { ElementType.Psychic }));
            gen1.Add(new PokemonType(98, "Krabby", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(99, "Kingler", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(100, "Voltorb", new ElementType[] { ElementType.Electric }));
            gen1.Add(new PokemonType(101, "Electrode", new ElementType[] { ElementType.Electric }));
            gen1.Add(new PokemonType(102, "Exeggcute", new ElementType[] { ElementType.Grass, ElementType.Psychic }));
            gen1.Add(new PokemonType(103, "Exeggutor", new ElementType[] { ElementType.Grass, ElementType.Psychic }));
            gen1.Add(new PokemonType(104, "Cubone", new ElementType[] { ElementType.Ground }));
            gen1.Add(new PokemonType(105, "Marowak", new ElementType[] { ElementType.Ground }));
            gen1.Add(new PokemonType(106, "Hitmonlee", new ElementType[] { ElementType.Fighting }));
            gen1.Add(new PokemonType(107, "Hitmonchan", new ElementType[] { ElementType.Fighting }));
            gen1.Add(new PokemonType(108, "Lickitung", new ElementType[] { ElementType.Normal }));
            gen1.Add(new PokemonType(109, "Koffing", new ElementType[] { ElementType.Poison }));
            gen1.Add(new PokemonType(110, "Weezing", new ElementType[] { ElementType.Poison }));
            gen1.Add(new PokemonType(111, "Rhyhorn", new ElementType[] { ElementType.Ground, ElementType.Rock }));
            gen1.Add(new PokemonType(112, "Rhydon", new ElementType[] { ElementType.Ground, ElementType.Rock }));
            gen1.Add(new PokemonType(113, "Chansey", new ElementType[] { ElementType.Normal }));
            gen1.Add(new PokemonType(114, "Tangela", new ElementType[] { ElementType.Grass }));
            gen1.Add(new PokemonType(115, "Kangaskhan", new ElementType[] { ElementType.Normal }));
            gen1.Add(new PokemonType(116, "Horsea", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(117, "Seadra", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(118, "Goldeen", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(119, "Seaking", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(120, "Staryu", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(121, "Starmie", new ElementType[] { ElementType.Water, ElementType.Psychic }));
            gen1.Add(new PokemonType(122, "Mr. Mime", new ElementType[] { ElementType.Psychic, ElementType.Fairy }));
            gen1.Add(new PokemonType(123, "Scyther", new ElementType[] { ElementType.Bug, ElementType.Flying }));
            gen1.Add(new PokemonType(124, "Jynx", new ElementType[] { ElementType.Ice, ElementType.Psychic }));
            gen1.Add(new PokemonType(125, "Electabuzz", new ElementType[] { ElementType.Electric }));
            gen1.Add(new PokemonType(126, "Magmar", new ElementType[] { ElementType.Fire }));
            gen1.Add(new PokemonType(127, "Pinsir", new ElementType[] { ElementType.Bug }));
            gen1.Add(new PokemonType(128, "Tauros", new ElementType[] { ElementType.Normal }));
            gen1.Add(new PokemonType(129, "Magikarp", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(130, "Gyarados", new ElementType[] { ElementType.Water, ElementType.Flying }));
            gen1.Add(new PokemonType(131, "Lapras", new ElementType[] { ElementType.Water, ElementType.Ice }));
            gen1.Add(new PokemonType(132, "Ditto", new ElementType[] { ElementType.Normal }));
            gen1.Add(new PokemonType(133, "Eevee", new ElementType[] { ElementType.Normal }));
            gen1.Add(new PokemonType(134, "Vaporeon", new ElementType[] { ElementType.Water }));
            gen1.Add(new PokemonType(135, "Jolteon", new ElementType[] { ElementType.Electric }));
            gen1.Add(new PokemonType(136, "Flareon", new ElementType[] { ElementType.Fire }));
            gen1.Add(new PokemonType(137, "Porygon", new ElementType[] { ElementType.Normal }));
            gen1.Add(new PokemonType(138, "Omanyte", new ElementType[] { ElementType.Rock, ElementType.Water }));
            gen1.Add(new PokemonType(139, "Omastar", new ElementType[] { ElementType.Rock, ElementType.Water }));
            gen1.Add(new PokemonType(140, "Kabuto", new ElementType[] { ElementType.Rock, ElementType.Water }));
            gen1.Add(new PokemonType(141, "Kabutops", new ElementType[] { ElementType.Rock, ElementType.Water }));
            gen1.Add(new PokemonType(142, "Aerodactyl", new ElementType[] { ElementType.Rock, ElementType.Flying }));
            gen1.Add(new PokemonType(143, "Snorlax", new ElementType[] { ElementType.Normal }));
            gen1.Add(new PokemonType(144, "Articuno", new ElementType[] { ElementType.Ice, ElementType.Flying }));
            gen1.Add(new PokemonType(145, "Zapdos", new ElementType[] { ElementType.Electric, ElementType.Flying }));
            gen1.Add(new PokemonType(146, "Moltres", new ElementType[] { ElementType.Fire, ElementType.Flying }));
            gen1.Add(new PokemonType(147, "Dratini", new ElementType[] { ElementType.Dragon }));
            gen1.Add(new PokemonType(148, "Dragonair", new ElementType[] { ElementType.Dragon }));
            gen1.Add(new PokemonType(149, "Dragonite", new ElementType[] { ElementType.Dragon, ElementType.Flying }));
            gen1.Add(new PokemonType(150, "Mewtwo", new ElementType[] { ElementType.Psychic }));
            gen1.Add(new PokemonType(151, "Mew", new ElementType[] { ElementType.Psychic }));
            pokemons = gen1.ToArray();
        }
        
        static PokemonUtils()
        {
            InitializePokemons();
     
        }

    
    }
}