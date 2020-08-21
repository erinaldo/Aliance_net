using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormRelPadrao
{
    public class TCN_LayoutDuplicata
    {
        public static void Imprime_Duplicata(bool Altera_relatorio,
                                             List<CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela> lParc,
                                             CamadaDados.Diversos.TList_CadEmpresa lEmpresa,
                                             CamadaDados.Financeiro.Cadastros.TList_CadClifor lSacado,
                                             bool St_imprimir,
                                             bool St_visualizar,
                                             bool St_exportpdf,
                                             string Path_exportpdf,
                                             bool St_enviaremail,
                                             List<string> Destinatarios,
                                             string Titulo,
                                             string Mensagem)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Altera_Relatorio = Altera_relatorio;
            System.Windows.Forms.BindingSource Bin = new System.Windows.Forms.BindingSource();
            Bin.DataSource = lParc;

            Relatorio.DTS_Relatorio = Bin;
            Relatorio.Nome_Relatorio = "TFDuplicata";
            Relatorio.NM_Classe = "TFDuplicata";
            Relatorio.Modulo = "FIN";

            Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlImagem("IMAGEM_RELATORIO", string.Empty, null));

            System.Windows.Forms.BindingSource bsEmpresa = new System.Windows.Forms.BindingSource();
            bsEmpresa.DataSource = lEmpresa;

            System.Windows.Forms.BindingSource bsSacado = new System.Windows.Forms.BindingSource();
            bsSacado.DataSource = lSacado;

            Relatorio.Adiciona_DataSource("DTS_EMPRESA", bsEmpresa);
            Relatorio.Adiciona_DataSource("DTS_SACADO", bsSacado);

            Relatorio.Gera_Relatorio(string.Empty,
                                     St_imprimir,
                                     St_visualizar,
                                     St_enviaremail,
                                     St_exportpdf,
                                     Path_exportpdf,
                                     Destinatarios,
                                     null,
                                     Titulo,
                                     Mensagem);
        }
    }
}
