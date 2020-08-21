using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace Utils.ValidaSchema
{
    public class ValidaXML
    {
        public static string Retorno
        {
            get;
            set;
        }

        public static bool XML_Erro
        { get; set; }


        public static void validaXML(string nm_arquivo, string nm_schema)
        {
            using (StreamReader sr = new StreamReader(nm_arquivo.Trim()))
            {
                XmlValidatingReader reader = new XmlValidatingReader(new XmlTextReader(sr));
                XmlSchemaCollection schemaCollection = new XmlSchemaCollection();
                schemaCollection.Add("http://www.portalfiscal.inf.br/nfe", nm_schema.Trim());
                reader.Schemas.Add(schemaCollection);
                Retorno += "Início da validação...";

                reader.ValidationEventHandler += new ValidationEventHandler(reader_ValidationEventHandler);

                while (reader.Read())
                { }
                Retorno += "\rFim de validação\n";
                sr.Close();
            }
        }

        private static void reader_ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            // Report back error information to the console...
            Retorno += string.Format("\rLinha:{0} Coluna:{1} Erro:{2}\r", new object[] { e.Exception.LinePosition, e.Exception.LineNumber, e.Exception.Message });
            XML_Erro = true;
        }
    }

    public class ValidaXML2
    {
        public static string xml
        { get; set; }

        public static string Retorno
        {
            get;
            set;
        }

        public static void validaXML(string xml, 
                                     string uri_schema,
                                     string TP_Documento)
        {
            Retorno = string.Empty;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;

            byte[] arraybyte = Encoding.ASCII.GetBytes(xml);

            XmlReader r = XmlReader.Create(new MemoryStream(arraybyte), settings);

            XmlDocument doc = new XmlDocument();
            doc.Load(r);
            if (TP_Documento.Trim().ToUpper().Equals("NFES"))
                doc.Schemas.Add("http://www.equiplano.com.br/esnfs", uri_schema.Trim());
            else if (TP_Documento.Trim().ToUpper().Equals("CTE"))
                doc.Schemas.Add("http://www.portalfiscal.inf.br/cte", uri_schema.Trim());
            else if (TP_Documento.Trim().ToUpper().Equals("LMC"))
                doc.Schemas.Add("http://www.fazenda.pr.gov.br/sefaws", uri_schema.Trim());
            else if (TP_Documento.Trim().ToUpper().Equals("MDFE"))
                doc.Schemas.Add("http://www.portalfiscal.inf.br/mdfe", uri_schema.Trim());
            else
                doc.Schemas.Add("http://www.portalfiscal.inf.br/nfe", uri_schema.Trim());

            ValidationEventHandler eventHandler = new ValidationEventHandler(reader_ValidationEventHandler);
            doc.Validate(eventHandler);
            if (!string.IsNullOrEmpty(Retorno))
                Retorno = "Início da validação..." + Retorno + "\rFim de validação\n";
        }

        private static void reader_ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    {
                        Retorno += string.Format("\rLinha:{0} Coluna:{1} Erro:{2}\r", new object[] { e.Exception.LinePosition, e.Exception.LineNumber, e.Exception.Message });
                        break;
                    }
                case XmlSeverityType.Warning:
                    {
                        Retorno += string.Format("\rLinha:{0} Coluna:{1} Warning:{2}\r", new object[] { e.Exception.LinePosition, e.Exception.LineNumber, e.Exception.Message });
                        break;
                    }
            }
        }
    }   
}
