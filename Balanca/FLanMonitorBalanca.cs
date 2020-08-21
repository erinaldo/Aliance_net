using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Balanca
{
    public partial class TFLanMonitorBalanca : Form
    {
        public TFLanMonitorBalanca()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            //Buscar Tickets cancelados
            TpBusca[] filtro = new TpBusca[1];
            filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'C'";
            if (cbEmpresa.SelectedValue != null)
                Utils.Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + cbEmpresa.SelectedValue.ToString() + "'");
            if ((!string.IsNullOrEmpty(DT_Inicial.Text)) && (DT_Inicial.Text.Trim() != "/  /"))
                Utils.Estruturas.CriarParametro(ref filtro, "a.dt_bruto", "'" + DateTime.Parse(DT_Inicial.Text).ToString("yyyyMMdd HH:mm") + "'", ">=");
            if ((!string.IsNullOrEmpty(DT_Final.Text)) && (DT_Final.Text.Trim() != "/  /"))
                Utils.Estruturas.CriarParametro(ref filtro, "a.dt_bruto", "'" + DateTime.Parse(DT_Final.Text).ToString("yyyyMMdd HH:mm") + "'", "<=");
            bsTicketsCancelados.DataSource = new CamadaDados.Balanca.TCD_LanPesagemGraos().Select(filtro, string.Empty, string.Empty, 0, string.Empty);

            //Buscar Tickets com pesagem manual
            filtro = new TpBusca[1];
            filtro[0].vNM_Campo = "a.tp_captura_bruto";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'M' or a.tp_captura_tara = 'M' ";
            if (cbEmpresa.SelectedValue != null)
                Utils.Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + cbEmpresa.SelectedValue.ToString() + "'");
            if ((!string.IsNullOrEmpty(DT_Inicial.Text)) && (DT_Inicial.Text.Trim() != "/  /"))
                Utils.Estruturas.CriarParametro(ref filtro, "a.dt_bruto", "'" + DateTime.Parse(DT_Inicial.Text).ToString("yyyyMMdd HH:mm") + "'", ">=");
            if ((!string.IsNullOrEmpty(DT_Final.Text)) && (DT_Final.Text.Trim() != "/  /"))
                Utils.Estruturas.CriarParametro(ref filtro, "a.dt_bruto", "'" + DateTime.Parse(DT_Final.Text).ToString("yyyyMMdd HH:mm") + "'", "<=");
            bsTicketsManuais.DataSource = new CamadaDados.Balanca.TCD_LanPesagemGraos().Select(filtro, string.Empty, string.Empty, 0, string.Empty);

            //Buscar NFe Canceladas
            filtro = new TpBusca[2];
            filtro[0].vNM_Campo = "a.cd_evento";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'110111'";
            filtro[1].vNM_Campo = "a.st_registro";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'T'";
            if (cbEmpresa.SelectedValue != null)
                Utils.Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + cbEmpresa.SelectedValue.ToString() + "'");
            if ((!string.IsNullOrEmpty(DT_Inicial.Text)) && (DT_Inicial.Text.Trim() != "/  /"))
                Utils.Estruturas.CriarParametro(ref filtro, "a.dt_evento", "'" + DateTime.Parse(DT_Inicial.Text).ToString("yyyyMMdd HH:mm") + "'", ">=");
            if ((!string.IsNullOrEmpty(DT_Final.Text)) && (DT_Final.Text.Trim() != "/  /"))
                Utils.Estruturas.CriarParametro(ref filtro, "a.dt_evento", "'" + DateTime.Parse(DT_Final.Text).ToString("yyyyMMdd HH:mm") + "'", "<=");
            bsNfCanceladas.DataSource = new CamadaDados.Faturamento.NFE.TCD_EventoNFe().Select(filtro, 0, string.Empty);
        }

        private void TFLanMonitorBalanca_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
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
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanMonitorBalanca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }
    }
}
