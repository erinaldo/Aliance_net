using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Cadastros;


namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadClifor
    {
        public static TList_CadClifor Busca_Clifor( string CD_Clifor, 
                                                    string NM_Clifor,
                                                    string NM_Fantasia, 
                                                    string CNPJ, 
                                                    string CPF, 
                                                    string TP_Pessoa,
                                                    string Id_categoria,
                                                    string Cd_condfiscal,
                                                    string Id_regiao,
                                                    string vNm_campo, 
                                                    bool St_cadastrosrenovar,
                                                    string CEP,
                                                    string Cd_cidade,
                                                    string Cd_uf,
                                                    string Dt_iniCad,
                                                    string Dt_finCad,
                                                    string St_registro,
                                                    int vTop,
                                                    TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(CD_Clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Clifor.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            
            if (!string.IsNullOrEmpty(NM_Clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NM_Clifor";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + NM_Clifor.Trim() + "%'  COLLATE Latin1_General_CI_AI)";
                filtro[filtro.Length - 1].vOperador = "like";
            }
                        
            if ((CPF.Trim() != "") && (CPF.Replace(',', '.').Trim() != ".   .   -"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_cpf";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + CPF.Replace(',', '.').Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }

            if ((CNPJ.Trim() != "") && (CNPJ.Replace(',', '.').Trim() != ".   .   /    -"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_CGC";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + CNPJ.Replace(',', '.').Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }

            if (NM_Fantasia.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NM_Fantasia";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + NM_Fantasia.Trim() + "%' COLLATE Latin1_General_CI_AI)";
                filtro[filtro.Length - 1].vOperador = "like";
            }

            if (TP_Pessoa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_Pessoa";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + TP_Pessoa.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Id_categoria))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_categoriaclifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_categoria;
            }
            if (!string.IsNullOrEmpty(Cd_condfiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_condfiscal_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_condfiscal.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_regiao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_regiao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_regiao;
            }
            if (St_cadastrosrenovar)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "DATEADD(dd, a.diasrenovacaocadastro, a.dt_renovacaocadastro)";
                filtro[filtro.Length - 1].vOperador = "<";
                filtro[filtro.Length - 1].vVL_Busca = "case when a.diascarenciadebvencto = 0 then  DATEADD(dd, -1, a.dt_renovacaocadastro) else GETDATE() end";
            }
            if(!string.IsNullOrEmpty(CEP.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_endereco x " +
                                                      "where x.cd_clifor = a.cd_clifor " +
                                                      "and x.cep = '" + CEP + "')";
            }
            if (!string.IsNullOrEmpty(Cd_cidade))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_endereco x " +
                                                      "where x.cd_clifor = a.cd_clifor " +
                                                      "and x.cd_cidade = '" + Cd_cidade.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Cd_uf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_endereco x " +
                                                      "inner join TB_FIN_Cidade y " +
                                                      "on x.cd_cidade = y.cd_cidade " +
                                                      "where x.cd_clifor = a.cd_clifor " +
                                                      "and y.cd_uf = '" + Cd_uf.Trim() + "')";
            }
            if ((!string.IsNullOrEmpty(Dt_iniCad)) && (Dt_iniCad.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_cad)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_iniCad).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_finCad)) && (Dt_finCad.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_cad)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_finCad).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_CadClifor(banco).Select(filtro, vTop, vNm_campo);
        }

        public static TList_CadClifor BuscaVendedor(string Cd_vendedor,
                                                    string Loginvendedor,
                                                    TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[2];
            filtro[0].vNM_Campo = "isnull(a.st_vendedor, 'N')";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'S'";
            filtro[1].vNM_Campo = "isnull(a.st_funcativo, 'N')";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'S'";
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Loginvendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.loginvendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Loginvendedor.Trim() + "'";
            }
            return new TCD_CadClifor(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_CadClifor BuscaMotorista(string Cd_motorista,
                                                   string id_veiculo,
                                                   BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[2];
            filtro[0].vNM_Campo = "isnull(a.st_motorista, 'N')";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'S'";
            filtro[1].vNM_Campo = "isnull(a.st_ativo, 'S')";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'S'";
        
            if (!string.IsNullOrEmpty(Cd_motorista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_motorista.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_veiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_veiculo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_veiculo;
            }
            return new TCD_CadClifor(banco).Select(filtro, 0, string.Empty);
        }

        public static TRegistro_CadClifor Busca_Clifor_Codigo(string CD_Clifor,
                                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(CD_Clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Clifor.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            return new TCD_CadClifor(banco).Select(filtro, 0, string.Empty)[0];
        }

        public static string Gravar(TRegistro_CadClifor val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadClifor qtb_clifor = new TCD_CadClifor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_clifor.CriarBanco_Dados(true);
                else
                    qtb_clifor.Banco_Dados = banco;
                //testa se cliente e novo para bloquear credito a prazo
                if (string.IsNullOrEmpty(val.Cd_clifor) && CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_BLOQ_CLIENTE", "", qtb_clifor.Banco_Dados).Trim().Equals("S"))
                { val.St_bloqcreditoavulso = "S"; }
                else if (qtb_clifor.BuscarEscalar(new TpBusca[] 
                {
                    new TpBusca (){vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + val.Cd_clifor.Trim() + "'"}
                }, "1") == null && CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_BLOQ_CLIENTE", "", qtb_clifor.Banco_Dados).Trim().Equals("S"))
                    val.St_bloqcreditoavulso = "S";
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
                //Excluir Dados bancarios
                val.lDadosBancDel.ForEach(p => TCN_CadDados_Bancarios_Clifor.Excluir(p, qtb_clifor.Banco_Dados));
                //Gravar Dados Bancarios
                val.lDadosBanc.ForEach(p =>
                    {
                        p.CD_Clifor = val.Cd_clifor;
                        TCN_CadDados_Bancarios_Clifor.Gravar(p, qtb_clifor.Banco_Dados);
                    });
                //Excluir Contatos
                val.lContatoDel.ForEach(p => TCN_CadContatoCliFor.Excluir(p, qtb_clifor.Banco_Dados));
                //Gravar Contatos
                val.lContato.ForEach(p =>
                    {
                        p.Cd_CliFor = val.Cd_clifor;
                        TCN_CadContatoCliFor.Gravar(p, qtb_clifor.Banco_Dados);
                    });
                //Excluir Referencias
                val.lReferenciaDel.ForEach(p => TCN_CadReferenciaClifor.Excluir(p, qtb_clifor.Banco_Dados));
                //Gravar Referencias
                val.lReferencia.ForEach(p=>
                {
                    p.Cd_CliFor = val.Cd_clifor;
                    TCN_CadReferenciaClifor.Gravar(p, qtb_clifor.Banco_Dados);
                });
                //Exluir Data Clifor
                val.lDataCliforDel.ForEach(p=> TCN_DataClifor.Excluir(p, qtb_clifor.Banco_Dados));
                //Gravar Data Clifor
                val.lDataClifor.ForEach(p =>
                    {
                        p.Cd_clifor = val.Cd_clifor;
                        TCN_DataClifor.Gravar(p, qtb_clifor.Banco_Dados);
                    });
                //Gravar Pessoas Autorizadas
                val.lPessoas.ForEach(p =>
                    {
                        p.Cd_clifor = val.Cd_clifor;
                        TCN_PessoasAutorizadas.Gravar(p, qtb_clifor.Banco_Dados);
                    });
                //Excluir Anexos
                val.lAnexoDel.ForEach(p=> TCN_AnexoClifor.Excluir(p, qtb_clifor.Banco_Dados));
                //Gravar Anexos
                val.lAnexo.ForEach(p=>
                    {
                        p.Cd_clifor = val.Cd_clifor;
                        TCN_AnexoClifor.Gravar(p, qtb_clifor.Banco_Dados);
                    });
                //Excluir Tab Preco
                val.lTabPrecoDel.ForEach(p => TCN_Clifor_X_TabPreco.Excluir(p, qtb_clifor.Banco_Dados));
                //Gravar Tab Preco
                val.lTabPreco.ForEach(p =>
                    {
                        p.Cd_clifor = val.Cd_clifor;
                        TCN_Clifor_X_TabPreco.Gravar(p, qtb_clifor.Banco_Dados);
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

        public static string Excluir(TRegistro_CadClifor val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadClifor qtb_clifor = new TCD_CadClifor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_clifor.CriarBanco_Dados(true);
                else
                    qtb_clifor.Banco_Dados = banco;
                try
                {
                    qtb_clifor.Excluir(val);
                }
                catch
                {
                    val.St_registro = "C";
                    Gravar(val, qtb_clifor.Banco_Dados);
                }
                if (st_transacao)
                    qtb_clifor.Banco_Dados.Commit_Tran();
                return val.Cd_clifor;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_clifor.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir clifor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_clifor.deletarBanco_Dados();
            }
        }
    }

    public class TCN_PessoasAutorizadas
    {
        public static TList_PessoasAutorizadas Buscar(string Cd_clifor,
                                                      string Id_pessoa,
                                                      string Nm_pessoa,
                                                      string Nr_cpf,
                                                      string St_registro,
                                                      BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_pessoa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pessoa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pessoa;
            }
            if (!string.IsNullOrEmpty(Nm_pessoa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_pessoa";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Nm_pessoa.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Nr_cpf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_cpf";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_cpf.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_PessoasAutorizadas(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_PessoasAutorizadas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PessoasAutorizadas qtb_pessoas = new TCD_PessoasAutorizadas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pessoas.CriarBanco_Dados(true);
                else qtb_pessoas.Banco_Dados = banco;
                val.Id_pessoastr = CamadaDados.TDataQuery.getPubVariavel(qtb_pessoas.Gravar(val), "@P_ID_PESSOA");
                if (st_transacao)
                    qtb_pessoas.Banco_Dados.Commit_Tran();
                return val.Id_pessoastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pessoas.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pessoas.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PessoasAutorizadas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PessoasAutorizadas qtb_pessoas = new TCD_PessoasAutorizadas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pessoas.CriarBanco_Dados(true);
                else qtb_pessoas.Banco_Dados = banco;
                val.St_registro = "C";
                qtb_pessoas.Gravar(val);
                if (st_transacao)
                    qtb_pessoas.Banco_Dados.Commit_Tran();
                return val.Id_pessoastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pessoas.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pessoas.deletarBanco_Dados();
            }
        }
    }

    public class TCN_AnexoClifor
    {
        public static TList_AnexoClifor Buscar(string Cd_clifor,
                                                      string Id_anexo,
                                                      BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_anexo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_anexo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_anexo;
            }
            return new TCD_AnexoClifor(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AnexoClifor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AnexoClifor qtb_anexo = new TCD_AnexoClifor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_anexo.CriarBanco_Dados(true);
                else qtb_anexo.Banco_Dados = banco;
                val.Id_anexostr = CamadaDados.TDataQuery.getPubVariavel(qtb_anexo.Grava(val), "@P_ID_ANEXO");
                if (st_transacao)
                    qtb_anexo.Banco_Dados.Commit_Tran();
                return val.Id_anexostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_anexo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_anexo.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AnexoClifor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AnexoClifor qtb_anexo = new TCD_AnexoClifor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_anexo.CriarBanco_Dados(true);
                else qtb_anexo.Banco_Dados = banco;
                qtb_anexo.Deleta(val);
                if (st_transacao)
                    qtb_anexo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_anexo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_anexo.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Clifor_X_TabPreco
    {
        public static TList_Clifor_X_TabPreco Buscar(string Cd_clifor,
                                                     string Cd_tabelapreco,
                                                     BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_tabelapreco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tabelapreco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tabelapreco.Trim() + "'";
            }
            return new TCD_Clifor_X_TabPreco(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Clifor_X_TabPreco val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Clifor_X_TabPreco qtb_tab = new TCD_Clifor_X_TabPreco();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tab.CriarBanco_Dados(true);
                else qtb_tab.Banco_Dados = banco;
                string ret = qtb_tab.Gravar(val);
                if (st_transacao)
                    qtb_tab.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tab.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tab.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Clifor_X_TabPreco val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Clifor_X_TabPreco qtb_tab = new TCD_Clifor_X_TabPreco();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tab.CriarBanco_Dados(true);
                else qtb_tab.Banco_Dados = banco;
                qtb_tab.Excluir(val);
                if (st_transacao)
                    qtb_tab.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tab.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tab.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Clifor_X_CondPgto
    {
        public static TList_Clifor_X_CondPgto Buscar(string Cd_clifor,
                                                     string CD_CondPGTO,
                                                     BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(CD_CondPGTO))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CondPGTO";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_CondPGTO.Trim() + "'";
            }
            return new TCD_Clifor_X_CondPgto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Clifor_X_CondPgto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Clifor_X_CondPgto qtb_tab = new TCD_Clifor_X_CondPgto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tab.CriarBanco_Dados(true);
                else qtb_tab.Banco_Dados = banco;
                string ret = qtb_tab.Gravar(val);
                if (st_transacao)
                    qtb_tab.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tab.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tab.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Clifor_X_CondPgto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Clifor_X_CondPgto qtb_tab = new TCD_Clifor_X_CondPgto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tab.CriarBanco_Dados(true);
                else qtb_tab.Banco_Dados = banco;
                qtb_tab.Excluir(val);
                if (st_transacao)
                    qtb_tab.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tab.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tab.deletarBanco_Dados();
            }
        }
    }
}


