using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utils;

namespace Frota
{
    public partial class TFListaNFeMDFe : Form
    {
        public string pCd_empresa
        { get; set; }

        public List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento> lNFe
        {
            get
            {
                if (bsNFe.Count > 0)
                    return (bsNFe.List as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento).FindAll(p => p.St_formarlotectrc);
                else return null;
            }
        }

        public TFListaNFeMDFe()
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
            //NFe
            filtro[1].vNM_Campo = "a.cd_modelo";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'55'";
            //Ativo
            filtro[2].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[2].vOperador = "<>";
            filtro[2].vVL_Busca = "'C'";
            //Transmitido se for propria ou sem protocolo se for terceiro
            filtro[3].vNM_Campo = "case when a.tp_nota = 'P' then isnull(a.nr_protocolo, '') else isnull(a.nr_protocolo, '') end";
            filtro[3].vOperador = "=";
            filtro[3].vVL_Busca = "case when a.tp_nota = 'P' then isnull(a.nr_protocolo, '1') else '' end";
            //Não existir em um MDFe
            filtro[4].vNM_Campo = string.Empty;
            filtro[4].vOperador = "not exists";
            filtro[4].vVL_Busca = "(select 1 from tb_ctr_mdfe_documentos x " +
                                  "inner join tb_ctr_mdfe y " +
                                  "on x.cd_empresa = y.cd_empresa " +
                                  "and x.id_mdfe = y.id_mdfe " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                  "and isnull(y.st_registro, 'A') <> 'C')";
            //Não pode ser servico
            filtro[5].vNM_Campo = "e.Tp_Serie";
            filtro[5].vOperador = "<>";
            filtro[5].vVL_Busca = "'S'";
            if (!string.IsNullOrEmpty(nr_notafiscal.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_notafiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_notafiscal.Text;
            }
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_clifor.Text.Trim() + "'";
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
            if(cbTpNota.SelectedIndex >= 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_nota";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cbTpNota.SelectedIndex == 0 ? "'P'" : "'T'";
            }
            if(cbMov.SelectedIndex >= 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cbMov.SelectedIndex == 0 ? "'E'" : "'S'";
            }
            bsNFe.DataSource = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(filtro, 0, string.Empty);
        }

        private void TFListaNFeMDFe_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFListaNFeMDFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void gNFe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).St_formarlotectrc =
                    !(bsNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).St_formarlotectrc;
                bsNFe.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsNFe.Count > 0)
            {
                (bsNFe.List as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento).ForEach(p => p.St_formarlotectrc = cbTodos.Checked);
                bsNFe.ResetBindings(true);
            }
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }
    }
}
