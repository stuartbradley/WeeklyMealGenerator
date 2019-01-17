using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeeklyMealGenerator.Models
{
    [Table("Ingredients")]
    public class Ingredient : Java.Lang.Object, IShoppingItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        [ManyToMany(typeof(Recipe))]
        public List<Meal> Meals { get; set; }

        [ManyToMany(typeof(ShoppingListIngredient))]
        public List<ShoppingList> ShoppingLists { get; set; }


    }
}