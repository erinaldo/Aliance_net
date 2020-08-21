using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Idioma
{
    public class TIdioma
    {
        

        private static void AlteraThreadIdioma()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                new System.Globalization.CultureInfo(Utils.Parametros.pubCultura, true);
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo(Utils.Parametros.pubCultura, true);
        }

        private static void AlteraCultura(System.Windows.Forms.Control frm,
                                          System.ComponentModel.ComponentResourceManager rsx)
        {
            if(frm is System.Windows.Forms.Form)
                frm.Text = rsx.GetObject("$this.Text",
                                        System.Threading.Thread.CurrentThread.CurrentCulture).ToString();
            foreach (System.Windows.Forms.Control ctrl in frm.Controls)
            {
                if ((ctrl is System.Windows.Forms.TabControl) ||
                    (ctrl is System.Windows.Forms.TableLayoutPanel) ||
                    (ctrl is System.Windows.Forms.Panel) ||
                    (ctrl is System.Windows.Forms.GroupBox) ||
                    (ctrl is Componentes.CheckedListBoxDefault) ||
                    (ctrl is Componentes.PanelDados) ||
                    (ctrl is Componentes.RadioGroup))
                    AlteraCultura(ctrl, rsx);
                rsx.ApplyResources(ctrl, ctrl.Name, System.Threading.Thread.CurrentThread.CurrentCulture);
            }
        }

        public static void AjustaCultura(System.Windows.Forms.Form frm)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
            {
                AlteraThreadIdioma();
                System.ComponentModel.ComponentResourceManager resx =
                    new System.ComponentModel.ComponentResourceManager(frm.GetType());
                AlteraCultura(frm, resx);
            }
        }
    }
}
