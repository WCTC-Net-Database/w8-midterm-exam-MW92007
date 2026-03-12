using System.Collections.Generic;
using System.Linq;
using Attribute = ConsoleRpgEntities.Models.Attribute;

namespace ConsoleRpgEntities.Models
{
    /// <summary>
    /// Represents a player character in the RPG game.
    /// </summary>
    public class Player
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public int Level { get; set; }
        public AbilityScores AbilityScores { get; set; } = new();
        public List<Item> Items { get; set; } = new();

        public Player() { }

        public Player(string name, string profession, int level, List<Item> items, AbilityScores abilityScores = null)
        {
            Name = name;
            Profession = profession;
            Level = level;
            Items = items ?? new List<Item>();
            AbilityScores = abilityScores ?? new AbilityScores();
        }

        public override string ToString()
        {
            string itemList = Items != null && Items.Count > 0
                ? string.Join(", ", Items.Select(i => i.Name))
                : "None";
            return $"Name: {Name}\nProfession: {Profession}\nLevel: {Level}\nHealth: {AbilityScores.Health}\nHit Points: {AbilityScores.HitPoints}\nItems: {itemList}\nGold: {AbilityScores.Gold}";
        }
        // Returns the player's total attack value (base + equipped item bonuses).
        public int GetTotalAttack()
        {
            // TODO: For those NOT copying the LINQ code from the README.md:
            // Step-by-step guidance to calculate total attack:
            // 1. Start by calculating the player's base attack:
            //      int baseAttack = AbilityScores.Attack + Level;
            // 2. Initialize a variable to hold the total item attack bonus, e.g., int itemAttackBonus = 0;
            // 3. Loop through each item in the Items list:
            //      a. Check if the item is equipped (item.IsEquipped == true).
            //      b. Check if the item has AttributeModifiers and it contains an Attack bonus.
            //      c. If so, add the Attack bonus (item.AttributeModifiers[Attribute.Attack]) to itemAttackBonus.
            //         - Use TryGetValue to safely access the bonus if you are unsure if the key exists.
            // 4. Add baseAttack and itemAttackBonus together.
            // 5. Return the result.
            // If you prefer, you can use the LINQ code example from the README.md instead of this manual approach.
            return 42; // <-- Replace this with your calculation!
        }

        // Returns the player's total defense value (base + equipped item bonuses).
        public int GetTotalDefense()
        {
            // TODO: For those NOT copying the LINQ code from the README.md:
            // Step-by-step guidance to calculate total defense:
            // 1. Start by getting the player's base defense:
            //      int baseDefense = AbilityScores.Defense;
            // 2. Initialize a variable to hold the total item defense bonus, e.g., int itemDefenseBonus = 0;
            // 3. Loop through each item in the Items list:
            //      a. Check if the item is equipped (item.IsEquipped == true).
            //      b. Check if the item has AttributeModifiers and it contains a Defense bonus.
            //      c. If so, add the Defense bonus (item.AttributeModifiers[Attribute.Defense]) to itemDefenseBonus.
            //         - Use TryGetValue to safely access the bonus if you are unsure if the key exists.
            // 4. Add baseDefense and itemDefenseBonus together.
            // 5. Return the result.
            // If you prefer, you can use the LINQ code example from the README.md instead of this manual approach.
            return 24; // <-- Replace this with your calculation!
        }

    }
}
