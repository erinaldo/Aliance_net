using CamadaDados.Faturamento.VendasExterna;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FormRelPadrao
{
    public class VendasExterna
    {
        public class Licenca
        {
            public string CODIGO { get; set; }
            public string ATIVA { get; set; }
            public string GRATUITA { get; set; }
            public string PAIS { get; set; }
            public string NOME { get; set; }
            public string APELIDO { get; set; }
            public string DOCUMENTO { get; set; }
        }
        public class Integracao
        {
            public REFERENCIA Referencia { get; set; }
            public List<REGISTROS> Registros { get; set; }
        }
        public class Sistema
        {
            public string DESCRICAO { get; set; }
        }
        public class REFERENCIA
        { public string CODIGO { get; set; } }
        public class REGISTROS
        {
            public string CODIGO { get; set; }
            public string DESCRICAO { get; set; }
        }
        public class Token
        {
            public string token_acesso { get; set; }
            public string token_renovacao { get; set; }
            public string usuario { get; set; }
            public string licenca { get; set; }
            public int validade { get; set; }
            public DateTime Dt_cad { get; set; } = DateTime.Now;
            public bool St_valido => Dt_cad.AddSeconds(Convert.ToDouble(validade)) >= DateTime.Now;
        }
        public class Pessoas_enderecos
        {
            public REFERENCIA REFERENCIAS { get; set; }
        }
        public class Referencias
        {
            public string CODIGO { get; set; }
            public List<Pessoas_enderecos> PESSOAS_ENDERECOS { get; set; }
        }
        public class Retorno
        {
            public Referencias REFERENCIAS { get; set; }

        }
        public class BaixarBoleto
        {
            public string CODIGO { get; set; }
            public string VALOR_PAGO { get; set; }
            public string DATA_PAGAMENTO { get; set; }
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
                    if(it.Registros == null ? true : it.Registros.Count.Equals(0))
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
