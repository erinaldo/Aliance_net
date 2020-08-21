using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.PDV;

namespace CamadaNegocio.Faturamento.PDV
{
    #region Mapa Resumo
    public class TCN_MapaResumo
    {
        public static TList_MapaResumo Buscar(string Id_mapa,
                                              string Id_equipamento,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_mapa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_mapa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mapa;
            }
            if (!string.IsNullOrEmpty(Id_equipamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_equipamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_equipamento;
            }
            return new TCD_MapaResumo(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MapaResumo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MapaResumo qtb_mapa = new TCD_MapaResumo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mapa.CriarBanco_Dados(true);
                else
                    qtb_mapa.Banco_Dados = banco;
                val.Id_mapastr = CamadaDados.TDataQuery.getPubVariavel(qtb_mapa.Gravar(val), "@P_ID_MAPA");
                //Gravar totalizador
                val.lTotalizador.ForEach(p =>
                    {
                        p.Id_mapa = val.Id_mapa;
                        TCN_TotalizadorMapa.Gravar(p, qtb_mapa.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_mapa.Banco_Dados.Commit_Tran();
                return val.Id_mapastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mapa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar mapa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mapa.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MapaResumo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MapaResumo qtb_mapa = new TCD_MapaResumo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mapa.CriarBanco_Dados(true);
                else
                    qtb_mapa.Banco_Dados = banco;
                //Excluir totalizador
                val.lTotalizador.ForEach(p => TCN_TotalizadorMapa.Excluir(p, qtb_mapa.Banco_Dados));
                //Excluir mapa
                qtb_mapa.Excluir(val);
                if (st_transacao)
                    qtb_mapa.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mapa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir mapa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mapa.deletarBanco_Dados();
            }
        }

        public static void TratarRetornoRegistro60M(TRegistro_MapaResumo val)
        {
            if(System.IO.File.Exists("C:\\work\\retorno.txt"))
                using (System.IO.StreamReader sr = new System.IO.StreamReader("C:\\work\\retorno.txt"))
                {
                    val = new TRegistro_MapaResumo();
                    int index = 0;
                    string linha = string.Empty;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(linha))
                        {
                            if (index == 2)
                            {
                                //Data reducao Z
                                string[] aux = linha.Split(new char[] { ':' });
                                try
                                {
                                    val.Dt_mapa = DateTime.Parse(aux[1].Trim());
                                }
                                catch
                                { }
                            }
                            if (index == 6)
                            {
                                //COO Inicial
                                string[] aux = linha.Split(new char[] { ':' });
                                try
                                {
                                    val.Nr_coo_inicial = decimal.Parse(aux[1]);
                                }
                                catch
                                { }
                            }
                            if (index == 7)
                            {
                                //COO Final
                                string[] aux = linha.Split(new char[] { ':' });
                                try
                                {
                                    val.Nr_coo_final = decimal.Parse(aux[1]);
                                }
                                catch
                                { }
                            }
                            if (index == 8)
                            {
                                //Contador Reducoes
                                string[] aux = linha.Split(new char[] { ':' });
                                try
                                {
                                    val.Contador_reducaoZ = decimal.Parse(aux[1]);
                                }
                                catch
                                { }
                            }
                            if (index == 9)
                            {
                                //Contador reinicio operacao
                                string[] aux = linha.Split(new char[] { ':' });
                                try
                                {
                                    val.Contador_reinicio_operacao = decimal.Parse(aux[1]);
                                }
                                catch
                                { }
                            }
                            if (index == 10)
                            {
                                //Venda bruta
                                string[] aux = linha.Split(new char[] { ':' });
                                try
                                {
                                    val.Vl_vendabruta = decimal.Parse(aux[1]);
                                }
                                catch
                                { }
                            }
                            if (index == 11)
                            {
                                //Venda total
                                string[] aux = linha.Split(new char[] { ':' });
                                try
                                {
                                    val.Vl_totalgeral = decimal.Parse(aux[1]);
                                }
                                catch
                                { }
                            }
                            index++;
                        }
                    }
                    sr.Close();
                }
        }

        public static void TratarRetornoRegistro60A(TRegistro_MapaResumo val)
        {
            if (System.IO.File.Exists("C:\\work\\retorno.txt"))
                using (System.IO.StreamReader sr = new System.IO.StreamReader("C:\\work\\retorno.txt"))
                {
                    val = new TRegistro_MapaResumo();
                    int index = 0;
                    string linha = string.Empty;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(linha))
                        {
                            if (index == 2)
                            {
                                //Data reducao Z
                                string[] aux = linha.Split(new char[] { ':' });
                                try
                                {
                                    val.Dt_mapa = DateTime.Parse(aux[1].Trim());
                                }
                                catch
                                { }
                            }
                            if (index == 6)
                            {
                                //COO Inicial
                                string[] aux = linha.Split(new char[] { ':' });
                                try
                                {
                                    val.Nr_coo_inicial = decimal.Parse(aux[1]);
                                }
                                catch
                                { }
                            }
                            if (index == 7)
                            {
                                //COO Final
                                string[] aux = linha.Split(new char[] { ':' });
                                try
                                {
                                    val.Nr_coo_final = decimal.Parse(aux[1]);
                                }
                                catch
                                { }
                            }
                            if (index == 8)
                            {
                                //Contador Reducoes
                                string[] aux = linha.Split(new char[] { ':' });
                                try
                                {
                                    val.Contador_reducaoZ = decimal.Parse(aux[1]);
                                }
                                catch
                                { }
                            }
                            if (index == 9)
                            {
                                //Contador reinicio operacao
                                string[] aux = linha.Split(new char[] { ':' });
                                try
                                {
                                    val.Contador_reinicio_operacao = decimal.Parse(aux[1]);
                                }
                                catch
                                { }
                            }
                            if (index == 10)
                            {
                                //Venda bruta
                                string[] aux = linha.Split(new char[] { ':' });
                                try
                                {
                                    val.Vl_vendabruta = decimal.Parse(aux[1]);
                                }
                                catch
                                { }
                            }
                            if (index == 11)
                            {
                                //Venda total
                                string[] aux = linha.Split(new char[] { ':' });
                                try
                                {
                                    val.Vl_totalgeral = decimal.Parse(aux[1]);
                                }
                                catch
                                { }
                            }
                            index++;
                        }
                    }
                    sr.Close();
                }
        }
    }
    #endregion

    #region Totalizador Mapa
    public class TCN_TotalizadorMapa
    {
        public static TList_TotalizadorMapa Buscar(string Id_mapa,
                                                   string Id_totalizador,
                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_mapa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_mapa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mapa;
            }
            if (!string.IsNullOrEmpty(Id_totalizador))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_totalizador";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_totalizador;
            }
            return new TCD_TotalizadorMapa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TotalizadorMapa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TotalizadorMapa qtb_tot = new TCD_TotalizadorMapa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tot.CriarBanco_Dados(true);
                else
                    qtb_tot.Banco_Dados = banco;
                val.Id_totalizadorstr = CamadaDados.TDataQuery.getPubVariavel(qtb_tot.Gravar(val), "@P_ID_TOTALIZADOR");
                if (st_transacao)
                    qtb_tot.Banco_Dados.Commit_Tran();
                return val.Id_totalizadorstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tot.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar totalizador: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tot.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TotalizadorMapa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TotalizadorMapa qtb_tot = new TCD_TotalizadorMapa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tot.CriarBanco_Dados(true);
                else
                    qtb_tot.Banco_Dados = banco;
                qtb_tot.Excluir(val);
                if (st_transacao)
                    qtb_tot.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tot.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir totalizador: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tot.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
