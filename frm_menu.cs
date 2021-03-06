﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sistema {
    public partial class frm_menu : Form {
        public frm_menu() {
            InitializeComponent();
        }

        private void frm_menu_Load(object sender, EventArgs e) {

        }

        private void btn_cad_produtos_Click(object sender, EventArgs e) {
            frm_produtos frm = new frm_produtos();
            frm.Show();
        }

        private void btn_cad_categorias_Click(object sender, EventArgs e) {
            frm_categorias frm = new frm_categorias();
            frm.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e) {
            frm_produtos frm = new frm_produtos();
            frm.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e) {
            frm_categorias frm = new frm_categorias();
            frm.Show();
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e) {
            frm_consultaProdutos frm = new frm_consultaProdutos();
            frm.Show();
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e) {
            frm_venda frm = new frm_venda();
            frm.Show();
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e) {
            frm_consultaProdutos frm = new frm_consultaProdutos();
            frm.Show();
        }

        private void produtosToolStripMenuItem1_Click_1(object sender, EventArgs e) {
            frm_rel_produtos frm = new frm_rel_produtos();
            frm.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void btn_cad_usuario_Click(object sender, EventArgs e) {
            frm_usuario frm = new frm_usuario();
            frm.Show();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e) {
            frm_usuario frm = new frm_usuario();
            frm.Show();
        }

        private void btn_cad_clientes_Click(object sender, EventArgs e) {
            frm_clientes frm = new frm_clientes();
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e) {
            frm_clientes frm = new frm_clientes();
            frm.Show();
        }
    }
}
