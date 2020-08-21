using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;

namespace Mudanca
{
    public partial class TFLanGuardaVolume : Form
    {
        private bool Altera_Relatorio;

        public TFLanGuardaVolume()
        {
            InitializeComponent();
        }

        private void LimparCampos()
        {
            nr_guardavol.Text = string.Empty;
            id_mudanca.Text = string.Empty;
            cd_empresa.Text = string.Empty;
            Cd_clifor.Text = string.Empty;
            dt_ini.Text = string.Empty;
            dt_fin.Text = string.Empty;
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbAberto.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbFinalizado.Checked)
            {
                status += virg + "'F'";
                virg = ",";
            }
            if (cbCancelado.Checked)
                status += virg + "'C'"; 
            bsGuardaVolume.DataSource =
                CamadaNegocio.Mudanca.TCN_GuardaVolume.Buscar(cd_empresa.Text,
                                                              string.Empty,
                                                              Cd_clifor.Text,
                                                              id_mudanca.Text,
                                                              nr_guardavol.Text,
                                                              rbRegistro.Checked ? "R" : "P",
                                                              dt_ini.Text,
                                                              dt_fin.Text,
                                                              status,
                                                              null);
            bsGuardaVolume.ResetCurrentItem();
            bsGuardaVolume_PositionChanged(this, new EventArgs());
        }

        private void afterNovo()
        {
            using (TFGuardaVolume fGuarda = new TFGuardaVolume())
            {
                if (fGuarda.ShowDialog() == DialogResult.OK)
                    if (fGuarda.rGuardaVol != null)
                        try
                        {
                            CamadaNegocio.Mudanca.TCN_GuardaVolume.Gravar(fGuarda.rGuardaVol, null);
                            MessageBox.Show("Guarda Volume gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsGuardaVolume.DataSource = new CamadaDados.Mudanca.TList_GuardaVolume() { fGuarda.rGuardaVol };
                            bsGuardaVolume.ResetBindings(true);

                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsGuardaVolume.Current != null)
            {
                if ((bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).St_registro.ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é possivel alterar guarda volume CANCELADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).St_registro.ToUpper().Equals("F"))
                {
                    MessageBox.Show("Não é possivel alterar guarda volume FINALIZADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFGuardaVolume fGuarda = new TFGuardaVolume())
                {
                    fGuarda.rGuardaVol = bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume;
                    if (fGuarda.ShowDialog() == DialogResult.OK)
                        if (fGuarda.rGuardaVol != null)
                            try
                            {
                                CamadaNegocio.Mudanca.TCN_GuardaVolume.Gravar(fGuarda.rGuardaVol, null);
                                bsGuardaVolume.ResetCurrentItem();
                                MessageBox.Show("Guarda Volume alterado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void afterExclui()
        {
            if (bsGuardaVolume.Current != null)
            {
                if ((bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).St_registro.ToUpper().Equals("C"))
                {
                    MessageBox.Show("Guarda Volume já está CANCELADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).St_registro.ToUpper().Equals("F"))
                {
                    MessageBox.Show("Não é possivel cancelar guarda volume FINALIZADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Deseja CANCELAR o Guarda Volume?",
                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Mudanca.TCN_GuardaVolume.Excluir(bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume, null);
                        MessageBox.Show("Guarda Volume cancelado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterRetirar()
        {
            if (bsGuardaVolume.Current != null)
                if (!(bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).St_registro.Trim().ToUpper().Equals("C"))
                    if ((bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).lItensGuardaVolume.Count > 0)
                        if ((bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).lItensGuardaVolume.Exists(p => p.SaldoRetirar > 0))
                        {
                            using (TFRetGuardaVol fRetirar = new TFRetGuardaVol())
                            {
                                fRetirar.Cd_empresa = (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).Cd_empresa;
                                fRetirar.Id_guardaVol = (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).Id_guardavolstr;
                                if (fRetirar.ShowDialog() == DialogResult.OK)
                                    if (fRetirar.lItens.Count > decimal.Zero)
                                    {
                                        fRetirar.lItens.ForEach(p =>
                                            {
                                                (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).lRetGuardaVol.Add(
                                                    new CamadaDados.Mudanca.TRegistro_RetGuardaVol()
                                                    {
                                                        Id_itemguardavolstr = p.Id_itemguardavolstr,
                                                        Quantidade = p.Qtd_retirar,
                                                        Login = Utils.Parametros.pubLogin,
                                                        Ds_observacao = p.Ds_observacao
                                                    });
                                            });
                                        CamadaNegocio.Mudanca.TCN_GuardaVolume.RetirarItens(bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume, null);
                                        MessageBox.Show("Itens retirados com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.afterBusca();
                                        bsGuardaVolume.ResetCurrentItem();
                                    }
                            }
                        }
                        else
                            MessageBox.Show("Não existe nenhum item com saldo a retirar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Guarda Volume não possui itens adicionados!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Não é permitido retirar guarda volume CANCELADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Não existem Guarda Volumes na consulta!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterCancelarRetirada()
        {
            if (bsRetirada.Current != null)
            {
                if ((bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).St_registro.ToUpper().Equals("F"))
                {
                    MessageBox.Show("Não é permitido cancelar retirada de guarda volume FINALIZADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsRetirada.Current as CamadaDados.Mudanca.TRegistro_RetGuardaVol).St_registro.ToUpper().Equals("C"))
                {
                    MessageBox.Show("Retirada já está CANCELADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Tem certeza que CANCELAR a retirada corrente?", "Pergunta",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                    try
                    {
                        //Cancelar Retirada
                        CamadaNegocio.Mudanca.TCN_RetGuardaVol.Excluir(bsRetirada.Current as CamadaDados.Mudanca.TRegistro_RetGuardaVol, null);
                        MessageBox.Show("Retirada cancelada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFLanGuardaVolume_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pConsulta.set_FormatZero();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void Cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + Cd_clifor.Text.Trim() + "'",
              new Componentes.EditDefault[] { Cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_clifor }, string.Empty);
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFLanGuardaVolume_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.afterRetirar();
            else if (tcItens.SelectedTab.Equals(tpRetirada) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.afterCancelarRetirada();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                this.Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bsGuardaVolume_PositionChanged(object sender, EventArgs e)
        {
            if (bsGuardaVolume.Current != null)
            {
                //Buscar Itens
                (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).lItensGuardaVolume =
                    new CamadaDados.Mudanca.TCD_ItensGuardaVolume().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_guardavol",
                                vOperador = "=",
                                vVL_Busca = (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).Id_guardavolstr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            }
                        }, 0, string.Empty);

                //Buscar Itens Retirada
                (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).lRetGuardaVol =
                    CamadaNegocio.Mudanca.TCN_RetGuardaVol.Buscar((bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).Cd_empresa,
                                                                  (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).Id_guardavolstr,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  null);
                bsGuardaVolume.ResetCurrentItem();
            }
        }

        private void bb_retirar_Click(object sender, EventArgs e)
        {
            this.afterRetirar();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.afterCancelarRetirada();
        }

        private void gGuardaVolume_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FINALIZADO"))
                        gGuardaVolume.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("ABERTO"))
                        gGuardaVolume.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    else gGuardaVolume.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
        }

        private void gItensGuardaVolume_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ATIVO"))
                        gItensGuardaVolume.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("RETIRADO"))
                        gItensGuardaVolume.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else gItensGuardaVolume.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
        }

        private void gRetirada_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ATIVO"))
                        gRetirada.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    else gRetirada.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
        }

        private void fichaVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsGuardaVolume.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new CamadaDados.Mudanca.TList_GuardaVolume() { bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume };
                    Rel.DTS_Relatorio = bs;

                    //Endereco Empresa
                    BindingSource bsEmp = new BindingSource();
                    bsEmp.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).Cd_empresa,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null);
                    //Verificar se existe logo configurada para a empresa
                    if (bsEmp.Count > 0)
                        if ((bsEmp.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (bsEmp.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    Rel.Adiciona_DataSource("DTS_EMP", bsEmp);
                    
                    Rel.Nome_Relatorio = "FLanGuardaVolFicha";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "MUD";
                    Rel.Ident = "FLanGuardaVolFicha";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).Cd_clifor;
                    fImp.pMensagem = "MUDANÇA";

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "MUDANÇA",
                                           fImp.pDs_mensagem);

                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "MUDANÇA",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void guardaVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (bsGuardaVolume.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new CamadaDados.Mudanca.TList_GuardaVolume() { bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume };
                    Rel.DTS_Relatorio = bs;

                    //Endereco Empresa
                    BindingSource bsEmp = new BindingSource();
                    bsEmp.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).Cd_empresa,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null);

                    //Buscar endereco cliente
                    BindingSource bsEndCli = new BindingSource();
                    bsEndCli.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).Cd_clifor.Trim() + "'"
                                }
                            }, 1, string.Empty);
                    Rel.Adiciona_DataSource("DTS_ENDCLIFOR", bsEndCli);

                    //buscar ajudantes
                    CamadaDados.Mudanca.TList_AjudantesMud lajudantes =
                        new CamadaDados.Mudanca.TCD_AjudantesMud().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_mudanca",
                                    vOperador = "=",
                                    vVL_Busca = (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).Id_mudancastr
                                }
                            }, 0, string.Empty);
                    string ajudantes = string.Empty;
                    if (lajudantes.Count > 0)
                    {
                        for (int i = 0; i < lajudantes.Count;i++ )
                        {
                            ajudantes += lajudantes[i].Nm_ajudante ;
                            if (i != lajudantes.Count - 1)
                                if (i != lajudantes.Count - 2 )
                                    ajudantes += ", ";
                                else
                                    ajudantes += " E ";
                        }
                        Rel.Parametros_Relatorio.Add("AJUDANTES", ajudantes);
                    }

                    //Verificar se existe logo configurada para a empresa
                    if (bsEmp.Count > 0)
                        if ((bsEmp.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (bsEmp.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    Rel.Adiciona_DataSource("DTS_EMP", bsEmp);

                    Rel.Nome_Relatorio = "FLanGuardaVolume";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "MUD";
                    Rel.Ident = "FLanGuardaVolume";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).Cd_clifor;
                    fImp.pMensagem = "MUDANÇA";

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "Guarda Volume" + (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).NR_GuardaVol,
                                           fImp.pDs_mensagem);

                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "Guarda Volume" + (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).NR_GuardaVol,
                                               fImp.pDs_mensagem);
                }
            }
        }
    }
}
