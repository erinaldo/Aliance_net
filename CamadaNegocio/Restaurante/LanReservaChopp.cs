using BancoDados;
using CamadaDados.Restaurante;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace CamadaNegocio.Restaurante
{
    public static class TCN_ReservaChopp
    {
        public static TList_ReservaChopp Buscar(string Cd_empresa,
                                                string Cd_clifor,
                                                string Celular,
                                                string Id_chopeira,
                                                string Nr_chopeira,
                                                string Voltagem,
                                                string Id_barril,
                                                string Nr_barril,
                                                string Volume,
                                                string Cd_produto,
                                                string Tp_data,
                                                string Dt_ini,
                                                string Dt_fin,
                                                string St_registro,
                                                string StatusItem,
                                                TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
                Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrEmpty(Cd_clifor))
                Estruturas.CriarParametro(ref filtro, "a.cd_clifor", "'" + Cd_clifor.Trim() + "'");
            if (!string.IsNullOrEmpty(Celular))
                Estruturas.CriarParametro(ref filtro, "c.celular", "'%" + Celular.Trim() + "%'", "like");
            if (!string.IsNullOrEmpty(Id_chopeira))
                Estruturas.CriarParametro(ref filtro,
                    "(select 1 from tb_res_itensreserva x " +
                    "where x.cd_empresa = a.cd_empresa " +
                    "and x.id_reserva = a.id_reserva " +
                    "and x.id_chopeira = " + Id_chopeira + ")", string.Empty, "exists");
            if (!string.IsNullOrEmpty(Nr_chopeira))
                Estruturas.CriarParametro(ref filtro, 
                    "(select 1 from tb_res_itensreserva x inner join tb_res_chopeira y " +
                    "on x.id_chopeira = y.id_chopeira " +
                    "and x.cd_empresa = a.cd_empresa " +
                    "and x.id_reserva = a.id_reserva " +
                    "and y.nr_chopeira = '" + Nr_chopeira.Trim() + "')", string.Empty, "exists");
            if (!string.IsNullOrEmpty(Voltagem))
                Estruturas.CriarParametro(ref filtro,
                    "(select 1 from tb_res_itensreserva x " +
                    "where x.cd_empresa = a.cd_empresa " +
                    "and x.id_reserva = a.id_reserva " +
                    "and x.voltagem = '" + Voltagem.Trim() + "')", string.Empty, "exists");
            if (!string.IsNullOrEmpty(Id_barril))
                Estruturas.CriarParametro(ref filtro,
                    "(select 1 from tb_res_itensreserva x " +
                    "where x.cd_empresa = a.cd_empresa " +
                    "and x.id_reserva = a.id_reserva " +
                    "and x.id_barril = " + Id_barril + ")", string.Empty, "exists");
            if(!string.IsNullOrEmpty(Nr_barril))
                Estruturas.CriarParametro(ref filtro, 
                    "(select 1 from tb_res_itensreserva x inner join tb_res_barril y " +
                    "on x.id_barril = y.id_barril " +
                    "and x.cd_empresa = a.cd_empresa " +
                    "and x.id_reserva = a.id_reserva " +
                    "and y.nr_barril = '" + Nr_barril.Trim() + "')", string.Empty, "exists");
            if (!string.IsNullOrEmpty(Volume))
                Estruturas.CriarParametro(ref filtro,
                    "(select 1 from tb_res_itensreserva x " +
                    "where x.cd_empresa = a.cd_empresa " +
                    "and x.id_reserva = a.id_reserva " +
                    "and x.volume = " + Volume + ")", string.Empty, "exists");
            if(!string.IsNullOrEmpty(Cd_produto))
                Estruturas.CriarParametro(ref filtro, 
                    "(select 1 from tb_res_itensreserva x " +
                    "where x.cd_empresa = a.cd_empresa " +
                    "and x.id_reserva = a.id_reserva " +
                    "and x.cd_produto = '" + Cd_produto.Trim() + "')", string.Empty, "exists");
            if(Dt_ini.IsDateTime())
                Estruturas.CriarParametro(ref filtro,
                    "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("R") ? "a.dt_reserva" : "a.dt_prevretorno") + ")))",
                    DateTime.Parse(Dt_ini).ToString("yyyyMMdd"), ">=");
            if (Dt_fin.IsDateTime())
                Estruturas.CriarParametro(ref filtro,
                    "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("R") ? "a.dt_reserva" : "a.dt_prevretorno") + ")))",
                    DateTime.Parse(Dt_fin).ToString("yyyyMMdd"), "<=");
            if (!string.IsNullOrEmpty(St_registro))
                Estruturas.CriarParametro(ref filtro, "isnull(a.st_registro, 'A')", "(" + St_registro.Trim() + ")", "in");
            if (!string.IsNullOrEmpty(StatusItem))
                Estruturas.CriarParametro(ref filtro,
                    "(select 1 from tb_res_itensreserva x " +
                    "where x.cd_empresa = a.cd_empresa " +
                    "and x.id_reserva = a.id_reserva " +
                    "and isnull(x.st_registro, 'A') in(" + StatusItem.Trim() + "))", string.Empty, "exists");
            return new TCD_ReservaChopp(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_ReservaChopp BuscarReservaImprimir(string Cd_empresa,
                                                               string Id_reserva,
                                                               TObjetoBanco banco)
        {
            TList_ReservaChopp lista = new TCD_ReservaChopp(banco).Select(
                new TpBusca[]
                {
                    new TpBusca{ vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + Cd_empresa.Trim() + "'" },
                    new TpBusca{ vNM_Campo = "a.id_reserva", vOperador = "=", vVL_Busca = Id_reserva }
                }, 0, string.Empty);
            lista.ForEach(p =>
                {
                    p.Itens = TCN_ItensReserva.Buscar(p.Cd_empresa, p.Id_reserva.Value.ToString(), string.Empty, banco);
                    p.lExpedicao = TCN_Expedicao.Buscar(p.Cd_empresa, p.Id_reserva.Value.ToString(), string.Empty, string.Empty, string.Empty, string.Empty, false, string.Empty, banco);
                }
            );
            return lista;
        }

        public static string Gravar(TRegistro_ReservaChopp val, 
                                    TRegistro_ItensReserva rChopeira,
                                    bool St_kitextrator,
                                    TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ReservaChopp query = new TCD_ReservaChopp();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                val.Id_reserva = Convert.ToInt32(CamadaDados.TDataQuery.getPubVariavel(query.Gravar(val), "@P_ID_RESERVA"));
                if (rChopeira != null)
                    val.Itens.Add(rChopeira);
                if (St_kitextrator)
                    val.Itens.Add(new TRegistro_ItensReserva { St_kitextrator = true });
                val.Itens.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_reserva = val.Id_reserva;
                    TCN_ItensReserva.Gravar(p, query.Banco_Dados);
                });
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Id_reserva.ToString();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar reserva: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ReservaChopp val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ReservaChopp query = new TCD_ReservaChopp();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                val.Itens.ForEach(p =>
                {
                    p.MotivoCanc = val.MotivoCanc;
                    TCN_ItensReserva.Excluir(p, query.Banco_Dados);
                });
                val.St_registro = "C";
                query.Gravar(val);
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Id_reserva.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir reserva: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }

        public static void EntregarItens(TRegistro_ReservaChopp val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ReservaChopp query = new TCD_ReservaChopp();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                val.Itens
                    .ForEach(p =>
                    {
                        p.lExpedicao
                        .ForEach(v =>
                        {
                            v.Cd_empresa = p.Cd_empresa;
                            v.Id_reserva = p.Id_reserva.Value;
                            v.Id_item = p.Id_item.Value;
                            v.Dt_lancto = CamadaDados.UtilData.Data_Servidor(query.Banco_Dados);
                            v.Tp_lancto = "E";
                            v.St_registro = "A";
                            TCN_Expedicao.Gravar(v, query.Banco_Dados);
                        });
                    });
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro entregar itens: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }

        public static void ReceberResumido(List<TRegistro_ReservaChopp> val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ReservaChopp query = new TCD_ReservaChopp();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                val.ForEach(p =>
                {
                    p.Tp_pagamento = "0";//Pago
                    p.St_registro = "E";//Encerrado
                    query.Gravar(p);
                });
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro faturar resumido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }
    }

    public static class TCN_ItensReserva
    {
        public static TList_ItensReserva Buscar(string Cd_empresa,
                                                string Id_reserva,
                                                string Status,
                                                TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
                Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrEmpty(Id_reserva))
                Estruturas.CriarParametro(ref filtro, "a.id_reserva", Id_reserva);
            if (!string.IsNullOrEmpty(Status))
                Estruturas.CriarParametro(ref filtro, "isnull(a.st_registro, '0')", "(" + Status.Trim() + ")", "in");
            return new TCD_ItensReserva(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensReserva val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensReserva query = new TCD_ItensReserva();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                val.Id_item = Convert.ToInt32(CamadaDados.TDataQuery.getPubVariavel(query.Gravar(val), "@P_ID_ITEM"));
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Id_reserva.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item reserva: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensReserva val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensReserva query = new TCD_ItensReserva();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                val.St_registro = "5";//CANCELADO
                query.Gravar(val);
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Id_reserva.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item reserva: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }
    }

    public static class TCN_Reserva_X_PreVenda
    {
        public static TList_Reserva_X_PreVenda Buscar(string Cd_empresa,
                                                      string Id_reserva,
                                                      string Id_item,
                                                      string Id_prevenda,
                                                      string Id_itemprevenda,
                                                      TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
                Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrEmpty(Id_reserva))
                Estruturas.CriarParametro(ref filtro, "a.id_reserva", Id_reserva);
            if (!string.IsNullOrEmpty(Id_item))
                Estruturas.CriarParametro(ref filtro, "a.id_item", Id_item);
            if (!string.IsNullOrEmpty(Id_prevenda))
                Estruturas.CriarParametro(ref filtro, "a.id_prevenda", Id_prevenda);
            if (!string.IsNullOrEmpty(Id_itemprevenda))
                Estruturas.CriarParametro(ref filtro, "a.id_itemprevenda", Id_itemprevenda);
            return new TCD_Reserva_X_PreVenda(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Reserva_X_PreVenda val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Reserva_X_PreVenda query = new TCD_Reserva_X_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                query.Gravar(val);
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Id_reserva.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Reserva_X_PreVenda val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Reserva_X_PreVenda query = new TCD_Reserva_X_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                query.Excluir(val);
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Id_reserva.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }
    }

    public static class TCN_Expedicao
    {
        public static TList_Expedicao Buscar(string Cd_empresa,
                                             string Id_reserva,
                                             string Id_item,
                                             string Dt_ini,
                                             string Dt_fin,
                                             string Tp_lancto,
                                             bool RetornouCheio,
                                             string St_registro,
                                             TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
                Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrEmpty(Id_reserva))
                Estruturas.CriarParametro(ref filtro, "a.id_reserva", Id_reserva);
            if (!string.IsNullOrEmpty(Id_item))
                Estruturas.CriarParametro(ref filtro, "a.id_item", Id_item);
            if (!string.IsNullOrEmpty(Dt_ini))
                Estruturas.CriarParametro(ref filtro,
                    "convert(datetime, floor(convert(decimal(30,10), a.dt_lancto)))",
                    "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'", ">=");
            if(!string.IsNullOrEmpty(Dt_fin))
                Estruturas.CriarParametro(ref filtro,
                    "convert(datetime, floor(convert(decimal(30,10), a.dt_lancto)))",
                    "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'", "<=");
            if (!string.IsNullOrEmpty(Tp_lancto))
                Estruturas.CriarParametro(ref filtro, "a.tp_lancto", "'" + Tp_lancto.Trim() + "'");
            if (RetornouCheio)
                Estruturas.CriarParametro(ref filtro, "a.retornoucheio", "1");
            if (!string.IsNullOrEmpty(St_registro))
                Estruturas.CriarParametro(ref filtro, "isnull(a.st_registro, 'A')", "'" + St_registro.Trim() + "'");
            return new TCD_Expedicao().Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Expedicao val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Expedicao query = new TCD_Expedicao();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                val.Id_expedicao = Convert.ToInt32(CamadaDados.TDataQuery.getPubVariavel(query.Gravar(val), "@P_ID_EXPEDICAO"));
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Id_expedicao.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar expedição: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Expedicao val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Expedicao query = new TCD_Expedicao();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                query.Excluir(val);
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Id_reserva.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir expedição: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }

        public static void DevolverItens(TList_Expedicao val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Expedicao query = new TCD_Expedicao();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                val.Where(p => p.St_processar)
                    .ToList()
                    .ForEach(p => Gravar(
                        new TRegistro_Expedicao
                        {
                            Cd_empresa = p.Cd_empresa,
                            Id_reserva = p.Id_reserva,
                            Id_item = p.Id_item,
                            LoginRetCheio = p.LoginRetCheio,
                            Id_barril = p.Id_barril,
                            Id_chopeira = p.Id_chopeira,
                            Id_kit = p.Id_kit,
                            Dt_lancto = CamadaDados.UtilData.Data_Servidor(query.Banco_Dados),
                            Tp_lancto = "D",
                            RetornouCheio = p.RetornouCheio,
                            St_registro = "A"
                        }, query.Banco_Dados));
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro devolver itens: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }
    }
}
