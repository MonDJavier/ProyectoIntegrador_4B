using System;
using System.Collections.Generic;
using System.Data;
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
    [Activity(Label = "Registrar_Reservacion",MainLauncher = false)]
    public class Registrar_Reservacion : Activity
    {
        static int id = 0;
        Base_Datos web = new Base_Datos();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Registrar_Reservacion);
            var txtnombres = FindViewById<EditText>(Resource.Id.edt_NA);
            var txtfecha = FindViewById<EditText>(Resource.Id.edt_Fe);//fecha
            var txttelefono = FindViewById<EditText>(Resource.Id.edt_Num);//numero telefono
            var txtemail = FindViewById<EditText>(Resource.Id.edt_E);//correo
            var txthora = FindViewById<EditText>(Resource.Id.edt_H);//hora de la reservacion
            var txtnpersonas = FindViewById<EditText>(Resource.Id.edt_NP);//numero de personas
            var btn_regresar = FindViewById<Button>(Resource.Id.btn_Atras);//boton atras
            var btn_registro = FindViewById<Button>(Resource.Id.btn_Registrar);//boton registrar
            var btn_modificacion = FindViewById<Button>(Resource.Id.btn_Editar);//boton editar
            var btn_eliminacion = FindViewById<Button>(Resource.Id.btn_Eliminar);//boton eliminar

            btn_registro.Click += delegate
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                AlertDialog alert = dialog.Create();
                alert.SetTitle("Guardar Informacion");
                alert.SetIcon(Android.Resource.Drawable.BottomBar);
                alert.SetMessage("¿Estas seguro de realizar la reservacion?");

                alert.SetButton("No", (s, ev) =>
                {
                    Toast.MakeText(this, "Reservacion cancelada", ToastLength.Short).Show();


                });
                alert.SetButton3("Si", (s, ev) =>
                {
                    Toast.MakeText(this, "La reservacion se registro con exito", ToastLength.Short).Show();
                });

                alert.Show();

                web.RegistrarReservacion(txtnombres.Text, Convert.ToDateTime(txtfecha.Text), Convert.ToInt32(txttelefono.Text), txtemail.Text, Convert.ToDateTime(txthora.Text), Convert.ToInt32(txtnpersonas.Text));
                
            };

            btn_modificacion.Click += delegate
            {
                DataSet dt = web.CargarReservacion(txtnombres.Text);
                id = Convert.ToInt32(dt.Tables[0].Rows[0]["res_id"].ToString());
                web.ModificarReservacion(txtnombres.Text, Convert.ToInt32(txttelefono.Text), Convert.ToDateTime(txtfecha.Text), txtemail.Text, Convert.ToDateTime(txthora.Text), Convert.ToInt32(txtnpersonas.Text), id);
                Toast.MakeText(this, "Reservacion Modificada Correctamente", ToastLength.Short).Show();
                limpiar();
            };
            btn_eliminacion.Click += delegate
            {
                DataSet dt = web.CargarReservacion(txtnombres.Text);
                id = Convert.ToInt32(dt.Tables[0].Rows[0]["res_id"].ToString()); Toast.MakeText(this, "Reservacion Modificada Correctamente", ToastLength.Short).Show();
                web.EliminarReservacion(id);
                Toast.MakeText(this, "Reservacion Eliminada Correctamente", ToastLength.Short).Show();
                limpiar();
            };
            void limpiar()
            {
                txtnombres.Text = txtfecha.Text = txthora.Text = txttelefono.Text = txtemail.Text = txtnpersonas.Text = "";
                
            }

            btn_regresar.Click += delegate
            {

                Intent intent = new Intent(this, typeof(Reservacion));
                StartActivity(intent);

            };
        }
    }
}