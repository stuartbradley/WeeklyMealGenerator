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
    public class ShoppingList
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        //[ManyToMany(typeof(ShoppingListMeal))]
        //public List<Meal> Meals { get; set; }

        [ManyToMany(typeof(ShoppingListFruit))]
        public List<Fruit> Fruits { get; set; }

        [ManyToMany(typeof(ShoppingListIngredient))]
        public List<Ingredient> Ingredients { get; set; }

        [ManyToMany(typeof(ShoppingListMiscItems))]
        public List<MiscItem> MiscItems { get; set; }

    }
}