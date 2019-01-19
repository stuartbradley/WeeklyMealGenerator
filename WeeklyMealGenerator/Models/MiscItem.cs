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
    public class MiscItem : Java.Lang.Object, IShoppingItem
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        [ManyToMany(typeof(ShoppingListMiscItems))]
        public List<ShoppingList> ShoppingLists { get; set; }
    }
}