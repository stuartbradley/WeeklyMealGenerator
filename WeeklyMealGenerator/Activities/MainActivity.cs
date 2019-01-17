using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using System.IO;
using WeeklyMealGenerator.Models;
using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;
using WeeklyMealGenerator.Database;

namespace WeeklyMealGenerator
{
    [Activity(MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            SetDataBaseForFirstTime();

            FindViewById<CheckBox>(Resource.Id.cbIncludeFruit).CheckedChange += CbIncludeFruitChanged;
            FindViewById<Button>(Resource.Id.btnViewMeals).Click += btnViewMealsClicked;
            FindViewById<Button>(Resource.Id.btnViewFruit).Click += btnViewFruitClicked;
            FindViewById<Button>(Resource.Id.btnGenerateMenu).Click += btnGenerateMenuClicked;
        }

        private void SetDataBaseForFirstTime()
        {
            string dbName = "WeeklyMealGeneratorDatabase.db";
            string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);

            if (!File.Exists(dbPath))
            {
                DataStore.CopyMealsWithIngredientsIntoDatabase(dbName, dbPath);
                DataStore.SetupDatabase();
            }
        }

        private void btnGenerateMenuClicked(object sender, EventArgs e)
        {
            int numberOfRequestedMeals = Int32.Parse(FindViewById<TextView>(Resource.Id.inputMealsWanted).Text);
            int numberOfRequestedFruit = Int32.Parse(FindViewById<TextView>(Resource.Id.inputFruitWanted).Text);

            Intent intent = new Intent(this, typeof(ViewGeneratedMenu));
            
            intent.PutExtra("numberOfMeals", numberOfRequestedMeals);
            intent.PutExtra("numberOfFruits", numberOfRequestedFruit);
            StartActivity(intent);
        }

        private void btnViewMealsClicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ViewMealsActivity));
            StartActivity(intent);
        }

        private void btnViewFruitClicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ViewFruitActivity));
            StartActivity(intent);
        }

        private void CbIncludeFruitChanged(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            CheckBox isFruitRequired = sender as CheckBox;

            if (isFruitRequired.Checked)
            {
                FindViewById<LinearLayout>(Resource.Id.layoutFruit).Visibility = Android.Views.ViewStates.Visible;
            }
            else
            {
                FindViewById<LinearLayout>(Resource.Id.layoutFruit).Visibility = Android.Views.ViewStates.Gone;
            }
        }
    }
}
