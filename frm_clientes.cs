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
    public partial class frm_clientes : Form {
        public frm_clientes() {
            InitializeComponent();
        }

        private void frm_clientes_Load(object sender, EventArgs e) {
            clienteBindingSource.DataSource = DataContextFactory.DataContext.Cliente;
        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void label7_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void label6_Click(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label8_Click(object sender, EventArgs e) {

        }

        private void btn_novo_Click(object sender, EventArgs e) {
            clienteBindingSource.AddNew();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e) {
            if (valida()) {
                clienteBindingSource.EndEdit();
                DataContextFactory.DataContext.SubmitChanges();
                dataGridView1.Refresh();
                MessageBox.Show("Cliente cadastrado com sucesso!");
            }
           
        }

        public bool valida() {
            if (txt_cliente.Text.Trim() == string.Empty || txt_tel.Text.Trim() == string.Empty || txt_endereco.Text.Trim() == string.Empty || txt_nº.Text.Trim() == string.Empty || txt_bairro.Text.Trim() == string.Empty || txt_cidade.Text.Trim() == string.Empty) {
                MessageBox.Show("Apenas os campos 'COMPLEMENTO' e 'E-MAIL' são opcionais, os demais são obrigatórios!");
                txt_cliente.Focus();
                txt_tel.Focus();
                txt_endereco.Focus();
                txt_nº.Focus();
                txt_bairro.Focus();
                txt_cidade.Focus();
                return false;
            }
            return true;
        }

        private void btn_excluir_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Tem certeza?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                clienteBindingSource.RemoveCurrent();
                DataContextFactory.DataContext.SubmitChanges();
                MessageBox.Show("Cliente excluido com sucesso!");
            }
            
        }

        private void btn_cancelar_Click(object sender, EventArgs e) {
            clienteBindingSource.CancelEdit();
        }
    }
}
