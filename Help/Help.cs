using System.Collections.Generic;
using CamadaDados.Help;
using System;
using System.Threading.Tasks;
using System.Linq;
using Utils;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;

namespace Help
{
    public class THelp
    {
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

        public static TChaveLic CalcularLicenca()
        {
            //Buscar CNPJ das empresas ativas
            CamadaDados.Diversos.TList_CadEmpresa lEmp =
                CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(string.Empty, string.Empty, "A", null);
            string emp = string.Empty;
            string virg = string.Empty;
            lEmp.Where(p => !string.IsNullOrEmpty(p.rClifor.Nr_cgc.SoNumero())).ToList().ForEach(p =>
            {
                emp += virg + "'" + p.rClifor.Nr_cgc.SoNumero() + "'";
                virg = ",";
            });
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlString("WS_SERVIDOR_BI", null));
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/CalcularSerial?cnpj_cliente=" + emp + "&dt_servidor=" + CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy") + "&diasvalidade=0").Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TChaveLic>(ts.Result);
            }
            else return null;
        }

        public static List<CamadaDados.Fiscal.TRegistro_CadCFOP> BuscarCFOPRest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/BuscarCFOP").Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CamadaDados.Fiscal.TRegistro_CadCFOP>>(ts.Result);
            }
            else return null;
        }

        public static List<CamadaDados.Fiscal.TRegistro_CadNCM> BuscarNCMRest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Parametros.WS_ServidorHelpDesk);
            HttpResponseMessage response = client.GetAsync("api/HelpDesk/BuscarNCM").Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> ts = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CamadaDados.Fiscal.TRegistro_CadNCM>>(ts.Result);
            }
            else return null;
        }

        public static CamadaDados.Financeiro.Cadastros.TEndereco_CEPRest BuscarEndCEPRest(string cep)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://viacep.com.br");
            Task<HttpResponseMessage> response = client.GetAsync("/ws/" + cep.SoNumero() + "/json");
            if (response.Result.IsSuccessStatusCode)
            {
                HttpContent content = response.Result.Content;
                Task<string> ret = content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CamadaDados.Financeiro.Cadastros.TEndereco_CEPRest>(ret.Result);
            }
            else return null;
        }

        public static string ValidarLogin(string Login_BI, string Senha_BI)
        {
            //Buscar CNPJ das empresas ativas
            TList_CadEmpresa lEmp = TCN_CadEmpresa.Busca(string.Empty, string.Empty, "A", null);
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
    }
}
