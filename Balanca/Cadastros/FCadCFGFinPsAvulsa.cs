using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Balanca.Cadastros
{
    public partial class TFCadCFGFinPsAvulsa : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCFGFinPsAvulsa()
        {
            InitializeComponent();
            this.DTS = bsCfgFinPsAvulsa;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Balanca.Cadastros.TCN_CFGFinPsAvulsa.GravarCFGFinPsAvulsa(bsCfgFinPsAvulsa.Current as CamadaDados.Balanca.Cadastros.TRegistro_CFGFinPsAvulsa, null);
            else
                return string.Empty;

        }

        public override int buscarRegistros()
        {
            CamadaDados.Balanca.Cadastros.TList_CFGFinPsAvulsa lista =
                CamadaNegocio.Balanca.Cadastros.TCN_CFGFinPsAvulsa.Buscar(cd_empresa.Text,
                                                                         tp_pesagem.Text,
                                                                         cd_cliforpadrao.Text,
                                                                         cd_endpadrao.Text,
                                                                         tp_docto.Text,
                                                                         cd_condpgto.Text,
                                                                         tp_duplicata.Text,
                                                                         cd_historico.Text,
                                                                         cd_contager.Text,
                                                                         0,
                                                                         string.Empty,
                                                                         null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfgFinPsAvulsa.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || ((vTP_Modo == Utils.TTpModo.tm_busca)))
                        bsCfgFinPsAvulsa.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
                bsCfgFinPsAvulsa.AddNew();
            base.afterNovo();
            cd_empresa.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo.Equals(Utils.TTpModo.tm_Edit))
            {
                bb_empresa.Enabled = false;
                bb_tppesagem.Enabled = false;
                cd_cliforpadrao.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCfgFinPsAvulsa.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                CamadaNegocio.Balanca.Cadastros.TCN_CFGFinPsAvulsa.DeletarCFGFinPsAvulsa((bsCfgFinPsAvulsa.Current as CamadaDados.Balanca.Cadastros.TRegistro_CFGFinPsAvulsa), null);
                pDados.LimparRegistro();
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa, nm_empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { cd_empresa, nm_empresa }
               , new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_tppesagem_Click(object sender, EventArgs e)
        {
            string vColunas = "NM_TPPesagem|Tipo Pesagem|350;" +
                              "TP_Pesagem|TP. Pesagem|100";
            string vParamFixo = "TP_Modo|=|'V';" +
                                "|EXISTS|(select 1 from tb_div_usuario_x_tppesagem x " +
                                "           where x.tp_pesagem = a.tp_pesagem " +
                                "           and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "           (EXISTS(select 1 from tb_div_usuario_x_grupos y " +
                                "                   where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_pesagem, nm_tppesagem },
                                    new CamadaDados.Balanca.Cadastros.TCD_CadTpPesagem(), vParamFixo);
        }

        private void tp_pesagem_Leave(object sender, EventArgs e)
        {
            string vColunas = "tp_pesagem|=|'" + tp_pesagem.Text.Trim() + "';" +
                              "TP_Modo|=|'V';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_tppesagem x " +
                                "           where x.tp_pesagem = a.tp_pesagem " +
                                "           and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "           (EXISTS(select 1 from tb_div_usuario_x_grupos y " +
                                "                   where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { tp_pesagem, nm_tppesagem },
                                    new CamadaDados.Balanca.Cadastros.TCD_CadTpPesagem());
        }

        private void bb_cliforpadrao_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasia|Fantasia|100;" +
                "EMAILPF|E-Mail P.F|100;" +
                "EMAILPJ|E-Mail P.J|100;" +
                "a.cd_transportador|Cd. Tranportadora|80;" +
                "transp.nm_clifor|Transportadora|200;" +
                "a.cd_endereco_transp|Cd. Transportadora|80;" +
                "endTransp.ds_endereco|Endereco Transportadora|200"
                , new Componentes.EditDefault[] { cd_cliforpadrao, nm_cliforpadrao }, 
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor()
                , "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_cliforpadrao_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_cliforpadrao.Text.Trim() + "';isnull(a.st_registro, 'A')|<>|'C'"
                    , new Componentes.EditDefault[] { cd_cliforpadrao, nm_cliforpadrao }, 
                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_endpadrao_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;a.UF|Estado|150;a.fone|Telefone|80"
                                                            , new Componentes.EditDefault[] { cd_endpadrao, ds_endpadrao }, 
                                                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), 
                                                            "a.cd_clifor|=|'" + cd_cliforpadrao.Text.Trim() + "'");
        }

        private void cd_endpadrao_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + cd_endpadrao.Text.Trim() + "';a.cd_clifor|=|'" + cd_cliforpadrao.Text.Trim() + "'"
                                , new Componentes.EditDefault[] { cd_endpadrao, ds_endpadrao }, 
                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.TP_Duplicata|TP. Duplicata|80;" +
                              "a.DS_TpDuplicata| Tipo Duplicata|200;" +
                              "a.tp_Mov|Movimento|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_mov },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), string.Empty);
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_mov },
                                                     new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_TpDocto|Tipo Documento|200;"+
                              "a.TP_Docto|TP. Docto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                   new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), string.Empty);
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_docto|=|" + tp_docto.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Cd. CondPgto|80;" +
                              "a.cd_juro|Cd. Juro|80;" +
                              "d.ds_juro|Juro de Mora|200;" +
                              "a.cd_moeda|Cd. Moeda|80;" +
                              "c.ds_moeda_singular|Moeda|200;" +
                              "a.cd_portador|Cd. Portador|80;" +
                              "b.ds_portador|Portador|200";
            UtilPesquisa.BTN_BUSCA(vColunas,
                new Componentes.EditDefault[] { cd_condpgto, ds_condpgto, cd_juro, ds_juro, cd_moeda, ds_moeda_singular, cd_portador, ds_portador },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), string.Empty);
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam,
                new Componentes.EditDefault[] { cd_condpgto, ds_condpgto, cd_juro, ds_juro, cd_moeda, ds_moeda_singular, cd_portador, ds_portador },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico Operação|200;" +
                              "a.cd_historico|Cd. Historico|80";
            string vParam = "a.Tp_Mov|=|'" + tp_mov.Text.Trim().ToUpper() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico.Text.Trim() + "';" +
                            "a.tp_mov|=|'" + tp_mov.Text.Trim().ToUpper() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico, ds_historico },
                            new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;" +
                              "a.cd_contager|Cd. Conta|80";
            string vParam = "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contager.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_fin_contager_X_empresa x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void TFCadCFGFinPsAvulsa_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void gCfg_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCfg.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCfgFinPsAvulsa.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Balanca.Cadastros.TRegistro_CFGFinPsAvulsa());
            CamadaDados.Balanca.Cadastros.TList_CFGFinPsAvulsa lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCfg.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCfg.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Balanca.Cadastros.TList_CFGFinPsAvulsa(lP.Find(gCfg.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCfg.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Balanca.Cadastros.TList_CFGFinPsAvulsa(lP.Find(gCfg.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCfg.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCfgFinPsAvulsa.List as CamadaDados.Balanca.Cadastros.TList_CFGFinPsAvulsa).Sort(lComparer);
            bsCfgFinPsAvulsa.ResetBindings(false);
            gCfg.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
