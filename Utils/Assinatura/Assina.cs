using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;

namespace Utils.Assinatura
{
    public class TAssinatura2
    {
        public enum TTpArq { tpCancela, tpInutiliza, tpEnviaNFE, tpCCe, tpEnviaCTe, tpEventoCTe, tpLMCe, tpMDFe };
        public TTpArq Tipo_Arq { get; set; }
        
        public string DocXML
        { get; set; }

        public string Nr_certificado
        {
            get;
            set;
        }

        public TAssinatura2()
        { }

        public TAssinatura2(string nr_certificado)
        { this.Nr_certificado = nr_certificado; }

        public TAssinatura2(string nr_certificado,
                           TTpArq tipo_arq,
                           string doc)
        {
            this.Nr_certificado = nr_certificado;
            this.Tipo_Arq = tipo_arq;
            this.DocXML = doc;
        }

        public TAssinatura2(string nr_certificado,
                            string doc)
        {
            this.Nr_certificado = nr_certificado;
            this.DocXML = doc;
        }

        public static X509Certificate2 BuscaNroSerie(string NroSerie)
        {
            X509Certificate2 _X509Cert = null;
            //Cria objeto store
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            //Abre o Store como somente leitura
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            //Lista todos os certificados
            X509Certificate2Collection lCert = store.Certificates;
            lCert = lCert.Find(X509FindType.FindBySerialNumber, NroSerie, true);
            if (lCert.Count.Equals(0))
            {
                store.Close();
                store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                //Abre o Store como somente leitura
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                //Lista todos os certificados
                lCert = store.Certificates;
                lCert = lCert.Find(X509FindType.FindBySerialNumber, NroSerie, true);
                if (lCert.Count.Equals(0))
                {
                    store.Close();
                    throw new Exception("Nenhum certificado encontrado com o número de série: " + NroSerie.Trim());
                }
                else
                {
                    foreach (X509Certificate2 cert in lCert)
                        if (cert.HasPrivateKey &&
                            (cert.NotAfter > DateTime.Now) &&
                            (cert.NotBefore < DateTime.Now))
                        {
                            _X509Cert = cert;
                            break;
                        }
                }

            }
            else
            {
                foreach(X509Certificate2 cert in lCert)
                    if (cert.HasPrivateKey &&
                        (cert.NotAfter > DateTime.Now) &&
                        (cert.NotBefore < DateTime.Now))
                    {
                        _X509Cert = cert;
                        break;
                    }
            }
            store.Close();
            return _X509Cert;
        }

        public DateTime ValidadeCertificado()
        {
            if (string.IsNullOrEmpty(Nr_certificado))
                throw new Exception("Não existe numero serie configurado.");
            X509Certificate2 x509Cert = BuscaNroSerie(Nr_certificado);
            if (x509Cert == null)
                throw new Exception("Obrigatorio informar certificado.");
            return x509Cert.NotAfter;
        }   

        public string Assinar()
        {
            try
            {
                string RefUri = string.Empty;
                if (Tipo_Arq.Equals(TTpArq.tpEnviaNFE))
                    RefUri = "infNFe";
                else if (Tipo_Arq.Equals(TTpArq.tpCancela))
                    RefUri = "infCanc";
                else if (Tipo_Arq.Equals(TTpArq.tpInutiliza))
                    RefUri = "infInut";
                else if (Tipo_Arq.Equals(TTpArq.tpCCe))
                    RefUri = "infEvento";
                else if (Tipo_Arq.Equals(TTpArq.tpEnviaCTe))
                    RefUri = "infCte";
                else if (Tipo_Arq.Equals(TTpArq.tpEventoCTe))
                    RefUri = "infEvento";
                else if (Tipo_Arq.Equals(TTpArq.tpLMCe))
                    RefUri = "infLivroCombustivel";
                else if (Tipo_Arq.Equals(TTpArq.tpMDFe))
                    RefUri = "infMDFe";
                
                //Buscar certificado digital
                if (string.IsNullOrEmpty(Nr_certificado))
                    throw new Exception("Não existe numero serie configurado.");
                X509Certificate2 X509Cert = BuscaNroSerie(Nr_certificado);
                if (X509Cert == null)
                    throw new Exception("Obrigatorio informar certificado para assinar arquivo.");
                else
                {
                    // Create a new XML document.
                    XmlDocument doc = new XmlDocument();
                    // Format the document to ignore white spaces.
                    doc.PreserveWhitespace = false;
                    try
                    {
                        // Load the passed XML file using it’s name.
                        doc.LoadXml(DocXML);
                        // Verifica se a tag a ser assinada existe é única
                        int qtdeRefUri = doc.GetElementsByTagName(RefUri).Count;
                        
                        if (qtdeRefUri == 0)
                            // a URI indicada não existe
                            throw new Exception("A tag de assinatura " + RefUri.Trim() + " inexiste");
                        // Exsiste mais de uma tag a ser assinada
                        else
                        {
                            if (qtdeRefUri > 1)
                                // existe mais de uma URI indicada
                                throw new Exception("A tag de assinatura " + RefUri.Trim() + " não é unica");
                            else
                            {
                                try
                                {
                                    //Obter no a ser assinado
                                    XmlNodeList nInfNFe = doc.GetElementsByTagName(RefUri);
                                    foreach (XmlElement infNFe in nInfNFe)
                                    {
                                        string id = infNFe.Attributes.GetNamedItem("Id").Value;
                                        if (!string.IsNullOrEmpty(id))
                                        {
                                            SignedXml signedXml = new SignedXml(infNFe);
                                            signedXml.SigningKey = X509Cert.PrivateKey;

                                            Reference reference = new Reference("#" + id);
                                            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                                            reference.AddTransform(new XmlDsigC14NTransform());
                                            signedXml.AddReference(reference);

                                            KeyInfo key = new KeyInfo();
                                            key.AddClause(new KeyInfoX509Data(X509Cert));
                                            signedXml.KeyInfo = key;

                                            //Calcular assinatura
                                            signedXml.ComputeSignature();

                                            XmlElement xmlSignature = doc.CreateElement("Signature", "http://www.w3.org/2000/09/xmldsig#");
                                            XmlElement xmlSignedInfo = signedXml.SignedInfo.GetXml();
                                            XmlElement xmlKeyInfo = signedXml.KeyInfo.GetXml();

                                            XmlElement xmlSignatureValue = doc.CreateElement("SignatureValue", xmlSignature.NamespaceURI);
                                            string sigBase64 = Convert.ToBase64String(signedXml.Signature.SignatureValue);
                                            XmlText text = doc.CreateTextNode(sigBase64);
                                            xmlSignatureValue.AppendChild(text);
                                            xmlSignature.AppendChild(doc.ImportNode(xmlSignedInfo, true));
                                            xmlSignature.AppendChild(xmlSignatureValue);
                                            xmlSignature.AppendChild(doc.ImportNode(xmlKeyInfo, true));

                                            if (Tipo_Arq.Equals(TTpArq.tpCCe))
                                                doc.DocumentElement["evento"].AppendChild(xmlSignature);
                                            else if (Tipo_Arq.Equals(TTpArq.tpLMCe))
                                                doc.DocumentElement["livroCombustivel"].AppendChild(xmlSignature);
                                            else
                                                doc.DocumentElement.AppendChild(xmlSignature);

                                            break;
                                        }
                                    }
                                    return doc.OuterXml;
                                }                                                                                                                                                                                                                                                                                                                                                                                                                                       
                                catch (Exception caught)
                                { throw new Exception("Erro: Ao assinar o documento - " + caught.Message); }
                            }
                        }
                    }
                    catch (Exception caught)
                    { throw new Exception("Erro: XML mal formado - " + caught.Message); }
                }
            }
            catch (Exception ex)
            { throw new Exception("Erro assinar arquivo XML: " + ex.Message); }
        }

        public string AssinarNFSe()
        {
            try
            {
                //Buscar certificado digital
                X509Certificate2 X509Cert = new X509Certificate2();
                if (!string.IsNullOrEmpty(Nr_certificado.Trim()))
                    X509Cert = BuscaNroSerie(Nr_certificado.Trim());
                else
                    throw new Exception("Erro NFe: Numero Série do certificado invalido!");

                if (X509Cert == null)
                    throw new Exception("Obrigatorio informar certificado para assinar arquivo.");
                else
                {
                    string x = X509Cert.GetKeyAlgorithm().ToString();
                    XmlDocument doc = new XmlDocument();
                    // Format the document to ignore white spaces.
                    doc.PreserveWhitespace = false;
                    doc.LoadXml(DocXML);
                    // Create a SignedXml object.
                    SignedXml signedXml = new SignedXml(doc);

                    // Add the key to the SignedXml document
                    signedXml.SigningKey = X509Cert.PrivateKey;

                    // Create a reference to be signed
                    Reference reference = new Reference();
                    reference.Uri = string.Empty;

                    // Add an enveloped transformation to the reference.
                    XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                    reference.AddTransform(env);

                    XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                    reference.AddTransform(c14);

                    // Add the reference to the SignedXml object.
                    signedXml.AddReference(reference);

                    // Create a new KeyInfo object
                    KeyInfo keyInfo = new KeyInfo();

                    // Load the certificate into a KeyInfoX509Data object
                    // and add it to the KeyInfo object.
                    keyInfo.AddClause(new KeyInfoX509Data(X509Cert));

                    // Add the KeyInfo object to the SignedXml object.
                    signedXml.KeyInfo = keyInfo;

                    signedXml.ComputeSignature();

                    // Get the XML representation of the signature and save
                    // it to an XmlElement object.
                    XmlElement xmlDigitalSignature = signedXml.GetXml();

                    // Append the element to the XML document.
                    doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

                    return doc.OuterXml;
                }
            }
            catch (Exception ex)
            { throw new Exception("Erro assinar arquivo XML: " + ex.Message); }
        }
    }
}
