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
    public partial class frm_login : Form {

        public bool logado = false;

        public frm_login() {
            InitializeComponent();
        }

        private void efetuarLogin() {
            var user = DataContextFactory.DataContext.tb_usuario.Count(x => x.usuario== txt_usuario.Text && x.senha == txt_senha.Text);
            if (user > 0) {
                logado = true;
                Dispose();
            }
            else {
                MessageBox.Show("Usuário ou senha Incorreta!");
            }
            
        }

        private void btn_login_Click(object sender, EventArgs e) {
            efetuarLogin();
        }

        private void btn_sair_Click(object sender, EventArgs e) {
            Dispose();
        }
    }
}
