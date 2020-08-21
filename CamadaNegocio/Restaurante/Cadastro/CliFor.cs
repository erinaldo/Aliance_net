using System;
using System.Collections.Generic;
using System.Linq;
using CamadaDados.Restaurante.Cadastro;
using Utils;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using System.Text;

namespace CamadaNegocio.Restaurante.Cadastro
{
    public class TCN_CliFor 
    {
        public static string Gravar(TRegistro_Clifor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadClifor qtb_clifor = new TCD_CadClifor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_clifor.CriarBanco_Dados(true);
                else
                    qtb_clifor.Banco_Dados = banco;
                //cria objeto cliente do financeiro
                TRegistro_CadEndereco cendereco = new TRegistro_CadEndereco();
                cendereco.Cd_clifor = val.Cd_clifor;
                cendereco.Cd_endereco = val.Cd_Endereco;
                cendereco.Celular = val.celular.SoNumero();
                cendereco.Ds_endereco = val.endereco;
                cendereco.Bairro = val.bairro;
                cendereco.Cep = val.cep;
                cendereco.Numero = val.numero;
                cendereco.Proximo = val.obs; 
                cendereco.Cd_cidade = val.cd_cidade;
                val.lEndereco.Add(cendereco);

                //Gravar Clifor
                val.Cd_clifor = CamadaDados.TDataQuery.getPubVariavel(qtb_clifor.Gravar(val), "@P_CD_CLIFOR");
                //Excluir Enderecos
                val.lEndDel.ForEach(p => TCN_CadEndereco.Excluir(p, qtb_clifor.Banco_Dados));
                //Gravar Enderecos
                val.lEndereco.ForEach(p =>
                {
                    p.Cd_clifor = val.Cd_clifor;
                    TCN_CadEndereco.Gravar(p, qtb_clifor.Banco_Dados);
                });

                if (st_transacao)
                    qtb_clifor.Banco_Dados.Commit_Tran();
                return val.Cd_clifor;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_clifor.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar clifor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_clifor.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Clifor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadClifor qtb_clifor = new TCD_CadClifor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_clifor.CriarBanco_Dados(true);
                else
                    qtb_clifor.Banco_Dados = banco;
                TRegistro_CadClifor rClifor = new TRegistro_CadClifor();
                rClifor.Cd_clifor = val.Cd_clifor;
                TCN_CadClifor.Excluir(rClifor, qtb_clifor.Banco_Dados);
                if (st_transacao)
                    qtb_clifor.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_clifor.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar clifor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_clifor.deletarBanco_Dados();
            }
        }
    }
}
