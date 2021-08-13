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
using ProyectoIntegrador_4B.com.somee.losmugiwara.www;

namespace ProyectoIntegrador_4B
{
    [Activity(Label = "Registrar_Usuario")]
    public class Registrar_Usuario : Activity
    {
        Base_Datos web = new Base_Datos();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Registrar_Usuario);

            var txtNombreApellido = FindViewById<EditText>(Resource.Id.edt_NA);
            var txtUsuario = FindViewById<EditText>(Resource.Id.edt_Usu);
            var txtContra = FindViewById<EditText>(Resource.Id.edt_Con);
            var txtTelefono = FindViewById<EditText>(Resource.Id.edt_Tel);
            var txtFechaNac = FindViewById<EditText>(Resource.Id.edt_FN);
            var btnRegistrar = FindViewById<Button>(Resource.Id.btn_Registrar);
            var btnRegresar = FindViewById<Button>(Resource.Id.btn_Atras);

            btnRegistrar.Click += delegate
            {
                web.RegistrarUsuario(txtNombreApellido.Text,txtUsuario.Text, txtContra.Text, Convert.ToInt32(txtTelefono.Text),Convert.ToDateTime(txtFechaNac.Text));
                Toast.MakeText(this, "Usuario Registrado Correctamente", ToastLength.Short).Show();
                txtNombreApellido.Text = "";
                txtUsuario.Text = "";
                txtContra.Text = "";
                txtTelefono.Text = "";
                txtFechaNac.Text = "";


            };
            btnRegresar.Click += delegate
            {

                Intent intent = new Intent(this, typeof(Login));
                StartActivity(intent);

            };
        }
    }
}