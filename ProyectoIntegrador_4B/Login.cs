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
    [Activity(Label = "PrroyectoIntegrador", MainLauncher = true)]
    public class Login : Activity
    {
        Base_Datos web = new Base_Datos();
        //int cont = 1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);

            var edt_Usuario = FindViewById<EditText>(Resource.Id.edt_Usu);

            var edt_Contraseña = FindViewById<EditText>(Resource.Id.edt_Con);

            var edt_Rol = FindViewById<EditText>(Resource.Id.edt_Rol);

            var btn_Ingresar = FindViewById<Button>(Resource.Id.btn_Iniciar);

            var btn_Registrar = FindViewById<Button>(Resource.Id.btn_Registrar);

            btn_Ingresar.Click += delegate
            {
                if (web.Ingresar(edt_Usuario.Text, edt_Contraseña.Text) == 2)
                {
                    Toast.MakeText(this, "Bienvenido Jefe", ToastLength.Short).Show();
                    //Habilitar una nueva vista
                    Intent intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);

                    //StartActivity(Intent.CreateChooser(correo, "Mensaje Enviado"));
                }
                else if (web.Ingresar(edt_Usuario.Text, edt_Contraseña.Text) == 1)
                {
                    //Muestra mensaje en pantalla
                    Toast.MakeText(this, "Bienvenido Usuario", ToastLength.Short).Show();
                    Intent intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);

                }
                else if(web.Ingresar(edt_Usuario.Text, edt_Contraseña.Text) != 2)
                {
                    //Muestra mensaje en pantalla
                    Toast.MakeText(this, "Usuario o Contraseña incorrectos", ToastLength.Short).Show();
                    //Limpia los campos
                    edt_Usuario.Text = "";
                    edt_Contraseña.Text = "";
                }

            };
            btn_Registrar.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Registrar_Usuario));
                StartActivity(intent);

            };
        }
    }
}