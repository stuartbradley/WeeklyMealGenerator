using SQLite;
using SQLiteNetExtensions.Attributes;

namespace WeeklyMealGenerator.Models
{
    [Table("ShoppingListMeals")]
    public class ShoppingListMeal
    {
        [ForeignKey(typeof(ShoppingList))]
        public int ShoppingListId { get; set; }

        [ForeignKey(typeof(Meal))]
        public int MealId { get; set; }
    }
}