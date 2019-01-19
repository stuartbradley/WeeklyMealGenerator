using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLiteNetExtensions.Extensions;
using WeeklyMealGenerator.Models;

namespace WeeklyMealGenerator.Database
{   
    public static class DataStore 
    {
        static readonly string DBNAME = "WeeklyMealGeneratorDatabase.db";
        public static readonly string DBPATH = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), DBNAME);

        public static void SetupDatabase()
        {
            var db = new SQLiteConnection(DBPATH);
            db.CreateTable<Fruit>();
            db.CreateTable<Ingredient>();
            db.CreateTable<Meal>();
            db.CreateTable<Recipe>();
            db.CreateTable<ShoppingList>();

            //create join tables

            db.CreateTable<MiscItem>();
            db.CreateTable<ShoppingListMiscItems>();
            db.CreateTable<ShoppingListIngredient>();
            db.CreateTable<ShoppingListFruit>();

            var food = db.GetAllWithChildren<Meal>();
            var fruit = db.GetAllWithChildren<Fruit>();
            var test = food[0].Ingredients;

            db.InsertWithChildren(new ShoppingList
            {
                Name = "Shopping List",
                Ingredients = food[0].Ingredients,
                Fruits = fruit,
                Date = DateTime.Now.ToString(),
                MiscItems = null
            });







        }




        public static void CopyMealsWithIngredientsIntoDatabase(string dbName, string dbPath)
        {
            using (BinaryReader br = new BinaryReader(Android.App.Application.Context.Assets.Open(dbName)))
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                {
                    byte[] buffer = new byte[2048];
                    int len = 0;
                    while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        bw.Write(buffer, 0, len);
                    }
                }
            }
        }
    }
}