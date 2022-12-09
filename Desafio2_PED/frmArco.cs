using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio2_PED
{
    public partial class frmArco : Form
    {

        public bool control;
        public string dato;
        public frmArco()
        {
            InitializeComponent();
            control = false;
            dato = "";
            txtArco.Clear();
            txtArco.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dato = txtArco.Text.Trim();

            if((dato == "") || (dato == " "))
            {
                MessageBox.Show("Debes ingresar un valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                control = true;
                Hide();
            }
        }

        private void frmArco_Load(object sender, EventArgs e)
        {
            txtArco.Clear();
            txtArco.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            control = false;
            Hide();
        }

        private void frmArco_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void txtArco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(null, null);
            }
        }
    }
}
