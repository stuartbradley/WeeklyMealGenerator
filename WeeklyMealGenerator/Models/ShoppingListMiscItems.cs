﻿using System;
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
    [Table("ShoppingListMeals")]
    public class ShoppingListMiscItems
    {
        [ForeignKey(typeof(ShoppingList))]
        public int ShoppingListId { get; set; }

        [ForeignKey(typeof(Meal))]
        public int MealId { get; set; }
    }
}