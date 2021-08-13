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
    [Activity(Label = "Reservacion")]
    public class Reservacion : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Reservacion);

            var btnmesa1 = FindViewById<Button>(Resource.Id.btn_M1);
            var btnmesa2 = FindViewById<Button>(Resource.Id.btn_M2);
            var btnmesa3 = FindViewById<Button>(Resource.Id.btn_M3);
            var btnmesa4 = FindViewById<Button>(Resource.Id.btn_M4);
            var btnmesa5 = FindViewById<Button>(Resource.Id.btn_M5);
            var btnmesa6 = FindViewById<Button>(Resource.Id.btn_M6);
            var btnmesa7 = FindViewById<Button>(Resource.Id.btn_M7);
            var btnmesa8 = FindViewById<Button>(Resource.Id.btn_M8);
            var btnmesa9 = FindViewById<Button>(Resource.Id.btn_M9);

            btnmesa1.Click += delegate
            {
                Intent intent = new Intent(this,typeof(Registrar_Reservacion));
                StartActivity(intent);
            };
            btnmesa2.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Registrar_Reservacion));
                StartActivity(intent);
            };
            btnmesa3.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Registrar_Reservacion));
                StartActivity(intent);
            };
            btnmesa4.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Registrar_Reservacion));
                StartActivity(intent);
            };
            btnmesa5.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Registrar_Reservacion));
                StartActivity(intent);
            };
            btnmesa6.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Registrar_Reservacion));
                StartActivity(intent);
            };
            btnmesa7.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Registrar_Reservacion));
                StartActivity(intent);
            };
            btnmesa8.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Registrar_Reservacion));
                StartActivity(intent);
            };
            btnmesa9.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Registrar_Reservacion));
                StartActivity(intent);
            };

        }
    }
}