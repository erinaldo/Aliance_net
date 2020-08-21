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
    public partial class TFConsultaCliente : Form
    {
        public string pCd_empresa
        { get; set; }

        public TFConsultaCliente()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (!string.IsNullOrEmpty(Cd_clifor.Text))
            {
                //Buscar dados clifor
                bsClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(Cd_clifor.Text,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    false,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    1,
                                                                                                    null);
                if (bsClifor.Count > 0)
                {
                    //Buscar endereco clifor
                    (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lEndereco =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(Cd_clifor.Text,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  0,
                                                                                  null);
                    //Buscar contatos clifor
                    (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lContato =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                       Cd_clifor.Text,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       false,
                                                                                       false,
                                                                                       false,
                                                                                       string.Empty,
                                                                                       0,
                                                                                       null);
                    bsClifor.ResetCurrentItem();
                }
                //Buscar dados credito clifor
                CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados = new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(Cd_clifor.Text, 
                                                                                              decimal.Zero, 
                                                                                              true,
                                                                                              ref rDados, 
                                                                                              null);
                vl_limitecredito.Value = rDados.Vl_limitecredito;
                vl_debitoaberto.Value = rDados.Vl_debito_aberto;
                saldo_credito.Value = vl_limitecredito.Value > decimal.Zero ? vl_limitecredito.Value - vl_debitoaberto.Value : decimal.Zero;
                if ((vl_limitecredito.Value > decimal.Zero) && (saldo_credito.Value < vl_financeiro.Value))
                    lblSaldoCredito.ForeColor = Color.Red;
                vl_debitovencido.Value = rDados.Vl_debito_vencto;
                st_bloq_debitovencido.Checked = rDados.St_bloq_debitovencidobool;
                if (st_bloq_debitovencido.Checked && (vl_debitovencido.Value > decimal.Zero))
                    lblDebVencto.ForeColor = Color.Red;
                st_bloqavulso.Checked = rDados.St_bloqcreditoavulsobool;
                ds_motivo.Text = rDados.Ds_motivobloqavulso;
                if (st_bloqavulso.Checked)
                    lblMotivo.ForeColor = Color.Red;
                st_renovarcadastro.Checked = rDados.St_renovarcadastro;
                dt_renovacaocadastro.Text = rDados.Dt_renovacaocadastro.HasValue ? rDados.Dt_renovacaocadastro.Value.ToString("dd/MM/yyyy") : string.Empty;
                if (st_renovarcadastro.Checked)
                    lblRenovacao.ForeColor = Color.Red;
                tot_chdevolvido.Value = rDados.Vl_ch_devolvido;
                if (tot_chdevolvido.Value > decimal.Zero)
                    lblChDevolvido.ForeColor = Color.Red;
                vl_limiteCH.Value = rDados.Vl_limitecredCH;
                vl_ch_predatado.Value = rDados.Vl_ch_predatado;
                saldo_credCH.Value = vl_limiteCH.Value > decimal.Zero ? vl_limiteCH.Value - vl_ch_predatado.Value : decimal.Zero;
                if ((vl_limiteCH.Value > decimal.Zero) && (saldo_credCH.Value < vl_financeiro.Value))
                    lblSaldoCredCH.ForeColor = Color.Red;

                //Buscar convenio
                Utils.TpBusca[] filtro = new Utils.TpBusca[6];
                //Empresa
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + cd_posto.Text.Trim() + "'";
                //Cliente
                filtro[1].vNM_Campo = "a.cd_clifor";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "'" + Cd_clifor.Text.Trim() + "'";
                //Status convenio
                filtro[2].vNM_Campo = "isnull(conv.st_registro, 'A')";
                filtro[2].vOperador = "=";
                filtro[2].vVL_Busca = "'A'";
                //Convenio nao expirado
                filtro[3].vNM_Campo = "CONVERT(datetime, floor(convert(decimal(30,10), case when conv.DiasValidade = 0 then getdate() else DATEADD(DAY, conv.DiasValidade, conv.DT_Convenio) end)))";
                filtro[3].vOperador = ">=";
                filtro[3].vVL_Busca = "CONVERT(datetime, floor(convert(decimal(30,10), getdate())))";
                //Status convenio x clifor
                filtro[4].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[4].vOperador = "=";
                filtro[4].vVL_Busca = "'A'";
                //Saldo litros convenio
                filtro[5].vNM_Campo = "case when a.qtd_convenio > 0 then a.qtd_convenio - a.qtd_vendida else 1 end";
                filtro[5].vOperador = ">";
                filtro[5].vVL_Busca = "0";
                bsConvenioClifor.DataSource = new CamadaDados.PostoCombustivel.TCD_Convenio_Clifor().Select(filtro, 0, string.Empty);
                bsConvenioClifor_PositionChanged(this, new EventArgs());
            }
        }

        private void TFConsultaCliente_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pFiltro.set_FormatZero();
            cd_posto.Text = this.pCd_empresa;
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_clifor, NM_Clifor }, string.Empty);
            this.afterBusca();
        }

        private void Cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + Cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { Cd_clifor, NM_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.afterBusca();
        }

        private void bsConvenioClifor_PositionChanged(object sender, EventArgs e)
        {
            if (bsConvenioClifor.Current != null)
            {
                //Buscar placa
                (bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).lPlaca =
                    CamadaNegocio.PostoCombustivel.TCN_Convenio_Placa.Buscar((bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Id_conveniostr,
                                                                             (bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Cd_empresa,
                                                                             (bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Cd_clifor,
                                                                             (bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Cd_endereco,
                                                                             (bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Cd_produto,
                                                                             null);
                //Buscar motorista
                (bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).lMotorista =
                    CamadaNegocio.PostoCombustivel.TCN_Motorista_Convenio.Buscar((bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Id_conveniostr,
                                                                                 (bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Cd_empresa,
                                                                                 (bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Cd_clifor,
                                                                                 (bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Cd_endereco,
                                                                                 (bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Cd_produto,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 null);
                bsConvenioClifor.ResetCurrentItem();
            }
        }        
    }
}
