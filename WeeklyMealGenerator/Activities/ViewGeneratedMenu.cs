using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLiteNetExtensions.Extensions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WeeklyMealGenerator.Models;

namespace WeeklyMealGenerator
{
    [Activity(Label = "ViewGeneratedMenu")]
    public class ViewGeneratedMenu : Activity
    {
        SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(Database.DataStore.DBPATH);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

               
        }

        //private List<Fruit> GetRandomFruit()
        //{
        //    int numberOfRequestedFruits = Intent.GetIntExtra("numberOfFruits", 0);
        //    Random random = new Random();
        //    List<Fruit> pickedFruit = new List<Fruit>();
        //    List<Fruit> allFruit = db.GetAllWithChildren<Fruit>();
            
        //    for (int i = 1; i <= numberOfRequestedFruits; i++)
        //    {
        //        Fruit fruit = allFruit[random.Next(0, allFruit.Count)];
        //        pickedFruit.Add(fruit);
        //        allFruit.Remove(fruit);
        //    }
        //    pickedFruit.ForEach(r => r.IncrementTimesPicked());
        //    return pickedFruit;
        //}

        //private List<Meal> GetRandomMeals()
        //{
        //    Random roll = new Random();
        //    int numberOfRequestedMeals = Intent.GetIntExtra("numberOfMeals", 0);
        //    List<Meal> pickedMeals = new List<Meal>();
            
        //    List<Meal> allActiveMeals = db.GetAllWithChildren<Meal>().Where(r => r.IsActive).ToList();         
        //    for (int i = 1; i <= numberOfRequestedMeals; i++)
        //    {
        //        Meal meal = allActiveMeals[roll.Next(0, allActiveMeals.Count)];
        //        allActiveMeals.Remove(meal);
        //        pickedMeals.Add(meal);
        //    }
        //    pickedMeals.ForEach(r => r.IsActive = false);
        //    db.UpdateAll(pickedMeals);
            
        //    return pickedMeals;
        //}
    }
}