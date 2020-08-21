using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Servicos.Cadastros;
using CamadaNegocio.Servicos.Cadastros;
using System.Collections;
using Utils;
using FormBusca;

namespace Servico.Cadastros
{
    public partial class TFCadOseTpOrdemxEtapa : FormCadPadrao.FFormCadPadrao
    {
        public TFCadOseTpOrdemxEtapa()
        {
            InitializeComponent();
            DTS = BS_CadOseTpOrdemxEtapa;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_TpOrdem_X_Etapa.Gravar(BS_CadOseTpOrdemxEtapa.Current as TRegistro_TpOrdem_X_Etapa, null);
            else
                return string.Empty;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadOseTpOrdemxEtapa.AddNew();
                base.afterNovo();
                Tp_ordem.Focus();
            }
        }

        public override void afterAltera()
        {
            MessageBox.Show("Não é permitido realizar alterações.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bb_ordenar.Enabled = true;
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadOseTpOrdemxEtapa.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_TpOrdem_X_Etapa lista = TCN_TpOrdem_X_Etapa.Buscar(Id_Etapa.Text, Tp_ordem.Text, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadOseTpOrdemxEtapa.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadOseTpOrdemxEtapa.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_TpOrdem_X_Etapa.Excluir(BS_CadOseTpOrdemxEtapa.Current as TRegistro_TpOrdem_X_Etapa, null);
                    BS_CadOseTpOrdemxEtapa.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
        }

        private void bb_idEtapa_Click(object sender, EventArgs e)
        {
            string vParam = "|not exists|(select 1 from tb_ose_tpordem_x_etapa x " +
                            "               where x.id_etapa = a.id_etapa " +
                            "               and x.tp_ordem = '" + Tp_ordem.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA("ds_etapa|Nome Etapa|150;a.id_etapa|Código Ordem|80"
             , new Componentes.EditDefault[] { Id_Etapa,Ds_Etapa }, new TCD_EtapaOrdem(), vParam);
        }

        private void Id_Etapa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.id_etapa|=|" + Id_Etapa.Text + ";" +
                              "|not exists|(select 1 from tb_ose_tpordem_x_etapa x " +
                              "             where x.id_etapa = a.id_etapa " +
                              "             and x.tp_ordem = '" + Tp_ordem.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vColunas
                , new Componentes.EditDefault[] { Id_Etapa, Ds_Etapa }, new TCD_EtapaOrdem());

        }

        private void bb_idTpordem_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("ds_tipoordem|Tipo Ordem|150;a.tp_ordem|Código|80"
             , new Componentes.EditDefault[] { Tp_ordem, Ds_TipoOrdem }, new TCD_TpOrdem(), null);
        }

        private void Tp_ordem_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.tp_ordem|=|" + Tp_ordem.Text, new Componentes.EditDefault[] { Tp_ordem, Ds_TipoOrdem }, new TCD_TpOrdem());
        }

        private void TFCadOseTpOrdemxEtapa_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_ordem_X_Etapa);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            bb_ordenar.Enabled = false;
        }

        private void TFCadOseTpOrdemxEtapa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_ordem_X_Etapa);
        }

        private void bb_ordenar_Click(object sender, EventArgs e)
        {
            using (Servicos.TFOrdenarEtapa fOrdenar = new Servicos.TFOrdenarEtapa())
            {
                if (fOrdenar.ShowDialog() == DialogResult.OK)
                    if (fOrdenar.lTpOrdem != null)
                        try
                        {
                            fOrdenar.lTpOrdem.ForEach(p => 
                                {
                                    p.lEtapa.ForEach(x=> 
                                    {
                                        CamadaNegocio.Servicos.Cadastros.TCN_TpOrdem_X_Etapa.Gravar(
                                            new CamadaDados.Servicos.Cadastros.TRegistro_TpOrdem_X_Etapa()
                                            {
                                                Id_etapa = x.Id_etapa,
                                                Tp_ordem = p.Tp_ordem,
                                                Ordem = x.Ordem
                                            },null);
                                    });
                                });
                            MessageBox.Show("Etapas Ordem Ordenadas com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.limparControls();
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }
    }
}
