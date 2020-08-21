using System;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Utils
{
    public partial class NativeMethods
    {
        /// Return Type: BOOL->int
        ///fBlockIt: BOOL->int
        [DllImportAttribute("user32.dll", EntryPoint = "BlockInput")]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool BlockInput([MarshalAsAttribute(UnmanagedType.Bool)] bool fBlockIt);
    }
    
    public enum TTpModo { tm_Standby, tm_Insert, tm_Edit, tm_busca };

    public struct Parcelas
    {
        public string vCd_empresa
        {
            get;
            set;
        }
        public decimal? vNr_lancto
        {
            get;
            set;
        }
        public decimal? vCd_parcela
        {
            get;
            set;
        }
    }

    public struct TDataCombo
    {
        public TDataCombo(string Display, string Value)
        {
            vDisplay = Display;
            vValue = Value;
        }
        private string vDisplay;
        public string Display
        {
            get { return vDisplay; }
            set { vDisplay = value; }
        }
        private string vValue;
        public string Value
        {
            get { return vValue; }
            set { vValue = value; }
        }
    }

    public struct TpBusca
    {
        public string vNM_Caption;
        public int vWidth;
        public string vNM_Campo;
        public string vVL_Busca;
        public string vOperador;
    }

    
    public struct CFGBanco
    {
        
        public string Nm_servidor;
        
        public string Nm_bancoDados;
        
        public string Nm_login;
    }

    public struct Parametros
    {
        public static string pubNM_Servidor;
        public static string pubNM_BancoDados;
        public static string pubLogin;
        public static string pubSenha;
        public static string pubTerminal;
        public static string pubPathConfig;
        public static short pubTopMax;
        public static string pubCultura;
        public static bool ST_UtilizarCoringaEsq;
        public static string WS_ServidorHelpDesk;
        public static decimal pubTmpStatusTicket;
        public static decimal pubTmpMsgTicket;
        public static bool pubTruncarSubTotal;
        public static string pubPathAliance;
        public static string URL_Utils;
    }

    public struct ParamGer
    {
        public static string paramGer = "PATH_DLL|" +
                                        "PATH_RELATORIO";
    }

    public class Estruturas
    {
        public static void CriarParametro(ref TpBusca[] filtro, string Key, string Value, string Operador = "=")
        {
            if (string.IsNullOrEmpty(Value) ? false : !string.IsNullOrEmpty(Value.Replace("'", "")))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Key;
                filtro[filtro.Length - 1].vOperador = Operador;
                filtro[filtro.Length - 1].vVL_Busca = Value;
            }
        }
        public static string StrTam(string vStr, string vStrAcrescentar, bool vSt_AcrescentarDireita, int vTamanho)
        {
            int len = vStr.Length;
            if (vStr.Length < vTamanho)
            {
                for (int i = 0; i < (vTamanho - len); i++)
                    if (vSt_AcrescentarDireita)
                        vStr += vStrAcrescentar;
                    else
                        vStr = vStrAcrescentar + vStr;
                return vStr;
            }
            else if (vStr.Length.Equals(vTamanho))
                return vStr;
            else
                return vStr.Substring(0, vTamanho);
        }

        public static int Mod11(string vValor, int vBase, bool vResto, int vVl_complento)
        {
            int soma = 0;
            int peso = 2;
            for (int i = (vValor.Trim().Length - 1); i >= 0; i--)
            {
                soma += Convert.ToInt32(vValor.Trim()[i].ToString()) * peso;
                if (peso < vBase)
                    peso += 1;
                else
                    peso = 2;
            }
            if (vResto)
                return (soma + vVl_complento) % 11;
            else
            {
                int ret = ((soma + vVl_complento) % 11);
                int digito = 11 - ret;
                if (digito > 9)
                    return 0;
                else
                    return digito;
            }
        }

        public static int Mod10(string vValor, int vBase)
        {
            int soma = 0;
            int peso = 2;
            for (int i = (vValor.Trim().Length - 1); i >= 0; i--)
            {
                soma += Convert.ToInt32(vValor.Trim()[i].ToString()) * peso;
                if (peso < vBase)
                    peso += 1;
                else
                    peso = 2;
            }
            int digito = 10 - (soma % 10);
            if (digito > 9)
                return 0;
            else
                return digito;
        }

        public static int Mod10(string vValor)
        {
            int peso = 2;
            string auxiliar = string.Empty;
            for (int i = (vValor.Trim().Length - 1); i >= 0; i--)
            {
                auxiliar = Convert.ToInt32(vValor.Trim()[i].ToString()) * peso + auxiliar;
                if (peso == 1)
                    peso = 2;
                else
                    peso = 1;
            }
            int digito = 0;
            for (int i = 0; i < auxiliar.Trim().Length; i++)
                digito += Convert.ToInt32(auxiliar.Trim()[i].ToString());
            digito = 10 - (digito % 10);
            if (digito > 9)
                return 0;
            else
                return digito;
        }

        public static int DigitoEAN13(string vValor)
        {
            int soma_par = 0;
            int soma_impar = 0;
            for (int i = vValor.ToCharArray().Length - 1; i >= 0; i--)
            {
                if (i.NumeroPar())
                    soma_par += Convert.ToInt32(vValor.ToCharArray()[i].ToString());
                else if (i.NumeroImpar())
                    soma_impar += Convert.ToInt32(vValor.ToCharArray()[i].ToString());
            }
            int soma = soma_par + (soma_impar * 3);
            int digito = 0;
            while (!soma.Multiplo10())
            {
                soma++;
                digito++;
            }
            return digito;
        }

        public static int CalcFatorVencto(DateTime vDt_Vencto)
        {
            return vDt_Vencto.Subtract(new DateTime(1997, 10, 07)).Days;
        }

        public static decimal[] calcularRateio(int QTDVezes, decimal valor, decimal[] valorAlterarRateio)
        {
            decimal totalRateio = valor / QTDVezes;
            decimal[] rateio = new decimal[QTDVezes];

            try
            {
                for (int i = 0; i < QTDVezes; i++)
                {
                    decimal valorRateio = 0M;

                    for (int x = 0; x < rateio.Length; x++)
                    {
                        if (rateio[x] != 0M)
                        {
                            valorRateio = valorRateio + rateio[x];
                        }
                    }

                    if (valorRateio < valor)
                    {
                        if (i == (QTDVezes - 1))
                        {
                            valorRateio = valor - valorRateio;
                        }
                        else
                        {
                            if ((valorAlterarRateio != null) && (valorAlterarRateio[i] != 0M))
                            {
                                valorRateio = valorAlterarRateio[i];
                            }
                            else
                            {
                                valorRateio = totalRateio;
                            }
                        }
                    }
                    else
                    {
                        return null;
                    }

                    rateio[i] = Math.Round(valorRateio, 2);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao calcular o rateio: " + erro.ToString());
            }

            return rateio;
        }

        public static void EnviarFtp(string arquivo,
                                     string Servidor_ftp,
                                     string Usuario_ftp,
                                     string Senha_ftp)
        {
            System.IO.FileInfo fileInf = new System.IO.FileInfo(arquivo);
            string uri = "ftp://" + Servidor_ftp.Trim() + "/" + fileInf.Name;
            System.Net.FtpWebRequest reqFtp;
            reqFtp = (System.Net.FtpWebRequest)System.Net.FtpWebRequest.Create(new System.Uri(uri));
            reqFtp.Credentials = new System.Net.NetworkCredential(Usuario_ftp.Trim(), Servidor_ftp.Trim());
            reqFtp.KeepAlive = false;
            reqFtp.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            reqFtp.UseBinary = true;
            reqFtp.ContentLength = fileInf.Length;
            int bufflength = 2048;
            byte[] buff = new byte[bufflength];
            int contLength;
            System.IO.FileStream fs = fileInf.OpenRead();
            try
            {
                System.IO.Stream atm = reqFtp.GetRequestStream();
                contLength = fs.Read(buff, 0, bufflength);
                while (contLength != 0)
                {
                    atm.Write(buff, 0, contLength);
                    contLength = fs.Read(buff, 0, bufflength);
                }
                atm.Close();
                System.Net.FtpWebResponse response = (System.Net.FtpWebResponse)reqFtp.GetResponse();
                string mensagem = response.StatusDescription;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.Trim());
            }
        }

        public static string GetSerialHd()
        {
            System.Management.ManagementObject disk = new System.Management.ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            return disk["VolumeSerialNumber"].ToString();
            //return "02AB1309";Serial computador casa do pescado
        }

        public static string CalcChaveAcesso(string valor)
        {
            Cryptography.Cryptography cr = new Cryptography.Cryptography();
            return cr.Encrypt(valor);
        }

        public static string DecChaveAcesso(string valor)
        {
            Cryptography.Cryptography cr = new Cryptography.Cryptography();
            return cr.Decrypt(valor);
        }

        public static string PaginaSuporteOnLine()
        {
            System.Text.StringBuilder html = new System.Text.StringBuilder();
            html.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            html.AppendLine("<head>");
            html.AppendLine("<title>");
            html.AppendLine(Parametros.pubNM_BancoDados.Trim().ToUpper() + "-" + Parametros.pubLogin.Trim().ToUpper());
            html.AppendLine("</title>");
            html.AppendLine("</head>");

            html.AppendLine("<body>");
            html.AppendLine(SettingsUtils.Default.URL_SUPORTE.Trim());
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            return html.ToString();
        }

        public static bool BaixarDll(string Nm_dll)
        {
            if (System.IO.File.Exists(Utils.Parametros.pubPathAliance.Trim() +
                                      System.IO.Path.DirectorySeparatorChar.ToString() + Nm_dll.Trim()))
                return true;
            //Implementar o codigo para baixar arquivos
            if (!string.IsNullOrEmpty(Parametros.URL_Utils))
            {
                string path = Parametros.URL_Utils;
                if (path.Trim().Substring(path.Trim().Length - 1, 1) != "/")
                    path += "/";
                try
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    wc.BaseAddress = path.Trim();
                    byte[] buff = new byte[0];
                    buff = wc.DownloadData(path.Trim() + Nm_dll.Trim());
                    System.IO.FileInfo fi = new System.IO.FileInfo(Utils.Parametros.pubPathAliance.Trim() +
                                                                   System.IO.Path.DirectorySeparatorChar.ToString() +
                                                                   Nm_dll.Trim());
                    System.IO.FileStream fs = fi.Create();
                    fs.Write(buff, 0, buff.Length);
                    fs.Close();
                    return true;
                }
                catch
                { return false; }
            }
            else
                return false;
        }

        public static bool BaixarArqAux(string Url_download,
                                        string Nm_arquivo,
                                        string Path_arquivo,
                                        ref byte[] buff)
        {
            if (System.IO.File.Exists(Path_arquivo.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + Nm_arquivo.Trim()))
                System.IO.File.Delete(Path_arquivo.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + Nm_arquivo.Trim());
            //Implementar o codigo para baixar arquivos
            if (!string.IsNullOrEmpty(Url_download))
            {
                if (Url_download.Trim().Substring(Url_download.Trim().Length - 1, 1) != "/")
                    Url_download += "/";
                try
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    wc.BaseAddress = Url_download.Trim();
                    buff = new byte[0];
                    buff = wc.DownloadData(Url_download.Trim() + Nm_arquivo.Trim());
                    if (!string.IsNullOrEmpty(Path_arquivo))
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(Path_arquivo.Trim() +
                                                                       System.IO.Path.DirectorySeparatorChar.ToString() +
                                                                       Nm_arquivo.Trim());
                        System.IO.FileStream fs = fi.Create();
                        fs.Write(buff, 0, buff.Length);
                        fs.Close();
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }

        public static decimal Truncar(decimal valor, decimal CasasDec)
        {
            decimal casas = decimal.Zero;
            if (CasasDec.Equals(1))
                casas = 10;
            else if (CasasDec.Equals(2))
                casas = 100;
            else if (CasasDec.Equals(3))
                casas = 1000;
            else if (CasasDec.Equals(4))
                casas = 10000;
            else if (CasasDec > 4)
                casas = 100000;
            if (casas.Equals(decimal.Zero))
                return Math.Truncate(valor);
            else
            {
                valor *= casas;
                valor = Math.Truncate(valor);
                valor /= casas;
                return valor;
            } 
        }

        public static string SHA1(string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                byte[] data = System.Text.Encoding.Default.GetBytes(val);
                byte[] ret;
                System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                ret = sha.ComputeHash(data);
                string hexa = string.Empty;
                foreach (byte c in ret)
                {
                    int value = Convert.ToInt32(c);
                    hexa += String.Format("{0:X}", value);
                }
                return BitConverter.ToString(new System.Security.Cryptography.SHA1CryptoServiceProvider().ComputeHash(data)).Replace("-", string.Empty);
            }
            else return string.Empty;
        }

        public static bool ValidarChaveAcesso(string Cnpj,
                                              double Sequencial,
                                              DateTime Dt_licenca,
                                              double Qt_diasvalidade,
                                              string Chave)
        {
            return Chave.Trim().Equals(new Cryptography.Cryptography().GerarChaveAliance(Cnpj.SoNumero(),
                                                                                         Sequencial,
                                                                                         Dt_licenca,
                                                                                         Qt_diasvalidade));
        }
    }

    public static class CNPJ_Valido
    {
        private static string _nr_CNPJ;
        public static string nr_CNPJ
        {
            get
            {
                return _nr_CNPJ;
            }
            set
            {
                string tmp = value.SoNumero();
                if (!string.IsNullOrEmpty(tmp))
                    if (decimal.Parse(tmp) > decimal.Zero)
                        _nr_CNPJ = ValidaCNPJ(tmp) ? tmp : string.Empty;
                    else 
                        _nr_CNPJ = string.Empty;
                else
                    _nr_CNPJ = string.Empty;
            }
        }
        private static bool ValidaCNPJ(string num)
        {
            if (num.Trim().Length != 14)
                return false;
            Int32[] n = new Int32[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int d1 = 0, d2 = 0, y = 0;
            string digitado = num.Substring(12, 2), calculado = "";

            try
            {
                for (int x = 0; x < 12; x++)
                    n[x] = Convert.ToInt32(num[x].ToString());

                y = 2;
                d1 = 0;
                d2 = 0;
                for (int x = 12; x >= 1; x--)
                {
                    d1 += n[x - 1] * y;
                    y++;
                    if (y > 9) y = 2;
                };
                d1 = 11 - (d1 % 11);
                if (d1 >= 10) d1 = 0;

                y = 3;
                d2 = d1 * 2;

                for (int x = 12; x >= 1; x--)
                {
                    d2 += n[x - 1] * y;
                    y++;
                    if (y > 9) y = 2;
                };


                d2 = 11 - (d2 % 11);
                if (d2 >= 10) d2 = 0;
                calculado = d1.ToString() + d2.ToString();


                if (calculado == digitado)
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            };

        }
    }

    public static class Convercao_imagem
    {
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
    }

    public static class CPF_Valido
    {
        private static string _nr_CPF;
        public static string nr_CPF
        {
            get { return _nr_CPF; }
            set
            {
                string tmp = value.SoNumero();
                if (!string.IsNullOrEmpty(tmp))
                    if (decimal.Parse(tmp) > decimal.Zero)
                        _nr_CPF = ValidaCPF(tmp) ? tmp : string.Empty;
                    else
                        _nr_CPF = string.Empty;
                else
                    _nr_CPF = string.Empty;
            }
        }
        private static bool ValidaCPF(string num)
        {
            if (num.Trim().Length != 11)
                return false;
            Int32[] n = new Int32[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int d1 = 0, d2 = 0, y = 0;
            string digitado = num.Substring(9, 2), calculado = "";

            try
            {
                for (int x = 0; x < 9; x++)
                    n[x] = Convert.ToInt32(num[x].ToString());

                y = 2;
                for (int x = 9; x >= 1; x--)
                {
                    d1 += n[x - 1] * y;
                    y++;
                };
                d1 = 11 - (d1 % 11);
                if (d1 >= 10) d1 = 0;

                y = 3;
                for (int x = 9; x >= 1; x--)
                {
                    d2 += n[x - 1] * y;
                    y++;
                };

                d2 = d1 * 2 + d2;
                d2 = 11 - (d2 % 11);
                if (d2 >= 10) d2 = 0;
                calculado = d1.ToString() + d2.ToString();
                if (calculado == digitado)
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            }
        }
    }

    public static class ShapeGrid
    {
        public static void SaveShape(Form Formulario, DataGridView Grid)
        {
            //BUSCA O NOME DAS COLUNAS E ORDEM
            DataSet ds = new DataSet();
            string vPath = Parametros.pubPathConfig;
            if ((vPath == null ? string.Empty : vPath) != string.Empty)
            {
                if (vPath.Substring(vPath.Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                    vPath += System.IO.Path.DirectorySeparatorChar.ToString();
            }
            else
                vPath = Parametros.pubPathAliance.Trim() + System.IO.Path.DirectorySeparatorChar;

            try
            {
                if (System.IO.File.Exists(vPath + "configGrid.xml"))
                    ds.ReadXml(vPath + "configGrid.xml");
                else
                {
                    DataTable dt_config = new DataTable("tb_config_grid");
                    ds.Tables.Add(dt_config);

                    DataColumn vlogin = new DataColumn("login", Type.GetType("System.String"));
                    DataColumn nm_formulario = new DataColumn("nm_formulario", Type.GetType("System.String"));
                    DataColumn nm_grid = new DataColumn("nm_grid", Type.GetType("System.String"));
                    DataColumn nm_coluna = new DataColumn("nm_coluna", Type.GetType("System.String"));
                    DataColumn[] pk = new DataColumn[] { vlogin, nm_formulario, nm_grid, nm_coluna };
                    dt_config.Columns.Add(vlogin);
                    dt_config.Columns.Add(nm_formulario);
                    dt_config.Columns.Add(nm_grid);
                    dt_config.Columns.Add(nm_coluna);
                    dt_config.PrimaryKey = pk;
                    dt_config.Columns.Add("ordem_campo", Type.GetType("System.Int32"));
                }

                for (int i = 0; i < Grid.ColumnCount; i++)
                {
                    DataRow linha = ds.Tables[0].NewRow();

                    linha["nm_coluna"] = Grid.Columns[i].Name.Trim();
                    linha["ordem_campo"] = Grid.Columns[i].DisplayIndex.ToString();
                    linha["login"] = Parametros.pubLogin;
                    linha["nm_formulario"] = Formulario.Name;
                    linha["nm_grid"] = Grid.Name;

                    object[] nChave = new object[] { Utils.Parametros.pubLogin, Formulario.Name, Grid.Name, Grid.Columns[i].Name.Trim() };
                    if (ds.Tables[0].Rows.Count > 0)
                        if (ds.Tables[0].Rows.Contains(nChave))
                            ds.Tables[0].Rows.Remove(ds.Tables[0].Rows.Find(nChave));
                    ds.Tables[0].Rows.Add(linha);
                }
                try
                {
                    ds.WriteXml(vPath + "configGrid.xml", XmlWriteMode.WriteSchema);
                }
                catch { }
            }
            catch 
            {
                if (System.IO.File.Exists(vPath + "configGrid.xml"))
                    System.IO.File.Delete(vPath + "configGrid.xml");
            }
        }

        public static void RestoreShape(Form Formulario, DataGridView Grid)
        {
            DataSet ds_config = new DataSet();
            string vPath = Parametros.pubPathConfig;
            if ((vPath == null ? string.Empty : vPath) != string.Empty)
            {
                if (vPath.Substring(vPath.Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                    vPath += System.IO.Path.DirectorySeparatorChar.ToString();
            }
            else
                vPath = Parametros.pubPathAliance.Trim() + System.IO.Path.DirectorySeparatorChar;
            try
            {
                if (System.IO.File.Exists(vPath + "configGrid.xml"))
                {
                    ds_config.ReadXml(vPath + "configGrid.xml", XmlReadMode.ReadSchema);
                    for (int i = 0; i < Grid.Columns.Count; i++)
                    {
                        object[] chave = new object[] { Utils.Parametros.pubLogin, Formulario.Name, Grid.Name, Grid.Columns[i].Name };
                        DataRow linha = ds_config.Tables[0].Rows.Find(chave);

                        Grid.Columns[i].DisplayIndex = Convert.ToInt32(linha["ordem_campo"]);
                    }
                    Grid.Refresh();
                }
            }
            catch 
            {
                if (System.IO.File.Exists(vPath + "configGrid.xml"))
                    System.IO.File.Delete(vPath + "configGrid.xml");
            }
        }
    }

    public static class TVersaoOS
    {
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool lpSystemInfo);

        private static bool Is32BitProcessOn64BitProcessor()
        {
            bool retVal;

            IsWow64Process(Process.GetCurrentProcess().Handle, out retVal);

            return retVal;
        } 

        public static bool Is64Bit()
        {
            if (IntPtr.Size == 8 || (IntPtr.Size == 4 && Is32BitProcessOn64BitProcessor()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }   

    public static class TGavetaDinheiro
    {
        public static void AbrirGaveta(string Porta, string Comando)
        {
            System.IO.FileInfo f = null;
            System.IO.StreamWriter w = null;
            f = new System.IO.FileInfo(System.IO.Path.GetTempPath() + System.IO.Path.DirectorySeparatorChar + "AbreGaveta.txt");
            w = f.CreateText();
            try
            {
                if (!string.IsNullOrEmpty(Comando.Trim()))
                {
                    string[] v = Comando.Split(new char[] { '|' });
                    if (v.Length > 0)
                        foreach (string s in v)
                            w.Write(Convert.ToChar(Convert.ToInt32(s)));
                    else
                    {
                        w.Write(Convert.ToChar(27));
                        w.Write(Convert.ToChar(118));
                        w.Write(Convert.ToChar(110));
                    }
                }
                else
                {
                    w.Write(Convert.ToChar(27));
                    w.Write(Convert.ToChar(118));
                    w.Write(Convert.ToChar(110));
                }
                w.Flush();

                f.CopyTo(Porta);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message.Trim()); }
            finally
            {
                w.Dispose();
                f = null;
            }
        }
    }

    public static class TEtiquetaZebra
    {
        public static void ImpEtiquetaL1(string Referencia,
                                         string Ds_produto,
                                         string Cod_barra,
                                         decimal Vl_preco,
                                         string Porta)
        {
            if (!System.IO.Directory.Exists("c:\\aliance.net"))
                System.IO.Directory.CreateDirectory("c:\\aliance.net");
            System.IO.FileInfo f = new System.IO.FileInfo("c:\\aliance.net\\etiqueta.txt");
            System.IO.StreamWriter w = f.CreateText();
            try
            {
                w.WriteLine("I8,A,001");
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("Q120,022");
                w.WriteLine("q831");
                w.WriteLine("rN");
                w.WriteLine("S4");
                w.WriteLine("D7");
                w.WriteLine("ZT");
                w.WriteLine("JF");
                w.WriteLine("OD");
                w.WriteLine("R96,0");
                w.WriteLine("f100");
                w.WriteLine("N");
                if(!string.IsNullOrEmpty(Cod_barra))
                    w.WriteLine("B509,6,0,E30,1,2,56,B,\"" + Cod_barra.Trim() + "\"");
                w.WriteLine("A499,76,0,1,1,1,N,\"Ref: " + Referencia.Trim() + "\"");
                w.WriteLine("A338,7,0,1,1,1,N,\"Ref: " + Referencia + "\"");
                string prod1 = string.Empty;
                string prod2 = string.Empty;
                string prod3 = string.Empty;
                string prod4 = string.Empty;
                if (Ds_produto.Trim().Length > 15)
                {
                    prod1 = Ds_produto.Trim().Substring(0, 15);
                    Ds_produto = Ds_produto.Remove(0, 15);
                    if (Ds_produto.Trim().Length > 15)
                    {
                        prod2 = Ds_produto.Trim().Substring(0, 15);
                        Ds_produto = Ds_produto.Remove(0, 15);
                        if (Ds_produto.Trim().Length > 15)
                        {
                            prod3 = Ds_produto.Trim().Substring(0, 15);
                            Ds_produto = Ds_produto.Remove(0, 15);
                            if (Ds_produto.Trim().Length > 15)
                                prod4 = Ds_produto.Trim().Substring(0, 15);
                            else prod4 = Ds_produto;
                        }
                        else prod3 = Ds_produto;
                    }
                    else prod2 = Ds_produto;
                }
                else prod1 = Ds_produto;
                if(!string.IsNullOrEmpty(prod1))
                    w.WriteLine("A338,19,0,1,1,1,N,\"" + prod1.Trim() + "\"");
                if(!string.IsNullOrEmpty(prod2))
                    w.WriteLine("A338,31,0,1,1,1,N,\"" + prod2.Trim() + "\"");
                if(!string.IsNullOrEmpty(prod3))
                    w.WriteLine("A338,43,0,1,1,1,N,\"" + prod3.Trim() + "\"");
                if(!string.IsNullOrEmpty(prod4))
                    w.WriteLine("A338,55,0,1,1,1,N,\"" + prod4.Trim() + "\"");
                w.WriteLine("A357,77,0,1,1,1,N,\"#000" + decimal.Divide(Vl_preco, 5).ToString("N4", new System.Globalization.CultureInfo("pt-BR")) + "#\"");
                w.WriteLine("P1");
                w.Flush();
                f.CopyTo(Porta.Trim());
            }
            finally
            {
                w.Dispose();
                f = null;
            }
        }

        public static void ImpEtiquetaL2(string Cd_produto,
                                         string Ds_produto,
                                         decimal Vl_preco,
                                         string Porta)
        {
            if (!System.IO.File.Exists("C:\\Aliance.NET\\zebra2.prn"))
            {
                MessageBox.Show("Não existe layout <zebra2.prn>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string prod1 = string.Empty;
            string prod2 = string.Empty;
            string prod3 = string.Empty;
            if (Ds_produto.Trim().Length > 25)
            {
                prod1 = Ds_produto.Trim().Substring(0, 25);
                Ds_produto = Ds_produto.Remove(0, 25);
                if (Ds_produto.Trim().Length > 25)
                {
                    prod2 = Ds_produto.Trim().Substring(0, 25);
                    Ds_produto = Ds_produto.Remove(0, 25);
                    if (Ds_produto.Trim().Length > 25)
                        prod3 = Ds_produto.Trim().Substring(0, 25);
                    else prod3 = Ds_produto;
                }
                else prod2 = Ds_produto;
            }
            else prod1 = Ds_produto;
            System.IO.FileInfo f = null;
            try
            {
                string layout = System.IO.File.ReadAllText("C:\\Aliance.NET\\zebra2.prn");
                layout = layout.Replace("@CODIGO", Cd_produto).Replace("@PROD1", prod1).Replace("@PROD2", prod2).Replace("@PROD3", prod3).Replace("@VALOR", Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR")));
                System.IO.File.WriteAllText("C:\\Aliance.NET\\etiqueta.txt", layout);
                f = new System.IO.FileInfo("C:\\Aliance.NET\\etiqueta.txt");                
                f.CopyTo(Porta.Trim());
            }
            finally
            { f = null; }
        }

        public static void ImpEtiquetaL3(string Cd_produto,
                                         string Ds_produto,
                                         string Cod_barra,
                                         decimal Vl_preco,
                                         string Porta)
        {
            if (!System.IO.File.Exists("C:\\Aliance.NET\\zebra3.prn"))
            {
                MessageBox.Show("Não existe layout <zebra3.prn>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string prod1 = string.Empty;
            string prod2 = string.Empty;
            string prod3 = string.Empty;
            if (Ds_produto.Trim().Length > 25)
            {
                prod1 = Ds_produto.Trim().Substring(0, 25);
                Ds_produto = Ds_produto.Remove(0, 25);
                if (Ds_produto.Trim().Length > 25)
                {
                    prod2 = Ds_produto.Trim().Substring(0, 25);
                    Ds_produto = Ds_produto.Remove(0, 25);
                    if (Ds_produto.Trim().Length > 25)
                        prod3 = Ds_produto.Trim().Substring(0, 25);
                    else prod3 = Ds_produto;
                }
                else prod2 = Ds_produto;
            }
            else prod1 = Ds_produto;
            System.IO.FileInfo f = null;
            try
            {
                string layout = System.IO.File.ReadAllText("C:\\Aliance.NET\\zebra3.prn");
                layout = layout.Replace("@CODIGO", Cd_produto).Replace("@PROD1", prod1).Replace("@PROD2", prod2).Replace("@PROD3", prod3).Replace("@VALOR", Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).Replace("@BARRA", Cod_barra);
                System.IO.File.WriteAllText("C:\\Aliance.NET\\etiqueta.txt", layout);
                f = new System.IO.FileInfo("C:\\Aliance.NET\\etiqueta.txt");
                f.CopyTo(Porta.Trim());
            }
            finally
            { f = null; }
        }

        public static void ImpEtiquetaL4(string Produto,
                                         string Cod_barra,
                                         int Qtd_etiqueta,
                                         string Porta)
        {
            if (!System.IO.Directory.Exists("c:\\aliance.net"))
                System.IO.Directory.CreateDirectory("c:\\aliance.net");
            System.IO.FileInfo f = new System.IO.FileInfo("c:\\aliance.net\\etiqueta.txt");
            System.IO.StreamWriter w = f.CreateText();
            try
            {
                w.WriteLine("I8,A,001");
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("Q240,022");
                w.WriteLine("q831");
                w.WriteLine("rN");
                w.WriteLine("S4");
                w.WriteLine("D7");
                w.WriteLine("ZT");
                w.WriteLine("JF");
                w.WriteLine("OD");
                w.WriteLine("R96,0");
                w.WriteLine("f100");
                w.WriteLine("N");
                if (!string.IsNullOrEmpty(Cod_barra))
                    w.WriteLine("B180,83,0,E30,2,4,56,B,\"" + Cod_barra.Trim() + "\"");
                string prod1 = string.Empty;
                string prod2 = string.Empty;
                string prod3 = string.Empty;
                string prod4 = string.Empty;
                if (Produto.Trim().Length > 38)
                {
                    prod1 = Produto.Trim().Substring(0, 38);
                    Produto = Produto.Remove(0, 38);
                    if (Produto.Trim().Length > 38)
                    {
                        prod2 = Produto.Trim().Substring(0, 38);
                        Produto = Produto.Remove(0, 38);
                        if (Produto.Trim().Length > 38)
                        {
                            prod3 = Produto.Trim().Substring(0, 38);
                            Produto = Produto.Remove(0, 38);
                            if (Produto.Trim().Length > 38)
                                prod4 = Produto.Trim().Substring(0, 38);
                            else prod4 = Produto;
                        }
                        else prod3 = Produto;
                    }
                    else prod2 = Produto;
                }
                else prod1 = Produto;
                if (!string.IsNullOrEmpty(prod1))
                    w.WriteLine("A100,40,0,3,1,1,N,\"" + prod1.Trim() + "\"");
                if (!string.IsNullOrEmpty(prod2))
                    w.WriteLine("A100,60,0,3,1,1,N,\"" + prod2.Trim() + "\"");
                w.WriteLine("P" + Qtd_etiqueta.ToString());
                w.Flush();
                f.CopyTo(Porta.Trim());
            }
            finally
            {
                w.Dispose();
                f = null;
            }
        }
        public static void ImpEtiquetaL5(string Produto,
                                         string Cod_barra,
                                         decimal Vl_preco,
                                         int Qtd_etiqueta,
                                         string Porta)
        {
            if (!System.IO.Directory.Exists("c:\\aliance.net"))
                System.IO.Directory.CreateDirectory("c:\\aliance.net");
            System.IO.FileInfo f = new System.IO.FileInfo("c:\\aliance.net\\etiqueta.txt");
            System.IO.StreamWriter w = f.CreateText();
            try
            {
                w.WriteLine("I8,A,001");
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("822,022");
                w.WriteLine("q400");
                w.WriteLine("rN");
                w.WriteLine("S4");
                w.WriteLine("D7");
                w.WriteLine("ZT");
                w.WriteLine("JF");
                w.WriteLine("OD");
                w.WriteLine("R8,0");
                w.WriteLine("f100");
                w.WriteLine("N");
                if (!string.IsNullOrEmpty(Cod_barra))
                {
                    w.WriteLine("B40,104,0,E30,2,4,56,B,\"" + Cod_barra.Trim() + "\"");
                    w.WriteLine("B462,104,0,E30,2,4,56,B,\"" + Cod_barra.Trim() + "\"");
                }
                string prod1 = string.Empty;
                string prod2 = string.Empty;
                string prod3 = string.Empty;
                string prod4 = string.Empty;
                if (Produto.Trim().Length > 30)
                {
                    prod1 = Produto.Trim().Substring(0, 30);
                    Produto = Produto.Remove(0, 30);
                    if (Produto.Trim().Length > 30)
                    {
                        prod2 = Produto.Trim().Substring(0, 30);
                        Produto = Produto.Remove(0, 30);
                        if (Produto.Trim().Length > 30)
                        {
                            prod3 = Produto.Trim().Substring(0, 30);
                            Produto = Produto.Remove(0, 30);
                            if (Produto.Trim().Length > 30)
                                prod4 = Produto.Trim().Substring(0, 30);
                            else prod4 = Produto;
                        }
                        else prod3 = Produto;
                    }
                    else prod2 = Produto;
                }
                else prod1 = Produto;
                if (!string.IsNullOrEmpty(prod1))
                {
                    w.WriteLine("A8,8,0,2,1,1,N,\"" + prod1.Trim() + "\"");
                    w.WriteLine("A430,8,0,2,1,1,N,\"" + prod1.Trim() + "\"");
                }
                if (!string.IsNullOrEmpty(prod2))
                {
                    w.WriteLine("A8,24,0,2,1,1,N,\"" + prod2.Trim() + "\"");
                    w.WriteLine("A430,24,0,2,1,1,N,\"" + prod2.Trim() + "\"");
                }
                if (!string.IsNullOrEmpty(prod3))
                {
                    w.WriteLine("A8,40,0,2,1,1,N,\"" + prod3.Trim() + "\"");
                    w.WriteLine("A430,40,0,2,1,1,N,\"" + prod3.Trim() + "\"");
                }
                if (!string.IsNullOrEmpty(prod4))
                {
                    w.WriteLine("A8,56,0,2,1,1,N,\"" + prod4.Trim() + "\"");
                    w.WriteLine("A430,56,0,2,1,1,N,\"" + prod4.Trim() + "\"");
                }
                //Preco Venda
                if (Vl_preco > decimal.Zero)
                {
                    w.WriteLine("A8,72,0,3,1,1,N,\"" + Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)) + "\"");
                    w.WriteLine("A430,72,0,3,1,1,N,\"" + Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)) + "\"");
                }
                w.WriteLine("P" + Qtd_etiqueta.ToString());
                w.Flush();
                f.CopyTo(Porta.Trim());
            }
            finally
            {
                w.Dispose();
                f = null;
            }
        }

        public static void ImpEtiquetaL6(decimal Codigo,
                                        string Produto,
                                        string Cod_barra,
                                        decimal Vl_preco,
                                        int Qtd_etiqueta,
                                        string Porta)
        {
            if (!System.IO.Directory.Exists("c:\\aliance.net"))
                System.IO.Directory.CreateDirectory("c:\\aliance.net");
            System.IO.FileInfo f = new System.IO.FileInfo("c:\\aliance.net\\etiqueta.txt");
            System.IO.StreamWriter w = f.CreateText();
            try
            {
                w.WriteLine("I8,A,001");
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("Q176,024"); // altura espaco
                w.WriteLine("rN");
                w.WriteLine("S4");
                w.WriteLine("D7");
                w.WriteLine("ZT");
                w.WriteLine("JF");
                w.WriteLine("OD");
                w.WriteLine("f100");
                w.WriteLine("N");
                if (!string.IsNullOrEmpty(Cod_barra))
                {
                    w.WriteLine("B40,88,0,E30,2,4,56,B,\"" + Cod_barra.Trim() + "\"");
                    w.WriteLine("B320,88,0,E30,2,4,56,B,\"" + Cod_barra.Trim() + "\"");
                    w.WriteLine("B600,88,0,E30,2,4,56,B,\"" + Cod_barra.Trim() + "\"");
                }
                string prod1 = string.Empty;
                string prod2 = string.Empty;
                string prod3 = string.Empty;
                if (Produto.Trim().Length > 20)
                {
                    prod1 = Produto.Trim().Substring(0, 20);
                    Produto = Produto.Remove(0, 20);
                    if (Produto.Trim().Length > 20)
                    {
                        prod2 = Produto.Trim().Substring(0, 20);
                        Produto = Produto.Remove(0, 20);
                        if (Produto.Trim().Length > 20)
                        {
                            prod3 = Produto.Trim().Substring(0, 20);
                            Produto = Produto.Remove(0, 20);
                        }
                        else prod3 = Produto;
                    }
                    else prod2 = Produto;
                }
                else prod1 = Produto;
                if (!string.IsNullOrEmpty(prod1))
                {
                    w.WriteLine("A24,8,0,2,1,1,N,\"" + prod1.Trim() + "\"");
                    w.WriteLine("A304,8,0,2,1,1,N,\"" + prod1.Trim() + "\"");
                    w.WriteLine("A584,8,0,2,1,1,N,\"" + prod1.Trim() + "\"");
                }
                if (!string.IsNullOrEmpty(prod2))
                {
                    w.WriteLine("A24,32,0,2,1,1,N,\"" + prod2.Trim() + "\"");
                    w.WriteLine("A304,32,0,2,1,1,N,\"" + prod2.Trim() + "\"");
                    w.WriteLine("A584,32,0,2,1,1,N,\"" + prod2.Trim() + "\"");
                }
                //Preco Venda
                if (Vl_preco > decimal.Zero)
                {
                    w.WriteLine("A24,56,0,2,1,1,N,\"" + Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)) + " Cd:" + Codigo.ToString() + "\"");
                    w.WriteLine("A304,56,0,2,1,1,N,\"" + Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)) + " Cd:" + Codigo.ToString() + "\"");
                    w.WriteLine("A584,56,0,2,1,1,N,\"" + Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)) + " Cd:" + Codigo.ToString() + "\"");
                }
                w.WriteLine("P" + Qtd_etiqueta.ToString());
                w.Flush();
                f.CopyTo(Porta.Trim());
            }
            finally
            {
                w.Dispose();
                f = null;
            }
        }


    }
}
