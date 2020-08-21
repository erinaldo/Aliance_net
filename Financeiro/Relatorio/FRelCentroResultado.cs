using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Utils;

namespace Financeiro.Relatorio
{
    public partial class TFRelCentroResultado : Form
    {
        private IEnumerable<XElement> result
        { get; set; }
        private bool Altera_Relatorio = false;
        public TFRelCentroResultado()
        {
            InitializeComponent();
        }

        private void LimparCampos()
        {
            dt_ini.Text = string.Empty;
            dt_fin.Text = string.Empty;
            cd_ccusto.Text = string.Empty;
        }

        private void afterBusca()
        {
            TpBusca[] vBusca = new TpBusca[1];
            //Retirar Centro Resultado Cancelado
            vBusca[0].vNM_Campo = "isnull(b.st_registro, 'A')";
            vBusca[0].vOperador = "<>";
            vBusca[0].vVL_Busca = "'C'";
            Estruturas.CriarParametro(ref vBusca, "a.cd_empresa", "'" + cbEmpresa.SelectedValue.ToString().Trim() + "'");
            if (!string.IsNullOrEmpty(cd_ccusto.Text))
            {
                string[] linha = cd_ccusto.Text.Trim().Split(',');
                string valor = string.Empty;
                for (int i = 0; i < linha.Count(); i++)
                    valor += "a.cd_centroresult like '" + linha[i].Trim() + "%'" + (linha.Count() > (i + 1) ? " or " : string.Empty);
                Estruturas.CriarParametro(ref vBusca, string.Empty, valor, string.Empty);
            }
            if ((!string.IsNullOrEmpty(dt_ini.Text)) && (dt_ini.Text.Trim() != "/  /"))
                Estruturas.CriarParametro(ref vBusca, "a.dt_lancto", "'" + Convert.ToDateTime(dt_ini.Text).ToString("yyyyMMdd").Trim() + "'", ">=");
            if ((!string.IsNullOrEmpty(dt_fin.Text)) && (dt_fin.Text.Trim() != "/  /"))
                Estruturas.CriarParametro(ref vBusca, "a.dt_lancto", "'" + Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd").Trim() + "'", "<=");
            bsCCustoLan.DataSource = new CamadaDados.Financeiro.CCustoLan.TCD_LanCCustoLancto().Select(vBusca, 0, string.Empty);

        }

        private void afterPrint()
        {
            afterBusca();
            IEnumerable <CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto> query = (bsCCustoLan.DataSource as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).OrderBy(c => c.Dt_lancto);
            bsCCustoLan.DataSource = query;
            if (bsCCustoLan.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsCCustoLan;
                    Rel.Nome_Relatorio = "TFRelCentroResultado";
                    Rel.NM_Classe = "TFRelCentroResultado";
                    Rel.Modulo = "FIN";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = Text.Trim();
                    Rel.Parametros_Relatorio.Add("FILTRO", "Período de " + dt_ini.Text + " até " + dt_fin.Text);
                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           Text.Trim(),
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           null,
                                           fImp.pDestinatarios,
                                           Text.Trim(),
                                           fImp.pDs_mensagem);
                }
            }
        }

        private void BuscarPerfilConsulta()
        {
            if (System.IO.File.Exists("C:\\Aliance.NET\\ConsultaCentroResultado.xml"))
            {
                lvConsulta.Clear();
                XElement xml = XElement.Load("C:\\Aliance.NET\\ConsultaCentroResultado.xml");
                //Verificar se existe elemento para a consulta
                result =
                   from x in xml.Elements("Centro")
                   select x;
                foreach (XElement r in result)
                    lvConsulta.Items.Add(r.Attribute("Nome").Value);
            }
        }

        private void TFRelCentroResultado_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            cd_ccusto.Text = "Clique em ENTER ou TAB, ou selecione a Lista de Consulta ao lado.";
            BuscarPerfilConsulta();
            dt_ini.Focus();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void cd_ccusto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                using (TFBuscaCentroResult fBusca = new TFBuscaCentroResult())
                {
                    fBusca.St_processar = true;
                    if (fBusca.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                            cd_ccusto.Text = fBusca.Cd_centro;
                }
        }

        private void bb_salvarConsulta_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_ccusto.Text) && !cd_ccusto.Text.Equals("Clique em ENTER ou TAB, ou selecione a Lista de Consulta ao lado.".ToUpper()))
            {
                InputBox ibp = new InputBox();
                ibp.Text = "Descrição Anexo";
                string ds = ibp.ShowDialog();
                if (string.IsNullOrEmpty(ds))
                {
                    MessageBox.Show("Obrigatório informar Nome da Consulta!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!System.IO.File.Exists("C:\\Aliance.NET\\ConsultaCentroResultado.xml"))
                {
                    XElement xml = new XElement("consulta",
                                                   new XElement("Centro",
                                                                  new XAttribute("Nome", ds.ToUpper()),
                                                                  new XAttribute("busca", cd_ccusto.Text.Trim())));
                    xml.Save("C:\\Aliance.NET\\ConsultaCentroResultado.xml");
                }
                else
                {
                    XElement xml = XElement.Load("C:\\Aliance.NET\\ConsultaCentroResultado.xml");
                    xml.Add(new XElement("Centro",
                                         new XAttribute("Nome", ds.ToUpper()),
                                         new XAttribute("busca", cd_ccusto.Text.Trim())));
                    xml.Save("C:\\Aliance.NET\\ConsultaCentroResultado.xml");
                }
                BuscarPerfilConsulta();
            }
        }

        private void lvConsulta_DoubleClick(object sender, EventArgs e)
        {
            if (result != null)
                foreach (XElement r in result)
                    if (r.Attribute("Nome").Value.Equals(lvConsulta.FocusedItem.Text.Trim()))
                        cd_ccusto.Text = r.Attribute("busca").Value;
            dt_ini.Focus();
        }

        private void TFRelCentroResultado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                LimparCampos();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_Relatorio = true;
            }
        }
    }
}
