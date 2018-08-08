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
    public partial class frm_consultaProdutos : Form {
        public frm_consultaProdutos() {
            InitializeComponent();
        }

        private void frm_consultaProdutos_Load(object sender, EventArgs e) {
            this.categoriaBindingSource.DataSource = DataContextFactory.DataContext.Categoria;
        }

        private void btn_buscar_Click(object sender, EventArgs e) {
            this.pesquisar((int)CB_categoria.SelectedValue);
        }

        public void pesquisar(int codCategoria) {
            this.produtoBindingSource.DataSource = DataContextFactory.DataContext.Produto.Where(x => x.CodigoCategoria == codCategoria);
        }
    }
}
