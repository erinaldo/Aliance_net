using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFMedicaoTanque : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public DateTime? Dt_lmc
        { get; set; }
        public string Cd_combustivel
        { get; set; }
        public bool St_abertura
        { get; set; }

        private CamadaDados.PostoCombustivel.TRegistro_MedicaoTanque rmedicao;
        public CamadaDados.PostoCombustivel.TRegistro_MedicaoTanque rMedicao
        {
            get
            {
                if(bsMedicao.Current != null)
                    return bsMedicao.Current as CamadaDados.PostoCombustivel.TRegistro_MedicaoTanque;
                else
                    return null;
            }
            set { rmedicao = value; }
        }

        public TFMedicaoTanque()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ABERTURA", "A"));
            cbx.Add(new Utils.TDataCombo("FECHAMENTO", "F"));

            tp_medicao.DataSource = cbx;
            tp_medicao.DisplayMember = "Display";
            tp_medicao.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (qtd_combustivel.Focused)
                (bsMedicao.Current as CamadaDados.PostoCombustivel.TRegistro_MedicaoTanque).Qtd_combustivel = qtd_combustivel.Value;
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void BuscarDetalhes()
        {
            if ((!string.IsNullOrEmpty(cd_empresa.Text)) &&
                (!string.IsNullOrEmpty(id_tanque.Text)) &&
                (dt_medicao.Text.Trim() != "/  /") &&
                (tp_medicao.SelectedValue != null))
            {
                //Buscar Ultima afericao tanque
                object obj = new CamadaDados.PostoCombustivel.TCD_MedicaoTanque().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_tanque",
                                        vOperador = "=",
                                        vVL_Busca = id_tanque.Text
                                    }
                                }, "a.qtd_combustivel", string.Empty, "a.dt_medicao desc", null);
                if (obj != null)
                    ultima_afericao.Value = decimal.Parse(obj.ToString());
                //Buscar volume vendido
                obj = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "c.id_tanque",
                                vOperador = "=",
                                vVL_Busca = id_tanque.Text
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "ISNULL(a.ST_Afericao, 'N')",
                                vOperador = "<>",
                                vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abastecimento)))",
                                vOperador = "=",
                                vVL_Busca = "'" + (tp_medicao.SelectedValue.ToString().Equals("A") ? dt_medicao.Data.AddDays(-1).ToString("yyyyMMdd") : dt_medicao.Data.ToString("yyyyMMdd")) + "'"
                            }
                        }, "isnull(sum(isnull(a.volumeabastecido, 0)), 0)");
                if (obj != null)
                    vendas_dia.Value = decimal.Parse(obj.ToString());
                //Buscar compras dia
                obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "nf.tp_movimento",
                                vOperador = "=",
                                vVL_Busca = "'E'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(nfcmi.st_mestra, 'N')",
                                vOperador = "<>",
                                vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(nf.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), nf.dt_saient)))",
                                vOperador = "=",
                                vVL_Busca = "'" + (tp_medicao.SelectedValue.ToString().Equals("A") ? dt_medicao.Data.AddDays(-1).ToString("yyyyMMdd") : dt_medicao.Data.ToString("yyyyMMdd")) + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_pdc_tanque x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.cd_local = a.cd_local " +
                                            "and x.id_tanque = " + id_tanque.Text + ")"
                            }
                        }, "isnull(sum(isnull(a.Quantidade, 0)), 0)");
                if (obj != null)
                    compras_dia.Value = decimal.Parse(obj.ToString());
            }
        }

        private void TFMedicaoTanque_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            if (rmedicao != null)
            {
                bsMedicao.DataSource = new CamadaDados.PostoCombustivel.TList_MedicaoTanque() { rmedicao };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                id_tanque.Enabled = false;
                bb_tanque.Enabled = false;
            }
            else
            {
                bsMedicao.AddNew();
                cd_empresa.Text = Cd_empresa;
                nm_empresa.Text = Nm_empresa;
                cd_empresa.Enabled = string.IsNullOrEmpty(Cd_empresa);
                bb_empresa.Enabled = string.IsNullOrEmpty(Cd_empresa);
                dt_medicao.Text = Dt_lmc.HasValue ? Dt_lmc.Value.ToString() : string.Empty;
            }
            BuscarDetalhes();
            cd_empresa.Focus();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFMedicaoTanque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(id_tanque.Text))
                vParam = "|exists|(select 1 from tb_pdc_tanque x " +
                         "      where x.cd_empresa = a.cd_empresa " +
                         "      and x.id_tanque = " + id_tanque.Text + ")";
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, vParam);
            this.BuscarDetalhes();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(id_tanque.Text))
                vParam += ";|exists|(select 1 from tb_pdc_tanque x " +
                          "     where x.cd_empresa = a.cd_empresa " +
                          "     and x.id_tanque = " + id_tanque.Text + ")";
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa(vParam, new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            this.BuscarDetalhes();
        }

        private void bb_tanque_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_tanque|Id. Tanque|80;" +
                              "a.cd_produto|Cd. Combustivel|80;" +
                              "e.ds_produto|Combustivel|200;" +
                              "sg_produto|Unidade|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';isnull(g.st_lubrificante, 'N')|<>|'S'";
            if (!string.IsNullOrEmpty(cd_empresa.Text))
                vParam += ";a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(Cd_combustivel))
                vParam += ";a.cd_produto|=|'" + Cd_combustivel + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_tanque, cd_combustivel, ds_combustivel, sigla_unidade },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_TanqueCombustivel(), vParam);
            this.BuscarDetalhes();
        }

        private void id_tanque_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_tanque|=|" + id_tanque.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(g.st_lubrificante, 'N')|<>|'S'";
            if (!string.IsNullOrEmpty(cd_empresa.Text))
                vParam += ";a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(Cd_combustivel))
                vParam += ";a.cd_produto|=|'" + Cd_combustivel.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_tanque, cd_combustivel, ds_combustivel, sigla_unidade },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_TanqueCombustivel());
            this.BuscarDetalhes();
        }

        private void bb_funcionario_Click(object sender, EventArgs e)
        {
            string vParam = "a.st_funcionarios|=|'S'";
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_funcionario, nm_funcionario }, vParam);
        }

        private void cd_funcionario_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_funcionario.Text.Trim() + ";" +
                            "a.st_funcionarios|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LeaveClifor(vParam, new Componentes.EditDefault[] { cd_funcionario, nm_funcionario },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void dt_medicao_Leave(object sender, EventArgs e)
        {
            if(Dt_lmc.HasValue)
                if(dt_medicao.Text.Trim() != "/  /")
                    if (St_abertura)
                    {
                        if (DateTime.Parse(dt_medicao.Text).Date > Dt_lmc.Value.Date)
                        {
                            MessageBox.Show("Data medição não pode ser maior que data do LCM.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dt_medicao.Focus();
                        }
                    }
                    else if (DateTime.Parse(dt_medicao.Text).Date < Dt_lmc.Value.Date)
                    {
                        MessageBox.Show("Data medição não pode ser menor que data do LCM.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dt_medicao.Focus();
                    }
            this.BuscarDetalhes();
        }

        private void bb_calcmedicao_Click(object sender, EventArgs e)
        {
            if ((ultima_afericao.Value - vendas_dia.Value + compras_dia.Value) < 0)
                MessageBox.Show("Não é permitido medição negativa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                qtd_combustivel.Value = ultima_afericao.Value - vendas_dia.Value + compras_dia.Value;

        }

        private void tp_medicao_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BuscarDetalhes();
        }

        private void qtd_combustivel_Leave(object sender, EventArgs e)
        {
            



        }
    }
}
