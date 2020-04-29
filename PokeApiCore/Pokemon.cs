using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApiCore
{
    public class Pokemon
    {
        // Decimeter: 1 dm = 10cm = 100 mm = 3.937 in
        private const double InchesPerDecimeter = 3.9370;
        private const double PoundsPerHectogram = 0.22046;
        private int height1;
        private int weight1;

        /// <summary>
        /// Represents a single Pokemon
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// The base experience gained for defeating this Pokémon.
        /// </summary>
        public int base_experience { get; set; }

        /// <summary>
        /// The height of this Pokémon in decimetres.
        /// </summary>
        public int Height
        {
            get => (int)Math.Ceiling(height1 * InchesPerDecimeter); //height1 is an int, converting to inches produces double, math.ceiling returns double, then cast to (int)
            set => height1 = value;
        }

        /// <summary>
        /// Set for exactly one Pokémon used as the default for each species.
        /// </summary>
        public bool is_default { get; set; }
        public int order { get; set; }

        /// <summary>
        /// The weight of this Pokémon in hectograms.
        /// 1 hg = 100 g = 0.220462 lbs
        /// </summary>
        public int Weight
        { 
            get => (int)Math.Ceiling(weight1 * PoundsPerHectogram);
            set => weight1 = value; 
        }
        public Ability[] Abilities { get; set; }
        public Form[] forms { get; set; }
        public Game_Indices[] game_indices { get; set; }
        public Held_Items[] held_items { get; set; }
        public string location_area_encounters { get; set; }
        public Move[] moves { get; set; }
        public Species species { get; set; }
        public Sprites Sprites { get; set; }
        public Stat[] stats { get; set; }
        public Type[] types { get; set; }
    }

    public class Species
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Sprites
    {
        public string back_female { get; set; }
        public string back_shiny_female { get; set; }
        public string back_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny_female { get; set; }
        public string back_shiny { get; set; }

        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }
        public string front_shiny { get; set; }
    }

    public class Ability
    {
        public bool is_hidden { get; set; }
        public int slot { get; set; }
        public Ability1 ability { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Ability1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Form
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Game_Indices
    {
        public int game_index { get; set; }
        public Version version { get; set; }
    }

    public class Version
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Held_Items
    {
        public Item item { get; set; }
        public Version_Details[] version_details { get; set; }
    }

    public class Item
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Version_Details
    {
        public int rarity { get; set; }
        public Version1 version { get; set; }
    }

    public class Version1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Location_Area_Encounters
    {
        public Location_Area location_area { get; set; }
        public Version_Details1[] version_details { get; set; }
    }

    public class Location_Area
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Version_Details1
    {
        public int max_chance { get; set; }
        public Encounter_Details[] encounter_details { get; set; }
        public Version2 version { get; set; }
    }

    public class Version2
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Encounter_Details
    {
        public int min_level { get; set; }
        public int max_level { get; set; }
        public Condition_Values[] condition_values { get; set; }
        public int chance { get; set; }
        public Method method { get; set; }
    }

    public class Method
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Condition_Values
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Move
    {
        public Move1 move { get; set; }
        public Version_Group_Details[] version_group_details { get; set; }
    }

    public class Move1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Version_Group_Details
    {
        public int level_learned_at { get; set; }
        public Version_Group version_group { get; set; }
        public Move_Learn_Method move_learn_method { get; set; }
    }

    public class Version_Group
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Move_Learn_Method
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Stat
    {
        public int base_stat { get; set; }
        public int effort { get; set; }
        public Stat1 stat { get; set; }
    }

    public class Stat1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Type
    {
        public int slot { get; set; }
        public Type1 type { get; set; }
    }

    public class Type1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
