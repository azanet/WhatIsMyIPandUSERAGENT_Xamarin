using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using WhatIsMyIPandUSERAGENT.Clases;
using WhatIsMyIPandUSERAGENT.Servicios;

namespace WhatIsMyIPandUSERAGENT.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagPrincipal : ContentPage
    {
        public PagPrincipal()
        {
            InitializeComponent();
            //Le Bindeamos la clase Principal para "pasarle los objetos (lbls botones etc) que hemos creado enesa clase a el XAML"
            this.BindingContext = new DtoIpUseragent();
        }//Fin del constructor



        public async void BtnConsultar_Clicked(object sender, EventArgs e)
        {

            //Creamos un objeto NUEVO (que tendrá las qtiquetas vacías)
            DtoIpUseragent dtoIpUa = new DtoIpUseragent();

            //Comprobamos el estado del botón y según sea, actuará
            
            if (BtnConsultar.Text.ToString().Equals("Consultar"))
            {

                try
                {
                    //Recibimos el objeto "PRINCIPAL" que nos devolverá la consulta
                    dtoIpUa = await ServicioConsultaIpUa.ConsultarIp();

                }
                catch (Exception)
                {}


                //Comprobamos que trae información de la IP si no... mostraremos un error
                if (!dtoIpUa.LblIpInfo.ToString().Equals("")) {

                    //Seteamos las propiedades de los Elementos
                    LblIpXaml.TextColor = Color.White;
                    dtoIpUa.LblIp = "Tu IP es:";
                }else{
                    
                    LblIpXaml.TextColor = Color.Red;
                    dtoIpUa.LblIp = "Se ha producido un ERROR\n" +
                    $"No se ha recibido la información esperada\n\nRecibido:{dtoIpUa.LblIpInfo}";
                }//Fin del if-else


                //Comprobamos que trae información el UserAgent si no... mostraremos un error
                if (!dtoIpUa.LblUaInfo.ToString().Equals(""))
                {
                    //Seteamos las propiedades de los Elementos
                    LblUaXaml.TextColor = Color.White;
                    dtoIpUa.LblUa = "Tu User-Agent es:";
                }else{
                
                    LblUaXaml.TextColor = Color.Red;
                    dtoIpUa.LblUa = "Se ha producido un ERROR\n" +
                    $"No se ha recibido la información esperada\n\nRecibido:{dtoIpUa.LblUaInfo}";
                }//Fin del if que comprueba Si EXISTE algo en el "LblDos" del objeto recibido






                BtnConsultar.Text = "Reset Result";
                //Pasamos el objeto al XAML para setear los Botones y etiquetas
                this.BindingContext = dtoIpUa;




            }else{

                //Seteamos el botón ya que arriba de declaró un objeto vacío
                BtnConsultar.Text = "Consultar";
                //Pasamos el objeto al XAML para setear los Botones y etiquetas
                this.BindingContext = dtoIpUa;
            }//Fin del IF que comprueba el estado del BOTON

        }





    }//Fin del la clase
}
