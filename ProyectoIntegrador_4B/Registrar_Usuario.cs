using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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
        static int id=0;
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
            var txtRol = FindViewById<Spinner>(Resource.Id.spn_Rol);
            var btnRegistrar = FindViewById<Button>(Resource.Id.btn_Registrar);
            var btnRegresar = FindViewById<Button>(Resource.Id.btn_Atras);
            var btnEditar = FindViewById<Button>(Resource.Id.btn_Editar);
            var btnEliminar = FindViewById<Button>(Resource.Id.btn_Eliminar);

            List<string> roles = new List<string>();
            roles.Add("Seleccione");
            roles.Add("Usuario");
            roles.Add("Administrador");
            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, roles);
            txtRol.Adapter = adapter;


            btnRegistrar.Click += delegate
            {
                
                Toast.MakeText(this, "Usuario Registrado Correctamente", ToastLength.Short).Show();
                if (txtRol.SelectedItem.ToString()== "Administrador" )
                {
                    web.RegistrarUsuario(txtNombreApellido.Text, txtUsuario.Text, txtContra.Text, Convert.ToInt32(txtTelefono.Text), Convert.ToDateTime(txtFechaNac.Text), "A");
                    limpiar();
                }
                else if(txtRol.SelectedItem.ToString() == "Usuario")
                {

                    web.RegistrarUsuario(txtNombreApellido.Text, txtUsuario.Text, txtContra.Text, Convert.ToInt32(txtTelefono.Text), Convert.ToDateTime(txtFechaNac.Text), "U");
                    limpiar();
                }
                else
                {
                    Toast.MakeText(this, "Usuario no registrado", ToastLength.Short).Show();
                }
            };

            btnEditar.Click += delegate
            {
                DataSet dt = web.CargarUsuario(txtUsuario.Text);
                id = Convert.ToInt32(dt.Tables[0].Rows[0]["usu_id"].ToString());
                web.ModificarUsuario(txtNombreApellido.Text, Convert.ToInt32(txtTelefono.Text), Convert.ToDateTime(txtFechaNac.Text),id);
                Toast.MakeText(this, "Usuario Modificado Correctamente", ToastLength.Short).Show();
                limpiar();
            };

            btnEliminar.Click += delegate
            {
                DataSet dt = web.CargarUsuario(txtUsuario.Text);
                id = Convert.ToInt32(dt.Tables[0].Rows[0]["usu_id"].ToString());
                web.EliminarUsuario(id);
                Toast.MakeText(this, "Usuario Eliminado Correctamente", ToastLength.Short).Show();
                limpiar();
            };
            void limpiar()
            {
                txtContra.Text = txtFechaNac.Text = txtNombreApellido.Text = txtTelefono.Text = txtUsuario.Text = "";
                txtRol.SetSelection(0);
            }

            btnRegresar.Click += delegate
            {

                Intent intent = new Intent(this, typeof(Login));
                StartActivity(intent);

            };

        }
    }
}