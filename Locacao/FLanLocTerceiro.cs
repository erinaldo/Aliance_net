using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Locacao;
using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Locacao
{
    public partial class TFLanLocTerceiro : Form
    {
        public TFLanLocTerceiro()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbxAberto.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbxEncerrado.Checked)
            {
                status += virg + "'E'";
                virg = ",";
            }
            if (cbxCancelado.Checked)
                status += virg + "'C'";
            bsLocTerceiro.DataSource =
                CamadaNegocio.Locacao.TCN_LocTerceiro.buscar(cbEmpresa.SelectedValue.ToString(),
                                                             id_locacao.Text,
                                                             string.Empty,
                                                             Cd_clifor.Text,
                                                             string.Empty,
                                                             status,
                                                             string.Empty,
                                                             DT_Inicial.Text,
                                                             DT_Final.Text,
                                                             null);
            bsLocTerceiro.ResetCurrentItem();
            bsLocTerceiro_PositionChanged(this, new EventArgs());
        }

        private void afterNovo()
        {
            using (TFLocTerceiro fLoc = new TFLocTerceiro())
            {
                if (fLoc.ShowDialog() == DialogResult.OK)
                    if (fLoc.rLoc != null)
                        try
                        {
                            CamadaNegocio.Locacao.TCN_LocTerceiro.Gravar(fLoc.rLoc, null);
                            MessageBox.Show("Locação gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsLocTerceiro.Current != null)
            {
                if ((bsLocTerceiro.Current as TRegistro_LocTerceiro).St_registro.ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido alterar locação encerrada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocTerceiro.Current as TRegistro_LocTerceiro).St_registro.ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido alterar locação cancelada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFLocTerceiro fLoc = new TFLocTerceiro())
                {
                    fLoc.rLoc = bsLocTerceiro.Current as TRegistro_LocTerceiro;
                    if (fLoc.ShowDialog() == DialogResult.OK)
                        if (fLoc.rLoc != null)
                            try
                            {
                                CamadaNegocio.Locacao.TCN_LocTerceiro.Gravar(fLoc.rLoc, null);
                                MessageBox.Show("Locação alterada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void afterExclui()
        {
            if (bsLocTerceiro.Current != null)
            {
                if ((bsLocTerceiro.Current as TRegistro_LocTerceiro).St_registro.ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido cancelar locação encerrada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocTerceiro.Current as TRegistro_LocTerceiro).St_registro.ToUpper().Equals("C"))
                {
                    MessageBox.Show("Locação já se encontra cancelada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma o cancelamento da locação selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Locacao.TCN_LocTerceiro.Excluir(bsLocTerceiro.Current as TRegistro_LocTerceiro, null);
                        MessageBox.Show("Locação cancelada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void Encerrar()
        {
            if (bsLocTerceiro.Current != null)
            {
                if ((bsLocTerceiro.Current as TRegistro_LocTerceiro).St_registro.ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido cancelar locação cancelada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocTerceiro.Current as TRegistro_LocTerceiro).St_registro.ToUpper().Equals("E"))
                {
                    MessageBox.Show("Locação já se encontra encerrada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma o encerramento da locação selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        (bsLocTerceiro.Current as TRegistro_LocTerceiro).St_registro = "E";
                        CamadaNegocio.Locacao.TCN_LocTerceiro.Gravar(bsLocTerceiro.Current as TRegistro_LocTerceiro, null);
                        MessageBox.Show("Locação encerrada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void GerarDup()
        {
            if (bsLocTerceiro.Current != null)
            {
                if ((bsLocTerceiro.Current as TRegistro_LocTerceiro).St_permutabool)
                {
                    MessageBox.Show("Não é possível gerar financeiro de contrato que possui permuta!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!(bsLocTerceiro.Current as TRegistro_LocTerceiro).St_registro.Trim().ToUpper().Equals("C"))
                {
                    using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                    {
                        fDuplicata.vCd_empresa = (bsLocTerceiro.Current as TRegistro_LocTerceiro).Cd_empresa;
                        fDuplicata.vNm_empresa = (bsLocTerceiro.Current as TRegistro_LocTerceiro).Nm_empresa;
                        fDuplicata.vCd_clifor = (bsLocTerceiro.Current as TRegistro_LocTerceiro).Cd_fornecedor;
                        fDuplicata.vNm_clifor = (bsLocTerceiro.Current as TRegistro_LocTerceiro).Nm_fornecedor;
                        fDuplicata.vCd_endereco = (bsLocTerceiro.Current as TRegistro_LocTerceiro).Cd_endereco;
                        fDuplicata.vDs_endereco = (bsLocTerceiro.Current as TRegistro_LocTerceiro).Ds_endereco;
                        //Buscar Moeda Padrao
                        TList_Moeda tabela =
                            CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao((bsLocTerceiro.Current as TRegistro_LocTerceiro).Cd_empresa, null);
                        if (tabela != null)
                            if (tabela.Count > 0)
                            {
                                fDuplicata.vCd_moeda = tabela[0].Cd_moeda;
                                fDuplicata.vDs_moeda = tabela[0].Cd_moeda;
                            }
                        fDuplicata.vTp_mov = "P";
                        fDuplicata.vVl_documento = (bsLocTerceiro.Current as TRegistro_LocTerceiro).Vl_contrato;
                        fDuplicata.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                        fDuplicata.vSt_finPed = true;
                        if (fDuplicata.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                (bsLocTerceiro.Current as TRegistro_LocTerceiro).lDup.Add(
                                                        fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata);
                                CamadaNegocio.Locacao.TCN_LocTerceiro.GravaDuplicata(bsLocTerceiro.Current as TRegistro_LocTerceiro, null);
                                afterBusca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatorio informar Financeiro para Gerar Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não é possivel Gerar Duplicata em Pedido Cancelado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void TFLanLocTerceiro_Load(object sender, EventArgs e)
        {
            pConsulta.set_FormatZero();
            tlpItens.ColumnStyles[1].Width = 0;
            Icon = ResourcesUtils.TecnoAliance_ICO;
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanLocTerceiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                Encerrar();
            else if (e.KeyCode.Equals(Keys.F10))
                GerarDup();
        }

        private void Cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE(string.Empty, new Componentes.EditDefault[] { Cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_clifor }, string.Empty);
        }

        private void bsLocTerceiro_PositionChanged(object sender, EventArgs e)
        {
            if (bsLocTerceiro.Current != null)
            {
                (bsLocTerceiro.Current as TRegistro_LocTerceiro).lItens =
                    CamadaNegocio.Locacao.TCN_ItensLocTerceiro.buscar((bsLocTerceiro.Current as TRegistro_LocTerceiro).Cd_empresa,
                                                                      (bsLocTerceiro.Current as TRegistro_LocTerceiro).Id_locstr,
                                                                      string.Empty,
                                                                      null);
                bsLocTerceiro.ResetCurrentItem();
                bsItens_PositionChanged(this, new EventArgs());
                tcDetalhes_SelectedIndexChanged(this, new EventArgs());
            }
        }

        private void gLocTerceiro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gLocTerceiro.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("ENCERRADO"))
                        gLocTerceiro.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gLocTerceiro.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bb_encerrar_Click(object sender, EventArgs e)
        {
            Encerrar();
        }

        private void gItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bb_gerarDup_Click(object sender, EventArgs e)
        {
            GerarDup();
        }

        private void tcDetalhes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bsLocTerceiro.Current != null)
            {
                if (tcDetalhes.SelectedTab.Equals(tpDup))
                {
                    (bsLocTerceiro.Current as TRegistro_LocTerceiro).lDup =
                        new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from TB_LOC_FatLocTerceiro x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.Nr_lancto = a.Nr_lancto " +
                                                "and x.cd_empresa = '" + (bsLocTerceiro.Current as TRegistro_LocTerceiro).Cd_empresa.Trim() + "'" +
                                                "and x.id_loc = " + (bsLocTerceiro.Current as TRegistro_LocTerceiro).Id_locstr + ") "
                                }
                            }, 0, string.Empty);
                    bsLocTerceiro.ResetCurrentItem();
                }
            }
        }
        
        private void bbNovo_Click(object sender, EventArgs e)
        {
            if(bsItens.Current != null)
                if((bsItens.Current as TRegistro_ItensLocTerceiro).St_controlehora)
                {
                    using (TFEnderecoProd fEnd = new TFEnderecoProd())
                    {
                        if (fEnd.ShowDialog() == DialogResult.OK)
                        {
                            //Verificar se endereço ja existe na lista
                            if ((bsItens.Current as TRegistro_ItensLocTerceiro).ProdutoItens.Exists(p => p.Endereco.Trim().Equals(fEnd.pEndereco.Trim())))
                            {
                                if (MessageBox.Show("Endereço ja esta cadastrado para outro produto\r\nDeseja alterar produto?",
                                    "Pergunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                                {

                                    TRegistro_ProdutoItens r = (bsItens.Current as TRegistro_ItensLocTerceiro).ProdutoItens.Find(p => p.Endereco.Equals(fEnd.pEndereco));
                                    r.Cd_produto = fEnd.pCd_produto;
                                    try
                                    {
                                        CamadaNegocio.Locacao.TCN_ProdutoItens.Gravar(r, null);
                                        MessageBox.Show("Produto alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        bsItens_PositionChanged(this, new EventArgs());
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                            }
                            else
                                try
                                {
                                    CamadaNegocio.Locacao.TCN_ProdutoItens.Gravar(
                                        new TRegistro_ProdutoItens
                                        {
                                            Cd_empresa = (bsItens.Current as TRegistro_ItensLocTerceiro).Cd_empresa,
                                            Id_loc = (bsItens.Current as TRegistro_ItensLocTerceiro).Id_loc,
                                            Id_item = (bsItens.Current as TRegistro_ItensLocTerceiro).Id_item,
                                            Cd_produto = fEnd.pCd_produto,
                                            Endereco = fEnd.pEndereco
                                        }, null);
                                    MessageBox.Show("Produto incluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    bsItens_PositionChanged(this, new EventArgs());
                                }
                                catch(Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                }
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if(bsItens.Current != null)
            {
                if ((bsItens.Current as TRegistro_ItensLocTerceiro).St_controlehora)
                    tlpItens.ColumnStyles[1].Width = 50;
                else tlpItens.ColumnStyles[1].Width = 0;
                (bsItens.Current as TRegistro_ItensLocTerceiro).ProdutoItens =
                    CamadaNegocio.Locacao.TCN_ProdutoItens.Buscar((bsItens.Current as TRegistro_ItensLocTerceiro).Cd_empresa,
                                                                  (bsItens.Current as TRegistro_ItensLocTerceiro).Id_locstr,
                                                                  (bsItens.Current as TRegistro_ItensLocTerceiro).Id_itemstr,
                                                                  null);
                bsItens.ResetCurrentItem();
            }
        }

        private void bbExcluir_Click(object sender, EventArgs e)
        {
            if (bsProdutos.Current != null)
                if(MessageBox.Show("Confirma exclusão produto selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Locacao.TCN_ProdutoItens.Excluir(bsProdutos.Current as TRegistro_ProdutoItens, null);
                        MessageBox.Show("Produto excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsItens_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
