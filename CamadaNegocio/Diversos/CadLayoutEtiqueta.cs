using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Diversos;
using Utils;
using BancoDados;

namespace CamadaNegocio.Diversos
{
    public class TRegistro_Objeto
    {
        public decimal Codigo { get; set; } = decimal.Zero;
        public string Produto { get; set; } = string.Empty;
        public string Cod_barra { get; set; } = string.Empty;
        public decimal Vl_preco { get; set; } = decimal.Zero;
        public int Qtd_etiqueta { get; set; } = 0;
        public int posicao { get; set; } = 0;
    }

    public class TCN_CadLayoutEtiqueta
    {

        public static void ImpEtiquetaLayout(List<TRegistro_Objeto> obj,
                                       string Porta, CamadaDados.Diversos.TRegistro_CadTerminal rTerminal, bool sobra = false)
        {
            if (!System.IO.Directory.Exists("c:\\aliance.net"))
                System.IO.Directory.CreateDirectory("c:\\aliance.net");
            //carrega layouts
            TList_CadLayoutEtiqueta lLyaout = new TList_CadLayoutEtiqueta();
            if (rTerminal.Id_layout != decimal.Zero)
                lLyaout = TCN_CadLayoutEtiqueta.Busca(rTerminal.Id_layout.ToString(), string.Empty, null);
            if (lLyaout.Count <= 0)
                return;
            lLyaout.ForEach(p => { p.lCampos = TCN_CamposLayout.Busca(string.Empty, p.Id_layoutstr, string.Empty, null); });
            
            decimal total_etiqueta = obj.Sum(p => p.Qtd_etiqueta);

            //desagrupar quantidades e definir posicoes
            List<TRegistro_Objeto> prod_un = new List<TRegistro_Objeto>();
            int pos = 0;
            obj.ForEach(p =>
            {
                for (int i = 1; i <= p.Qtd_etiqueta; i++)
                {
                    pos++;
                    prod_un.Add(new TRegistro_Objeto()
                    {
                        Codigo = p.Codigo,
                        Cod_barra = p.Cod_barra,
                        Produto = p.Produto,
                        Vl_preco = p.Vl_preco,
                        posicao = pos
                    });             //1 1 2
                    if (pos == 3)               //2 2 3
                        pos = 0;                //3 3 3
                }
            });
            decimal total_imprimido = decimal.Zero;
            //lista de impressao 
            StringBuilder w = new StringBuilder();
            lLyaout.ForEach(p =>
            {

                TList_CamposEtiqueta lcamp = new TList_CamposEtiqueta();

                p.lCampos.ForEach(o =>
                {
                    lcamp.Add(o);
                });
                pos = 0;
                prod_un.ForEach(pro =>
                {
                    pos++;
                    if (string.IsNullOrEmpty(w.ToString()))
                    {

                        w.AppendLine("I8,A,001");
                        w.AppendLine();
                        w.AppendLine();
                        w.AppendLine("Q" + p.alturaetiqueta.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ",0"
                            + p.larguraetiqueta.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)));
                        w.AppendLine("rN");
                        w.AppendLine("S4");
                        w.AppendLine("D7");
                        w.AppendLine("ZT");
                        w.AppendLine("JF");
                        w.AppendLine("OD");
                        w.AppendLine("f100");
                        w.AppendLine("N");
                    }

                    string prod1 = string.Empty;
                    string prod2 = string.Empty;
                    string prod3 = pro.Produto;
                    if (pro.Produto.Trim().Length > 20)
                    {
                        prod1 = pro.Produto.Trim().Substring(0, 20);
                        pro.Produto = pro.Produto.Remove(0, 20);
                        if (pro.Produto.Trim().Length > 20)
                        {
                            prod2 = pro.Produto.Trim().Substring(0, 20);
                            pro.Produto = pro.Produto.Remove(0, 20);
                        }
                        else prod2 = pro.Produto;
                    }
                    else prod1 = pro.Produto;
                    pro.Produto = prod3;

                    lcamp.ForEach(o =>
                    {
                        string tp = string.Empty;
                        if (o.Status.Equals("CAMPO"))
                            tp = "A";
                        else
                            tp = "B";
                        if (o.ds_campo.Equals("DESCRICAO") && o.coluna.Equals(pro.posicao))
                        {
                            w.AppendLine(tp + o.posx.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ","
                                + o.posy.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ",0,2,1,1,N,\"" + prod1.Trim() + "\"");
                        }
                        if (o.ds_campo.Equals("DESCRICAO2") && o.coluna.Equals(pro.posicao))
                        {
                            w.AppendLine(tp + o.posx.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ","
                                + o.posy.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ",0,2,1,1,N,\"" + prod2.Trim() + "\"");
                        }
                        else if (o.ds_campo.Equals("VALOR") && o.coluna.Equals(pro.posicao))
                        {
                            w.AppendLine(tp + o.posx.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + "," + o.posy.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ",0,2,1,1,N,\""  //A24,56
                                + " Cd:" + pro.Codigo.ToString() + "\"");
                                //+ pro.Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)) + " Cd:" + pro.Codigo.ToString() + "\"");
                        }
                        else if (o.ds_campo.Equals("COD_BAR") && o.coluna.Equals(pro.posicao))
                        {
                            w.AppendLine(tp + o.posx.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ","
                                + o.posy.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ",0,E30,2,4,56,B,\"" + pro.Cod_barra.Trim() + "\"");//B40,88
                        }
                    });
                    if (pos == 3 || (decimal.Subtract(total_etiqueta, decimal.Add(total_imprimido, pos)) == decimal.Zero))
                    {
                        System.IO.FileInfo f = new System.IO.FileInfo("c:\\aliance.net\\etiqueta.txt");
                        System.IO.StreamWriter we = f.CreateText();
                        try
                        {
                            w.AppendLine("P1");
                            we.WriteLine(w.ToString());
                        }
                        finally
                        {
                            we.Flush();
                            we.Dispose();
                            f.CopyTo(Porta.Trim());
                            pos = 0;
                            w.Clear();
                            total_imprimido += 3;
                        }
                    }
                });


            });





        }

        public static void ImpEtiquetaLayout(decimal Codigo,
                                       string Produto,
                                       string Cod_barra,
                                       decimal Vl_preco,
                                       int Qtd_etiqueta,
                                       string Porta, CamadaDados.Diversos.TRegistro_CadTerminal rTerminal, bool sobra = false)
        {
            if (!System.IO.Directory.Exists("c:\\aliance.net"))
                System.IO.Directory.CreateDirectory("c:\\aliance.net");
            System.IO.FileInfo f = new System.IO.FileInfo("c:\\aliance.net\\etiqueta.txt");
            System.IO.StreamWriter w = f.CreateText();

            decimal falta = decimal.Zero;
            try
            {
                TList_CadLayoutEtiqueta lLyaout = new TList_CadLayoutEtiqueta();
                if (rTerminal.Id_layout != decimal.Zero)
                    lLyaout = TCN_CadLayoutEtiqueta.Busca(rTerminal.Id_layout.ToString(), string.Empty, null);
                lLyaout.ForEach(p => { p.lCampos = TCN_CamposLayout.Busca(string.Empty, p.Id_layoutstr, string.Empty, null); });

                decimal qtidade = decimal.Zero;
                decimal qtd = decimal.Zero;
                if (!string.IsNullOrEmpty(Qtd_etiqueta.ToString()))
                    qtidade = Convert.ToDecimal(Qtd_etiqueta.ToString());
                lLyaout.ForEach(p =>
                {
                    qtd = decimal.Divide(qtidade, p.nr_Coluna);

                    String[] str = qtd.ToString().Split(',');
                    if (str.Length > 1)
                    {
                        if (Convert.ToDecimal(str[0]) > 1)
                        {
                            qtd = Convert.ToDecimal(str[0]);
                        }
                        else
                            qtd = 1;

                        //{

                        //}

                    }

                    falta = Qtd_etiqueta - qtd * p.nr_Coluna;

                    w.WriteLine("I8,A,001");
                    w.WriteLine();
                    w.WriteLine();
                    w.WriteLine("Q" + p.alturaetiqueta.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ",0"
                        + p.larguraetiqueta.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true))); // altura espaco 176,024
                    w.WriteLine("rN");
                    w.WriteLine("S4");
                    w.WriteLine("D7");
                    w.WriteLine("ZT");
                    w.WriteLine("JF");
                    w.WriteLine("OD");
                    w.WriteLine("f100");
                    w.WriteLine("N");

                    TList_CamposEtiqueta lcamp = new TList_CamposEtiqueta();
                    //if (sobra)
                    //{
                    p.lCampos.ForEach(o =>
                    {
                        if (o.coluna <= Qtd_etiqueta)
                            lcamp.Add(o);
                    });
                    //}
                    //else
                    //{
                    //    p.lCampos.ForEach(o =>
                    //    { 
                    //        lcamp.Add(o);
                    //    });
                    //}
                    int cont = 0;

                    string prod1 = string.Empty;
                    string prod2 = string.Empty;
                    string prod3 = Produto;
                    if (Produto.Trim().Length > 20)
                    {
                        prod1 = Produto.Trim().Substring(0, 20);
                        Produto = Produto.Remove(0, 20);
                        if (Produto.Trim().Length > 20)
                        {
                            prod2 = Produto.Trim().Substring(0, 20);
                            Produto = Produto.Remove(0, 20);
                            //if (Produto.Trim().Length > 20)
                            //{
                            //    prod3 = Produto.Trim().Substring(0, 20);
                            //    Produto = Produto.Remove(0, 20);
                            //}
                            //else prod3 = Produto;
                        }
                        else prod2 = Produto;       // f
                    }

                    else prod1 = Produto;
                    Produto = prod3;
                    lcamp.ForEach(o =>
                    {
                        string tp = string.Empty;
                        if (o.Status.Equals("CAMPO"))
                            tp = "A";
                        else
                            tp = "B";
                        cont = 0;
                        //string prod1 = string.Empty;
                        //string prod2 = string.Empty;
                        //string prod3 = string.Empty;
                        //if (Produto.Trim().Length > 20)
                        //{
                        //    prod1 = Produto.Trim().Substring(0, 20);
                        //    Produto = Produto.Remove(0, 20);
                        //    if (Produto.Trim().Length > 20)
                        //    {
                        //        cont = 1;
                        //        prod2 = Produto.Trim().Substring(0, 20);
                        //        Produto = Produto.Remove(0, 20);
                        //        if (Produto.Trim().Length > 20)
                        //        {
                        //            prod3 = Produto.Trim().Substring(0, 20);
                        //            Produto = Produto.Remove(0, 20);
                        //        }
                        //        else prod3 = Produto;
                        //    }
                        //    else prod2 = Produto;       // f
                        //}
                        //else prod1 = Produto;
                        cont++;
                        if (o.ds_campo.Equals("DESCRICAO"))
                        {
                            w.WriteLine(tp + o.posx.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ","
                                + o.posy.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ",0," + o.Tp_Fonte + ",1,1,N,\"" + prod1.Trim() + "\"");//A24,8
                                                                                                                                                                       //w.WriteLine("A304,8,0,2,1,1,N,\"" + prod1.Trim() + "\"");
                                                                                                                                                                       //w.WriteLine("A584,8,0,2,1,1,N,\"" + prod1.Trim() + "\"");

                        }
                        if (o.ds_campo.Equals("DESCRICAO2"))
                        {

                            w.WriteLine(tp + o.posx.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ","
                                + o.posy.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ",0," + o.Tp_Fonte + ",1,1,N,\"" + prod2.Trim() + "\"");//A24,32
                            cont = 0;                                                                                                                                                                                                                              //w.WriteLine("A304,32,0,2,1,1,N,\"" + prod2.Trim() + "\"");
                                                                                                                                                                                                                                                                   //w.WriteLine("A584,32,0,2,1,1,N,\"" + prod2.Trim() + "\"");

                        }
                        else if (o.ds_campo.Equals("VALOR"))
                        {

                            w.WriteLine(tp + o.posx.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + "," + o.posy.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ",0," + o.Tp_Fonte + ",1,1,N,\""  //A24,56
                                + Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)) + " Cd:" + Codigo.ToString() + "\"");
                        }
                        else if (o.ds_campo.Equals("COD_BAR"))
                        {

                            w.WriteLine(tp + o.posx.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ","
                                + o.posy.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)) + ",0,E30,2," + o.Tp_Fonte + ",56,B,\"" + Cod_barra.Trim() + "\"");//B40,88
                        }


                    });



                });

                w.WriteLine("P" + qtd);
                w.Flush();
                f.CopyTo(Porta.Trim());

            }
            finally
            {
                w.Dispose();
                f = null;
            }
            try
            {
                if (falta > decimal.Zero)
                    ImpEtiquetaLayout(Codigo,
                                       Produto,
                                       Cod_barra,
                                       Vl_preco,
                                       Convert.ToInt32(falta.ToString("N0", new System.Globalization.CultureInfo("en-US"))),
                                       Porta, rTerminal, true);
            }
            finally
            {

            }
        }

        public static TList_CadLayoutEtiqueta Busca(string id_layout, string DS_layout, TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (id_layout.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_layout";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + id_layout + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            };

            if (DS_layout.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_layout";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + DS_layout + "%'";
                vBusca[vBusca.Length - 1].vOperador = "like";
            };

            TCD_CadLayoutEtiqueta qtb_Menu = new TCD_CadLayoutEtiqueta();

            if (banco != null)
                qtb_Menu.Banco_Dados = banco;

            return qtb_Menu.Select(vBusca, 0, string.Empty, string.Empty);
        }

        public static string GravarMenu(TRegistro_CadLayoutEtiqueta val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadLayoutEtiqueta qtb_Menu = new TCD_CadLayoutEtiqueta();

            try
            {
                if (banco == null)
                {
                    qtb_Menu.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Menu.Banco_Dados = banco;
                string retorno = qtb_Menu.GravarMenu(val);
                val.lCampos.ForEach(p =>
                {
                    p.Id_layout = val.Id_layout;
                    TCN_CamposLayout.GravarMenu(p, qtb_Menu.Banco_Dados);
                });
                val.lCamposDel.ForEach(p =>
                {
                    p.Id_layout = val.Id_layout;
                    TCN_CamposLayout.Excluir(p, qtb_Menu.Banco_Dados);
                });

                if (st_transacao)
                    qtb_Menu.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Menu.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Menu.deletarBanco_Dados();
            }
            //return new TCD_CadMenu().GravarMenu(val);
        }

        public static string Excluir(TRegistro_CadLayoutEtiqueta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadLayoutEtiqueta qtb_menu = new TCD_CadLayoutEtiqueta();
            try
            {
                if (banco == null)
                {
                    qtb_menu.CriarBanco_Dados(true);
                    st_transacao = true;
                    banco = qtb_menu.Banco_Dados;
                }
                else
                    qtb_menu.Banco_Dados = banco;


                //DELETA MENU
                string retorno = qtb_menu.DeletarMenu(val);

                if (st_transacao)
                    qtb_menu.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_menu.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_menu.deletarBanco_Dados();
            }
        }

    }
    public class TCN_CamposLayout
    {

        public static TList_CamposEtiqueta Busca(string id_campo, string id_layout, string ds_campo, TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (id_campo.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_campo";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + id_campo + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            };
            if (id_layout.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_layout";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + id_layout + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            };

            if (ds_campo.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "ds_campo";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + ds_campo + "%'";
                vBusca[vBusca.Length - 1].vOperador = "like";
            };

            TCD_CamposEtiqueta qtb_Menu = new TCD_CamposEtiqueta();

            if (banco != null)
                qtb_Menu.Banco_Dados = banco;

            return qtb_Menu.Select(vBusca, 0, string.Empty, string.Empty);
        }

        public static string GravarMenu(TRegistro_CamposEtiqueta val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CamposEtiqueta qtb_Menu = new TCD_CamposEtiqueta();

            try
            {
                if (banco == null)
                {
                    qtb_Menu.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Menu.Banco_Dados = banco;
                string retorno = qtb_Menu.GravarMenu(val);
                if (st_transacao)
                    qtb_Menu.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Menu.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Menu.deletarBanco_Dados();
            }
            //return new TCD_CadMenu().GravarMenu(val);
        }



        public static string Excluir(TRegistro_CamposEtiqueta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CamposEtiqueta qtb_menu = new TCD_CamposEtiqueta();
            try
            {
                if (banco == null)
                {
                    qtb_menu.CriarBanco_Dados(true);
                    st_transacao = true;
                    banco = qtb_menu.Banco_Dados;
                }
                else
                    qtb_menu.Banco_Dados = banco;


                //DELETA MENU
                string retorno = qtb_menu.DeletarMenu(val);

                if (st_transacao)
                    qtb_menu.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_menu.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_menu.deletarBanco_Dados();
            }
        }



    }
}
