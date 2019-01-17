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
using SQLiteNetExtensions.Extensions;
using WeeklyMealGenerator.Activities;
using WeeklyMealGenerator.Models;

namespace WeeklyMealGenerator
{
    [Activity(Label = "ViewMeals")]
    public class ViewMealsActivity : Activity
    {

        ExpandableListAdapter listAdapter;
        ExpandableListView expListView;
        List<Meal> listDataHeader;
        Dictionary<Meal, List<Ingredient>> listDataChild;
        int previousGroup = -1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ViewMeals);

            expListView = FindViewById<ExpandableListView>(Resource.Id.ElvFruit);
            Button button = FindViewById<Button>(Resource.Id.btnAddMeal);
            button.Click += btnAddMeal_Clicked;

            // Prepare list data
            FnGetListData();

            //Bind list
            listAdapter = new ExpandableListAdapter(this, listDataHeader, listDataChild);
            expListView.SetAdapter(listAdapter);

            FnClickEvents();
        }

        private void btnAddMeal_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AddMealActivity));
            StartActivity(intent);
        }

        void FnClickEvents()
        {
            //Listening to group expand
            //modified so that on selection of one group other opened group has been closed
            expListView.GroupExpand += delegate (object sender, ExpandableListView.GroupExpandEventArgs e) {

                if (e.GroupPosition != previousGroup)
                    expListView.CollapseGroup(previousGroup);
                previousGroup = e.GroupPosition;
            };
        }
        void FnGetListData()
        {
            listDataHeader = new List<Meal>();
            listDataChild = new Dictionary<Meal, List<Ingredient>>();

            List<Meal> meals = new List<Meal>();
            List<Ingredient> ingredients = new List<Ingredient>();


            using (var conn = new SQLiteConnection(Database.DataStore.DBPATH))
            {
                meals = conn.GetAllWithChildren<Meal>();
            }

            foreach (Meal meal in meals)
            {
                listDataHeader.Add(meal);             
                listDataChild.Add(meal, meal.Ingredients);
            }




        }
    }
}
    
