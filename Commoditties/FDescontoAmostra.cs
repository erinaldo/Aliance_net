using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFDescontoAmostra : Form
    {
        private CamadaDados.Graos.TRegistro_DescontoXAmostra rdesc;
        public CamadaDados.Graos.TRegistro_DescontoXAmostra rDesc
        {
            get
            {
                if (bsDescontoAmostra.Current != null)
                    return bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra;
                else
                    return null;
            }
            set { rdesc = value; }
        }

        public TFDescontoAmostra()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("BRUTO", "B"));
            cbx.Add(new Utils.TDataCombo("LIQUIDO", "L"));
            tp_desconto.DataSource = cbx;
            tp_desconto.DisplayMember = "Display";
            tp_desconto.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("PESO", "P"));
            cbx1.Add(new Utils.TDataCombo("PERCENTUAL", "R"));
            informarR_P.DataSource = cbx1;
            informarR_P.DisplayMember = "Display";
            informarR_P.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void InserirIndice()
        {
            if(bsDescontoAmostra.Current != null)
                using (TFIndiceDesc fIndice = new TFIndiceDesc())
                {
                    if (fIndice.ShowDialog() == DialogResult.OK)
                        if (fIndice.rPerc != null)
                        {
                            if ((bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPerc.Exists(p => p.Pc_resultado.Equals(fIndice.rPerc.Pc_resultado)))
                            {
                                (bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPerc.Find(p => p.Pc_resultado.Equals(fIndice.rPerc.Pc_resultado)).Pc_descpagto = fIndice.rPerc.Pc_descpagto;
                                (bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPerc.Find(p => p.Pc_resultado.Equals(fIndice.rPerc.Pc_resultado)).Pc_descestoque = fIndice.rPerc.Pc_descestoque;
                            }
                            else
                                (bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPerc.Add(fIndice.rPerc);
                            bsDescontoAmostra.ResetCurrentItem();
                        }
                }
        }

        private void AlterarIndice()
        {
            if(bsPerc.Current != null)
                using (TFIndiceDesc fIndice = new TFIndiceDesc())
                {
                    fIndice.rPerc = bsPerc.Current as CamadaDados.Graos.TRegistro_PercDesconto;
                    if (fIndice.ShowDialog() != DialogResult)
                    {
                        (bsPerc.Current as CamadaDados.Graos.TRegistro_PercDesconto).Pc_descpagto = fIndice.rPerc.Pc_descpagto;
                        (bsPerc.Current as CamadaDados.Graos.TRegistro_PercDesconto).Pc_descestoque = fIndice.rPerc.Pc_descestoque;
                    }
                    bsPerc.ResetCurrentItem();
                }
        }

        private void ExcluirIndice()
        {
            if(bsPerc.Count > 0)
            {
                DialogResult result = MessageBox.Show("Excluir indice corrente?\r\n(Obs.: Para excluir todos os indices click <NÃO>.\r\nPara não excluir click <CANCELAR>.", "Pergunta", MessageBoxButtons.YesNoCancel,
                                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    (bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPercDel.Add(
                        bsPerc.Current as CamadaDados.Graos.TRegistro_PercDesconto);
                    bsPerc.RemoveCurrent();
                }
                else if (result == DialogResult.No)
                {
                    (bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPerc.ForEach(p =>
                        (bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPercDel.Add(p));
                    bsPerc.Clear();
                }
            }
        }

        private void InserirLote()
        {
            if(bsDescontoAmostra.Current != null)
                using (TFLoteIndice fLote = new TFLoteIndice())
                {
                    if (fLote.ShowDialog() == DialogResult.OK)
                    {
                        List<CamadaDados.Graos.TRegistro_PercDesconto> lote =
                        CamadaNegocio.Graos.TCN_PercDesconto.CalcLoteDesconto(fLote.Pc_ini_resultado,
                                                                              fLote.Pc_fin_resultado,
                                                                              fLote.Intervalo_resultado,
                                                                              fLote.Pc_desconto_apartir,
                                                                              fLote.Pc_desconto_inicial,
                                                                              fLote.Intervalo_desconto);
                        if (lote != null)
                        {
                            lote.ForEach(p =>
                                {
                                    if ((bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPerc.Exists(v => v.Pc_resultado.Equals(p.Pc_resultado)))
                                    {
                                        (bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPerc.Find(v => v.Pc_resultado.Equals(p.Pc_resultado)).Pc_descestoque = p.Pc_descestoque;
                                        (bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPerc.Find(v => v.Pc_resultado.Equals(p.Pc_resultado)).Pc_descpagto = p.Pc_descpagto;
                                    }
                                    else
                                        (bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPerc.Add(p);
                                });
                            bsDescontoAmostra.ResetBindings(true);
                        }
                    }
                }
        }

        private void ImportarIndice()
        {
            if(bsDescontoAmostra.Current != null)
                using (TFImportIndice fImport = new TFImportIndice())
                {
                    if (fImport.ShowDialog() == DialogResult.OK)
                    {
                        CamadaNegocio.Graos.TCN_PercDesconto.Buscar(fImport.Cd_tabeladesconto,
                                                                    fImport.Cd_tipoamostra,
                                                                    null).ForEach(p =>
                                                                        {
                                                                            if ((bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPerc.Exists(v => v.Pc_resultado.Equals(p.Pc_resultado)))
                                                                            {
                                                                                (bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPerc.Find(v => v.Pc_resultado.Equals(p.Pc_resultado)).Pc_descestoque = p.Pc_descestoque;
                                                                                (bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPerc.Find(v => v.Pc_resultado.Equals(p.Pc_resultado)).Pc_descpagto = p.Pc_descpagto;
                                                                            }
                                                                            else
                                                                                (bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPerc.Add(p);
                                                                        });
                        bsDescontoAmostra.ResetCurrentItem();
                    }
                }
        }

        private void BuscarDescAmostra()
        {
            if ((!string.IsNullOrEmpty(CD_TabelaDesconto.Text)) &&
                (!string.IsNullOrEmpty(CD_TipoAmostra.Text)))
            {
                CamadaDados.Graos.TList_DescontoXAmostra lDesc =
                CamadaNegocio.Graos.TCN_DescontoXAmostra.Buscar(CD_TabelaDesconto.Text, CD_TipoAmostra.Text, null);
                if (lDesc.Count > 0)
                {
                    lDesc[0].lPerc = CamadaNegocio.Graos.TCN_PercDesconto.Buscar(lDesc[0].Cd_tabeladesconto, lDesc[0].Cd_tipoamostra, null);
                    bsDescontoAmostra.DataSource = lDesc;
                    CD_TabelaDesconto.Enabled = false;
                    bb_TabelaDesconto.Enabled = false;
                    CD_TipoAmostra.Enabled = false;
                    bb_Amostra.Enabled = false;
                }
            }
        }

        private void TFDescontoAmostra_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rdesc != null)
            {
                bsDescontoAmostra.DataSource = new CamadaDados.Graos.TList_DescontoXAmostra() { rdesc };
                CD_TabelaDesconto.Enabled = false;
                bb_TabelaDesconto.Enabled = false;
                CD_TipoAmostra.Enabled = false;
                bb_Amostra.Enabled = false;
                CD_Protocolo.Focus();
            }
            else
                bsDescontoAmostra.AddNew();
        }

        private void bb_TabelaDesconto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TabelaDesconto|Tabela Desconto|350;" +
                              "CD_TabelaDesconto|Cód. TabDesc.|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_TabelaDesconto, ds_tabelaDesconto },
                                    new CamadaDados.Graos.TCD_TabelaDesconto(), string.Empty);
            this.BuscarDescAmostra();
        }

        private void CD_TabelaDesconto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_tabeladesconto|=|'" + CD_TabelaDesconto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_TabelaDesconto, ds_tabelaDesconto },
                                    new CamadaDados.Graos.TCD_TabelaDesconto());
            this.BuscarDescAmostra();
        }

        private void bb_Amostra_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Amostra|Descrição Amostra|350;" +
                              "CD_TipoAmostra|Cód. Amostra|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_TipoAmostra, ds_amostra },
                                    new CamadaDados.Graos.TCD_CadAmostra(), string.Empty);
            this.BuscarDescAmostra();
        }

        private void CD_TipoAmostra_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_TipoAmostra|=|'" + CD_TipoAmostra.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_TipoAmostra, ds_amostra },
                                    new CamadaDados.Graos.TCD_CadAmostra());
            this.BuscarDescAmostra();
        }

        private void BTN_Protocolo_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Protocolo|Protocolo|350;" +
                              "CD_Protocolo|Cód. Protocolo|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Protocolo, DS_Protocolo },
                                    new CamadaDados.Diversos.TCD_CadProtocolo(), string.Empty);
        }

        private void CD_Protocolo_Leave(object sender, EventArgs e)
        {
            string vColunas = "cd_protocolo|=|'" + CD_Protocolo.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Protocolo, DS_Protocolo },
                                    new CamadaDados.Diversos.TCD_CadProtocolo());
        }

        private void BTN_Protocolo_Ref_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Protocolo|Protocolo|350;" +
                              "CD_Protocolo|Cód. Protocolo|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Protocolo_Ref, DS_Protocolo_Ref },
                                    new CamadaDados.Diversos.TCD_CadProtocolo(), string.Empty);
        }

        private void CD_Protocolo_Ref_Leave(object sender, EventArgs e)
        {
            string vColunas = "cd_protocolo|=|'" + CD_Protocolo_Ref.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Protocolo_Ref, DS_Protocolo_Ref },
                                    new CamadaDados.Diversos.TCD_CadProtocolo());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.InserirIndice();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            this.AlterarIndice();
        }

        private void bb_excluirindice_Click(object sender, EventArgs e)
        {
            this.ExcluirIndice();
        }

        private void bb_inserirlote_Click(object sender, EventArgs e)
        {
            this.InserirLote();
        }

        private void bb_importarIndice_Click(object sender, EventArgs e)
        {
            this.ImportarIndice();
        }

        private void TFDescontoAmostra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirIndice();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.AlterarIndice();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirIndice();
            else if (e.Control && e.KeyCode.Equals(Keys.L))
                this.InserirLote();
            else if (e.Control && e.KeyCode.Equals(Keys.I))
                this.ImportarIndice();
        }
    }
}
