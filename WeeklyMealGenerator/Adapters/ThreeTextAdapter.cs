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

namespace WeeklyMealGenerator.Adapters
{
    public class ThreeTextAdapter : BaseAdapter<ShoppingList>
    {
        private readonly List<ShoppingList> ShoppingLists;
        private readonly Activity _activity;

        public ThreeTextAdapter(Activity activity, IEnumerable<ShoppingList> fruits)
        {
            this.ShoppingLists = fruits.OrderBy(s => s.Name).ToList();
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

            var ShoppingList = ShoppingLists[position];

            TextView text1 = view.FindViewById<TextView>(Resource.Id.textView1);
            text1.Text = ShoppingList.Name;

            TextView text2 = view.FindViewById<TextView>(Resource.Id.TextView2);
            text2.Text = ShoppingList.Date;

            TextView text3 = view.FindViewById<TextView>(Resource.Id.TextView3);
            int numberOfItems;
            SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(Database.DataStore.DBPATH);
                




            return view;

        }
    }
}

        