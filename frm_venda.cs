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
    public partial class frm_venda : Form {
        public frm_venda() {
            InitializeComponent();
        }

        private void frm_venda_Load(object sender, EventArgs e) {
            Size = new Size(548, 79);
            clienteBindingSource.DataSource = DataContextFactory.DataContext.Cliente;
            vendaBindingSource.DataSource = DataContextFactory.DataContext.Venda;
            itensVendaBindingSource.DataSource = DataContextFactory.DataContext.ItensVenda;
            produtoBindingSource.DataSource = DataContextFactory.DataContext.Produto;
            statusPagamentoBindingSource.DataSource = DataContextFactory.DataContext.StatusPagamento;
            contasReceberBindingSource.DataSource = DataContextFactory.DataContext.ContasReceber;
            tbusuarioBindingSource.DataSource = DataContextFactory.DataContext.tb_usuario;

            vendaBindingSource.AddNew();
        }

        private Venda vendaCorrente {
            get {
                return (Venda)vendaBindingSource.Current;
            }
        }

        private ItensVenda itemCorrente {
            get {
                return (ItensVenda)itensVendaBindingSource.Current;
            }
        }

        private ContasReceber contaCorrente {
            get {
                return (ContasReceber)contasReceberBindingSource.Current;
            }
        }

        private void btn_nova_venda_Click(object sender, EventArgs e) {
            Size = new Size(599, 461);
            vendaBindingSource.EndEdit();
            DataContextFactory.DataContext.SubmitChanges();
            groupBox1.Visible = true;
            btn_nova_venda.Enabled = false;

            itensVendaBindingSource.DataSource = DataContextFactory.DataContext.ItensVenda.Where(x => x.CodigoProduto == this.vendaCorrente.CodigoVenda);
            novoItem();
            CB_cliente.Enabled = false;
            CB_vendedor.Enabled = false;
        }

        private void novoItem() {
            itensVendaBindingSource.AddNew();
            itemCorrente.CodigoVenda = vendaCorrente.CodigoVenda;
            itemCorrente.Quantidade = 1;
        }

        private void btn_novoItem_Click(object sender, EventArgs e) {
            itensVendaBindingSource.EndEdit();
            DG_vendas.Refresh();
            DataContextFactory.DataContext.SubmitChanges();
            mostraSomaValores();
            novoItem();
        }

        private void DG_vendas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (e.Value != null && e.ColumnIndex == 1) {
                e.Value = ((Produto)e.Value).Descricao;
            }
        }

        private void CB_produto_SelectedIndexChanged(object sender, EventArgs e) {
            if (CB_produto.SelectedItem != null) {
                var pro = (Produto)CB_produto.SelectedItem;
                itemCorrente.CodigoProduto = (int)pro.Codigo;
                itemCorrente.Valor = (decimal)pro.Valor;
            }
        }

        private void mostraSomaValores() {
            decimal total = 0;
            foreach (DataGridViewRow dg in DG_vendas.Rows) {
                decimal v1 = Convert.ToDecimal(dg.Cells[2].Value);
                decimal v2 = Convert.ToDecimal(dg.Cells[3].Value);
                decimal subtotal = v1 * v2;
                dg.Cells[4].Value = subtotal;
                total = total + subtotal;
            }
            vendaCorrente.Valor = total;
        }

        private void btn_finalizarPedido_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Tem certeza que deseja finalizar o Pedido?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                itensVendaBindingSource.CancelEdit();
                DataContextFactory.DataContext.SubmitChanges();

                vendaCorrente.Desconto = 0;

                btn_novoItem.Enabled = false;
                CB_produto.Enabled = false;
                txt_quantidade.Enabled = false;
                txt_desconto.ReadOnly = false;
                txt_desconto.Focus();
                btn_finalizarPedido.Enabled = false;
                btn_finalizarVenda.Enabled = true;

            }
        }

        private void btn_finalizarVenda_Click(object sender, EventArgs e) {
            vendaCorrente.Desconto = Convert.ToDecimal(txt_desconto.Text) / 100 * vendaCorrente.Valor;
            vendaCorrente.ValorPago = (decimal)vendaCorrente.Valor - vendaCorrente.Desconto;          
            itensVendaBindingSource.EndEdit();
            DataContextFactory.DataContext.SubmitChanges();
            txt_desconto.Enabled = false;
            btn_finalizarVenda.Enabled = false;
            //btn_imprimir.Enabled = true;            

            btn_finalizarTudo.Enabled = true;
            CB_pgto.Enabled = true;
            contasReceberBindingSource.AddNew();
            contaCorrente.CodigoVenda = vendaCorrente.CodigoVenda;
            contaCorrente.DataCompra = DateTime.Now;
            contaCorrente.DataVencimento = DateTime.Now;
        }

        private void CB_pgto_SelectedIndexChanged(object sender, EventArgs e) {
            if (CB_pgto.SelectedItem != null) {
                var status = (StatusPagamento)CB_pgto.SelectedItem;
                if (status.CodigoStatus == 1) {
                    contaCorrente.CodigoStatus = (int)status.CodigoStatus;
                    dataVencimentoDateTimePicker.Enabled = false;
                    contaCorrente.DataPagamento = DateTime.Now;
                    btn_finalizarTudo.Enabled = true;
                }
                else if (status.CodigoStatus == 2) {
                    contaCorrente.CodigoStatus = (int)status.CodigoStatus;
                    dataVencimentoDateTimePicker.Enabled = true;
                    contaCorrente.DataVencimento = DateTime.Now;
                    contaCorrente.DataPagamento = null;
                    btn_finalizarTudo.Enabled = true;
                }
            }
        }

        private void btn_finalizarTudo_Click(object sender, EventArgs e) {
            contasReceberBindingSource.EndEdit();
            btn_finalizarTudo.Enabled = false;
            CB_pgto.Enabled = false;
            btn_imprimir.Enabled = true;
            DataContextFactory.DataContext.SubmitChanges();
            MessageBox.Show("Venda Finalizada com Sucesso");
            dataVencimentoDateTimePicker.Enabled = false;
        }
    }
}
