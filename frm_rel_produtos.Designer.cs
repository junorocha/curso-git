namespace Sistema {
    partial class frm_rel_produtos {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DS_Relatorio_Produtos = new Sistema.DS_Relatorio_Produtos();
            this.tb_produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_produtoTableAdapter = new Sistema.DS_Relatorio_ProdutosTableAdapters.tb_produtoTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Relatorio_Produtos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DS_Relatorio_Produtos
            // 
            this.DS_Relatorio_Produtos.DataSetName = "DS_Relatorio_Produtos";
            this.DS_Relatorio_Produtos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_produtoBindingSource
            // 
            this.tb_produtoBindingSource.DataMember = "tb_produto";
            this.tb_produtoBindingSource.DataSource = this.DS_Relatorio_Produtos;
            // 
            // tb_produtoTableAdapter
            // 
            this.tb_produtoTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tb_produtoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema.Relatorios.Rel_produtos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(674, 396);
            this.reportViewer1.TabIndex = 0;
            // 
            // frm_rel_produtos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 396);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frm_rel_produtos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Produtos";
            this.Load += new System.EventHandler(this.frm_rel_produtos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DS_Relatorio_Produtos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource tb_produtoBindingSource;
        private DS_Relatorio_Produtos DS_Relatorio_Produtos;
        private DS_Relatorio_ProdutosTableAdapters.tb_produtoTableAdapter tb_produtoTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}