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
using Xamarin.Forms.PlatformConfiguration;

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

                view = _activity.LayoutInflater.Inflate(Resource.Layout.wayListView, null);

            }

            var shoppingList = ShoppingLists[position];

            TextView text1 = view.FindViewById<TextView>(Resource.Id.wayTextView1);
            text1.Text = shoppingList.Name;

            TextView text2 = view.FindViewById<TextView>(Resource.Id.wayTextView2);
            text2.Text = shoppingList.Date;
            
            TextView text3 = view.FindViewById<TextView>(Resource.Id.wayTextView3);        

            //SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(Database.DataStore.DBPATH);
            //ShoppingList shoppingListWithItems = db.FindWithChildren<ShoppingList>(shoppingList);
            text3.Text = (shoppingList.Ingredients.Count + shoppingList.MiscItems.Count + shoppingList.Fruits.Count) + "";
            return view;

        }
    }
}

        