using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Xml.Linq;

namespace Consulta
{
    public class DefaultData_Consulta
    {
        private string pathXML = Utils.Parametros.pubPathAliance.Trim() + System.IO.Path.DirectorySeparatorChar;
        
        public void GravaDefaultData(string NMCampo, string VLCampo)
        {
            try
            {
                XElement documentoXml;
                XElement element = new XElement(NMCampo.Replace("{@", "").Replace("}", ""));  
                element.Value = VLCampo; 

                if (!System.IO.File.Exists(pathXML + "configDefaultData.xml"))
                {
                    //GRAVA UM NOVO OBJETO OU ALTERA
                    documentoXml = new XElement("DefaultData");
                    documentoXml.Add(element);
                }
                else
                {
                    documentoXml = XElement.Load(pathXML + "configDefaultData.xml", LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);

                    XElement elesel = documentoXml.Element(element.Name);
                    if (elesel != null)
                        documentoXml.Element(element.Name).Value = VLCampo;
                    else
                    {
                        element.Value = VLCampo;
                        documentoXml.Add(element);
                    }
                }

                documentoXml.Save(pathXML + "configDefaultData.xml");
            }
            catch (Exception erro)
            {
                throw new Exception("ERRO: "+erro.Message);
            }
        }

        public string LerDefaultData(string NMCampo)
        {
            string VLCampo = "";

            try
            {
                XElement documentoXml;
                XElement element = new XElement(NMCampo.Replace("{@", "").Replace("}", ""));  
                element.Name = NMCampo.Replace("{@", "").Replace("}", ""); 

                if (System.IO.File.Exists(pathXML + "configDefaultData.xml"))
                {
                    documentoXml = XElement.Load(pathXML + "configDefaultData.xml", LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);

                    XElement elesel = documentoXml.Element(element.Name);
                    if (elesel != null)
                        VLCampo = elesel.Value.ToString();
                }
            }
            catch (Exception erro)
            {
                throw new Exception("ERRO: "+erro.Message);
            }

            return VLCampo;
        }
    }
}
