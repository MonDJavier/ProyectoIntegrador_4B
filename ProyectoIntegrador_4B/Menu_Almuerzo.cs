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

namespace ProyectoIntegrador_4B
{
    [Activity(Label = "ProyectoIntegrador", MainLauncher = false)]
    public class Menu_Almuerzo : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Menu_Almuerzo);

            var btn_Regresar = FindViewById<Button>(Resource.Id.button1);

            btn_Regresar.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };
        }
    }
}