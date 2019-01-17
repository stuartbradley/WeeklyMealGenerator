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
using WeeklyMealGenerator.Adapters;
using WeeklyMealGenerator.Adapters.WeeklyMealGenerator.Adapters;
using WeeklyMealGenerator.Models;

namespace WeeklyMealGenerator
{
    [Activity(Label = "ViewFruitActivity")]
    public class ViewFruitActivity : ListActivity
    {
        string Fruit = "";
        View input;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetPage();
        }

        private void SetPage()
        {
            List<Fruit> fruits = new List<Fruit>();

            using (var conn = new SQLite.SQLiteConnection(Database.DataStore.DBPATH))
            {
                fruits = conn.CreateCommand("Select * from Fruit").ExecuteQuery<Fruit>().ToList();
            }
            var adapter = new SimpleListItem2Adapter(this, fruits);
            this.ListAdapter = adapter;

            SetContentView(Resource.Layout.ViewFruits);
            FindViewById<Button>(Resource.Id.AddFruit).Click += btnAddFruit_OnClick;
        }

        private void btnAddFruit_OnClick(object sender, EventArgs e)
        {
            LayoutInflater layoutInflater = LayoutInflater.From(this);
            input = layoutInflater.Inflate(Resource.Layout.user_input_dialog_box, null);
            Android.Support.V7.App.AlertDialog.Builder alertbuilder = new Android.Support.V7.App.AlertDialog.Builder(this);
            alertbuilder.SetView(input);
            var userdata = input.FindViewById<EditText>(Resource.Id.editText);
            alertbuilder.SetCancelable(false)
            .SetPositiveButton("Submit", OkAction)
            .SetNegativeButton("Cancel", delegate
            {
                alertbuilder.Dispose();
            });
            Android.Support.V7.App.AlertDialog dialog = alertbuilder.Create();
            dialog.Show();


        }
        private void OkAction(object sender, DialogClickEventArgs e)
        {
            var userdata = input.FindViewById<EditText>(Resource.Id.editText);        
            using (var conn = new SQLite.SQLiteConnection(Database.DataStore.DBPATH))
            {
                conn.Insert(new Fruit
                {
                    _id = null,
                    Name = userdata.Text,
                    NumberOfTimesPicked = 0
                });
            }
            SetPage();
        }


    }
    }

