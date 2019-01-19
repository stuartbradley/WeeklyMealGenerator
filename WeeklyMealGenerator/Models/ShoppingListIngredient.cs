using SQLite;
using SQLiteNetExtensions.Attributes;

namespace WeeklyMealGenerator.Models
{
    [Table("ShoppingListIngredients")]
    public class ShoppingListIngredient
    {
        [ForeignKey(typeof(ShoppingList))]
        public int ShoppingListId { get; set; }

        [ForeignKey(typeof(Ingredient))]
        public int IngredientId { get; set; }

        public bool PickedUp { get; set; }
    }
}