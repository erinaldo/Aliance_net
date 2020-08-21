using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados.Frota.Cadastros;
using CamadaDados.Frota;
using Utils;

namespace CamadaNegocio.Frota.Cadastros
{
    public class TCN_CadDesenhoPneu
    {
        public static TList_CadDesenhoPneu Buscar(string Id_desenho,
                                                  string Ds_desenho,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_desenho))
                Estruturas.CriarParametro(ref filtro, "a.id_desenho", Id_desenho);
            if (!string.IsNullOrEmpty(Ds_desenho))
                Estruturas.CriarParametro(ref filtro, "a.ds_desenho", "'" + Ds_desenho + "'");
            return new TCD_CadDesenhoPneu(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadDesenhoPneu val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadDesenhoPneu qtb_desenho = new TCD_CadDesenhoPneu();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desenho.CriarBanco_Dados(true);
                else qtb_desenho.Banco_Dados = banco;

                val.Id_desenhostr = CamadaDados.TDataQuery.getPubVariavel(qtb_desenho.Gravar(val), "@P_ID_DESENHO");
                if (st_transacao)
                    qtb_desenho.Banco_Dados.Commit_Tran();
                return val.Id_desenhostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desenho.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar desenho: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desenho.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadDesenhoPneu val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadDesenhoPneu qtb_desenho = new TCD_CadDesenhoPneu();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desenho.CriarBanco_Dados(true);
                else
                    qtb_desenho.Banco_Dados = banco;

                qtb_desenho.Excluir(val);

                if (st_transacao)
                    qtb_desenho.Banco_Dados.Commit_Tran();
                return val.Id_desenhostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desenho.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir desenho: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desenho.deletarBanco_Dados();
            }
        }
    }
}
