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
    [Activity(Label = "Pedidos",MainLauncher =false)]
    public class Pedidos : Activity
    {
        Base_Datos web = new Base_Datos();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Pedidos);

            var spmCat = FindViewById<Spinner>(Resource.Id.spn_Cat);
            var btn_pedido = FindViewById<Button>(Resource.Id.btn_pedido);
            var spmPlato = FindViewById<Spinner>(Resource.Id.spn_Plato);
            var txtPrecio = FindViewById<TextView>(Resource.Id.txt_Precio);
            var txtCantidad = FindViewById<EditText>(Resource.Id.editText1);


            List<string> categoria = new List<string>();
            categoria.Add("Seleccione");
            categoria.Add("ALMUERZO");
            categoria.Add("PLATOS A LA CARTA");
            categoria.Add("BEBIDAS");
            categoria.Add("POSTRES");
            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, categoria);
            spmCat.Adapter = adapter;
            List<string> Platos = new List<string>();
            Platos.Add("Seco de Carne");
            Platos.Add("Parrillada");
            Platos.Add("Encebollado");
            Platos.Add("Hamburguesa de Carbon");
            List<string> Bebidas = new List<string>();
            Bebidas.Add("Coca Cola");
            Bebidas.Add("Sprite");
            Bebidas.Add("Jugo de Naranja");
            Bebidas.Add("Batido de mora");
            List<string> Postres = new List<string>();
            Postres.Add("Tres leches");
            Postres.Add("Pastel de chocolate");
            Postres.Add("Galletas");
            Postres.Add("Mouse de Maracuya");
            List<string> Almuerzo = new List<string>();
            Almuerzo.Add("Opcion 1");
            Almuerzo.Add("Opcion 2");
            Almuerzo.Add("Opcion 3");
            Almuerzo.Add("Opcion 4");

            spmCat.ItemSelected += delegate
            {
                if (spmCat.SelectedItem.ToString() == "PLATOS A LA CARTA")
                {
                    var adaptar2 = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, Platos);
                    spmPlato.Adapter = adaptar2;

                    if (spmPlato.SelectedItemPosition.ToString() == "0")
                    {
                        txtPrecio.Text = "3.00";
                    }
                    if (spmPlato.SelectedItemPosition.ToString() == "1")
                    {
                        txtPrecio.Text = "5.50";
                    }
                    if (spmPlato.SelectedItemPosition.ToString() == "2")
                    {
                        txtPrecio.Text = "2.50";
                    }
                    if (spmPlato.SelectedItemPosition.ToString() == "3")
                    {
                        txtPrecio.Text = "3.50";
                    }
                }
                if (spmCat.SelectedItem.ToString() == "ALMUERZO")
                {
                    var adaptar3 = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, Almuerzo);
                    spmPlato.Adapter = adaptar3;

                    if (spmPlato.SelectedItemPosition.ToString() == "0")
                    {
                        txtPrecio.Text = "2.50";
                    }
                    if (spmPlato.SelectedItemPosition.ToString() == "1")
                    {
                        txtPrecio.Text = "2.50";
                    }
                    if (spmPlato.SelectedItemPosition.ToString() == "2")
                    {
                        txtPrecio.Text = "2.50";
                    }
                    if (spmPlato.SelectedItemPosition.ToString() == "3")
                    {
                        txtPrecio.Text = "2.50";
                    }
                }
                if (spmCat.SelectedItem.ToString() == "BEBIDAS")
                {
                    var adaptar4 = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, Bebidas);
                    spmPlato.Adapter = adaptar4;

                    if (spmPlato.SelectedItemPosition.ToString() == "0")
                    {
                        txtPrecio.Text = "2.00";
                    }
                    if (spmPlato.SelectedItemPosition.ToString() == "1")
                    {
                        txtPrecio.Text = "1.00";
                    }
                    if (spmPlato.SelectedItemPosition.ToString() == "2")
                    {
                        txtPrecio.Text = "1.50";
                    }
                    if (spmPlato.SelectedItemPosition.ToString() == "3")
                    {
                        txtPrecio.Text = "0.50";
                    }
                }
                if (spmCat.SelectedItem.ToString() == "POSTRES")
                {
                    var adaptar5 = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, Postres);
                    spmPlato.Adapter = adaptar5;

                    if (spmPlato.SelectedItemPosition.ToString() == "0")
                    {
                        txtPrecio.Text = "1.50";
                    }
                    if (spmPlato.SelectedItemPosition.ToString() == "1")
                    {
                        txtPrecio.Text = "3.50";
                    }
                    if (spmPlato.SelectedItemPosition.ToString() == "2")
                    {
                        txtPrecio.Text = "4.50";
                    }
                    if (spmPlato.SelectedItemPosition.ToString() == "3")
                    {
                        txtPrecio.Text = "0.50";
                    }
                }

            };
            btn_pedido.Click += delegate
            {
                Toast.MakeText(this, "PEDIDO REGISTRADO CORRECTAMENTE", ToastLength.Short).Show();
                if (spmCat.SelectedItem.ToString() == "ALMUERZO")
                {

                    web.RegistrarPedido(spmCat.SelectedItem.ToString(),spmPlato.SelectedItem.ToString(), float.Parse(txtPrecio.Text),Convert.ToInt32(txtCantidad.Text));
                    limpiar();

                }
                else if (spmCat.SelectedItem.ToString() == "PLATOS A LA CARTA")
                {
                    web.RegistrarPedido(spmCat.SelectedItem.ToString(), spmPlato.SelectedItem.ToString(), float.Parse(txtPrecio.Text), Convert.ToInt32(txtCantidad.Text));
                    limpiar();

                }
                else if (spmCat.SelectedItem.ToString() == "BEBIDAS")
                {
                    web.RegistrarPedido(spmCat.SelectedItem.ToString(), spmPlato.SelectedItem.ToString(), float.Parse(txtPrecio.Text), Convert.ToInt32(txtCantidad.Text));
                    limpiar();

                }
                else if (spmCat.SelectedItem.ToString() == "POSTRES")
                {
                    web.RegistrarPedido(spmCat.SelectedItem.ToString(), spmPlato.SelectedItem.ToString(), float.Parse(txtPrecio.Text), Convert.ToInt32(txtCantidad.Text));
                    limpiar();

                }
                else
                {
                    Toast.MakeText(this, "Pedido no registrado", ToastLength.Short).Show();
                }
            };
            void limpiar()
            {
                txtCantidad.Text = txtPrecio.Text =  "";
                spmCat.SetSelection(0);
                spmPlato.SetSelection(0);
            }
        }
    }
}