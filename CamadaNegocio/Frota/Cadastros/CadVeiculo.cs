using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Frota.Cadastros;
using CamadaNegocio.Financeiro.Duplicata;

namespace CamadaNegocio.Frota.Cadastros
{
    public class TCN_CadVeiculo
    {
        public static TList_CadVeiculo Buscar(string Id_veiculo,
                                             string Cd_tpveiculo,
                                             string Cd_cidade,
                                             string Id_marca,
                                             string cor,
                                             string placa,
                                             string ano_fabric,
                                             string modelo,
                                             string Tp_combustivel,
                                             string Id_veiculo_principal,
                                             string St_registro,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_veiculo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_veiculo;
            }
            if (!string.IsNullOrEmpty(Cd_tpveiculo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_tpveiculo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_tpveiculo.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_cidade))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_cidade";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_cidade.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_marca))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_marca";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_marca;
            }
            if (!string.IsNullOrEmpty(cor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + cor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(placa.Replace("-", "").Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "REPLACE(a.placa, '-', '')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + placa.Replace("-", string.Empty).Trim() + "'";
            }
            if (!string.IsNullOrEmpty(ano_fabric))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ano_fabric";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + ano_fabric.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(modelo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.modelo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + modelo.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_combustivel))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_combustivel";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + Tp_combustivel.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Id_veiculo_principal))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_veiculo_principal";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_veiculo_principal;
            }

            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_CadVeiculo(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadVeiculo qtb_veiculo = new TCD_CadVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_veiculo.CriarBanco_Dados(true);
                else
                    qtb_veiculo.Banco_Dados = banco;
                //Gravar Veiculos
                val.Id_veiculostr = CamadaDados.TDataQuery.getPubVariavel(qtb_veiculo.Gravar(val), "@P_ID_VEICULO");
                if (st_transacao)
                    qtb_veiculo.Banco_Dados.Commit_Tran();
                return val.Id_veiculostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_veiculo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar veiculo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_veiculo.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadVeiculo qtb_veiculo = new TCD_CadVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_veiculo.CriarBanco_Dados(true);
                else
                    qtb_veiculo.Banco_Dados = banco;
                
                qtb_veiculo.Excluir(val);
                if (st_transacao)
                    qtb_veiculo.Banco_Dados.Commit_Tran();
                return val.Id_veiculostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_veiculo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir veiculo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_veiculo.deletarBanco_Dados();
            }
        }

        public static bool ExistsRodado(string Id_veiculo, BancoDados.TObjetoBanco banco)
        {
            TpBusca[] tpBuscas = new TpBusca[0];
            Estruturas.CriarParametro(ref tpBuscas, "a.id_veiculo", Id_veiculo);

            object obj = new TCD_RodadoVeic().BuscarEscalar(tpBuscas, "count(*)");
            if (obj != null && !string.IsNullOrEmpty(obj.ToString()) && decimal.Parse(obj.ToString()) > 0)
                return true;
            return false;
        }

    }

    public class TCN_CadSeguroVeiculo
    {
        public static TList_CadSeguroVeiculo Buscar(string Id_veiculo,
                                                    string Id_apolice,
                                                    string Tp_data,
                                                    string Dt_ini,
                                                    string Dt_fin,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_apolice))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_apolice";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_apolice;
            }
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_veiculo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_veiculo;
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (Tp_data.Trim().ToUpper().Equals("I") ? "a.dt_ini_vigencia" : "a.dt_fin_vigencia") + ")))";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (Tp_data.Trim().ToUpper().Equals("I") ? "a.dt_ini_vigencia" : "a.dt_fin_vigencia") + ")))";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }

            return new TCD_CadSeguroVeiculo(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadSeguroVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadSeguroVeiculo qtb_seguro = new TCD_CadSeguroVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_seguro.CriarBanco_Dados(true);
                else
                    qtb_seguro.Banco_Dados = banco;
                //Gravar  Seguro Veiculo
                val.Id_apolicestr = CamadaDados.TDataQuery.getPubVariavel(qtb_seguro.Gravar(val), "@P_ID_APOLICE");
                //Gravar Premios
                val.lPremiosDel.ForEach(p => TCN_CadSeguroPremios.Excluir(p, qtb_seguro.Banco_Dados));
                val.lPremios.ForEach(p =>
                    {
                        p.Id_apolice = val.Id_apolice;
                        p.Id_veiculo = val.Id_veiculo;
                        TCN_CadSeguroPremios.Gravar(p, qtb_seguro.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_seguro.Banco_Dados.Commit_Tran();
                return val.Id_apolicestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_seguro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar seguro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_seguro.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadSeguroVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadSeguroVeiculo qtb_seguro = new TCD_CadSeguroVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_seguro.CriarBanco_Dados(true);
                else
                    qtb_seguro.Banco_Dados = banco;
                //Excluir premios seguro
                val.lPremios.ForEach(p => TCN_CadSeguroPremios.Excluir(p, qtb_seguro.Banco_Dados));
                val.lPremiosDel.ForEach(p => TCN_CadSeguroPremios.Excluir(p, qtb_seguro.Banco_Dados));
                //Deletar Seguro Veiculo
                qtb_seguro.Excluir(val);
                if (st_transacao)
                    qtb_seguro.Banco_Dados.Commit_Tran();
                return val.Id_apolicestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_seguro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir seguro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_seguro.deletarBanco_Dados();
            }
        }
    }

    public class TCN_CadSeguroPremios
    {
        public static TList_CadSeguroPremios Buscar(string Id_apolice,
                                             string Id_veiculo,
                                             string Id_premio,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_premio))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_premio";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_premio;
            }
            if (!string.IsNullOrEmpty(Id_apolice))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_apolice";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_apolice;
            }
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_veiculo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_veiculo;
            }

            return new TCD_CadSeguroPremios(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadSeguroPremios val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadSeguroPremios qtb_premio = new TCD_CadSeguroPremios();
            try
            {
                if (banco == null)
                    st_transacao = qtb_premio.CriarBanco_Dados(true);
                else
                    qtb_premio.Banco_Dados = banco;
                //Gravar  Seguro Premios
                val.Id_premiostr = CamadaDados.TDataQuery.getPubVariavel(qtb_premio.Gravar(val), "@P_ID_PREMIO");
                if (st_transacao)
                    qtb_premio.Banco_Dados.Commit_Tran();
                return val.Id_premiostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_premio.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar premio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_premio.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadSeguroPremios val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadSeguroPremios qtb_premio = new TCD_CadSeguroPremios();
            try
            {
                if (banco == null)
                    st_transacao = qtb_premio.CriarBanco_Dados(true);
                else
                    qtb_premio.Banco_Dados = banco;
                //Deletar Seguro Premios
                qtb_premio.Excluir(val);
                if (st_transacao)
                    qtb_premio.Banco_Dados.Commit_Tran();
                return val.Id_premiostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_premio.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir seguro premio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_premio.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ManutencaoVeiculo
    {
        public static TList_ManutencaoVeiculo Buscar(string Id_veiculo,
                                                     string Id_manutencao,
                                                     string Id_despesa,
                                                     string Id_viagem,
                                                     string Cd_empresa,
                                                     string Cd_reponsavel,
                                                     string Cd_oficina,
                                                     string Dt_ini,
                                                     string Dt_fin,
                                                     decimal Km_ini,
                                                     decimal Km_fin,
                                                     BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_manutencao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_manutencao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_manutencao;
            }
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_veiculo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_veiculo;
            }
            if (!string.IsNullOrEmpty(Id_despesa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_despesa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_despesa;
            }
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_viagem";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa + "'";
            }
            if (!string.IsNullOrEmpty(Cd_reponsavel))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_cliforResponsavel";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_reponsavel + "'";
            }
            if (!string.IsNullOrEmpty(Cd_oficina))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_cliforOficina";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_oficina + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_realizada)))";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_realizada)))";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (Km_ini > decimal.Zero)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.km_realizada";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                vBusca[vBusca.Length - 1].vVL_Busca = Km_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (Km_fin > decimal.Zero)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.km_realizada";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                vBusca[vBusca.Length - 1].vVL_Busca = Km_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }

            return new TCD_ManutencaoVeiculo(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ManutencaoVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ManutencaoVeiculo qtb_manutencao = new TCD_ManutencaoVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_manutencao.CriarBanco_Dados(true);
                else
                    qtb_manutencao.Banco_Dados = banco;
                //Gravar Duplicata
                if (val.rDup != null)
                {
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.rDup, false, qtb_manutencao.Banco_Dados);
                    val.Nr_lancto = val.rDup.Nr_lancto;
                }
                //Gravar  Manutencao
                val.Id_manutencaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_manutencao.Gravar(val), "@P_ID_MANUTENCAO");
                //Excluir Manutenção
                val.lMovDel.ForEach(p => CamadaNegocio.Almoxarifado.TCN_Movimentacao.Excluir(p, qtb_manutencao.Banco_Dados));
                //Gravar Movimentação
                val.lMov.ForEach(p => CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(p, qtb_manutencao.Banco_Dados));
                //Gravar Manutenção X Almofarifado
                val.lMov.ForEach(p =>
                    {
                        CamadaNegocio.Frota.TCN_Manutencao_X_Almox.Gravar(new CamadaDados.Frota.TRegistro_Manutencao_X_Almox()
                        {
                            Id_veiculostr = val.Id_veiculostr,
                            Id_movimentostr = p.Id_movimentostr,
                            Id_manutencaostr = val.Id_manutencaostr
                        }, qtb_manutencao.Banco_Dados);
                    });
                //Gravar Centro Resultado
                if (val.lCCusto != null)
                    val.lCCusto.ForEach(p =>
                        {
                            p.Cd_empresa = val.Cd_empresa;
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(p, qtb_manutencao.Banco_Dados);
                            TCN_ManutFrota_X_CCusto.Gravar(new TRegistro_ManutFrota_X_CCusto()
                            {
                                Id_manutencao = val.Id_manutencao,
                                Id_veiculo = val.Id_veiculo,
                                Id_ccustolan = p.Id_ccustolan
                            }, qtb_manutencao.Banco_Dados);
                        });
                if (st_transacao)
                    qtb_manutencao.Banco_Dados.Commit_Tran();
                return val.Id_manutencaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_manutencao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar manutenção: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_manutencao.deletarBanco_Dados();
            }
        }

        public static void Gravar(TList_ManutencaoVeiculo lManutencao, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ManutencaoVeiculo qtb_manutencao = new TCD_ManutencaoVeiculo();
            try
            {
                lManutencao.ForEach(p => Gravar(p, qtb_manutencao.Banco_Dados));
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_manutencao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar manutenção: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_manutencao.deletarBanco_Dados();
            }
        }

        public static void Gravar(List<TRegistro_ManutencaoVeiculo> lista,
                                  CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup,
                                  BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ManutencaoVeiculo qtb_abast = new TCD_ManutencaoVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_abast.CriarBanco_Dados(true);
                else
                    qtb_abast.Banco_Dados = banco;
                //Gravar duplicata
                if (rDup != null)
                    Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(rDup, false, qtb_abast.Banco_Dados);
                //Gravar despesas
                lista.ForEach(x =>
                {
                    x.Nr_lancto = rDup.Nr_lancto;
                    Gravar(x, qtb_abast.Banco_Dados);
                });
                if (st_transacao)
                    qtb_abast.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_abast.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar abastecimentos: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_abast.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ManutencaoVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ManutencaoVeiculo qtb_manutencao = new TCD_ManutencaoVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_manutencao.CriarBanco_Dados(true);
                else
                    qtb_manutencao.Banco_Dados = banco;
                //Cancelar Duplicata
                if (val.Nr_lancto.HasValue)
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(
                            CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.Busca(val.Cd_empresa,
                                                                                      val.Nr_lanctostr,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      false,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      false,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      qtb_manutencao.Banco_Dados)[0], qtb_manutencao.Banco_Dados);
                //Buscar Movimentação X Almoxarifado
                CamadaDados.Frota.TList_Manutencao_X_Almox lAlmox =
                    CamadaNegocio.Frota.TCN_Manutencao_X_Almox.Buscar(val.Id_manutencaostr,
                                                                      val.Id_veiculostr,
                                                                      string.Empty,
                                                                      qtb_manutencao.Banco_Dados);
                //Excluir Movimentação X Almoxarifado
                lAlmox.ForEach(p => CamadaNegocio.Frota.TCN_Manutencao_X_Almox.Excluir(p, qtb_manutencao.Banco_Dados));
                //Excluir Movimentação Almoxarifado
                val.lMov.ForEach(p => CamadaNegocio.Almoxarifado.TCN_Movimentacao.Cancelar(p, qtb_manutencao.Banco_Dados));
                //Excluir Centro Resultado
                TCN_ManutFrota_X_CCusto.Buscar(val.Id_manutencaostr,
                                               val.Id_veiculostr,
                                               string.Empty,
                                               qtb_manutencao.Banco_Dados).ForEach(p =>
                                                   {
                                                       TCN_ManutFrota_X_CCusto.Excluir(p, qtb_manutencao.Banco_Dados);
                                                       CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(
                                                           new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                           {
                                                               Id_ccustolan = p.Id_ccustolan
                                                           }, qtb_manutencao.Banco_Dados);
                                                   });
                //Deletar Manutencao
                qtb_manutencao.Excluir(val);
                if (st_transacao)
                    qtb_manutencao.Banco_Dados.Commit_Tran();
                return val.Id_manutencaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_manutencao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir manutencao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_manutencao.deletarBanco_Dados();
            }
        }

        public static void Excluir(TList_ManutencaoVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ManutencaoVeiculo qtb_manutencao = new TCD_ManutencaoVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_manutencao.CriarBanco_Dados(true);
                else
                    qtb_manutencao.Banco_Dados = banco;

                //Cancelar Duplicata
                if (val[0].Nr_lancto.HasValue)
                    TCN_LanDuplicata.CancelarDuplicata(
                            TCN_LanDuplicata.Busca(val[0].Cd_empresa,
                                                   val[0].Nr_lanctostr,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   false,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   false,
                                                   1,
                                                   string.Empty,
                                                   qtb_manutencao.Banco_Dados)[0], qtb_manutencao.Banco_Dados);

                val.ForEach(x =>
                {
                    //Buscar Movimentação X Almoxarifado
                    CamadaDados.Frota.TList_Manutencao_X_Almox lAlmox =
                        CamadaNegocio.Frota.TCN_Manutencao_X_Almox.Buscar(x.Id_manutencaostr,
                                                                          x.Id_veiculostr,
                                                                          string.Empty,
                                                                          qtb_manutencao.Banco_Dados);
                    //Excluir Movimentação X Almoxarifado
                    lAlmox.ForEach(p => CamadaNegocio.Frota.TCN_Manutencao_X_Almox.Excluir(p, qtb_manutencao.Banco_Dados));
                });

                //Excluir Movimentação Almoxarifado
                val.ForEach(x => x.lMov.ForEach(p => CamadaNegocio.Almoxarifado.TCN_Movimentacao.Cancelar(p, qtb_manutencao.Banco_Dados)));
                //Excluir Centro Resultado
                val.ForEach(x => TCN_ManutFrota_X_CCusto.Buscar(x.Id_manutencaostr,
                                               x.Id_veiculostr,
                                               string.Empty,
                                               qtb_manutencao.Banco_Dados).ForEach(p =>
                                               {
                                                   TCN_ManutFrota_X_CCusto.Excluir(p, qtb_manutencao.Banco_Dados);
                                                   CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(
                                                       new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                       {
                                                           Id_ccustolan = p.Id_ccustolan
                                                       }, qtb_manutencao.Banco_Dados);
                                               }));
                //Deletar Manutencao
                val.ForEach(x => qtb_manutencao.Excluir(x));

                if (st_transacao)
                    qtb_manutencao.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_manutencao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir manutencao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_manutencao.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ManutFrota_X_CCusto
    {
        public static TList_ManutFrota_X_CCusto Buscar(string Id_manutencao,
                                                       string Id_veiculo,
                                                       string Id_ccustolan,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_manutencao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_manutencao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_manutencao;
            }
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_veiculo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_veiculo;
            }
            if (!string.IsNullOrEmpty(Id_ccustolan))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ccustolan";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ccustolan;
            }
            return new TCD_ManutFrota_X_CCusto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ManutFrota_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ManutFrota_X_CCusto qtb_custo = new TCD_ManutFrota_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_custo.CriarBanco_Dados(true);
                else qtb_custo.Banco_Dados = banco;
                string retorno = qtb_custo.Gravar(val);
                if (st_transacao)
                    qtb_custo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_custo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_custo.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ManutFrota_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ManutFrota_X_CCusto qtb_custo = new TCD_ManutFrota_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_custo.CriarBanco_Dados(true);
                else qtb_custo.Banco_Dados = banco;
                qtb_custo.Excluir(val);
                if (st_transacao)
                    qtb_custo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_custo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_custo.deletarBanco_Dados();
            }
        }

        public static void ProcessarManuCResultado(List<TRegistro_ManutencaoVeiculo> lManut,
                                                   string CD_CentroResult,
                                                   BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ManutFrota_X_CCusto qtb_desp = new TCD_ManutFrota_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else qtb_desp.Banco_Dados = banco;
                if (string.IsNullOrEmpty(CD_CentroResult))
                    throw new Exception("Obrigatório informar centro de resultado.");
                lManut.ForEach(p =>
                {
                    //Verificar se despesa possui centro de resultado
                    TCN_ManutFrota_X_CCusto.Buscar(p.Id_manutencaostr,
                                                   p.Id_veiculostr,
                                                   string.Empty,
                                                   qtb_desp.Banco_Dados).ForEach(v =>
                                                   {
                                                       TCN_ManutFrota_X_CCusto.Excluir(v, qtb_desp.Banco_Dados);
                                                       CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(
                                                           new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                           {
                                                               Id_ccustolan = v.Id_ccustolan
                                                           }, qtb_desp.Banco_Dados);
                                                   });
                    //Gravar Lancto Resultado
                    string id = CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                        new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Cd_centroresult = CD_CentroResult,
                            Vl_lancto = p.Vl_realizada,
                            Dt_lancto = p.Dt_realizada
                        }, qtb_desp.Banco_Dados);
                    //Amarrar Lancto a Caixa
                    Gravar(new TRegistro_ManutFrota_X_CCusto()
                    {
                        Id_ccustolan = decimal.Parse(id),
                        Id_manutencao = p.Id_manutencao,
                        Id_veiculo = p.Id_veiculo
                    }, qtb_desp.Banco_Dados);
                });
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar manutenções: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Infracoes
    {
        public static TList_Infracoes Buscar(string Id_veiculo,
                                             string Id_infracao,
                                             string Id_viagem,
                                             string Cd_empresa,
                                             string Cd_motorista,
                                             string Id_despesa,
                                             string Tp_data,
                                             string Dt_ini,
                                             string Dt_fin,
                                             int vTop,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_infracao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_infracao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_infracao;
            }
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_veiculo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_veiculo;
            }
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_viagem";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa + "'";
            }
            if (!string.IsNullOrEmpty(Cd_motorista))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_motorista";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_motorista.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_despesa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_despesa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_despesa;
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("I") ? "a.dt_infracao" : "a.dt_vencimento") + ")))";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("I") ? "a.dt_infracao" : "a.dt_vencimento") + ")))";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }

            return new TCD_Infracoes(banco).Select(vBusca, vTop, string.Empty);
        }

        public static string Gravar(TRegistro_Infracoes val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Infracoes qtb_infracao = new TCD_Infracoes();
            try
            {
                if (banco == null)
                    st_transacao = qtb_infracao.CriarBanco_Dados(true);
                else
                    qtb_infracao.Banco_Dados = banco;
                //Gravar Duplicata
                if (val.rDup != null)
                {
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.rDup, false, qtb_infracao.Banco_Dados);
                    val.Nr_lancto = val.rDup.Nr_lancto;
                }
                //Gravar  Infracao
                val.Id_infracaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_infracao.Gravar(val), "@P_ID_INFRACAO");
                if (st_transacao)
                    qtb_infracao.Banco_Dados.Commit_Tran();
                return val.Id_infracaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_infracao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar infrações: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_infracao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Infracoes val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Infracoes qtb_infracao = new TCD_Infracoes();
            try
            {
                if (banco == null)
                    st_transacao = qtb_infracao.CriarBanco_Dados(true);
                else
                    qtb_infracao.Banco_Dados = banco;
                //Cancelar Duplicata
                if (val.Nr_lancto.HasValue)
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(
                            CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.Busca(val.Cd_empresa,
                                                                                      val.Nr_lanctostr,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      false,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      false,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      qtb_infracao.Banco_Dados)[0], qtb_infracao.Banco_Dados);
                //Deletar Infracao
                qtb_infracao.Excluir(val);
                if (st_transacao)
                    qtb_infracao.Banco_Dados.Commit_Tran();
                return val.Id_infracaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_infracao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir infracao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_infracao.deletarBanco_Dados();
            }
        }
    }
}
