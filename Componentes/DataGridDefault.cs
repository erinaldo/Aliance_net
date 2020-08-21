using System.ComponentModel;
using System.Windows.Forms;

namespace Componentes
{
    public partial class DataGridDefault : DataGridView
    {
        public DataGridDefault()
        {
            InitializeComponent();
            AutoGenerateColumns = false;
        }

        public DataGridDefault(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            AutoGenerateColumns = false;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                e.SuppressKeyPress = true;
            else
                base.OnKeyDown(e);
        }

        protected override void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
