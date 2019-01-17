using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using WeeklyMealGenerator.Models;

namespace WeeklyMealGenerator.Adapters
{
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;


namespace WeeklyMealGenerator.Adapters
{
    public class SimpleListItem2Adapter : BaseAdapter<Fruit>    
    {
        private readonly List<Fruit> fruits;
        private readonly Activity _activity;

        public SimpleListItem2Adapter(Activity activity, IEnumerable<Fruit> fruits)
        {
            this.fruits = fruits.OrderBy(s => s.Name).ToList();
            _activity = activity;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Fruit this[int index]
        {
            get { return fruits[index]; }
        }

        public override int Count
        {
            get { return fruits.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                
                view = _activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
                
            }

            var fruit = fruits[position];

            TextView text1 = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            text1.Text = fruit.Name;

            TextView text2 = view.FindViewById<TextView>(Android.Resource.Id.Text2);
            text2.Text = "Chosen " + fruit.NumberOfTimesPicked.ToString() + " number of times";

            return view;
        }
    }
}
    }
