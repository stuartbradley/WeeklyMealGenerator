using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;


namespace WeeklyMealGenerator.Models
{
    [Table("Meals")]
    public class Meal: Java.Lang.Object,IShoppingItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }  
        
        [ManyToMany(typeof(Recipe))]
        public List<Ingredient> Ingredients { get; set; }

        public override string ToString()
        {
            return Name;
        }

        //[ManyToMany(typeof(WeeklyMenuMeal))]
        //public List<WeeklyMenu> WeeklyMenus { get; set; }
    }
}