﻿using System;
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




            //List<Meal> meals = db.GetAllWithChildren<Meal>();
            List<Meal> meals = db.GetAllWithChildren<Meal>();
            List<Ingredient> ingredients = db.GetAllWithChildren<Ingredient>();

            List<int> idsToBeLinked = new List<int>() { 2, 3, 4, 5, 6 };
            CreatManyToManyLink(meals[0], idsToBeLinked, meals, ingredients);

            idsToBeLinked = new List<int>() { 12, 29, 31, 28 };
            CreatManyToManyLink(meals[1], idsToBeLinked, meals, ingredients);

            idsToBeLinked = new List<int>() { 12, 24, 27, 28,73 };
            CreatManyToManyLink(meals[2], idsToBeLinked, meals, ingredients);

            List<Meal> test = db.GetAllWithChildren<Meal>();










        }


        private static void CreatManyToManyLink(Meal meal, List<int> ingredientsId, List<Meal> allMeals, List<Ingredient> allIngredients)
        {
            var db = new SQLiteConnection(DBPATH);
            Meal tempMeal = meal;
            List<Ingredient> ingredients = allIngredients.Where(r => ingredientsId.Contains(r.Id)).ToList();
            foreach (Ingredient ingredient in ingredients)
            {
                tempMeal.Ingredients.Add(ingredient);
            }
            db.UpdateWithChildren(tempMeal);
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