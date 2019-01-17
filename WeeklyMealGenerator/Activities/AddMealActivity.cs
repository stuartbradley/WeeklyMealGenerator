using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Views.InputMethods;

using WeeklyMealGenerator.Models;
using WeeklyMealGenerator.Database;
using System.IO;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace WeeklyMealGenerator.Activities
{
    [Activity(WindowSoftInputMode = SoftInput.StateHidden, Label = "AddMealAcitivity")]
    public class AddMealActivity : Activity
    {
        private ListView listView;
        private List<Ingredient> ingredients;
        View v;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddMeal);
            using (var db = new SQLiteConnection(Database.DataStore.DBPATH))
                ingredients = db.GetAllWithChildren<Ingredient>();

            listView = (ListView)FindViewById(Resource.Id.ListViewShoppingList);
            ArrayAdapter<Ingredient> arrayAdapter = new ArrayAdapter<Ingredient>(this, Android.Resource.Layout.SimpleListItemActivated1, ingredients.OrderBy(r => r.Name).ToList());
            listView.Adapter = arrayAdapter;
            listView.ChoiceMode = ChoiceMode.Multiple;
            FindViewById<Button>(Resource.Id.AddMeal_btnAddMeal).Click += btnAddMeal_OnClick;

        }

        private void btnAddMeal_OnClick(object sender, EventArgs e)
        {
            List<Ingredient> pickedIngredients = GetSelectedIngredientsForMeals();
            TextView MealName = FindViewById<TextView>(Resource.Id.MealName);
            Meal meal = new Meal
            {
                IsActive = true,
                Name = MealName.Text,
                Ingredients = GetSelectedIngredientsForMeals()
            };
            using (var db = new SQLiteConnection(Database.DataStore.DBPATH))
                db.InsertWithChildren(meal);             

            Toast.MakeText(this, $"{meal.Name} has been added to your selection", ToastLength.Long).Show();

            //would you like to add another meal?
            StartActivity(this.Intent);
        }

        private List<Ingredient> GetSelectedIngredientsForMeals()
        {
            List<Ingredient> chosenIngredients = new List<Ingredient>();
            ingredients = ingredients.OrderBy(r => r.Name).ToList();
            int len = listView.Count;
            SparseBooleanArray checkedItems = listView.CheckedItemPositions;
            for (int i = 0; i < len; i++)
            {
                if (checkedItems.Get(i)) {
                    chosenIngredients.Add(ingredients[i]); 
                }
            }
            return chosenIngredients;
        }
    }
}
