using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proc_Commoditties
{
    public class TProcessaDesdobroEspecial
    {
        public static void ProcessarDesdobroEspecial(string Nr_pedidoorig,
                                                     CamadaDados.Balanca.TList_DesdobroEspecial val,
                                                     DateTime? Dt_aplicacao)
        {
            val.ForEach(p =>
                {
                    if (p.Id_transf == null)
                    {
                        //Para cada item da lista, criar objeto Transferencia
                        using (TFTransfContrato fTransf = new TFTransfContrato())
                        {

                            fTransf.Nr_pedidoorig = Nr_pedidoorig;
                            fTransf.Nr_pedidodest = p.Nr_pedidodeststr;
                            fTransf.Dt_transf = Dt_aplicacao;
                            fTransf.Qtd_transf = p.Peso_desdobro;
                            fTransf.St_desdobroespecial = true;
                            if (fTransf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                //Para cada objeto Transferencia, chamar metodo processar para criar objetos NF correspondentes
                                TProcessaTransferencia.GerarTransferencia(fTransf.rTransf);
                                //Acrescentar objeto transferencia a 
                                p.rTransf = fTransf.rTransf;
                            }
                            else
                                throw new Exception("Obrigatorio informar dados transferencia para processar desdobros especiais.");
                        }
                    }
                });
        }
    }
}
