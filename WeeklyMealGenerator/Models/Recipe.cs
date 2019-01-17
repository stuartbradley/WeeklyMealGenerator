using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace WeeklyMealGenerator.Models
{
    [Table("Recipes")]
    public class Recipe
    {
        [ForeignKey(typeof(Meal))]
        public int MealId { get; set; }

        [ForeignKey(typeof(Ingredient))]
        public int IngredientId { get; set; }
    }
}