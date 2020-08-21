using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;

namespace Fiscal.Cadastros
{
    public partial class TFCadMov_X_CFOP : FormCadPadrao.FFormCadPadrao
    {
        private bool st_vendaconsumidor = false;

        public TFCadMov_X_CFOP()
        {
            InitializeComponent();
        }

        public override void habilitarControls(bool value)
        {
            this.pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override int buscarRegistros()
        {
            TList_Mov_X_CFOP lista = TCN_Mov_X_CFOP.Buscar(cd_movimentacao.Text,
                                                           (bsCondFiscalProd.Current != null ? 
                                                           (bsCondFiscalProd.List as TList_CadCondFiscalProduto).Exists(p=> p.St_agregar) ?
                                                           (bsCondFiscalProd.List as TList_CadCondFiscalProduto).Find(p=> p.St_agregar).CD_CONDFISCAL_PRODUTO : string.Empty : string.Empty),
                                                           CD_CFOP_DentroEstado.Text,
                                                           CD_CFOP_ForaEstado.Text,
                                                           string.Empty,
                                                           null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsMovCFOP.DataSource = lista;
                    this.PosicaoCursorGrids();
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsMovCFOP.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (bsCondFiscalProd.Count.Equals(0))
                    return string.Empty;
                if (!(bsCondFiscalProd.List as TList_CadCondFiscalProduto).Exists(p => p.St_agregar))
                    return string.Empty;
                return TCN_Mov_X_CFOP.Gravar(bsMovCFOP.Current as TRegistro_Mov_X_CFOP, (bsCondFiscalProd.List as TList_CadCondFiscalProduto).FindAll(p=> p.St_agregar), null);
            }
            else
                return string.Empty;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_Mov_X_CFOP.Excluir(bsMovCFOP.Current as TRegistro_Mov_X_CFOP, null);
                    bsMovCFOP.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
                bsMovCFOP.AddNew();
            base.afterNovo();
            if (bsCondFiscalProd.Count > 0)
            {
                (bsCondFiscalProd.List as TList_CadCondFiscalProduto).ForEach(p => p.St_agregar = false);
                bsCondFiscalProd.ResetBindings(true);
            }   
            cd_movimentacao.Focus();
            st_vendaconsumidor = false;
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_movimentacao.Enabled = false;
            if (this.vTP_Modo == TTpModo.tm_Edit)
                CD_CFOP_DentroEstado.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                cd_movimentacao.Focus();
        }

        private void PosicaoCursorGrids()
        {
            if (bsMovCFOP.Current != null)
            {
                //Posicionar cursor condicao fiscal produto
                if (bsCondFiscalProd.Count > 0)
                {
                    (bsCondFiscalProd.List as TList_CadCondFiscalProduto).ForEach(p => p.St_agregar = false);
                    if ((bsCondFiscalProd.List as TList_CadCondFiscalProduto).Exists(p => p.CD_CONDFISCAL_PRODUTO.Trim().Equals((bsMovCFOP.Current as TRegistro_Mov_X_CFOP).Cd_condfiscal_produto)))
                    {
                        (bsCondFiscalProd.List as TList_CadCondFiscalProduto).Find(p => p.CD_CONDFISCAL_PRODUTO.Trim().Equals((bsMovCFOP.Current as TRegistro_Mov_X_CFOP).Cd_condfiscal_produto)).St_agregar = true;
                        bsCondFiscalProd.ResetBindings(true);
                    }
                }
            }
        }

        private void TFCadMov_X_CFOP_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gMovCFOP);
            Utils.ShapeGrid.RestoreShape(this, gCondFiscalProd);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Preencher grid cond produto
            bsCondFiscalProd.DataSource = TCN_CadCondFiscalProduto.Busca(string.Empty, string.Empty);
        }

        private void bb_movimentacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_movimentacao|Movimentação Comercial|200;" +
                              "a.cd_movimentacao|Cd. Movimentação|80;" +
                              "a.tp_movimento|Movimento|80";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movimentacao, ds_movimentacao, tp_movimento },
                                                        new CamadaDados.Fiscal.TCD_CadMovimentacao(), string.Empty);
            if (linha != null)
                st_vendaconsumidor = linha["st_vendaconsumidor"].ToString().Trim().ToUpper().Equals("S");
            else st_vendaconsumidor = false;
        }

        private void cd_movimentacao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_movimentacao|=|" + cd_movimentacao.Text;
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_movimentacao, ds_movimentacao, tp_movimento },
                                                    new CamadaDados.Fiscal.TCD_CadMovimentacao());
            if (linha != null)
                st_vendaconsumidor = linha["st_vendaconsumidor"].ToString().Trim().ToUpper().Equals("S");
            else st_vendaconsumidor = false;
        }

        private void bb_cfopDentro_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_CFOP|Descrição CFOP|350;" +
                              "CD_CFOP|Cód. CFOP|100";
            string vParam = !string.IsNullOrEmpty(tp_movimento.Text) ?
                            tp_movimento.Text.Trim().ToUpper().Equals("E") ?
                            "SUBSTRING(a.CD_CFOP, 1, 1)|=|'1'" :
                            "SUBSTRING(a.CD_CFOP, 1, 1)|=|'5'" : string.Empty;
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CFOP_DentroEstado, ds_cfop_dentroestado },
                                    new CamadaDados.Fiscal.TCD_CadCFOP(), vParam);
        }

        private void CD_CFOP_DentroEstado_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CFOP|=|'" + CD_CFOP_DentroEstado.Text.Trim() + "'";
            vColunas += !string.IsNullOrEmpty(tp_movimento.Text) ?
                        tp_movimento.Text.Trim().ToUpper().Equals("E") ?
                        ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'1'" :
                        ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'5'" : string.Empty;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CFOP_DentroEstado, ds_cfop_dentroestado },
                                    new CamadaDados.Fiscal.TCD_CadCFOP());
        }

        private void bb_cfopFora_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_CFOP|Descrição CFOP|350;" +
                              "CD_CFOP|Cód. CFOP|100";
            string vParam = !string.IsNullOrEmpty(tp_movimento.Text) ?
                            tp_movimento.Text.Trim().ToUpper().Equals("E") ?
                            "SUBSTRING(a.CD_CFOP, 1, 1)|=|'2'" :
                            "SUBSTRING(a.CD_CFOP, 1, 1)|=|'" + (st_vendaconsumidor ? "5" : "6") + "'" : string.Empty;
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CFOP_ForaEstado, ds_cfop_foraestado },
                                    new CamadaDados.Fiscal.TCD_CadCFOP(), vParam);
        }

        private void CD_CFOP_ForaEstado_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CFOP|=|'" + CD_CFOP_ForaEstado.Text + "'";
            vColunas += !string.IsNullOrEmpty(tp_movimento.Text) ?
                        tp_movimento.Text.Trim().ToUpper().Equals("E") ?
                        ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'2'" :
                        ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'" + (st_vendaconsumidor ? "5" : "6") + "'" : string.Empty;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CFOP_ForaEstado, ds_cfop_foraestado },
                                    new CamadaDados.Fiscal.TCD_CadCFOP());
        }

        private void gCondFiscalProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((bsCondFiscalProd.Current != null) && vTP_Modo.Equals(TTpModo.tm_Insert))
                if (e.ColumnIndex == 0)
                {
                    (bsCondFiscalProd.Current as TRegistro_CadCondFiscalProduto).St_agregar =
                        !(bsCondFiscalProd.Current as TRegistro_CadCondFiscalProduto).St_agregar;
                    bsCondFiscalProd.ResetCurrentItem();
                }
        }

        private void bsMovCFOP_PositionChanged(object sender, EventArgs e)
        {
            this.PosicaoCursorGrids();
        }

        private void st_marcamov_Click(object sender, EventArgs e)
        {
            if ((bsCondFiscalProd.Count > 0) && vTP_Modo.Equals(TTpModo.tm_Insert))
            {
                (bsCondFiscalProd.List as TList_CadCondFiscalProduto).ForEach(p => p.St_agregar = st_marcamov.Checked);
                bsCondFiscalProd.ResetBindings(true);
            }
        }

        private void TFCadMov_X_CFOP_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gMovCFOP);
            Utils.ShapeGrid.SaveShape(this, gCondFiscalProd);
        }

        private void bb_cfop_internacional_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_CFOP|Descrição CFOP|350;" +
                              "CD_CFOP|Cód. CFOP|100";
            string vParam = !string.IsNullOrEmpty(tp_movimento.Text) ?
                            tp_movimento.Text.Trim().ToUpper().Equals("E") ?
                            "SUBSTRING(a.CD_CFOP, 1, 1)|=|'3'" :
                            "SUBSTRING(a.CD_CFOP, 1, 1)|=|'7'" : string.Empty;
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cfop_internacional, ds_cfop_internacional },
                                    new CamadaDados.Fiscal.TCD_CadCFOP(), vParam);
        }

        private void cd_cfop_internacional_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CFOP|=|'" + cd_cfop_internacional.Text + "'";
            vColunas += !string.IsNullOrEmpty(tp_movimento.Text) ?
                        tp_movimento.Text.Trim().ToUpper().Equals("E") ?
                        ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'3'" :
                        ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'7'" : string.Empty;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_cfop_internacional, ds_cfop_internacional },
                                    new CamadaDados.Fiscal.TCD_CadCFOP());
        }
    }
}
