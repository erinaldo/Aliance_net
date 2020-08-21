using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using CamadaDados.Mudanca;

namespace WS_OrcamentoMudanca
{
    /// <summary>
    /// Summary description for WS_Orcamento
    /// </summary>
    [WebService(Namespace = "http://tecnoaliance.com.br/ws_orcamento/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_Orcamento : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GravarOrcamento(TRegistro_Orcamento val)
        {
            if (val == null)
                return "Parametro com valor NULL";
            BancoDados.TObjetoBanco banco = new BancoDados.TObjetoBanco();
            try
            {
                //TConexao.BuscarParametros();
                banco.CriarConexao("MASTER", "localhost", "ALIANCE_PRMUDANCA");
                banco.CriarComando();
                banco.Conexao.Open();
                banco.Start_Tran(System.Data.IsolationLevel.ReadUncommitted);
                banco.Comando.Transaction = banco.Transac;
                //Gravar mudanca
                val.Cd_empresa = "0001";
                val.St_registro = "0";//Orcamento
                val.Dt_orcamento = DateTime.Now;
                val.Id_orcamentostr = CamadaDados.TDataQuery.getPubVariavel(new CamadaDados.Mudanca.TCD_Orcamento(banco).Gravar(val), "@P_ID_ORCAMENTO");
                //Gravar itens mudanca
                if (val.lItens != null)
                    val.lItens.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_orcamento = val.Id_orcamento;
                        new CamadaDados.Mudanca.TCD_Orcamento_X_Itens(banco).Gravar(p);
                    });
                ////Gravar itens encaixotamento
                if (val.lEnc != null)
                    val.lEnc.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_orcamento = val.Id_orcamento;
                        new CamadaDados.Mudanca.TCD_Encaixotamento(banco).Gravar(p);
                    });
                banco.Transac.Commit();
                return "Orçamento Gravado com Sucesso";
            }
            catch (Exception ex)
            {
                banco.Transac.Rollback();
                throw new Exception("Erro: " + ex.Message.Trim());
            }
            finally
            {
                if (banco.Conexao.State == System.Data.ConnectionState.Open)
                    banco.Conexao.Close();
                banco = null;
            }   
        }
    }
}
