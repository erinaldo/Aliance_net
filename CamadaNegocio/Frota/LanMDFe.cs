using System;
using Utils;
using CamadaDados.Frota;

namespace CamadaNegocio.Frota
{
    public class TCN_MDFe
    {
        public static TList_MDFe Buscar(string Cd_empresa,
                                        string Id_mdfe,
                                        string Nr_mdfe,
                                        string Cd_ufcarrega,
                                        string Cd_ufdescarrega,
                                        string Dt_ini,
                                        string Dt_fin,
                                        string St_registro,
                                        string St_transmitido,
                                        string Chaveacesso,
                                        string Id_veiculo,
                                        string Cd_motorista,
                                        BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_mdfe))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_mdfe";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mdfe;
            }
            if (!string.IsNullOrEmpty(Nr_mdfe))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_mdfe";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_mdfe;
            }
            if (!string.IsNullOrEmpty(Cd_ufcarrega))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_ufcarrega";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_ufcarrega.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_ufdescarrega))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_ufdescarrega";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_ufdescarrega.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(St_transmitido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_transmitido, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = St_transmitido.Trim().ToUpper().Equals("T") ? "'S'" : St_transmitido.Trim().ToUpper().Equals("N") ? "'N'" : "isnull(a.st_transmitido, 'N')";
            }
            if (!string.IsNullOrEmpty(Chaveacesso))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.chaveacesso";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Chaveacesso.Trim() + "'";
            }
            if (!string.IsNullOrWhiteSpace(Id_veiculo))
                Estruturas.CriarParametro(ref filtro, string.Empty, "(select 1 from tb_ctr_mdfe_x_veiculo x where x.cd_empresa = a.cd_empresa and x.id_mdfe = a.id_mdfe and x.id_veiculo = " + Id_veiculo + ")", "exists");
            if(!string.IsNullOrWhiteSpace(Cd_motorista))
                Estruturas.CriarParametro(ref filtro, string.Empty, "(select 1 from tb_ctr_mdfe_x_motorista x where x.cd_empresa = a.cd_empresa and x.id_mdfe = a.id_mdfe and x.cd_motorista = '" + Cd_motorista + "')", "exists");
            return new TCD_MDFe(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MDFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe qtb_mdfe = new TCD_MDFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                val.Id_mdfestr = CamadaDados.TDataQuery.getPubVariavel(qtb_mdfe.Gravar(val), "@P_ID_MDFE");
                //Buscar numero MDFe
                val.Nr_mdfestr = qtb_mdfe.BuscarEscalar(new TpBusca[]{new TpBusca(){vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"},
                                                                      new TpBusca(){vNM_Campo = "a.id_mdfe", vOperador = "=", vVL_Busca = val.Id_mdfestr}}, "a.nr_mdfe").ToString();
                //Veiculos
                val.lVeicDel.ForEach(p => TCN_MDFe_Veiculo.Excluir(p, qtb_mdfe.Banco_Dados));
                val.lVeic.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_mdfe = val.Id_mdfe;
                        TCN_MDFe_Veiculo.Gravar(p, qtb_mdfe.Banco_Dados);
                    });
                //Motoristas
                val.lMotDel.ForEach(p => TCN_MDFe_Motorista.Excluir(p, qtb_mdfe.Banco_Dados));
                val.lMot.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_mdfe = val.Id_mdfe;
                        TCN_MDFe_Motorista.Gravar(p, qtb_mdfe.Banco_Dados);
                    });
                //Municipios Carregamento
                val.lMunCarDel.ForEach(p => TCN_MDFe_MunCarrega.Excluir(p, qtb_mdfe.Banco_Dados));
                val.lMunCar.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_mdfe = val.Id_mdfe;
                        TCN_MDFe_MunCarrega.Gravar(p, qtb_mdfe.Banco_Dados);
                    });
                //UF Percurso
                val.lUfPercDel.ForEach(p => TCN_MDFe_UfPercurso.Excluir(p, qtb_mdfe.Banco_Dados));
                val.lUfPerc.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_mdfe = val.Id_mdfe;
                        TCN_MDFe_UfPercurso.Gravar(p, qtb_mdfe.Banco_Dados);
                    });
                //Documentos
                val.lDocDel.ForEach(p => TCN_MDFe_Documentos.Excluir(p, qtb_mdfe.Banco_Dados));
                val.lDoc.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_mdfe = val.Id_mdfe;
                        TCN_MDFe_Documentos.Gravar(p, qtb_mdfe.Banco_Dados);
                    });
                //Seguro
                val.lSeguroDel.ForEach(p => TCN_MDFe_Seguro.Excluir(p, qtb_mdfe.Banco_Dados));
                val.lSeguro.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_mdfe = val.Id_mdfe;
                    TCN_MDFe_Seguro.Gravar(p, qtb_mdfe.Banco_Dados);
                });
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
                return val.Id_mdfestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar MDF-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MDFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe qtb_mdfe = new TCD_MDFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                qtb_mdfe.Excluir(val);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
                return val.Id_mdfestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir MDF-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }

        public static void Cancelar(TRegistro_MDFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe qtb_mdfe = new TCD_MDFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                val.St_registro = "C";
                qtb_mdfe.Gravar(val);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar MDFe: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }

        public static void Encerrar(TRegistro_MDFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe qtb_mdfe = new TCD_MDFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                val.St_registro = "E";
                qtb_mdfe.Gravar(val);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro encerrar MDFe: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }
    }

    public class TCN_MDFe_Veiculo
    {
        public static TList_MDFe_Veiculo Buscar(string Cd_empresa,
                                                string Id_mdfe,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_mdfe))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_mdfe";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mdfe;
            }
            return new TCD_MDFe_Veiculo(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MDFe_Veiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe_Veiculo qtb_mdfe = new TCD_MDFe_Veiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                string ret = qtb_mdfe.Gravar(val);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Veiculo MDF-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MDFe_Veiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe_Veiculo qtb_mdfe = new TCD_MDFe_Veiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                qtb_mdfe.Excluir(val);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Veiculo MDF-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }
    }

    public class TCN_MDFe_Motorista
    {
        public static TList_MDFe_Motorista Buscar(string Cd_empresa,
                                                  string Id_mdfe,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_mdfe))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_mdfe";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mdfe;
            }
            return new TCD_MDFe_Motorista(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MDFe_Motorista val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe_Motorista qtb_mdfe = new TCD_MDFe_Motorista();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                string ret = qtb_mdfe.Gravar(val);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Motorista MDF-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MDFe_Motorista val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe_Motorista qtb_mdfe = new TCD_MDFe_Motorista();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                qtb_mdfe.Excluir(val);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Motorista MDF-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }
    }

    public class TCN_MDFe_MunCarrega
    {
        public static TList_MDFe_MunCarrega Buscar(string Cd_empresa,
                                                   string Id_mdfe,
                                                   BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_mdfe))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_mdfe";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mdfe;
            }
            return new TCD_MDFe_MunCarrega(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MDFe_MunCarrega val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe_MunCarrega qtb_mdfe = new TCD_MDFe_MunCarrega();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                string ret = qtb_mdfe.Gravar(val);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Municipio Carregamento MDF-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MDFe_MunCarrega val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe_MunCarrega qtb_mdfe = new TCD_MDFe_MunCarrega();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                qtb_mdfe.Excluir(val);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Municipio Carregamento MDF-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }
    }

    public class TCN_MDFe_UfPercurso
    {
        public static TList_MDFe_UfPercurso Buscar(string Cd_empresa,
                                                   string Id_mdfe,
                                                   BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_mdfe))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_mdfe";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mdfe;
            }
            return new TCD_MDFe_UfPercurso(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MDFe_UfPercurso val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe_UfPercurso qtb_mdfe = new TCD_MDFe_UfPercurso();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                string ret = qtb_mdfe.Gravar(val);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar UF Percurso MDF-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MDFe_UfPercurso val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe_UfPercurso qtb_mdfe = new TCD_MDFe_UfPercurso();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                qtb_mdfe.Excluir(val);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir UF Percurso MDF-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }
    }

    public class TCN_MDFe_Documentos
    {
        public static TList_MDFe_Documentos Buscar(string Cd_empresa,
                                                   string Id_mdfe,
                                                   BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_mdfe))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_mdfe";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mdfe;
            }
            return new TCD_MDFe_Documentos(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MDFe_Documentos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe_Documentos qtb_mdfe = new TCD_MDFe_Documentos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                string ret = qtb_mdfe.Gravar(val);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Documentos MDF-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MDFe_Documentos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe_Documentos qtb_mdfe = new TCD_MDFe_Documentos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                qtb_mdfe.Excluir(val);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Documentos MDF-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }
    }

    public class TCN_MDFe_Evento
    {
        public static TList_MDFe_Evento Buscar(string Cd_empresa,
                                               string Id_mdfe,
                                               string Tp_evento,
                                               string St_registro,
                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_mdfe))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_mdfe";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mdfe;
            }
            if (!string.IsNullOrEmpty(Tp_evento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.tp_evento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_evento.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_registro.Trim() + "'";
            }
            return new TCD_MDFe_Evento(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MDFe_Evento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe_Evento qtb_evento = new TCD_MDFe_Evento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_evento.CriarBanco_Dados(true);
                else qtb_evento.Banco_Dados = banco;
                val.Id_evento = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(qtb_evento.Gravar(val), "@P_ID_EVENTO"));
                if (st_transacao)
                    qtb_evento.Banco_Dados.Commit_Tran();
                return val.Id_evento.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_evento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar evento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_evento.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MDFe_Evento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe_Evento qtb_evento = new TCD_MDFe_Evento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_evento.CriarBanco_Dados(true);
                else qtb_evento.Banco_Dados = banco;
                qtb_evento.Excluir(val);
                if (st_transacao)
                    qtb_evento.Banco_Dados.Commit_Tran();
                return val.Id_evento.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_evento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir evento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_evento.deletarBanco_Dados();
            }
        }
    }

    public class TCN_MDFe_Seguro
    {
        public static TList_MDFe_Seguro Buscar(string Cd_empresa,
                                               string Id_mdfe,
                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrWhiteSpace(Cd_empresa))
                Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrWhiteSpace(Id_mdfe))
                Estruturas.CriarParametro(ref filtro, "a.id_mdfe", Id_mdfe);
            return new TCD_MDFe_Seguro(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_MDFe_Seguro val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe_Seguro qtb_mdfe = new TCD_MDFe_Seguro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                val.Id_segurostr = CamadaDados.TDataQuery.getPubVariavel(qtb_mdfe.Gravar(val), "@P_ID_SEGURO");
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
                return val.Id_segurostr;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar seguro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_MDFe_Seguro val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MDFe_Seguro qtb_mdfe = new TCD_MDFe_Seguro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                qtb_mdfe.Excluir(val);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
                return val.Id_segurostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir seguro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }
    }
}
