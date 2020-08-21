using CamadaDados.Consulta.Cadastro;
using CamadaDados.Diversos;
using CamadaDados.Faturamento.VendasExterna;
using CamadaDados.Financeiro.Bloqueto;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Fiscal;
using CamadaDados.Help;
using CamadaDados.WS_RDC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace ServiceRest
{
    public class DataService
    {
        public static string NovoTicket(Ticket ticket)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(string.IsNullOrWhiteSpace(Parametros.WS_ServidorHelpDesk) ? "http://191.32.62.40/AlianceAPI/" : Parametros.WS_ServidorHelpDesk);
            var result = client.PostAsync("api/HelpDesk/NovoTicket", new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8, "application/json")).Result;
            Task<string> s = result.Content.ReadAsStringAsync();
            return s.Result;
        }

        public static TList_Ticket BuscarTicket(string Id_ticket,
                                                string Ds_assunto,
                                                string Tp_data,
                                                string Dt_ini,
                                                string Dt_fin,
                                                string LoginCliente,
                                                string Status)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/BuscarTicket?id_ticket=" + Id_ticket +
                                            "&ds_assunto=" + Ds_assunto +
                                            "&prioridade=" + string.Empty +
                                            "&tp_data=" + Tp_data +
                                            "&dt_ini=" + Dt_ini +
                                            "&dt_fin=" + Dt_fin +
                                            "&loginCliente=" + LoginCliente +
                                            "&status=" + Status).Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TList_Ticket>(ts.Result);
            }
            else return null;
        }

        public static bool GravarHistorico(HistEvolucao historico)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            return client.PostAsync("api/HelpDesk/NovoHistorico", new StringContent(JsonConvert.SerializeObject(historico), Encoding.UTF8, "application/json")).Result.IsSuccessStatusCode;
        }

        public static List<HistEvolucao> BuscarHistorico(string LoginCliente)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/BuscarHistTicket?loginCliente=" + LoginCliente).Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                List<HistEvolucao> lTicket = JsonConvert.DeserializeObject<List<HistEvolucao>>(ts.Result);
                return lTicket;
            }
            else return null;
        }

        public static List<HistEvolucao> BuscarHistorico(string Id_ticket,
                                                         string Id_evolucao)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/BuscarHistorico?id_ticket=" + Id_ticket +
                                            "&id_evolucao=" + Id_evolucao).Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<HistEvolucao>>(ts.Result);
            }
            else return null;
        }

        public static List<Anexo> BuscarAnexos(string Id_ticket,
                                               string Id_evolucao)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/BuscarAnexo?id_ticket=" + Id_ticket +
                                            "&id_evolucao=" + Id_evolucao).Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Anexo>>(ts.Result);
            }
            else return null;
        }

        public static List<Evolucao> BuscarEvolucao(string Id_ticket)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/BuscarEvolucao?id_ticket=" + Id_ticket).Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                List<Evolucao> lEvolucao = JsonConvert.DeserializeObject<List<Evolucao>>(ts.Result);
                return lEvolucao.OrderBy(p => p.Dt_inietapa).ToList();
            }
            else return null;
        }

        public static TChaveLic CalcularLicenca(TList_CadEmpresa lEmp, string Uri)
        {
            string emp = string.Empty;
            string virg = string.Empty;
            lEmp.Where(p => !string.IsNullOrEmpty(p.rClifor.Nr_cgc.SoNumero())).ToList().ForEach(p =>
            {
                emp += virg + "'" + p.rClifor.Nr_cgc.SoNumero() + "'";
                virg = ",";
            });
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/CalcularSerial?cnpj_cliente=" + emp + "&dt_servidor=" + CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy") + "&diasvalidade=0").Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TChaveLic>(ts.Result);
            }
            else return null;
        }

        public static List<TRegistro_CadCFOP> BuscarCFOPRest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/BuscarCFOP").Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TRegistro_CadCFOP>>(ts.Result);
            }
            else return null;
        }

        public static List<TRegistro_CadNCM> BuscarNCMRest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/BuscarNCM").Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TRegistro_CadNCM>>(ts.Result);
            }
            else return null;
        }

        public static TEndereco_CEPRest BuscarEndCEPRest(string cep)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://viacep.com.br");
            Task<HttpResponseMessage> response = client.GetAsync("/ws/" + cep.SoNumero() + "/json");
            if (response.Result.IsSuccessStatusCode)
            {
                HttpContent content = response.Result.Content;
                Task<string> ret = content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TEndereco_CEPRest>(ret.Result);
            }
            else return null;
        }

        public static string ValidarLogin(TList_CadEmpresa lEmp, string Login_BI, string Senha_BI)
        {
            string emp = string.Empty;
            string virg = string.Empty;
            lEmp.Where(p => !string.IsNullOrEmpty(p.rClifor.Nr_cgc.SoNumero())).ToList().ForEach(p =>
            {
                emp += virg + "'" + p.rClifor.Nr_cgc.SoNumero() + "'";
                virg = ",";
            });
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/ValidarLogin?login=" + Login_BI + "&senha=" + Senha_BI + "&Cnpj=" + emp).Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsStringAsync().Result.SoNumero();
            else return string.Empty;
        }

        public static string ValidarLogin(string Cnpj, string Login_BI, string Senha_BI)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(string.IsNullOrWhiteSpace(Parametros.WS_ServidorHelpDesk) ? "http://191.32.62.40/AlianceAPI/" : Parametros.WS_ServidorHelpDesk);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/ValidarLogin?login=" + Login_BI + "&senha=" + Senha_BI + "&Cnpj=" + "'" + Cnpj + "'").Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsStringAsync().Result.SoNumero();
            else return string.Empty;
        }

        public static List<TRegistro_Cad_RDC> BuscarRDC(string ID_RDC,
                                                        string DS_RDC,
                                                        string Modulo,
                                                        string ST_RDC,
                                                        bool BuscarRelClasse,
                                                        bool NaoBuscarRelClasse)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            client.Timeout = new TimeSpan(0, 3, 0);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/BuscarRDC?ID_RDC=" + ID_RDC +
                                                           "&DS_RDC=" + DS_RDC +
                                                           "&Modulo=" + Modulo +
                                                           "&ST_RDC=" + ST_RDC +
                                                           "&BuscarRelClasse=" + BuscarRelClasse +
                                                           "&NaoBuscarRelClasse=" + NaoBuscarRelClasse).Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TRegistro_Cad_RDC>>(ts.Result);
            }
            else return null;
        }

        public static TRegistro_Cad_RDC BuscarDetalhesRDC(string ID_RDC)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            client.Timeout = new TimeSpan(0, 3, 0);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/BuscarDetalheRDC?ID_RDC=" + ID_RDC).Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TRegistro_Cad_RDC>(ts.Result);
            }
            else return null;
        }

        public static TRegistro_Cad_RDC BuscarRDCAtualizar(TRegistro_Cad_Report Reg_Report)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            client.Timeout = new TimeSpan(0, 3, 0);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/DownloadRDC?ID_RDC=" + Reg_Report.ID_RDC.Replace("-", "IFEM") +
                                                           "&NM_Classe=" + Reg_Report.NM_Classe +
                                                           "&Modulo=" + Reg_Report.Modulo +
                                                           "&Ident=" + Reg_Report.Ident +
                                                           "&ST_RDC=P").Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TRegistro_Cad_RDC>(ts.Result);
            }
            else return null;
        }

        public static decimal VerificarVersaoRDC(TRegistro_Cad_Report Reg_Report)
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            cliente.Timeout = new TimeSpan(0, 3, 0);
            HttpResponseMessage response = cliente.GetAsync("api/HelpDesk/VerificarVersaoRDC?ID_RDC=" + Reg_Report.ID_RDC.Replace("-", "IFEM") +
                                                            "&NM_Classe=" + Reg_Report.NM_Classe +
                                                            "&Modulo=" + Reg_Report.Modulo +
                                                            "&Ident=" + Reg_Report.Ident +
                                                            "&ST_RDC=P").Result;
            if (response.IsSuccessStatusCode)
                return decimal.Parse(response.Content.ReadAsStringAsync().Result.SoNumero());
            else return decimal.Zero;
        }

        public static string GravarRDC(TRegistro_Cad_RDC Reg_RDC)
        {
            //GRAVA E FECHA A CONEXÃO COM O WS
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            client.Timeout = new TimeSpan(0, 3, 0);
            var result = client.PostAsync("api/HelpDesk/GravarRDC", new StringContent(JsonConvert.SerializeObject(Reg_RDC), System.Text.Encoding.UTF8, "application/json")).Result;
            if (result.IsSuccessStatusCode)
                return result.Content.ReadAsStringAsync().Result;
            else return string.Empty;
        }

        public static void HomologarRDC(TRegistro_Cad_RDC Reg_RDC)
        {
            //CARREGA O OBJECT DO WS
            Reg_RDC.ST_RDC = "P";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            client.Timeout = new TimeSpan(0, 3, 0);
            var result = client.PostAsync("api/HelpDesk/HomologarRDC", new StringContent(JsonConvert.SerializeObject(Reg_RDC), System.Text.Encoding.UTF8, "application/json")).Result;
            if (result.IsSuccessStatusCode)
                throw new Exception("Relatório homologado com sucesso!");
            else throw new Exception("Houve algum erro na homologação do relatório,\n por favor tente novamente ou contate o nosso suporte!");
        }

        public static blTitulo BuscarTitulo(string Cd_empresa,
                                            string Nr_lancto,
                                            string Cd_parcela,
                                            string Id_cobranca)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/AtualizarBoleto?" +
                                            "cd_empresa=" + Cd_empresa.Trim() +
                                            "&nr_lancto=" + Nr_lancto +
                                            "&cd_parcela=" + Cd_parcela +
                                            "&id_cobranca=" + Id_cobranca).Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<blTitulo>(ts.Result);
            }
            else return null;
        }

        public static List<blTitulo> BuscarBoletos(string emp)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/BuscarBoletos?cnpj_cliente=" + emp).Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<blTitulo>>(ts.Result);
            }
            else return null;
        }

        public static string BuscarLicenca(string Login, string Senha)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.alkord.com");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(Login.Trim() + ":" + Senha.Trim())));
            var result = client.GetAsync("/licencas").Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> ret = result.Content.ReadAsStringAsync();
                List<Licenca> lista = JsonConvert.DeserializeObject<List<Licenca>>(ret.Result);
                if (lista.Count > 0)
                    return lista.FirstOrDefault(p => p.ATIVA.Trim().ToUpper().Equals("S")).CODIGO;
                else return string.Empty;
            }
            else return string.Empty;
        }

        public static string BuscarIntegracao(string Login, string Senha, string Licenca)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.alkord.com");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(Login.Trim() + ":" + Senha.Trim())));
            var result = client.GetAsync("/integracoes?licenca=" + Licenca).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> ret = result.Content.ReadAsStringAsync();
                Integracao it = JsonConvert.DeserializeObject<Integracao>(ret.Result);
                if (it != null)
                    if (it.Registros == null ? true : it.Registros.Count.Equals(0))
                    {
                        result = client.PostAsync("/integracoes?licenca=" + Licenca, new StringContent(JsonConvert.SerializeObject(new Sistema { DESCRICAO = "Aliance.NET" }), Encoding.UTF8)).Result;
                        ret = result.Content.ReadAsStringAsync();
                        Integracao rf = JsonConvert.DeserializeObject<Integracao>(ret.Result);
                        if (rf != null)
                            return rf.Referencia.CODIGO;
                        else return string.Empty;
                    }
                    else return it.Registros[0].CODIGO;
                else return string.Empty;
            }
            else return string.Empty;
        }

        public static Token GerarToken(string Login, string Senha, string Licenca, string Integracao)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.alkord.com");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(Login.Trim() + ":" + Senha.Trim())));
            var result = client.GetAsync("/token?licenca=" + Licenca + "&integracao=" + Integracao + "&finalidade=1").Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> ret = result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Token>(ret.Result);
            }
            else return null;
        }

        public static Retorno CadastrarCliente(Clientes cliente, Token token)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.alkord.com");
            var result = client.PostAsync("/clientes?token=" + token.token_acesso, new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8)).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> ret = result.Content.ReadAsStringAsync();
                Retorno rt = JsonConvert.DeserializeObject<Retorno>(ret.Result);
                return rt;
            }
            else return null;
        }

        public static Retorno AlterarCliente(string codigo, Clientes cliente, Token token)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.alkord.com");
            var result = client.PutAsync("/clientes/" + codigo.Trim() + "?token=" + token.token_acesso, new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8)).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> ret = result.Content.ReadAsStringAsync();
                Retorno rt = JsonConvert.DeserializeObject<Retorno>(ret.Result);
                return rt;
            }
            else return null;
        }

        public static bool InativarCliente(string codigo, Token token)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.alkord.com");
            var result = client.DeleteAsync("/clientes/" + codigo.Trim() + "?token=" + token.token_acesso).Result;
            if (result.IsSuccessStatusCode)
                return true;
            else return false;
        }

        public static List<Clientes> BuscarClientes(Token token, int registros = 0)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.alkord.com");
            var result = client.GetAsync("/clientes?token=" + token.token_acesso).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> ret = result.Content.ReadAsStringAsync();
                List<Clientes> c = JsonConvert.DeserializeObject<List<Clientes>>(ret.Result);
                return c;
            }
            else return null;
        }

        public static Retorno NovoProduto(Produtos produto, Token token)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.alkord.com");
            var result = client.PostAsync("/produtos?token=" + token.token_acesso, new StringContent(JsonConvert.SerializeObject(produto), Encoding.UTF8)).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> ret = result.Content.ReadAsStringAsync();
                Retorno rt = JsonConvert.DeserializeObject<Retorno>(ret.Result);
                return rt;
            }
            else return null;
        }

        public static Retorno AlterarProduto(string codigo, Produtos produto, Token token)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.alkord.com");
            var result = client.PutAsync("/produtos/" + codigo.Trim() + "?token=" + token.token_acesso, new StringContent(JsonConvert.SerializeObject(produto), Encoding.UTF8)).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> ret = result.Content.ReadAsStringAsync();
                Retorno rt = JsonConvert.DeserializeObject<Retorno>(ret.Result);
                return rt;
            }
            else return null;
        }

        public static bool InativarProduto(string codigo, Token token)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.alkord.com");
            var result = client.DeleteAsync("/produtos/" + codigo.Trim() + "?token=" + token.token_acesso).Result;
            if (result.IsSuccessStatusCode)
                return true;
            else return false;
        }

        public static List<Boleto> BuscarBoletos(DateTime Dt_ini, DateTime Dt_fin, Token token)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.alkord.com");
            var result = client.GetAsync("/boletos?token=" + token.token_acesso + "&filtros=EXCLUIDO:ig:N,PROCESSAMENTO:si:" + Dt_ini.ToString("yyyy-MM-dd") + ",PROCESSAMENTO:ii:" + Dt_fin.ToString("yyyy-MM-dd") + "&colunas=CODIGO,PROCESSAMENTO,VENCIMENTO,VALOR,NOSSO_NUMERO,NUMERO_DOCUMENTO,CODIGO_BANCO,LINHA_DIGITAVEL,ATENDIMENTOS[ATENDIMENTO[CODIGO,CLIENTE[CODIGO,DOCUMENTO,NOME]]]").Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> ret = result.Content.ReadAsStringAsync();
                Registros reg = JsonConvert.DeserializeObject<Registros>(ret.Result);
                if (reg != null)
                    return reg.REGISTROS;
                else return null;
            }
            else return null;
        }

        public static bool BaixarBoletos(BaixarBoleto val, Token token)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.alkord.com");
            var result = client.PutAsync("/boletos/" + val.CODIGO.Trim() + "?token=" + token.token_acesso, new StringContent(JsonConvert.SerializeObject(val), Encoding.UTF8)).Result;
            return result.IsSuccessStatusCode;
        }

        public static List<RegistroNFe> BuscarNFe(DateTime Dt_ini, DateTime Dt_fin, Token token)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.alkord.com");
            var result = client.GetAsync("/notas-fiscais-emitidas?token=" + token.token_acesso + "&filtros=DATA_EMISSAO:si:" + Dt_ini.ToString("yyyy-MM-dd") + ",DATA_EMISSAO:ii:" + Dt_fin.ToString("yyyy-MM-dd") + " 23:59:59,SITUACAO:ig:E").Result;
            if (result.IsSuccessStatusCode)
            {
                var s = result.Content.ReadAsStringAsync();
                RegistrosNFe reg = JsonConvert.DeserializeObject<RegistrosNFe>(s.Result);
                if (reg != null)
                    return reg.REGISTROS;
                else return null;
            }
            else return null;
        }
    }
}
