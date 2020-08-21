using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Bloqueto;
using System.Windows.Forms;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Bloqueto;

namespace FormRelPadrao
{
    public class TCN_LayoutBloqueto
    {
        public static void Imprime_Bloqueto(bool Altera_Bloqueto,
                                            List<blTitulo> lBloqueto,
                                            bool St_imprimir,
                                            bool St_visualizar,
                                            bool St_enviaremail,
                                            bool St_exportpdf,
                                            string Path_exportpdf,
                                            List<string> Destinatarios,
                                            string Titulo,
                                            string Mensagem,
                                            bool St_carne)
        {
            //Buscar configuracao de layout de impressao de bloqueto
            if (lBloqueto.Count > 0)
            {
                Relatorio Relatorio = new Relatorio();
                Relatorio.Altera_Relatorio = Altera_Bloqueto;
                BindingSource Bin = new BindingSource();
                Bin.DataSource = lBloqueto;

                Relatorio.DTS_Relatorio = Bin;
                if(St_carne || lBloqueto[0].Tp_layoutbloqueto.Trim().ToUpper().Equals("C"))
                {
                    Relatorio.Nome_Relatorio = "TFBloquetoCarne";
                    Relatorio.NM_Classe = "TFBloquetoCarne";
                }
                else
                {
                    Relatorio.Nome_Relatorio = "TFConsultaBloquetos_Bloqueto";
                    Relatorio.NM_Classe = "TFConsultaBloquetos_Bloqueto";
                }
                Relatorio.Modulo = "FIN";
                Relatorio.Parametros_Relatorio.Add("IMAGEM_BANCO", (Bin.Current as blTitulo).Logo_banco);
                Relatorio.Gera_Relatorio((Bin.Current as blTitulo).Nosso_numero.Trim(),
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
}
