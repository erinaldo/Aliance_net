using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel.Cadastros;

namespace CamadaNegocio.PostoCombustivel.Cadastros
{
    public class TCN_BombaAbastecimento
    {
        public static TList_BombaAbastecimento Buscar(string Id_bomba,
                                                      string Cd_empresa,
                                                      string Cd_fabricante,
                                                      string Ds_bomba,
                                                      string Cd_produto,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_bomba))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_bomba";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_bomba;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_fabricante))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_fabricante";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_fabricante.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ds_bomba))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_bomba";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_bomba.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdc_bicobomba x " +
                                                      "inner join tb_pdc_tanque y " +
                                                      "on x.id_tanque = y.id_tanque " +
                                                      "and x.cd_empresa = y.cd_empresa " +
                                                      "where x.id_bomba = a.id_bomba " +
                                                      "and x.cd_empresa = a.cd_empresa " +
                                                      "and y.cd_produto = '" + Cd_produto.Trim() + "')";
            }

            return new TCD_BombaAbastecimento(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_BombaAbastecimento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_BombaAbastecimento qtb_bomba = new TCD_BombaAbastecimento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_bomba.CriarBanco_Dados(true);
                else
                    qtb_bomba.Banco_Dados = banco;
                val.Id_bombastr = CamadaDados.TDataQuery.getPubVariavel(qtb_bomba.Gravar(val), "@P_ID_BOMBA");
                //Excluir bico amarrados
                val.lBicoDel.ForEach(p => TCN_BicoBomba.Excluir(p, qtb_bomba.Banco_Dados));
                //Gravar bico
                val.lBico.ForEach(p =>
                    {
                        p.Id_bomba = val.Id_bomba;
                        p.Cd_empresa = val.Cd_empresa;
                        TCN_BicoBomba.Gravar(p, qtb_bomba.Banco_Dados);
                    });
                //Exclui lacre
                val.lLacreDel.ForEach(p => TCN_LacreBomba.Excluir(p, qtb_bomba.Banco_Dados));
                //Gravar lacre
                val.lLacre.ForEach(p =>
                    {
                        p.Id_bomba = val.Id_bomba;
                        p.Cd_empresa = val.Cd_empresa;
                        TCN_LacreBomba.Gravar(p, qtb_bomba.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_bomba.Banco_Dados.Commit_Tran();
                return val.Id_bombastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bomba.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar bomba: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_bomba.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_BombaAbastecimento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_BombaAbastecimento qtb_bomba = new TCD_BombaAbastecimento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_bomba.CriarBanco_Dados(true);
                else
                    qtb_bomba.Banco_Dados = banco;
                //Excluir tanque amarrado
                val.lBicoDel.ForEach(p => TCN_BicoBomba.Excluir(p, qtb_bomba.Banco_Dados));
                val.lBico.ForEach(p => TCN_BicoBomba.Excluir(p, qtb_bomba.Banco_Dados));
                //Excluir lacre
                val.lLacre.ForEach(p => TCN_LacreBomba.Excluir(p, qtb_bomba.Banco_Dados));
                val.lLacreDel.ForEach(p => TCN_LacreBomba.Excluir(p, qtb_bomba.Banco_Dados));
                //Excluir bomba
                qtb_bomba.Excluir(val);
                if (st_transacao)
                    qtb_bomba.Banco_Dados.Commit_Tran();
                return val.Id_bombastr;
            }
            catch
            {
                if (st_transacao)
                    qtb_bomba.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir bomba, existe uma abastecida amarrada a um bico.");
            }
            finally
            {
                if (st_transacao)
                    qtb_bomba.deletarBanco_Dados();
            }
        }
    }
}
