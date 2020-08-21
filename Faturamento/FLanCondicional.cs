using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Faturamento.PDV;
using CamadaNegocio.Faturamento.PDV;

namespace Faturamento
{
    public partial class TFLanCondicional : Form
    {
        private bool Altera_Relatorio = false;
        public TFLanCondicional()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_condicional.Clear();
            cd_empresa.Clear();
            cd_clifor.Clear();
            cd_produto.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
            st_ativo.Checked = false;
            st_cancelado.Checked = false;
            st_saldodevolver.Checked = false;
            st_devolvido.Checked = false;
        }

        private void afterNovo()
        {
            using (TFCondicional fCond = new TFCondicional())
            {
                if (fCond.ShowDialog() == DialogResult.OK)
                    if (fCond.rCond != null)
                    {
                        LimparFiltros();
                        id_condicional.Text = fCond.rCond.Id_condicionalstr;
                        cd_empresa.Text = fCond.rCond.Cd_empresa;
                        afterBusca();
                        if (MessageBox.Show("Deseja gerar NF do condicional?", "Pergunta", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            try
                            {
                                fCond.rCond.lItens.ForEach(p => p.Qtd_faturar = p.Quantidade);
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                    Proc_Commoditties.TProcessarNFCondicional.ProcessarCondicional(fCond.rCond.Cd_clifor, fCond.rCond.lItens.ToList());
                                CamadaNegocio.Faturamento.PDV.TCN_Condicional.ProcessarNFCondicional(rNf, null);
                                afterBusca();
                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                {
                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                    rNf.Nr_lanctofiscalstr,
                                                                                                                    null);
                                    fGerNfe.ShowDialog();
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void afterExclui()
        {
            if (bsCondicional.Current != null)
            {
                if ((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Condicional ja se encontra CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma CANCELAMENTO do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.PDV.TCN_Condicional.Excluir(bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional, null);
                        MessageBox.Show("Condicional CANCELADO com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFiltros();
                        id_condicional.Text = (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Id_condicionalstr;
                        cd_empresa.Text = (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Cd_empresa;
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (st_ativo.Checked || st_devolvido.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (st_cancelado.Checked)
                status += virg + "'C'";
            string tp_mov = string.Empty;
            virg = string.Empty;
            if (cbEntrada.Checked)
            {
                tp_mov = "'E'";
                virg = ",";
            }
            if (cbSaida.Checked)
                tp_mov += virg + "'S'";

            CamadaDados.Faturamento.PDV.TList_Condicional lCondicional = CamadaNegocio.Faturamento.PDV.TCN_Condicional.Buscar(cd_empresa.Text,
                                                                               id_condicional.Text,
                                                                               cd_clifor.Text,
                                                                               cd_produto.Text,
                                                                               rbCondicional.Checked ? "C" : string.Empty,
                                                                               dt_ini.Text,
                                                                               dt_fin.Text,
                                                                               tp_mov,
                                                                               status,
                                                                               st_saldodevolver.Checked,
                                                                               cbSaldoNfNormal.Checked,
                                                                               cbSaldoNfDev.Checked,
                                                                               null);
            if (!st_devolvido.Checked)
                lCondicional.RemoveAll(p => p.Status.Equals("DEVOLVIDO"));
            else
                if (!st_ativo.Checked)
                lCondicional.RemoveAll(p => p.Status.Equals("ATIVO"));

            bsCondicional.DataSource = lCondicional;
            bsCondicional_PositionChanged(this, new EventArgs());
        }

        private void afterAlterar()
        {
            if ((bsCondicional.Current != null) &&
                (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Status.Equals("ATIVO"))
            {
                using (TFCondicional fCond = new TFCondicional())
                {
                    CamadaDados.Faturamento.PDV.TRegistro_Condicional rCond = (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional);
                    rCond.lItens.Clear();
                    fCond.rCond = rCond;
                    if (fCond.ShowDialog() == DialogResult.OK)
                    {
                        if (fCond.rCond != null)
                        {
                            LimparFiltros();
                            id_condicional.Text = fCond.rCond.Id_condicionalstr;
                            cd_empresa.Text = fCond.rCond.Cd_empresa;
                            afterBusca();
                            if (MessageBox.Show("Deseja gerar NF do condicional?", "Pergunta", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                try
                                {
                                    fCond.rCond.lItens.ForEach(p => p.Qtd_faturar = p.Quantidade);
                                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                        Proc_Commoditties.TProcessarNFCondicional.ProcessarCondicional(fCond.rCond.Cd_clifor, fCond.rCond.lItens.ToList());
                                    CamadaNegocio.Faturamento.PDV.TCN_Condicional.ProcessarNFCondicional(rNf, null);
                                    afterBusca();
                                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                    {
                                        fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                        rNf.Nr_lanctofiscalstr,
                                                                                                                        null);
                                        fGerNfe.ShowDialog();
                                    }
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                }
                afterBusca();
            }
        }

        private void DevolverParcialCondicional()
        {
            if (bsCondicional.Current != null)
            {
                if ((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido devolver condicional CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!(bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Status.Equals("ATIVO"))
                {
                    MessageBox.Show("Não é permitido devolver condicional parcial com status diferente de ATIVO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).lItens.Exists(p => p.Saldo_devolver > decimal.Zero))
                    using (TFDevolverCond fDev = new TFDevolverCond())
                    {
                        fDev.Text = "Devolver Parcialmente o Condicional";
                        fDev.Cd_empresa = (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Cd_empresa;
                        fDev.Id_condicional = (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Id_condicionalstr;
                        fDev.Tp_movimento = (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Tp_movimento;
                        fDev.St_faturar = false;
                        if (fDev.ShowDialog() == DialogResult.OK)
                            if (fDev.lItens != null)
                                if (fDev.lItens.Count > 0)
                                {
                                    try
                                    {
                                        CamadaNegocio.Faturamento.PDV.TCN_ItensCondicional.DevolverItensCond(fDev.lItens, null);
                                        LimparFiltros();
                                        cd_empresa.Text = fDev.Cd_empresa;
                                        id_condicional.Text = fDev.Id_condicional;
                                        st_ativo.Checked = true;
                                        afterBusca();
                                        //Gerar NF de Devolucao Condicional
                                        if (MessageBox.Show("Deseja gerar NF-e devolução?", "Pergunta", MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                        {
                                            List<CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional> lItens =
                                                (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).lItens.FindAll(p => p.Qtd_devolvida - p.Qtd_nfdev > decimal.Zero);
                                            lItens.ForEach(p => p.Qtd_devolver = p.Qtd_devolvida - p.Qtd_nfdev);
                                            try
                                            {
                                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                                    Proc_Commoditties.TProcessarNFCondicional.ProcessarNfDevolucao((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Cd_clifor, lItens);
                                                CamadaNegocio.Faturamento.PDV.TCN_Condicional.ProcessarNFDevCond(rNf, null);

                                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                                {
                                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                                    rNf.Nr_lanctofiscalstr,
                                                                                                                                    null);
                                                    fGerNfe.ShowDialog();
                                                }
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        }
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                    }
            }
        }

        private void DevolverTotalCondicional()
        {
            if (bsCondicional.Current == null) return;
            if ((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).St_registro.Trim().ToUpper().Equals("C"))
            {
                MessageBox.Show("Não é permitido devolver condicional CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).lItens.Exists(p => p.Saldo_devolver > decimal.Zero))
            {
                if ((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).lItens.Exists(p => p.Qtd_devolvida > decimal.Zero))
                {
                    MessageBox.Show("Não é permitido fazer devolução total de um condicional com devolução parcial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    if ((MessageBox.Show("Deseja realmente devolver totalmente o condicional: "
                        + (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Id_condicionalstr
                        + ", que resulta com subtotal de " + (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).lItens.Sum(p => p.Vl_subtotal) + " R$? "
                        , "Mensagem",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.No) return;
                    List<CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional> lItens =
                        (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).lItens.FindAll(p => p.Saldo_devolver > decimal.Zero);
                    lItens.ForEach(p =>
                    {
                        p.Qtd_devolver = p.Saldo_devolver;
                        p.lGrade.Clear();
                        new CamadaDados.Estoque.TCD_GradeEstoque().Select(new Utils.TpBusca[]
                        {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_pdv_itenscondicional_x_estoque x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.cd_produto = a.cd_produto " +
                                                "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                "and x.id_condicional = " + p.Id_condicionalstr + " " +
                                                "and x.id_item = " + p.Id_itemstr + ")"
                                }
                        }, 0, string.Empty).ForEach(v => p.lGrade.Add(new CamadaDados.Estoque.Cadastros.TRegistro_ValorCaracteristica() { Id_caracteristica = v.Id_caracteristica, Id_item = v.Id_item, Valor = v.valor, Vl_mov = v.quantidade.Value }));
                    });
                    CamadaNegocio.Faturamento.PDV.TCN_ItensCondicional.DevolverItensCond(lItens, null);
                    LimparFiltros();
                    cd_empresa.Text = (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Cd_empresa;
                    id_condicional.Text = (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Id_condicionalstr;
                    st_devolvido.Checked = true;
                    afterBusca();
                    //Gerar NF de Devolucao Condicional
                    if (MessageBox.Show("Deseja gerar NF-e devolução?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        lItens = (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).lItens.FindAll(p => p.Qtd_devolvida - p.Qtd_nfdev > decimal.Zero);
                        lItens.ForEach(p => p.Qtd_devolver = p.Qtd_devolvida - p.Qtd_nfdev);
                        try
                        {
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                Proc_Commoditties.TProcessarNFCondicional.ProcessarNfDevolucao((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Cd_clifor, lItens);
                            CamadaNegocio.Faturamento.PDV.TCN_Condicional.ProcessarNFDevCond(rNf, null);

                            using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                            {
                                fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                rNf.Nr_lanctofiscalstr,
                                                                                                                null);
                                fGerNfe.ShowDialog();
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else MessageBox.Show("Não existe item com saldo para devolver no condicional corrente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Print()
        {
            if (bsCondicional.Current != null)
            {
                if (!(bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).St_registro.Trim().ToUpper().Equals("C"))
                {
                    object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                              new Utils.TpBusca[]
                                                                {
                                                                    new Utils.TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_terminal",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                    }
                                                                }, "a.tp_imporcamento");
                    if (string.IsNullOrEmpty(obj.ToString()))
                        throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());

                    if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R")))
                        CamadaNegocio.Faturamento.PDV.TCN_Condicional.ImprimirReduzido(bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional, null);
                    else
                    {
                        FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                        Relatorio.Altera_Relatorio = Altera_Relatorio;

                        //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                        Relatorio.Nome_Relatorio = Name;
                        Relatorio.NM_Classe = Name;
                        Relatorio.Modulo = string.Empty;


                        BindingSource BinEmpresa = new BindingSource();
                        BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(
                                                                     (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Cd_empresa,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     null);

                        BindingSource BinClifor = new BindingSource();
                        BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Cd_clifor,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
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
                                                                                                              1,
                                                                                                              null);


                        BindingSource meu_bind = new BindingSource();
                        (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).lItens.ForEach(p =>
                        {
                            p.lGrade.Clear();
                            new CamadaDados.Estoque.TCD_GradeEstoque().Select(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_pdv_itenscondicional_x_estoque x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.cd_produto = a.cd_produto " +
                                                "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                "and x.id_condicional = " + p.Id_condicionalstr + " " +
                                                "and x.id_item = " + p.Id_itemstr + ")"
                                }
                            }, 0, string.Empty).ForEach(v => p.lGrade.Add(new CamadaDados.Estoque.Cadastros.TRegistro_ValorCaracteristica() { Valor = v.valor, Vl_mov = v.quantidade.Value }));
                        });
                        meu_bind.DataSource = new CamadaDados.Faturamento.PDV.TList_Condicional() { bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional };
                        Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                        Relatorio.DTS_Relatorio = meu_bind;



                        Relatorio.Ident = Name;
                        if (BinEmpresa.Current != null)
                            if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                                Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                        if (!Altera_Relatorio)
                        {
                            //Chamar tela de gerenciamento de impressao
                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Cd_clifor;
                                fImp.pMensagem = "CONDICIONAL Nº " + (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Id_condicionalstr;
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    Relatorio.Gera_Relatorio((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Id_condicionalstr,
                                                             fImp.pSt_imprimir,
                                                             fImp.pSt_visualizar,
                                                             fImp.pSt_enviaremail,
                                                             fImp.pSt_exportPdf,
                                                             fImp.Path_exportPdf,
                                                             fImp.pDestinatarios,
                                                             null,
                                                             "CONDICIONAL Nº " + (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Id_condicionalstr,
                                                             fImp.pDs_mensagem);
                            }
                        }
                        else
                        {
                            Relatorio.Gera_Relatorio();
                            Altera_Relatorio = false;
                        }
                    }
                }
            }
        }

        private void ExcluirItem()
        {
            if (bsCondicional.Current != null)
            {
                if (!(bsCondicional.Current as TRegistro_Condicional).Status.Equals("ATIVO"))
                {
                    MessageBox.Show("Não será possível excluir o item corrente, pois o status da condicional é " +
                        (bsCondicional.Current as TRegistro_Condicional).Status + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (bsItens.Current != null)
                    if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        TCN_ItensCondicional.Excluir((bsItens.Current as TRegistro_ItensCondicional), null);
                        afterBusca();
                    }
            }
            
        }

        private void TFLanCondicional_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCondicional);
            Utils.ShapeGrid.RestoreShape(this, gItens);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bsCondicional_PositionChanged(object sender, EventArgs e)
        {
            if (bsCondicional.Current != null)
            {
                (bsCondicional.Current as TRegistro_Condicional).lItens =
                            TCN_ItensCondicional.Buscar((bsCondicional.Current as TRegistro_Condicional).Cd_empresa,
                                                        (bsCondicional.Current as TRegistro_Condicional).Id_condicionalstr,
                                                        null);

                if ((bsCondicional.Current as TRegistro_Condicional).lItens != null)
                    (bsCondicional.Current as TRegistro_Condicional).lItens.RemoveAll(p => !p.Status.Equals("ATIVO"));
                bsCondicional.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAlterar();
        }

        private void gCondicional_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gCondicional.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("DEVOLVIDO"))
                        gCondicional.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else
                        gCondicional.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void TFLanCondicional_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                Print();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void TFLanCondicional_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCondicional);
            Utils.ShapeGrid.SaveShape(this, gItens);
        }

        private void nFNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsCondicional.Current != null)
                if ((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).lItens.Exists(p => p.Quantidade - p.Qtd_nfcond > decimal.Zero))
                    if (MessageBox.Show("Deseja gerar NF Condicional corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        List<CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional> lItens =
                            (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).lItens.FindAll(p => p.Quantidade - p.Qtd_nfcond > decimal.Zero);
                        lItens.ForEach(p => p.Qtd_faturar = p.Quantidade - p.Qtd_nfcond);
                        try
                        {
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                Proc_Commoditties.TProcessarNFCondicional.ProcessarCondicional((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Cd_clifor, lItens);
                            CamadaNegocio.Faturamento.PDV.TCN_Condicional.ProcessarNFCondicional(rNf, null);
                            using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                            {
                                fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                rNf.Nr_lanctofiscalstr,
                                                                                                                null);
                                fGerNfe.ShowDialog();
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    {
                        using (TFItensCondicional fItens = new TFItensCondicional())
                        {
                            fItens.St_nfdev = false;
                            if (fItens.ShowDialog() == DialogResult.OK)
                                if (fItens.lItens != null)
                                    try
                                    {
                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                            Proc_Commoditties.TProcessarNFCondicional.ProcessarCondicional(fItens.Cd_clifor, fItens.lItens);
                                        CamadaNegocio.Faturamento.PDV.TCN_Condicional.ProcessarNFCondicional(rNf, null);
                                        using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                        {
                                            fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                            rNf.Nr_lanctofiscalstr,
                                                                                                                            null);
                                            fGerNfe.ShowDialog();
                                        }
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                else
                {
                    using (TFItensCondicional fItens = new TFItensCondicional())
                    {
                        fItens.St_nfdev = false;
                        if (fItens.ShowDialog() == DialogResult.OK)
                            if (fItens.lItens != null)
                                try
                                {
                                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                        Proc_Commoditties.TProcessarNFCondicional.ProcessarCondicional(fItens.Cd_clifor, fItens.lItens);
                                    CamadaNegocio.Faturamento.PDV.TCN_Condicional.ProcessarNFCondicional(rNf, null);
                                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                    {
                                        fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                        rNf.Nr_lanctofiscalstr,
                                                                                                                        null);
                                        fGerNfe.ShowDialog();
                                    }
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            else
            {
                using (TFItensCondicional fItens = new TFItensCondicional())
                {
                    fItens.St_nfdev = false;
                    if (fItens.ShowDialog() == DialogResult.OK)
                        if (fItens.lItens != null)
                            try
                            {
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                    Proc_Commoditties.TProcessarNFCondicional.ProcessarCondicional(fItens.Cd_clifor, fItens.lItens);
                                CamadaNegocio.Faturamento.PDV.TCN_Condicional.ProcessarNFCondicional(rNf, null);
                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                {
                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                    rNf.Nr_lanctofiscalstr,
                                                                                                                    null);
                                    fGerNfe.ShowDialog();
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void nFDevoluçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsCondicional.Current != null)
                if ((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).lItens.Exists(p => p.Qtd_devolvida - p.Qtd_nfdev > decimal.Zero))
                    if (MessageBox.Show("Deseja gerar NF Devolução do condicional corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        List<CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional> lItens =
                            (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).lItens.FindAll(p => p.Qtd_devolvida - p.Qtd_nfdev > decimal.Zero);
                        lItens.ForEach(p => p.Qtd_devolver = p.Qtd_devolvida - p.Qtd_nfdev);
                        try
                        {
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                Proc_Commoditties.TProcessarNFCondicional.ProcessarNfDevolucao((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Cd_clifor, lItens);
                            CamadaNegocio.Faturamento.PDV.TCN_Condicional.ProcessarNFDevCond(rNf, null);

                            using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                            {
                                fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                rNf.Nr_lanctofiscalstr,
                                                                                                                null);
                                fGerNfe.ShowDialog();
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    {
                        using (TFItensCondicional fItens = new TFItensCondicional())
                        {
                            fItens.St_nfdev = true;
                            if (fItens.ShowDialog() == DialogResult.OK)
                                if (fItens.lItens != null)
                                    try
                                    {
                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                            Proc_Commoditties.TProcessarNFCondicional.ProcessarNfDevolucao(fItens.Cd_clifor, fItens.lItens);
                                        CamadaNegocio.Faturamento.PDV.TCN_Condicional.ProcessarNFCondicional(rNf, null);
                                        using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                        {
                                            fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                            rNf.Nr_lanctofiscalstr,
                                                                                                                            null);
                                            fGerNfe.ShowDialog();
                                        }
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                else
                {
                    using (TFItensCondicional fItens = new TFItensCondicional())
                    {
                        fItens.St_nfdev = true;
                        if (fItens.ShowDialog() == DialogResult.OK)
                            if (fItens.lItens != null)
                                try
                                {
                                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                        Proc_Commoditties.TProcessarNFCondicional.ProcessarNfDevolucao(fItens.Cd_clifor, fItens.lItens);
                                    CamadaNegocio.Faturamento.PDV.TCN_Condicional.ProcessarNFCondicional(rNf, null);
                                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                    {
                                        fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                        rNf.Nr_lanctofiscalstr,
                                                                                                                        null);
                                        fGerNfe.ShowDialog();
                                    }
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            else
            {
                using (TFItensCondicional fItens = new TFItensCondicional())
                {
                    fItens.St_nfdev = true;
                    if (fItens.ShowDialog() == DialogResult.OK)
                        if (fItens.lItens != null)
                            try
                            {
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                    Proc_Commoditties.TProcessarNFCondicional.ProcessarNfDevolucao(fItens.Cd_clifor, fItens.lItens);
                                CamadaNegocio.Faturamento.PDV.TCN_Condicional.ProcessarNFDevCond(rNf, null);
                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                {
                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                    rNf.Nr_lanctofiscalstr,
                                                                                                                    null);
                                    fGerNfe.ShowDialog();
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void devolverParcialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevolverParcialCondicional();
        }

        private void devolverTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevolverTotalCondicional();
        }

        private void bb_excluiritem_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }
    }
}
