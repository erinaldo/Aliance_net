using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FormBusca;

namespace Faturamento
{
    public partial class TFLan_Dados_Fiscais_Faturamento : Form
    {
        public bool Movimento_Entrada;
        public bool Movimento_Saida;
        public string CFG_TP_Fiscal = "";

        public TFLan_Dados_Fiscais_Faturamento()
        {
            InitializeComponent();
        }

        private void Lan_Dados_Fiscais_Faturamento_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pnl_Fiscais.set_FormatZero();

            ArrayList CBox3 = new ArrayList();
            CBox3.Add(new Utils.TDataCombo("N - Lançamentos Normais", "N"));
            CBox3.Add(new Utils.TDataCombo("C - Lançamentos de Complementos", "C"));
            CBox3.Add(new Utils.TDataCombo("D - Lançamentos de Devoluções", "D"));
            CBox3.Add(new Utils.TDataCombo("F - Lançamentos de Entregas Futuras", "F"));
            TP_Fiscal.DataSource = CBox3;
            TP_Fiscal.DisplayMember = "Display";
            TP_Fiscal.ValueMember = "Value";

            if (CFG_TP_Fiscal != "")
            {
                TP_Fiscal.SelectedValue = CFG_TP_Fiscal;
            }

        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLan_Dados_Fiscais_Faturamento_KeyDown(object sender, KeyEventArgs e)
        {
                    switch (e.KeyCode)
            {
                case (Keys.F6):
                    {
                        BB_Cancelar_Click(sender, new EventArgs()); break;
                    }
                case (Keys.F4):
                    {
                        BB_Gravar_Click(sender, new EventArgs()); break;
                    };
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (pnl_Fiscais.validarCampoObrigatorio())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BB_Serie_NORMAL_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_SerieNF|Ds Serie NF|300;a.NR_Serie|Nr.Serie|80"
                            , new Componentes.EditDefault[] { Nr_Serie, DS_Serie }, 
                            new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(),
                            null);
           
        }

        private void BB_Movto_NORMAL_Click(object sender, EventArgs e)
        {
            string cond = "";
            if (Movimento_Entrada == true)
            {
                if (TP_Fiscal.SelectedIndex == 2)
                    cond = "a.Tp_Movimento|=|'S'";
                else
                    cond = "a.Tp_Movimento|=|'E'";
            };
            if (Movimento_Saida == true)
            {
                if (TP_Fiscal.SelectedIndex == 2)
                    cond = "a.Tp_Movimento|=|'E'";
                else
                    cond = "a.Tp_Movimento|=|'S'";
            };
            UtilPesquisa.BTN_BUSCA("DS_Movimentacao|Ds Movimentação|300;CD_Movimentacao|Cd.Movimentação|80"
                            , new Componentes.EditDefault[] { CD_Movto, DS_Movto }, new CamadaDados.Fiscal.TCD_CadMovimentacao(),
                            cond);
        }

        private void BB_CMI_NORMAL_Click(object sender, EventArgs e)
        {
            if (CD_Movto.Text != "")
            {
                string cond = "";
                if (TP_Fiscal.SelectedIndex == 0) //NORMAL
                {
                    cond = "f.cd_Movimentacao|=|'" + CD_Movto.Text + "'";
                }
                else if (TP_Fiscal.SelectedIndex == 1) //COMPLEMENTO
                {
                    cond = "f.cd_Movimentacao|=|'" + CD_Movto.Text + "';a.ST_Complementar|=|'S'";
                }
                else if (TP_Fiscal.SelectedIndex == 2) //DEVOLUCAO
                {
                    cond = "f.cd_Movimentacao|=|'" + CD_Movto.Text + "';a.ST_Devolucao|=|'S'";
                }
                else if (TP_Fiscal.SelectedIndex == 3) //FUTURA
                {
                    cond = "f.cd_Movimentacao|=|'" + CD_Movto.Text + "';a.ST_Mestra|=|'S'";
                }
                UtilPesquisa.BTN_BUSCA("DS_CMI|Ds CMI|300;CD_CMI|Cd.CMI|80"
                                , new Componentes.EditDefault[] { CD_CMI, DS_CMI }, new CamadaDados.Fiscal.TCD_CadCMI("SqlCodeBuscaCMI_X_MOV"),
                                cond);
            }
        }

        private void Nr_Serie_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.Nr_Serie|=|'" + Nr_Serie.Text.Trim() + "'"
               , new Componentes.EditDefault[] { Nr_Serie, DS_Serie }, new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF());
        }

        private void CD_Movto_Leave(object sender, EventArgs e)
        {
            string cond = "";
            if (Movimento_Entrada == true)
            {
                if (TP_Fiscal.SelectedIndex == 2)
                    cond = "a.CD_Movimentacao|=|'" + CD_Movto.Text + "';a.Tp_Movimento|=|'S'";
                else
                    cond = "a.CD_Movimentacao|=|'" + CD_Movto.Text + "';a.Tp_Movimento|=|'E'";

            };
            if (Movimento_Saida == true)
            {
                if (TP_Fiscal.SelectedIndex == 2)
                    cond = "a.CD_Movimentacao|=|'" + CD_Movto.Text + "';a.Tp_Movimento|=|'E'";
                else
                    cond = "a.CD_Movimentacao|=|'" + CD_Movto.Text + "';a.Tp_Movimento|=|'S'";
            };

            UtilPesquisa.EDIT_LEAVE(cond, new Componentes.EditDefault[] { CD_Movto, DS_Movto }, new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void CD_CMI_Leave(object sender, EventArgs e)
        {
            if (CD_Movto.Text != "")
            {
                string cond = "";
                if (TP_Fiscal.SelectedIndex == 0) //NORMAL
                {
                    cond = "a.CD_CMI|=|'" + CD_CMI.Text + "';f.cd_Movimentacao|=|'" + CD_Movto.Text + "'";
                }
                else if (TP_Fiscal.SelectedIndex == 1) //COMPLEMENTO
                {
                    cond = "a.CD_CMI|=|'" + CD_CMI.Text + "';f.cd_Movimentacao|=|'" + CD_Movto.Text + "';a.ST_Complementar|=|'S'";
                }
                else if (TP_Fiscal.SelectedIndex == 2) //DEVOLUCAO
                {
                    cond = "a.CD_CMI|=|'" + CD_CMI.Text + "';f.cd_Movimentacao|=|'" + CD_Movto.Text + "';a.ST_Devolucao|=|'S'";
                }
                else if (TP_Fiscal.SelectedIndex == 3) //FUTURA
                {
                    cond = "a.CD_CMI|=|'" + CD_CMI.Text + "';f.cd_Movimentacao|=|'" + CD_Movto.Text + "';a.ST_Mestra|=|'S'";
                }

                UtilPesquisa.EDIT_LEAVE(cond, new Componentes.EditDefault[] { CD_CMI, DS_CMI }, new CamadaDados.Fiscal.TCD_CadCMI("SqlCodeBuscaCMI_X_MOV"));
            }
        }

    

      
    }
}
