using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Fazenda.Lancamento;
using CamadaNegocio.Fazenda.Lancamento;
using Utils;
using CamadaDados.Fazenda.Cadastros;
using CamadaDados.Graos;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Diversos;

namespace Fazenda
{
    public partial class TFLanAtividade : FormCadPadrao.FFormCadPadrao
    {
        public TFLanAtividade()
        {
            InitializeComponent();
            panelDados.set_FormatZero();
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            panelDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_LanAtividade.GravaLanAtividade(BS_LanAtividade.Current as TRegistro_LanAtividade);
            
            else
                return "";
        }

        public override int buscarRegistros()
        {

            TList_LanAtividade lista = TCN_LanAtividade.Busca(ID_LanctoAtiv.Text.Trim() != "" ? Convert.ToDecimal(ID_LanctoAtiv.Text) : 0,
                                                               CD_Fazenda.Text.Trim() != "" ? Convert.ToDecimal(CD_Fazenda.Text) : 0,
                                                               CD_Talhao.Text.Trim() != "" ? Convert.ToDecimal(CD_Talhao.Text) : 0,
                                                               AnoSafra.Text.Trim(),
                                                               NM_Responsavel.Text.Trim());

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_LanAtividade.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_LanAtividade.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public void buscarItensAtividade()
        {
            VLUnitarioTotal.Value = 0;
            Total.Value = 0;
            QTDETotal.Value = 0;

            if (BS_LanAtividade.Current != null)
            {
                TList_LanAtividade_Item lista = TCN_LanAtividade_Item.Busca(Convert.ToDecimal((BS_LanAtividade.Current as TRegistro_LanAtividade).ID_LanctoAtiv), "", 0, 0, 0, 0);

                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        BS_LanItemAtividade.DataSource = lista;

                        VLUnitarioTotal.Value = Convert.ToDecimal(lista.Sum(p => p.VL_Unitario));
                        Total.Value = Convert.ToDecimal(lista.Sum(p => p.VL_Total));
                        QTDETotal.Value = Convert.ToDecimal(lista.Sum(p => p.Quantidade));
                    }
                    else
                    {
                        BS_LanItemAtividade.Clear();
                    }
                }
            }
            else
            {
                BS_LanItemAtividade.Clear();
            }
        }

        public void buscarInsumo()
        {
            VLUnitarioTotal.Value = 0;
            Total.Value = 0;
            QTDETotal.Value = 0;

            if (BS_LanAtividade.Current != null)
            {
                TList_LanInsumos lista = TCN_LanInsumos.Busca(0, Convert.ToDecimal((BS_LanAtividade.Current as TRegistro_LanAtividade).ID_LanctoAtiv), 0, "");

                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        BS_Insumos.DataSource = lista;

                        VLUnitarioTotal.Value = Convert.ToDecimal(lista.Sum(p => p.VL_Unitario));
                        Total.Value = Convert.ToDecimal(lista.Sum(p => p.VL_Total));
                        QTDETotal.Value = Convert.ToDecimal(lista.Sum(p => p.Quantidade));
                    }
                    else
                    {
                        BS_Insumos.Clear();
                    }
                }
            }
            else
            {
                BS_Insumos.Clear();
            }
        }

        public override void afterBusca()
        {
            this.vTP_Modo = TTpModo.tm_busca;
            this.habilitarControls(false);
            vTP_Busca = null;
            this.buscarRegistros();
            this.modoBotoes(this.vTP_Modo, true, true, false, true, false, true, true);
            BB_Alterar.Visible = false;
            BB_Imprimir.Visible = false;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_LanAtividade.AddNew();
                BS_LanItemAtividade.Clear();
                base.afterNovo();
                NM_Responsavel.Text = Utils.Parametros.pubLogin;
            }
            habilitaTalhao();
            BB_Alterar.Visible = false;
            BB_Imprimir.Visible = false;
            if (ID_LanctoAtiv.Enabled)
                ID_LanctoAtiv.Focus();
            else
                CD_Empresa.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            this.modoBotoes(this.vTP_Modo, true, true, true, true, true, true, true);
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_LanAtividade.RemoveCurrent();
            habilitaTalhao();
            BB_Alterar.Visible = false;
            BB_Imprimir.Visible = false;
        } 

        public override void afterAltera()
        {
            base.afterAltera();
            this.modoBotoes(this.vTP_Modo, false, true, true, false, true, false, true);
            habilitaTalhao();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                buscarInsumo(); 
                buscarItensAtividade();
                if (BS_LanItemAtividade.Count > 0 && BS_Insumos.Count > 0)
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            TCN_LanAtividade.DeletaLanAtividade(BS_LanAtividade.Current as TRegistro_LanAtividade);
                            BS_LanAtividade.RemoveCurrent();
                            pDados.LimparRegistro();
                            afterBusca();
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show("ERRO: " + erro.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Atenção, é necessário deletar todos os itens da atividade e insumos para exclui-lá!");
                }
            }
        }

        public override void afterExclui()
        {
            this.vTP_Modo = TTpModo.tm_busca;
            this.excluirRegistro();
            this.limparControls();
            this.buscarRegistros();
            this.modoBotoes(this.vTP_Modo, true, true, false, true, true, true, true);
            BB_Alterar.Visible = false;
            BB_Imprimir.Visible = false;
        }

        public override void afterGrava()
        {
            if (this.gravarRegistro() != "")
            {
                this.vTP_Modo = TTpModo.tm_busca;
                this.habilitarControls(false);
                this.buscarRegistros();
                this.modoBotoes(this.vTP_Modo, true, true, false, true, false, true, true);
            }
            else
            {
                this.vTP_Modo = TTpModo.tm_Insert;
                this.modoBotoes(this.vTP_Modo, true, false, true, false, true, true, false);
            }

            BB_Alterar.Visible = false;
            BB_Imprimir.Visible = false;
        }

        private void BB_Fazenda_Click(object sender, EventArgs e)
        {
            if (CD_Empresa.Text != "")
            {
                string vColunas = "a.nm_fazenda|Nome Fazenda|350;" +
                                  "a.CD_Fazenda|Codigo Fazenda|100;" +
                                  "e.ds_ccusto|Centro de Custo|350;" +
                                  "e.cd_ccusto|Cód. Centro de Custo|100;" +
                                  "a.cd_empresa|Cód. Empresa|100";

                string vParam = "a.cd_empresa|=|'" + CD_Empresa.Text + "'";
                UtilPesquisa.BTN_BUSCA(vColunas,
                                       new Componentes.EditDefault[] { CD_Fazenda, NM_Fazenda },
                                       new TCD_CadFazenda(), vParam);

                if (CD_Fazenda.Text != "")
                {
                    habilitaTalhao();
                    CD_Fazenda_Leave(this, e);
                }
            }
        }

        private void BB_Talhao_Click(object sender, EventArgs e)
        {
            if (CD_Fazenda.Text != "")
            {
                string vColunas = "a.NM_Talhao|Nome Talhao|250;a.CD_Talhao|Cód. Talhão|100";
                string vParam = "a.cd_fazenda|=|'" + CD_Fazenda.Text.Trim() + "'|=|(select 1 from tb_faz_cadfazenda f where f.cd_fazenda = a.cd_fazenda)";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Talhao, NM_Talhao }, new TCD_CadTalhoes(), vParam);
            }
        }

        private void BB_AnoSafra_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Safra|Descrição Safra|250;a.AnoSafra|Ano Safra|100"
                , new Componentes.EditDefault[] { AnoSafra, DS_Safra }, new TCD_CadSafra(), null);
        }

        private void CD_Fazenda_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LEAVE("a.cd_fazenda|=|'" + CD_Fazenda.Text + "';"+
                                                    "a.cd_empresa|=|'" + CD_Empresa.Text + "'",
                                                    new Componentes.EditDefault[] { CD_Fazenda, NM_Fazenda }, 
                                                    new TCD_CadFazenda());

            if (linha != null)
            {
                (BS_LanAtividade.Current as TRegistro_LanAtividade).CD_CCusto = linha["CD_CCusto"].ToString().Trim();

                BS_LanAtividade.ResetBindings(true);
                habilitaTalhao();
            }
        }

        private void CD_Talhao_Leave(object sender, EventArgs e)
        {
            if (CD_Fazenda.Text != "")
            {
                UtilPesquisa.EDIT_LEAVE("a.CD_Talhao|=|'" + CD_Talhao.Text + "';a.cd_fazenda|=|'" + CD_Fazenda.Text.Trim() + "'"
                 , new Componentes.EditDefault[] { CD_Talhao, NM_Talhao }, new TCD_CadTalhoes());
            }
        }

        private void AnoSafra_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.AnoSafra|=|'" + AnoSafra.Text + "'"
            , new Componentes.EditDefault[] { AnoSafra, DS_Safra }, new TCD_CadSafra());
        }

        public void habilitaTalhao()
        {
            if (CD_Fazenda.Text.Trim() == "")
                CD_Talhao.Enabled = false;
            else
                CD_Talhao.Enabled = true;
        }

        private void TFLanAtividade_Load(object sender, EventArgs e)
        {
            DTS = BS_LanAtividade;
        }

        private void BS_LanAtividade_CurrentChanged(object sender, EventArgs e)
        {
            buscarItensAtividade();
        }

        private void TFLanAtividade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F9)
                if (tabControlInsumo.SelectedTab == tabAtividade)
                    tsBB_Add_Click(this, null);
                else
                    tsBB_AddInsumo_Click(this, null);
            else if (e.KeyData == Keys.F10)
                if (tabControlInsumo.SelectedTab == tabAtividade)
                    tsBB_Remover_Click(this, null);
                else
                    tsBB_RemoverInsumo_Click(this, null);
        }

        private void tsBB_AddInsumo_Click(object sender, EventArgs e)
        {
            if (BS_LanAtividade.Current != null)
            {
                if (Convert.ToDecimal((BS_LanAtividade.Current as TRegistro_LanAtividade).ID_LanctoAtiv) > 0)
                {
                    try
                    {
                        TRegistro_LanInsumos LanInsumo = new TRegistro_LanInsumos();
                        TFLanInsumos frameInsumo = new TFLanInsumos();
                        frameInsumo.ShowDialog();
                        LanInsumo = frameInsumo.reg_Insumo;

                        if (LanInsumo != null)
                        {
                            LanInsumo.ID_LanctoAtiv = Convert.ToDecimal((BS_LanAtividade.Current as TRegistro_LanAtividade).ID_LanctoAtiv);
                            LanInsumo.CD_Empresa = (BS_LanAtividade.Current as TRegistro_LanAtividade).CD_Empresa;
                            //GRAVA A ATIVIDADE ITEM
                            string retorno = TCN_LanInsumos.GravaLanInsumos(LanInsumo, null);

                            //BUSCA OS ITENS
                            buscarInsumo();

                            MessageBox.Show("Insumo lançado com sucesso!");
                        }

                        frameInsumo = null;
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("ERRO: " + erro.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Atenção, é necessário gravar a atividade antes de adicionar um insumo!");
                }
            }
            else
            {
                MessageBox.Show("Atenção, é necessário selecionar uma insumo!");
            }
        }

        private void tsBB_RemoverInsumo_Click(object sender, EventArgs e)
        {
            if (BS_Insumos.Current != null)
            {
                try
                {
                    //DELETA O ATIVIDADE ITEM
                    TCN_LanInsumos.DeletaLanInsumos((BS_Insumos.Current as TRegistro_LanInsumos), null);

                    BS_Insumos.RemoveCurrent();
                    buscarInsumo();

                    MessageBox.Show("Insumo removido com sucesso!");
                }
                catch (Exception erro)
                {
                    MessageBox.Show("ERRO: " + erro.Message);
                }
            }
            else
            {
                MessageBox.Show("Atenção, é necessário selecionar um insumo!");
            }
        }

        private void tabAtividade_Enter(object sender, EventArgs e)
        {
            tsBB_Add.Visible = true;
            tsBB_Remover.Visible = true;
            tsBB_AddInsumo.Visible = false;
            tsBB_RemoverInsumo.Visible = false;
            buscarItensAtividade();
        }

        private void tabInsumos_Enter(object sender, EventArgs e)
        {
            tsBB_Add.Visible = false;
            tsBB_Remover.Visible = false;
            tsBB_AddInsumo.Visible = true;
            tsBB_RemoverInsumo.Visible = true;
            buscarInsumo();
        }

        private void tsBB_Add_Click(object sender, EventArgs e)
        {
            if (BS_LanAtividade.Current != null)
            {
                if (Convert.ToDecimal((BS_LanAtividade.Current as TRegistro_LanAtividade).ID_LanctoAtiv) > 0)
                {
                    try
                    {
                        TRegistro_LanAtividade_Item LanAtividade_Item = new TRegistro_LanAtividade_Item();
                        TFLanAtividadeItem frameAtividadeItem = new TFLanAtividadeItem();
                        frameAtividadeItem.reg_Atividade = (BS_LanAtividade.Current as TRegistro_LanAtividade);
                        frameAtividadeItem.ShowDialog();
                        LanAtividade_Item = frameAtividadeItem.reg_Atividade_Item;

                        if (LanAtividade_Item != null)
                        {
                            LanAtividade_Item.ID_LanctoAtiv = Convert.ToDecimal((BS_LanAtividade.Current as TRegistro_LanAtividade).ID_LanctoAtiv);
                            //GRAVA A ATIVIDADE ITEM
                            string retorno = TCN_LanAtividade_Item.GravaLanAtividade(LanAtividade_Item, null);

                            //BUSCA OS ITENS
                            buscarItensAtividade();

                            MessageBox.Show("Item da Atividade lançado com sucesso!");
                        }

                        frameAtividadeItem = null;
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("ERRO: " + erro.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Atenção, é necessário gravar a atividade antes de adicionar item!");
                }
            }
            else
            {
                MessageBox.Show("Atenção, é necessário selecionar uma atividade!");
            }
        }

        private void tsBB_Remover_Click(object sender, EventArgs e)
        {
            if (BS_LanItemAtividade.Current != null)
            {
                try
                {
                    //DELETA O ATIVIDADE ITEM
                    TCN_LanAtividade_Item.DeletaLanAtividade((BS_LanItemAtividade.Current as TRegistro_LanAtividade_Item), null);

                    BS_LanItemAtividade.RemoveCurrent();
                    buscarItensAtividade();

                    MessageBox.Show("Item de atividade removido com sucesso!");
                }
                catch (Exception erro)
                {
                    MessageBox.Show("ERRO: " + erro.Message);
                }
            }
            else
            {
                MessageBox.Show("Atenção, é necessário selecionar uma item da atividade!");
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_empresa|Nome Empresa|150;a.cd_empresa|Código Empresa|80",
                                   new Componentes.EditDefault[] { CD_Empresa, DS_Empresa }, new TCD_CadEmpresa(), null);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text + "'",
                                    new Componentes.EditDefault[] { CD_Empresa, DS_Empresa }, new TCD_CadEmpresa());
        }

    }
}
