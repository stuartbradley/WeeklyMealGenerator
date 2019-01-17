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
using WeeklyMealGenerator.Models;
using SQLiteNetExtensions.Extensions;

namespace WeeklyMealGenerator.Adapters
{
    public class ThreeTextAdapter : BaseAdapter<ShoppingList>
    {
        private readonly List<ShoppingList> ShoppingLists;
        private readonly Activity _activity;

        public ThreeTextAdapter(Activity activity, IEnumerable<ShoppingList> shoppingLists)
        {
            this.ShoppingLists = shoppingLists.ToList();
            _activity = activity;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override ShoppingList this[int index]
        {
            get { return ShoppingLists[index]; }
        }

        public override int Count
        {
            get { return ShoppingLists.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {

                view = _activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);

            }

            var shoppingList = ShoppingLists[position];

            TextView text1 = view.FindViewById<TextView>(Resource.Id.textView1);
            text1.Text = shoppingList.Name;

            TextView text2 = view.FindViewById<TextView>(Resource.Id.TextView2);
            text2.Text = shoppingList.Date;
            
            TextView text3 = view.FindViewById<TextView>(Resource.Id.TextView3);        

            SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(Database.DataStore.DBPATH);
            var shoppingListWithItems = db.FindWithChildren<ShoppingList>(shoppingList);
            text3.Text = (shoppingListWithItems.Ingredients.Count + shoppingListWithItems.MiscItems.Count + shoppingListWithItems.Fruits.Count) + "";
            return view;

        }
    }
}

        