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
using WeeklyMealGenerator.Adapters;
using SQLiteNetExtensions.Extensions;
using WeeklyMealGenerator.Models;

namespace WeeklyMealGenerator.Activities
{
    [Activity(Label = "ViewShoppingListActivity")]
    public class ViewShoppingListActivity : Activity
    {
        ListView listView;
        ThreeTextAdapter listAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ViewShoppingLists);
            var db = new SQLiteConnection(Database.DataStore.DBPATH);
            listView = (ListView)FindViewById(Resource.Id.ListViewShoppingList);
            List<ShoppingList> shoppingLists = db.GetAllWithChildren<ShoppingList>();

            listAdapter = new ThreeTextAdapter(this, shoppingLists);
        }
    }
}