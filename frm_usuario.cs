using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sistema.DAL;

namespace Sistema {
    public partial class frm_usuario : Form {
        public frm_usuario() {
            InitializeComponent();
        }

        private void frm_usuario_Load(object sender, EventArgs e) {
            tbusuarioBindingSource.DataSource = DataContextFactory.DataContext.tb_usuario;
        }

        private void btn_novo_Click(object sender, EventArgs e) {
            tbusuarioBindingSource.AddNew();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e) {
            if (valida()) {
                tbusuarioBindingSource.EndEdit();
                DataContextFactory.DataContext.SubmitChanges();
                MessageBox.Show("Usuário cadastrado com sucesso!");
            }
        }

        private bool valida() {
            if (txt_usuario.Text.Trim() == string.Empty || txt_senha.Text.Trim() == string.Empty) {
                MessageBox.Show("Os campos usuário e senha são obrigatórios!");
                txt_usuario.Focus();
                return false;
            }
            return true;
        }

        private void btn_excluir_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Tem certeza?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                tbusuarioBindingSource.RemoveCurrent();
                DataContextFactory.DataContext.SubmitChanges();
                MessageBox.Show("Usuário excluido com sucesso!");
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e) {
            tbusuarioBindingSource.CancelEdit();
        }
    }
}
