using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using Utils;

namespace Faturamento
{
    public partial class FOrcAuditoria : Form
    {
        public FOrcAuditoria()
        {
            InitializeComponent();
        }

        private void FOrcAuditoria_Load(object sender, EventArgs e)
        { 
        }

        private void afterbusca()
        {
            TList_Auditoria laud = new TList_Auditoria();

            TpBusca[] filtro = new TpBusca[0];

            Array.Resize(ref filtro, filtro.Length + 1);
            filtro[filtro.Length - 1].vNM_Campo = "a.nm_tabela";
            filtro[filtro.Length - 1].vOperador = "=";
            filtro[filtro.Length - 1].vVL_Busca = "'tb_fat_orcamento'";

            Array.Resize(ref filtro, filtro.Length + 1);
            filtro[filtro.Length - 1].vNM_Campo = "a.tp_evento";
            filtro[filtro.Length - 1].vOperador = "=";
            filtro[filtro.Length - 1].vVL_Busca = "'U'";
            if (!string.IsNullOrEmpty(nr_orcamento.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_chave";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + nr_orcamento.Text+"%'";
            }
            //if ((!string.IsNullOrEmpty(DT_Inicial.Text)) && (DT_Inicial.Text.Trim() != "/  /"))
            //{
            //    Array.Resize(ref filtro, filtro.Length + 1);
            //    filtro[filtro.Length - 1].vNM_Campo = "a.dt_evento";
            //    filtro[filtro.Length - 1].vOperador = ">=";
            //    filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Inicial.Text).ToString("yyyyMMdd"))+"'";
            //}
            //if ((!string.IsNullOrEmpty(DT_Final.Text)) && (DT_Final.Text.Trim() != "/  /"))
            //{
            //    Array.Resize(ref filtro, filtro.Length + 1);
            //    filtro[filtro.Length - 1].vNM_Campo = "a.dt_evento";
            //    filtro[filtro.Length - 1].vOperador = "<=";
            //    filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd")) + " 00:00:00'";
            //}

            laud = new TCD_Auditoria().Select(filtro, 0, string.Empty);
            string vparam = string.Empty;
            int i = 0;
            laud.ForEach(p =>
            {
                
                string[] a = p.id_chave.Split(':');
                vparam += "("+a[0] +" = "+ a[1] + ")";
                
                if (i < laud.Count-1)
                    vparam += " or ";
                i++;
            });



            TpBusca[] filtro2 = new TpBusca[0];
            if (!string.IsNullOrEmpty(vparam))
            {
                Array.Resize(ref filtro2, filtro2.Length + 1);
                filtro2[filtro2.Length - 1].vVL_Busca = vparam;
            }

            if (nr_orcamento.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtro2, filtro2.Length + 1);
                filtro2[filtro2.Length - 1].vNM_Campo = "a.nr_orcamento";
                filtro2[filtro2.Length - 1].vOperador = "=";
                filtro2[filtro2.Length - 1].vVL_Busca = nr_orcamento.Text;
            }
            if (nm_clifor.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtro2, filtro2.Length + 1);
                filtro2[filtro2.Length - 1].vNM_Campo = "c.nm_clifor";
                filtro2[filtro2.Length - 1].vOperador = "like";
                filtro2[filtro2.Length - 1].vVL_Busca = "'%" + nm_clifor.Text + "%'";
            }
            if (cd_vendedor.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtro2, filtro2.Length + 1);
                filtro2[filtro2.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro2[filtro2.Length - 1].vOperador = "=";
                filtro2[filtro2.Length - 1].vVL_Busca = "'" + cd_vendedor.Text + "'";
            }
            if ((!string.IsNullOrEmpty(DT_Inicial.Text)) && (DT_Inicial.Text.Trim() != "/  /"))
                {
                    Array.Resize(ref filtro2, filtro2.Length + 1);
                    filtro2[filtro2.Length - 1].vNM_Campo = "a.dt_evento";
                    filtro2[filtro2.Length - 1].vOperador = ">=";
                    filtro2[filtro2.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Inicial.Text).ToString("yyyyMMdd")) + " 00:00:00'";
                }
                if ((!string.IsNullOrEmpty(DT_Final.Text)) && (DT_Final.Text.Trim() != "/  /"))
                {
                    Array.Resize(ref filtro2, filtro2.Length + 1);
                    filtro2[filtro2.Length - 1].vNM_Campo = "a.dt_evento";
                    filtro2[filtro2.Length - 1].vOperador = "<=";
                    filtro2[filtro2.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd")) + " 00:00:00'";
                }

            Array.Resize(ref filtro2, filtro2.Length + 1);
            filtro2[filtro2.Length - 1].vNM_Campo = "isnull(a.st_orcprojeto, 'N')";
            filtro2[filtro2.Length - 1].vOperador = "=";
            filtro2[filtro2.Length - 1].vVL_Busca = "'N'";

            bsOrcamento.DataSource = new CamadaDados.Faturamento.Orcamento.TCD_Orcamento().Select(filtro2, 0, string.Empty);
            bsOrcamento_PositionChanged(this, new EventArgs());
            bsOrcamento.ResetCurrentItem();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterbusca();
        }

        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if(bsOrcamento.Current != null)
            {
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens =
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_Item.Buscar(
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr,
                    false,
                    false,
                    null);
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lParcelas =
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_DT_Vencto.Buscar(
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr,
                    null);
                //busca nota
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lNotaFiscal =
                    new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from vtb_fat_orcamento x "+
                                            " join tb_fat_pedido_itens z "+
                                            " on z.nr_orcamento = x.nr_orcamento " +
                                            "where z.Nr_Pedido = a.nr_pedido "+
                                            "and x.nr_orcamento = "+(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamento.ToString()+")"
                            }
                        }, 0, string.Empty);
                // busca duplicata
                if((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_pedidovenda.HasValue)
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lParc =
                                new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                new TpBusca[]
                                {
                                    new TpBusca
                                    {
                                        vNM_Campo = "isnull(dup.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new TpBusca
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.nr_lancto = a.nr_lancto " +
                                                    "and x.nr_pedido = " + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_pedidovenda.Value.ToString() + ")"
                                    }
                                }, 0, string.Empty, string.Empty, string.Empty);
                bsOrcamento.ResetCurrentItem();
                bsItens_PositionChanged(this, new EventArgs());
                // TotalizarOrcamento();
                
                string codigo = string.Empty;
                string coluna = string.Empty;

                TpBusca[] filtro = new TpBusca[0];

                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = "(b.nm_tabela = 'tb_fat_orcamento_item') or (b.nm_tabela = 'tb_fat_orcamento') ";

                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.tp_evento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'U'";

                Array.Resize(ref filtro, filtro.Length + 1); 
                filtro[filtro.Length - 1].vVL_Busca = "(b.id_chave like '%" + nr_orcamento.Name + ":" 
                            + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr + "' )"+
                    "or ( b.id_chave like '%" + nr_orcamento.Name + ":" 
                            + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr + "|%')";
                 

                bsColunAudit.DataSource = new TCD_ColunasAudit().Select(filtro, 100, string.Empty);
                bsColunAudit.ResetCurrentItem();
            }
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_vendedor }, "isnull(a.st_vendedor, 'N')|=|'S';isnull(a.st_funcativo, 'N')|=|'S'");

        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });

        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';isnull(a.st_vendedor, 'N')|=|'S';isnull(a.st_funcativo, 'N')|=|'S'",
                new Componentes.EditDefault[] { cd_vendedor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());

        }

        private void FOrcAuditoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
            {
                afterbusca();
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                //Buscar ficha tecnica item orcamento
                (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec =
                    CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.Buscar((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Nr_orcamento.Value.ToString(),
                                                                                   (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Id_item.Value.ToString(),
                                                                                   string.Empty,
                                                                                   null);
                bsOrcamento.ResetCurrentItem();
                if ((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Count > 0)
                    tlpFichaTec.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 50);
                else
                    tlpFichaTec.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 0);
            }
        }
    }
}
