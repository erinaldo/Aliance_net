using System;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Financeiro.Relatorio
{
    public partial class TFRel_DupLiquidada : Form
    {
        private bool Altera_relatorio = false;

        public TFRel_DupLiquidada()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            dt_ini.Clear();
            dt_fin.Clear();
            rbPagar.Checked = false;
            rbReceber.Checked = false;
            rbTodas.Checked = true;
            dt_emissao.Checked = false;
            dt_vencto.Checked = false;
            dt_liquidacao.Checked = true;
            for (int i = 0; i < clbEmpresa.Items.Count; i++)
                clbEmpresa.SetItemChecked(i, false);
            cd_clifor.Clear();
            nm_clifor.Clear();
            cd_historico.Clear();
            ds_historico.Clear();
            cd_contager.Clear();
            ds_contager.Clear();
            nr_contrato.Clear();
            nr_pedido.Clear();
            nr_docto.Clear();
            rbClifor.Checked = true;
            rbHistorico.Checked = false;
            rbEmissao.Checked = false;
            rbLiquidacao.Checked = false;
            rbContaGer.Checked = false;
        }

        private void afterPrint()
        {
            if (string.IsNullOrEmpty(dt_ini.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatorio informar data inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_ini.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dt_fin.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatorio informar data final.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_fin.Focus();
                return;
            }
            if (string.IsNullOrEmpty(clbEmpresa.Vl_Busca))
            {
                MessageBox.Show("Obrigatorio selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Montar filtros da consulta
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.dt_vencto, a.vl_parcela, a.cd_parcela, cg.cd_contager, liq.CD_Portador, port.DS_Portador, ");
            sql.AppendLine("a.nr_lancto, liq.id_liquid, a.cd_empresa, b.nr_docto, b.cd_clifor, b.cd_historico as cd_historicoDup, ");
            sql.AppendLine("b.dt_emissao, caixa.cd_historico, day(liq.dt_liquidacao) as dia_liq, hisdup.ds_historico as ds_historicoDup, ");
            sql.AppendLine("month(liq.dt_liquidacao) as mes_liq, year(liq.dt_liquidacao) as ano_liq, DATENAME(month, b.dt_Emissao) as NM_Mes, ");
            sql.AppendLine("month(b.DT_emissao) as DT_Emissao_mes, year(b.DT_emissao) as DT_Emissao_ano, ");
            sql.AppendLine("day(b.DT_emissao) as DT_Emissao_dia, his.ds_historico, b.ds_observacao, ");
            sql.AppendLine("c.nm_clifor, isnull(b.complhistorico,'') as complhistorico, ");
            sql.AppendLine("case when t.tp_mov = 'P' then 'PAGAS' else 'RECEBIDAS' end as tp_mov, ");
            sql.AppendLine("case when isNull(a.st_registro, 'A') = 'A' then case when a.dt_vencto <= getdate() then 'VENCIDA' else 'ABERTA' end else case when isNull(a.st_registro, 'A') = 'L' then 'LIQUIDADA' else case when a.dt_vencto <= getdate() then 'VENCIDA'  else 'PARCIAL' end end end as st_registro, ");
            sql.AppendLine("DATEDIFF ( DAY , a.dt_vencto , GETDATE() ) AS QTD_DIAS, ");
            sql.AppendLine("Vl_Atual = DBO.F_CALC_ATUAL(a.cd_empresa, a.nr_lancto, a.cd_parcela,getDate(), 'N'), ");
            sql.AppendLine("liq.Vl_Liquidacao_Padrao as Vl_Liquidado, liq.Vl_DescontoBonus,liq.Vl_JuroAcrescimo, ");
            sql.AppendLine("liq.dt_liquidacao, liq.dt_alt, emp.nm_empresa,cg.ds_contager, ");
            sql.AppendLine("CONTRATO = isnull((select top 1 cp.nr_contrato from vtb_gro_contrato cp ");
            sql.AppendLine("					inner join tb_fat_pedido_itens p on p.nr_pedido = cp.nr_pedido and p.cd_produto = cp.cd_produto and p.id_pedidoitem = cp.id_pedidoitem ");
            sql.AppendLine("					inner join tb_fat_notafiscal_item nfi on p.nr_pedido = nfi.nr_pedido and p.cd_produto = nfi.cd_produto and p.id_pedidoitem = nfi.id_pedidoitem ");
            sql.AppendLine("					inner join tb_fat_notafiscal w on w.cd_empresa = nfi.cd_empresa and nfi.nr_lanctofiscal = w.nr_lanctofiscal ");
            sql.AppendLine("					inner join tb_fat_notafiscal_x_duplicata x on w.cd_empresa = x.cd_empresa and x.nr_lanctofiscal = w.nr_lanctofiscal ");
            sql.AppendLine("					where x.cd_empresa = b.cd_empresa and x.nr_lanctoduplicata = b.nr_lancto ),0), ");
            sql.AppendLine("PEDIDO = isnull((select top 1 y.nr_pedido from TB_FAT_NotaFiscal_X_Duplicata x ");
            sql.AppendLine("					inner join TB_FAT_NotaFiscal y ON x.CD_Empresa = y.CD_Empresa and x.nr_lanctofiscal = y.nr_lanctofiscal ");
            sql.AppendLine("					where x.cd_empresa = a.cd_empresa   and x.nr_lanctoduplicata = a.Nr_Lancto   and isnull(y.st_registro, 'A') <> 'C' ) ,0), ");
            sql.AppendLine("NR_NOTAFISCAL = isnull((select top 1 isnull(w.nr_notafiscal,0) from tb_fat_notafiscal w ");
            sql.AppendLine("					inner join tb_fat_notafiscal_x_duplicata x on w.cd_empresa = x.cd_empresa and x.nr_lanctofiscal = w.nr_lanctofiscal ");
            sql.AppendLine("				    where x.cd_empresa = b.cd_empresa and x.nr_lanctoduplicata = b.nr_lancto),0) ");

            sql.AppendLine("from tb_fin_duplicata b ");
            sql.AppendLine("inner join tb_fin_tpduplicata t ");
            sql.AppendLine("on b.tp_duplicata = t.tp_duplicata ");
            sql.AppendLine("inner join tb_fin_clifor c ");
            sql.AppendLine("on b.cd_clifor = c.cd_clifor ");
            sql.AppendLine("inner join tb_fin_parcela a ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = b.nr_lancto ");
            sql.AppendLine("left outer join TB_FIN_Liquidacao liq ");
            sql.AppendLine("on liq.CD_Empresa = A.CD_Empresa ");
            sql.AppendLine("and liq.Nr_lancto = A.Nr_Lancto ");
            sql.AppendLine("and liq.CD_parcela = A.CD_Parcela ");
            sql.AppendLine("and isnull(liq.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and liq.CD_LanctoCaixa_PerdaDup is null ");
            sql.AppendLine("inner join TB_FIN_Caixa caixa ");
            sql.AppendLine("on caixa.cd_lanctocaixa = liq.cd_lanctocaixa ");
            sql.AppendLine("and caixa.cd_contager = liq.cd_contager ");
            sql.AppendLine("inner join tb_div_empresa emp on ");
            sql.AppendLine("emp.cd_empresa = a.cd_empresa ");
            sql.AppendLine("left join tb_fin_contager cg ");
            sql.AppendLine("on cg.cd_contager = liq.cd_contager ");
            sql.AppendLine("left join tb_fin_historico his ");
            sql.AppendLine("on caixa.cd_historico = his.cd_historico ");
            sql.AppendLine("left outer join tb_fin_historico hisdup ");
            sql.AppendLine("on b.cd_historico = hisdup.cd_historico ");
            sql.AppendLine("left outer join TB_FIN_Portador port ");
            sql.AppendLine("on liq.CD_Portador = port.CD_Portador ");

            sql.AppendLine("where isNull(b.st_registro, 'A') <> 'C' ");
            sql.AppendLine("and isNull(a.st_registro, 'A')  in ('L', 'P') ");
            sql.AppendLine("and isnull(liq.st_registro,'A')<>'C' ");
            sql.AppendLine("and liq.CD_LANCTOCAIXA_PERDADUP is null ");
            sql.AppendLine("and not exists(select 1 from TB_COB_Titulo x ");
            sql.AppendLine("               where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("               and x.nr_lancto = a.nr_lancto ");
            sql.AppendLine("               and x.cd_parcela = a.cd_parcela ");
            sql.AppendLine("               and isnull(x.st_registro, 'A') = 'D') ");

            //Excluir liquidacao por agrupamento de duplicata
            sql.AppendLine("and not exists(select 1 from TB_FIN_VincularDup x ");
            sql.AppendLine("                where x.cd_empresa = liq.cd_empresa ");
            sql.AppendLine("                and x.nr_lanctovinculado = liq.nr_lancto ");
            sql.AppendLine("                and x.cd_parcelavinculado = liq.cd_parcela) ");
            //Data Inicial
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), " + (dt_emissao.Checked ? "b.dt_emissao" : dt_vencto.Checked ? "a.dt_vencto" : "liq.dt_liquidacao") + "))) >= '" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'");
            //Data Final
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), " + (dt_emissao.Checked ? "b.dt_emissao" : dt_vencto.Checked ? "a.dt_vencto" : "liq.dt_liquidacao") + "))) <= '" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'");
            //Empresa
            sql.AppendLine("and a.cd_empresa in (" + clbEmpresa.Vl_Busca + ")");
            //Verificar se Usuario tem acesso a TP.Duplicata
            sql.AppendLine("and exists(select 1 from tb_div_usuario_x_tpduplicata x ");
            sql.AppendLine("            where b.tp_duplicata = x.tp_duplicata ");
            sql.AppendLine("            and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')");
            //Tipo Movimento
            if (rbPagar.Checked || rbReceber.Checked)
                sql.AppendLine("and t.tp_mov = '" + (rbPagar.Checked ? "P" : "R") + "'");
            //Clifor
            if (!string.IsNullOrEmpty(cd_clifor.Text))
                sql.AppendLine("and b.cd_clifor = '" + cd_clifor.Text.Trim() + "'");
            if (!string.IsNullOrEmpty(cd_categoriaclifor.Text))
                sql.AppendLine("and c.id_categoriaclifor = '" + cd_categoriaclifor.Text.Trim() + "'");
            //Historico
            if (!string.IsNullOrEmpty(cd_historico.Text))
                sql.AppendLine("and caixa.cd_historico = '" + cd_historico.Text.Trim() + "'");
            //Conta Gerencial
            if (!string.IsNullOrEmpty(cd_contager.Text))
                sql.AppendLine("and cg.cd_contager = '" + cd_contager.Text.Trim() + "'");
            //Condicao pagamento
            if (!string.IsNullOrEmpty(editDefault2.Text))
                sql.AppendLine("and b.cd_condpgto = '" + editDefault2.Text.Trim() + "'");
            //Contrato
            if (!string.IsNullOrEmpty(nr_contrato.Text))
            {
                sql.AppendLine("and exists (select 1 from tb_fat_notafiscal_x_duplicata x ");
                sql.AppendLine("            inner join tb_fat_notafiscal_item y ");
                sql.AppendLine("            on x.cd_empresa = y.cd_empresa ");
                sql.AppendLine("            and x.nr_lanctofiscal = y.nr_lanctofiscal ");
                sql.AppendLine("            inner join vtb_gro_contrato z ");
                sql.AppendLine("            on y.nr_pedido = z.nr_pedido  ");
                sql.AppendLine("            and y.cd_produto = z.cd_produto ");
                sql.AppendLine("            and y.id_pedidoitem = z.id_pedidoitem ");
                sql.AppendLine("            where x.cd_empresa = b.cd_empresa ");
                sql.AppendLine("            and x.nr_lanctoduplicata = b.nr_lancto ");
                sql.AppendLine("            and z.nr_contrato = " + nr_contrato.Text + ")");
            }
            //Pedido
            if (!string.IsNullOrEmpty(nr_pedido.Text))
            {
                sql.AppendLine("and exists (select 1 from tb_fat_notafiscal_x_duplicata x ");
                sql.AppendLine("            inner join tb_fat_notafiscal_item y ");
                sql.AppendLine("            on x.cd_empresa = y.cd_empresa ");
                sql.AppendLine("            and x.nr_lanctofiscal = y.nr_lanctofiscal ");
                sql.AppendLine("            where x.cd_empresa = b.cd_empresa ");
                sql.AppendLine("            and x.nr_lanctoduplicata = b.nr_lancto ");
                sql.AppendLine("            and y.nr_pedido = " + nr_pedido.Text + ") or ");
                sql.AppendLine("            exists (select 1 from TB_FAT_Pedido_X_Duplicata k ");
                sql.AppendLine("                    where k.cd_empresa = b.cd_empresa ");
                sql.AppendLine("                    and k.nr_lancto = b.nr_lancto ");
                sql.AppendLine("                    and k.nr_pedido = " + nr_pedido.Text + ")");
            }
            //Documento
            if (!string.IsNullOrEmpty(nr_docto.Text))
                sql.AppendLine("and b.nr_docto = '" + nr_docto.Text.Trim() + "'");
            if(cbDescontadas.Checked)
            {
                sql.AppendLine("union all ");
                sql.AppendLine("select c.DT_Vencto, c.Vl_Parcela, c.CD_Parcela, f.CD_ContaGer, null as Cd_Portador, null as Ds_Portador, ");
                sql.AppendLine("a.Nr_Lancto, null as Id_Liquid, a.CD_Empresa, a.Nr_Docto, a.CD_Clifor, a.CD_Historico, a.DT_Emissao, ");
                sql.AppendLine("g.CD_Historico, day(g.DT_Lancto), h.DS_Historico, MONTH(g.DT_Lancto), YEAR(g.DT_Lancto), ");
                sql.AppendLine("MONTH(a.DT_Emissao), YEAR(a.DT_Emissao), DAY(a.DT_Emissao), i.DS_Historico, a.DS_Observacao, ");
                sql.AppendLine("j.nm_clifor, isnull(a.complhistorico, ''), case when b.tp_mov = 'P' then 'PAGAS' else 'RECEBIDAS' end, 'DESCONTA', 0, ");
                sql.AppendLine("Vl_Atual = DBO.F_CALC_ATUAL(a.cd_empresa, a.nr_lancto, c.cd_parcela,getDate(), 'N'), ");
                sql.AppendLine("c.vl_parcela_padrao, 0, 0, g.dt_lancto, g.dt_alt, k.nm_empresa, l.ds_contager, null, null, null ");

                sql.AppendLine("from TB_FIN_Duplicata a ");
                sql.AppendLine("inner join TB_FIN_TPDuplicata b ");
                sql.AppendLine("on a.TP_Duplicata = b.TP_Duplicata ");
                sql.AppendLine("inner join TB_FIN_Parcela c ");
                sql.AppendLine("on a.CD_Empresa = c.CD_Empresa ");
                sql.AppendLine("and a.Nr_Lancto = c.Nr_Lancto ");
                sql.AppendLine("inner join TB_COB_Titulo d ");
                sql.AppendLine("on c.CD_Empresa = d.CD_Empresa ");
                sql.AppendLine("and c.Nr_Lancto = d.Nr_Lancto ");
                sql.AppendLine("and c.CD_Parcela = d.CD_Parcela ");
                sql.AppendLine("inner join TB_COB_Lote_X_Titulo e ");
                sql.AppendLine("on d.CD_Empresa = e.CD_Empresa ");
                sql.AppendLine("and d.Nr_Lancto = e.Nr_Lancto ");
                sql.AppendLine("and d.CD_Parcela = e.CD_Parcela ");
                sql.AppendLine("and d.ID_Cobranca = e.ID_Cobranca ");
                sql.AppendLine("inner join TB_COB_Lote_X_Caixa f ");
                sql.AppendLine("on e.ID_Lote = f.ID_Lote ");
                sql.AppendLine("inner join TB_FIN_Caixa g ");
                sql.AppendLine("on f.CD_ContaGer = g.CD_ContaGer ");
                sql.AppendLine("and f.CD_LanctoCaixa = g.CD_LanctoCaixa ");
                sql.AppendLine("inner join TB_FIN_Historico h ");
                sql.AppendLine("on a.CD_Historico = h.CD_Historico ");
                sql.AppendLine("inner join TB_FIN_Historico i ");
                sql.AppendLine("on g.CD_Historico = i.CD_Historico ");
                sql.AppendLine("inner join TB_FIN_Clifor j ");
                sql.AppendLine("on a.CD_Clifor = j.cd_clifor ");
                sql.AppendLine("inner join tb_div_empresa k ");
                sql.AppendLine("on a.cd_empresa = k.cd_empresa ");
                sql.AppendLine("inner join tb_fin_contager l ");
                sql.AppendLine("on g.cd_contager = l.cd_contager ");

                //Data Inicial
                sql.AppendLine("where convert(datetime, floor(convert(decimal(30,10), " + (dt_emissao.Checked ? "a.dt_emissao" : dt_vencto.Checked ? "c.dt_vencto" : "g.DT_Lancto") + "))) >= '" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'");
                //Data Final
                sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), " + (dt_emissao.Checked ? "a.dt_emissao" : dt_vencto.Checked ? "c.dt_vencto" : "g.DT_Lancto") + "))) <= '" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'");
                //Empresa
                sql.AppendLine("and a.cd_empresa in (" + clbEmpresa.Vl_Busca + ")");
                //Verificar se Usuario tem acesso a TP.Duplicata
                sql.AppendLine("and exists(select 1 from tb_div_usuario_x_tpduplicata x ");
                sql.AppendLine("            where a.tp_duplicata = x.tp_duplicata ");
                sql.AppendLine("            and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')");
                //Tipo Movimento
                if (rbPagar.Checked || rbReceber.Checked)
                    sql.AppendLine("and b.tp_mov = '" + (rbPagar.Checked ? "P" : "R") + "'");
                //Clifor
                if (!string.IsNullOrEmpty(cd_clifor.Text))
                    sql.AppendLine("and a.cd_clifor = '" + cd_clifor.Text.Trim() + "'");
                if (!string.IsNullOrEmpty(cd_categoriaclifor.Text))
                    sql.AppendLine("and j.id_categoriaclifor = '" + cd_categoriaclifor.Text.Trim() + "'");
                //Historico
                if (!string.IsNullOrEmpty(cd_historico.Text))
                    sql.AppendLine("and g.cd_historico = '" + cd_historico.Text.Trim() + "'");
                //Conta Gerencial
                if (!string.IsNullOrEmpty(cd_contager.Text))
                    sql.AppendLine("and g.cd_contager = '" + cd_contager.Text.Trim() + "'");
                //Contrato
                if (!string.IsNullOrEmpty(nr_contrato.Text))
                {
                    sql.AppendLine("and exists (select 1 from tb_fat_notafiscal_x_duplicata x ");
                    sql.AppendLine("            inner join tb_fat_notafiscal_item y ");
                    sql.AppendLine("            on x.cd_empresa = y.cd_empresa ");
                    sql.AppendLine("            and x.nr_lanctofiscal = y.nr_lanctofiscal ");
                    sql.AppendLine("            inner join vtb_gro_contrato z ");
                    sql.AppendLine("            on y.nr_pedido = z.nr_pedido  ");
                    sql.AppendLine("            and y.cd_produto = z.cd_produto ");
                    sql.AppendLine("            and y.id_pedidoitem = z.id_pedidoitem ");
                    sql.AppendLine("            where x.cd_empresa = a.cd_empresa ");
                    sql.AppendLine("            and x.nr_lanctoduplicata = a.nr_lancto ");
                    sql.AppendLine("            and z.nr_contrato = " + nr_contrato.Text + ")");
                }
                //Pedido
                if (!string.IsNullOrEmpty(nr_pedido.Text))
                {
                    sql.AppendLine("and exists (select 1 from tb_fat_notafiscal_x_duplicata x ");
                    sql.AppendLine("            inner join tb_fat_notafiscal_item y ");
                    sql.AppendLine("            on x.cd_empresa = y.cd_empresa ");
                    sql.AppendLine("            and x.nr_lanctofiscal = y.nr_lanctofiscal ");
                    sql.AppendLine("            where x.cd_empresa = a.cd_empresa ");
                    sql.AppendLine("            and x.nr_lanctoduplicata = a.nr_lancto ");
                    sql.AppendLine("            and y.nr_pedido = " + nr_pedido.Text + ") or ");
                    sql.AppendLine("            exists (select 1 from TB_FAT_Pedido_X_Duplicata k ");
                    sql.AppendLine("                    where k.cd_empresa = a.cd_empresa ");
                    sql.AppendLine("                    and k.nr_lancto = a.nr_lancto ");
                    sql.AppendLine("                    and k.nr_pedido = " + nr_pedido.Text + ")");
                }
                //Documento
                if (!string.IsNullOrEmpty(nr_docto.Text))
                    sql.AppendLine("and a.nr_docto = '" + nr_docto.Text.Trim() + "'");
            }
            sql.AppendLine("order by year(dt_liquidacao),month(dt_liquidacao) , day(dt_liquidacao), cd_empresa, nm_clifor ");
            BindingSource bs_dup = new BindingSource();
            bs_dup.DataSource = new CamadaDados.TDataQuery().ExecutarBusca(sql.ToString(), null);
            
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_relatorio;
                Rel.DTS_Relatorio = bs_dup;
                if (rbClifor.Checked)
                {
                    Rel.Nome_Relatorio = "REL_FIN_DUPLICATA_LIQUIDADA_C";
                    Rel.NM_Classe = "REL_FIN_DUPLICATA_LIQUIDADA_C";
                }
                else if (rbHistorico.Checked)
                {
                    Rel.Nome_Relatorio = "REL_FIN_DUPLICATA_LIQUIDADA_H";
                    Rel.NM_Classe = "REL_FIN_DUPLICATA_LIQUIDADA_H";
                }
                else if (rbEmissao.Checked)
                {
                    Rel.Nome_Relatorio = "REL_FIN_DUPLICATA_LIQUIDADA_E";
                    Rel.NM_Classe = "REL_FIN_DUPLICATA_LIQUIDADA_E";
                }
                else if (rbLiquidacao.Checked)
                {
                    Rel.Nome_Relatorio = "REL_FIN_DUPLICATA_LIQUIDADA_L";
                    Rel.NM_Classe = "REL_FIN_DUPLICATA_LIQUIDADA_L";
                }
                else if (rbPortador.Checked)
                {
                    Rel.Nome_Relatorio = "REL_FIN_DUPLICATA_LIQUIDADA_P";
                    Rel.NM_Classe = "REL_FIN_DUPLICATA_LIQUIDADA_P";
                }
                else
                {
                    Rel.Nome_Relatorio = "REL_FIN_DUPLICATA_LIQUIDADA_G";
                    Rel.NM_Classe = "REL_FIN_DUPLICATA_LIQUIDADA_G";
                }
                Rel.Modulo = string.Empty;
                Rel.Parametros_Relatorio.Add("DT_INI", dt_ini.Text);
                Rel.Parametros_Relatorio.Add("DT_FIN", dt_fin.Text);
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO DE DUPLICATAS LIQUIDADAS";

                if (Altera_relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                       fImp.pSt_imprimir,
                                       fImp.pSt_visualizar,
                                       fImp.pSt_enviaremail,
                                       fImp.pSt_exportPdf,
                                       fImp.Path_exportPdf,
                                       fImp.pDestinatarios,
                                       null,
                                       "RELATORIO DE DUPLICATAS LIQUIDADAS",
                                       fImp.pDs_mensagem);
                    Altera_relatorio = false;
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
                                           "RELATORIO DE DUPLICATAS LIQUIDADAS",
                                           fImp.pDs_mensagem);
            }
        }

        private void TFRel_DupLiquidada_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            clbEmpresa.Display = "NM_Empresa";
            clbEmpresa.Value = "CD_Empresa";
            //Preencher lista empresa
            clbEmpresa.Tabela = new CamadaDados.Diversos.TCD_CadEmpresa().Buscar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                    "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                    "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                    }
                                }, 0);

            //Ordenar em ordem alfabética
            clbEmpresa.Sorted = true;
            LimparFiltros();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            LimparFiltros();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void cd_categoriaclifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.ID_CategoriaClifor|=|'" + cd_categoriaclifor.Text + "'",
              new Componentes.EditDefault[] { cd_categoriaclifor, nm_categoriaclifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadCategoriaCliFor());
        }

        private void bb_categoriaclifor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_categoriaclifor|Categoria Clifor|200;" +
                             "a.id_categoriaclifor|Id. Categoria|80;" +
                             "a.st_transportadora|Transportadora|80;" +
                             "a.st_fornecedor|Fornecedor|80;" +
                             "a.st_funcionarios|Funcionarios|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas,
                                            new Componentes.EditDefault[] { cd_categoriaclifor, nm_categoriaclifor },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCategoriaCliFor(), string.Empty);
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico|200;" +
                              "a.cd_historico|Codigo|80;" +
                              "a.Tp_Mov|Movimento|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), string.Empty);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_historico|=|'" + cd_historico.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_historico, ds_historico }, new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;" +
                              "a.cd_contager|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager, ds_contager },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contager.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contager, ds_contager }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFRel_DupLiquidada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                LimparFiltros();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Conta Gerencial|200;" +
                              "a.cd_condpgto|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { editDefault2, editDefault1},
                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), string.Empty);
        }

        private void editDefault2_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_condpgto|=|'" + editDefault2.Text.Trim() + "'",
                new Componentes.EditDefault[] { editDefault2, editDefault1 }, new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }
    }
}
