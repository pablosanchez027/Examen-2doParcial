using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Examen_2doParcial
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int contadorIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            panelFormularios.Children.Add(new ControlInfoPersonal());
            btnAccion.Content = "Siguiente";
            lblInfoPersonal.Foreground = Brushes.Red;
            lblContacto.Foreground = Brushes.Black;
            lblInfoPago.Foreground = Brushes.Black;
        }

        private void btnAccion_Click(object sender, RoutedEventArgs e)
        {
            switch (contadorIndex)
            {
                case 0:
                    var controlInfoPersonal = (ControlInfoPersonal)panelFormularios.Children[0];

                    if (controlInfoPersonal.txtNombre.Text == "" || controlInfoPersonal.txtApellidoPaterno.Text == "" || controlInfoPersonal.txtApellidoMaterno.Text == ""
                        || controlInfoPersonal.txtEdad.Text == "") {

                        txtMensaje.Text = "Es necesario llenar todos los campos";
                    }
                    else {
                        contadorIndex = 1;
                        txtMensaje.Text = " ";
                        panelFormularios.Children.Clear();
                        panelFormularios.Children.Add(new ControlContacto());
                        goto case 1;
                    }
                    break;
                case 1:
                    lblInfoPersonal.Foreground = Brushes.Black;
                    lblContacto.Foreground = Brushes.Red;
                    lblInfoPago.Foreground = Brushes.Black;
                    var controlContacto = (ControlContacto)panelFormularios.Children[0];

                    if (controlContacto.txtCorreo.Text == "" || controlContacto.txtTelefono.Text == "" || controlContacto.txtCelular.Text == "")
                    {
                        txtMensaje.Text = "Es necesario llenar todos los campos";
                    }
                    else
                    {
                        contadorIndex = 2;
                        txtMensaje.Text = " ";
                        btnAccion.Content = "Finalizar";
                        panelFormularios.Children.Clear();
                        panelFormularios.Children.Add(new ControlInfoPago());
                        goto case 2;
                    }
                    break;
                case 2:
                    lblInfoPersonal.Foreground = Brushes.Black;
                    lblContacto.Foreground = Brushes.Black;
                    lblInfoPago.Foreground = Brushes.Red;
                    var controlInfoPago = (ControlInfoPago)panelFormularios.Children[0];

                    if (controlInfoPago.txtNumeroTarjeta.Text == "" || controlInfoPago.txtCVV.Text == "" || controlInfoPago.txtMesExpiracion.Text == "" || controlInfoPago.txtAñoExpiracion.Text == "")
                    {
                        txtMensaje.Text = "Es necesario llenar todos los campos";
                    }
                    else
                    {
                        if (controlInfoPago.txtNumeroTarjeta.Text.Length < 16)
                        {
                            txtMensaje.Text = " ";
                            controlInfoPago.txtTarjeta.Text = "Es necesario que el número de tarjeta sean 16 dígitos";
                        }
                        else
                        {
                            controlInfoPago.txtTarjeta.Text = " ";
                            txtMensaje.Text = "¡Todo salió muy bien!";
                        }
                    }

                    break;
            }
        }
    }
}
