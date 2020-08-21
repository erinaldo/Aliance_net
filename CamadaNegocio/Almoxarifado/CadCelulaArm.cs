using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaNegocio.Almoxarifado
{
    public class TCN_CadCelulaArm
    {
        public static CamadaDados.Almoxarifado.TList_CadCelulaArm Buscar(string Id_celula,
                                                                         string Ds_celula,
                                                                         string Id_secao,
                                                                         string Id_rua,
                                                                         BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_celula))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_celula";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_celula;
            }
            if (!string.IsNullOrEmpty(Ds_celula))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_celula";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_celula.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Id_secao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_secao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_secao;
            }
            if (!string.IsNullOrEmpty(Id_rua))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_rua";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_rua;
            }
            return new CamadaDados.Almoxarifado.TCD_CadCelulaArm(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(CamadaDados.Almoxarifado.TRegistro_CadCelulaArm val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Almoxarifado.TCD_CadCelulaArm qtb_cel = new CamadaDados.Almoxarifado.TCD_CadCelulaArm();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_cel.CriarBanco_Dados(true);
                else
                    qtb_cel.Banco_Dados = banco;
                val.Id_celulastr = CamadaDados.TDataQuery.getPubVariavel(qtb_cel.Gravar(val), "@P_ID_CELULA");
                if (st_transacao)
                    qtb_cel.Banco_Dados.Commit_Tran();
                return val.Id_celulastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cel.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar celula: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cel.deletarBanco_Dados();
            }
        }

        public static string Excluir(CamadaDados.Almoxarifado.TRegistro_CadCelulaArm val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Almoxarifado.TCD_CadCelulaArm qtb_cel = new CamadaDados.Almoxarifado.TCD_CadCelulaArm();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cel.CriarBanco_Dados(true);
                else
                    qtb_cel.Banco_Dados = banco;
                qtb_cel.Excluir(val);
                if (st_transacao)
                    qtb_cel.Banco_Dados.Commit_Tran();
                return val.Id_celulastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cel.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir celula: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cel.deletarBanco_Dados();
            }
        }
    }
}
