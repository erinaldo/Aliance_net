using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaNegocio.Fiscal.IDominio
{
    public class TCN_ImportDominio
    {
        public static void GerarArquivo(string Cd_empresa,
                                        DateTime Dt_ini,
                                        DateTime Dt_fin,
                                        string Path,
                                        bool St_cliente,
                                        bool St_fornecedor,
                                        bool St_remetDest)
        {
            try
            {
                if (Path.Trim().Substring(Path.Trim().Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                    Path = Path.Trim() + System.IO.Path.DirectorySeparatorChar.ToString();
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Path.Trim() + Cd_empresa.Trim() + "IDominio.txt", false, System.Text.Encoding.Default))
                {
                    string arquivo = string.Empty;
                    if (St_cliente)
                        arquivo += TCN_IDominioClifor.GerarRegistroCliente(Cd_empresa,
                                                                           Dt_ini,
                                                                           Dt_fin);
                    if (St_fornecedor)
                        arquivo += TCN_IDominioClifor.GerarRegistroFornecedor(Cd_empresa,
                                                                              Dt_ini,
                                                                              Dt_fin);
                    if (St_remetDest)
                        arquivo += TCN_IDominioClifor.GerarRegistroRemetenteDest(Cd_empresa,
                                                                                 Dt_ini,
                                                                                 Dt_fin);
                    sw.Write(arquivo);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
    }
}
