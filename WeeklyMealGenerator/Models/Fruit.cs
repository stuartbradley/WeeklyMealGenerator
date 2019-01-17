using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    [Table("Fruits")]
    public class Fruit : Java.Lang.Object, IShoppingItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfTimesPicked { get; private set; }

        [ManyToMany(typeof(ShoppingListFruit))]
        public List<ShoppingList> ShoppingLists { get; set; }

        public Fruit()
        {
            NumberOfTimesPicked = 0;
        }
        public void IncrementTimesPicked()
        {
            NumberOfTimesPicked++;
            SQLiteConnection db = new SQLiteConnection(Database.DataStore.DBPATH);
            db.Update(this);
        }


    }
}