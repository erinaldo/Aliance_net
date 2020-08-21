using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Servicos.Cadastros;
using CamadaNegocio.Servicos.Cadastros;
using Utils;
using FormBusca;

namespace Servicos.Cadastros
{
    public partial class TFCad_OseProximaEtapa : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_OseProximaEtapa()
        {
            InitializeComponent();
            DTS = Bs_CadOseProximaEtapa;
        }
        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_ProximaEtapa.Gravar(Bs_CadOseProximaEtapa.Current as TRegistro_ProximaEtapa, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_ProximaEtapa lista = TCN_ProximaEtapa.Buscar(Id_Etapa.Text, Id_ProximaEtapa.Text, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    Bs_CadOseProximaEtapa.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        Bs_CadOseProximaEtapa.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                Bs_CadOseProximaEtapa.AddNew();
                base.afterNovo();
                Id_Etapa.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
            {
                BB_ProximaEtapa.Enabled = false;
                BB_Etapa.Enabled = false;
            }
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_ProximaEtapa.Excluir(Bs_CadOseProximaEtapa.Current as TRegistro_ProximaEtapa, null);
                }
            }
        }

        private void BB_Etapa_Click(object sender, EventArgs e)
        {
            string vParam = "|EXISTS|(Select 1 from tb_ose_EtapaOrdem b "+
                            "           where a.id_Etapa = b.id_Etapa "+
                            "           and isnull(b.st_FinalizarOs, 'N') <> 'S')";
            string vColunas = "ds_Etapa|Descrição Etapa|350;" +
                         "id_Etapa|Cód. Etapa|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Id_Etapa, Ds_Etapa },
                                    new TCD_EtapaOrdem(), vParam);
        }

        private void id_Etapa_Leave(object sender, EventArgs e)
        {
            string vColunas = "id_Etapa |=| '" + Id_Etapa.Text + "';"+
                "|EXISTS|(Select 1 from tb_ose_EtapaOrdem b "+
                "           where a.id_Etapa = b.id_Etapa "+
                "           and isnull(b.st_FinalizarOs, 'N') <> 'S')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Id_Etapa, Ds_Etapa},
                                    new TCD_EtapaOrdem());
        }

        private void BB_ProximaEtapa_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_Etapa|Descrição Etapa|350;" +
                         "id_Etapa|Cód. Etapa|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Id_ProximaEtapa, Ds_ProximaEtapa },
                                    new TCD_EtapaOrdem(), string.Empty);
        }

        private void id_ProximaEtapa_Leave(object sender, EventArgs e)
        {
            string vColunas = "id_Etapa|=|" + Id_ProximaEtapa.Text;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Id_ProximaEtapa, Ds_ProximaEtapa},
                                    new TCD_EtapaOrdem());
        }

        private void TFCad_OseProximaEtapa_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
        }

        private void TFCad_OseProximaEtapa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
