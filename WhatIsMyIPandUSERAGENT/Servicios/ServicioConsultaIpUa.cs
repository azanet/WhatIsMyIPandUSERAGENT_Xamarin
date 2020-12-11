using WhatIsMyIPandUSERAGENT.Clases;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WhatIsMyIPandUSERAGENT.Servicios
{
    public class ServicioConsultaIpUa
    {
        public static async Task<DtoIpUseragent> ConsultarIp() {

            var dtoIpUa = new DtoIpUseragent(); //Creamos el objeto
            var uri = $"https://ifconfig.me/all.json"; //URL DE LA PETICION

            //Creamos un objeto HttpClient  para utilizarlo en nuestra consulta
            using (HttpClient client = new HttpClient()) {

                //Lanzamos la petición y recogemos la respuesta (será un JSON)
                var response = await client.GetAsync(uri);

                if (response != null) {
                    //Leemos como string el resultado contenido en "response"
                    var json = response.Content.ReadAsStringAsync().Result;

                    //Deserializamos el contenido y la almacenamos (obtendremos una Lista, que será como un diccionario[KEY:VALUE] )
                    var data = (JContainer)JsonConvert.DeserializeObject(json);

                    //Comprobamos si existen los correspondientes datos Proporcionandole la "KEY" y los seteamos en caso de tenerlos
                    if (data["ip_addr"] != null) {
                        
                        dtoIpUa.LblIpInfo = (string)data["ip_addr"];
                    }

                    if (data["user_agent"] != null) { 

                        dtoIpUa.LblUaInfo = (string)data["user_agent"];
                    }

                }//Fin del if (response != null)
     
            }//Fin del USING HTTPclient

            return dtoIpUa;

        }//Fin del metodo ConsultarIp

    }//Fin de la Clase ServicioConsultaIP
}
