using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Frota
{
    public partial class TFListaCTeMDFe : Form
    {
        public string pCd_empresa
        { get; set; }
        public List<CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete> lCte
        {
            get
            {
                if (bsCTe.Count > 0)
                    return (bsCTe.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).FindAll(p => p.St_processar);
                else return null;
            }
        }

        public TFListaCTeMDFe()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            TpBusca[] filtro = new TpBusca[6];
            //Empresa
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            //Tipo Nota
            filtro[1].vNM_Campo = "a.tp_emissao";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'P'";
            //NFe
            filtro[2].vNM_Campo = "a.cd_modelo";
            filtro[2].vOperador = "=";
            filtro[2].vVL_Busca = "'57'";
            //Ativo
            filtro[3].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[3].vOperador = "<>";
            filtro[3].vVL_Busca = "'C'";
            //Transmitido
            filtro[4].vNM_Campo = "a.Nr_protocolo";
            filtro[4].vOperador = "is not";
            filtro[4].vVL_Busca = "null";
            //Não existir em um MDFe
            filtro[5].vNM_Campo = string.Empty;
            filtro[5].vOperador = "not exists";
            filtro[5].vVL_Busca = "(select 1 from tb_ctr_mdfe_documentos x " +
                                  "inner join tb_ctr_mdfe y " +
                                  "on x.cd_empresa = y.cd_empresa " +
                                  "and x.id_mdfe = y.id_mdfe " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.nr_lanctoctr = a.nr_lanctoctr " +
                                  "and isnull(y.st_registro, 'A') <> 'C')";
            if (!string.IsNullOrEmpty(nr_cte.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_ctrc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_cte.Text;
            }
            if (!string.IsNullOrEmpty(cd_remetente.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_remetente";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_remetente.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_destinatario.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_destinatario";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_destinatario.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(dt_ini.Text.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(dt_fin.Text.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
            }
            bsCTe.DataSource = new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().Select(filtro, 0, string.Empty);
        }

        private void TFListaCTeMDFe_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaCTeMDFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void gCte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_processar =
                    !(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_processar;
                bsCTe.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsCTe.Count > 0)
            {
                (bsCTe.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).ForEach(p => p.St_processar = cbTodos.Checked);
                bsCTe.ResetBindings(true);
            }
        }

        private void bb_remetente_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_remetente }, string.Empty);
        }

        private void cd_remetente_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_remetente.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_remetente }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_destinatario_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_destinatario }, string.Empty);
        }

        private void cd_destinatario_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_destinatario.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_destinatario }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }
    }
}
