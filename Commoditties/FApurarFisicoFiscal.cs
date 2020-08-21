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
    public partial class TFApurarFisicoFiscal : Form
    {
        public string Cd_empresa
        {get;set;}
        public string Nr_pedido
        {get;set;}
        public string Tp_movimento
        {get;set;}

        public List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item> lDev
        {
            get
            {
                if (bsNfItemDevolver.Count > 0)
                    return (bsNfItemDevolver.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item> lComp
        {
            get
            {
                if (bsNfItemComplementar.Count > 0)
                    return (bsNfItemComplementar.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFApurarFisicoFiscal()
        {
            InitializeComponent();
        }

        private void TotalizarNfDev()
        {
            if (bsNfItemDevolver.Count > 0)
            {
                sd_qtddevolver.Value = (bsNfItemDevolver.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).Sum(p => p.Sd_qtdfiscaldevolver);
                qtd_devprocessar.Value = (bsNfItemDevolver.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).Where(p => p.St_processar).Sum(p => p.Sd_qtdfiscaldevolver);
                sd_vldevolver.Value = (bsNfItemDevolver.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).Sum(p => p.Sd_vlfiscaldevolver);
                vl_devprocessar.Value = (bsNfItemDevolver.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).Where(p => p.St_processar).Sum(p => p.Sd_vlfiscaldevolver);
            }
        }

        private void TotalizarNfComp()
        {
            if (bsNfItemComplementar.Count > 0)
            {
                sd_qtdcomplementar.Value = (bsNfItemComplementar.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).Sum(p => p.Sd_qtdfiscalcomplementar);
                qtd_compprocessar.Value = (bsNfItemComplementar.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).Where(p => p.St_processar).Sum(p => p.Sd_qtdfiscalcomplementar);
                sd_vlcomplementar.Value = (bsNfItemComplementar.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).Sum(p => p.Sd_vlfiscalcomplementar);
                vl_compprocessar.Value = (bsNfItemComplementar.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).Where(p => p.St_processar).Sum(p => p.Sd_vlfiscalcomplementar);
            }
        }

        private void BuscarNfDevolver()
        {
            //Buscar notas com saldo fiscal devolver
            bsNfItemDevolver.DataSource = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_pedido",
                                                    vOperador = "=",
                                                    vVL_Busca = Nr_pedido
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "nf.tp_movimento",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Tp_movimento.Trim().ToUpper() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "isnull(nf.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = string.Empty,
                                                    vVL_Busca = "((a.qtd_fiscaldevolver - a.qtd_fiscaldevolvido) > 0) or " +
                                                                "((a.vl_fiscaldevolver - a.vl_fiscaldevolvido) > 0)"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), nf.dt_emissao)))",
                                                    vOperador = "=",
                                                    vVL_Busca = dt_dev.Text.Trim() != "/  /" ? "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_dev.Text).ToString("yyyyMMdd")) + "'" :
                                                                "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), nf.dt_emissao)))"
                                                }
                                            }, 0, string.Empty, string.Empty, "a.id_nfitem");
        }

        private void BuscarNfComplementar()
        {
            //Buscar notas com saldo fiscal complementar
            bsNfItemComplementar.DataSource = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().Select(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.nr_pedido",
                                                        vOperador = "=",
                                                        vVL_Busca = Nr_pedido
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "nf.tp_movimento",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Tp_movimento.Trim().ToUpper() + "'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(nf.st_registro, 'A')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'C'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = string.Empty,
                                                        vVL_Busca = "((a.qtd_fiscalcomplementar - a.qtd_fiscalcomplemento) > 0) or " +
                                                                    "((a.vl_fiscalcomplementar - a.vl_fiscalcomplemento) > 0)"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), nf.dt_emissao)))",
                                                        vOperador = "=",
                                                        vVL_Busca = dt_comp.Text.Trim() != "/  /" ? "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_comp.Text).ToString("yyyyMMdd")) + "'" :
                                                                    "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), nf.dt_emissao)))"
                                                    }
                                                }, 0, string.Empty, string.Empty, "a.id_nfitem");
        }

        private void TFApurarFisicoFiscal_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dgDevolver);
            Utils.ShapeGrid.RestoreShape(this, dgComplementar);
            lblConciliacao.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            label1.BackColor = Utils.SettingsUtils.Default.COLOR_2;

            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.BuscarNfDevolver();
            this.BuscarNfComplementar();
            this.TotalizarNfComp();
            this.TotalizarNfDev();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFApurarFisicoFiscal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cbDev_Click(object sender, EventArgs e)
        {
            if (bsNfItemDevolver.Count > 0)
            {
                (bsNfItemDevolver.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).ForEach(p => p.St_processar = cbDev.Checked);
                bsNfItemDevolver.ResetBindings(true);
                this.TotalizarNfDev();
            }
        }

        private void cbComp_Click(object sender, EventArgs e)
        {
            if (bsNfItemComplementar.Count > 0)
            {
                (bsNfItemComplementar.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).ForEach(p => p.St_processar = cbComp.Checked);
                bsNfItemComplementar.ResetBindings(true);
                this.TotalizarNfComp();
            }
        }

        private void dgDevolver_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsNfItemDevolver.Current != null))
            {
                (bsNfItemDevolver.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_processar =
                    !(bsNfItemDevolver.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_processar;
                bsNfItemDevolver.ResetCurrentItem();
                this.TotalizarNfDev();
            }
        }

        private void dgComplementar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsNfItemComplementar.Current != null))
            {
                (bsNfItemComplementar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_processar =
                    !(bsNfItemComplementar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_processar;
                bsNfItemComplementar.ResetCurrentItem();
                this.TotalizarNfComp();
            }
        }

        private void dt_dev_Leave(object sender, EventArgs e)
        {
            this.BuscarNfDevolver();
        }

        private void dt_comp_Leave(object sender, EventArgs e)
        {
            this.BuscarNfComplementar();
        }

        private void TFApurarFisicoFiscal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dgDevolver);
            Utils.ShapeGrid.SaveShape(this, dgComplementar);
        }
    }
}
