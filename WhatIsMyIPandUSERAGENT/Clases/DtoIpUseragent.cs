using System;
using System.Collections.Generic;
using System.Text;

namespace WhatIsMyIPandUSERAGENT.Clases
{
    public class DtoIpUseragent {

        public string Titulo { get; }
        public string LblIp { get; set; }
        public string LblIpInfo { get; set; }
        public string LblUa{ get; set; }
        public string LblUaInfo { get; set; }



        public DtoIpUseragent() {

            this.Titulo = "Consultar IP y UserAgent";
            this.LblIp = string.Empty;
            this.LblIpInfo = string.Empty;
            this.LblUa = string.Empty;
            this.LblUaInfo = string.Empty;
        }
    }
}
