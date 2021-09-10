﻿using Controladores.ServicoModule;
using Controladores.Shared;
using Dominio.ServicoModule;
using System;
using System.Windows.Forms;
using WindowsApp.Shared;

namespace WindowsApp.ServicoModule
{
    public partial class CadastroServico : CadastroEntidade<Servico>
    {
        public override Controlador<Servico> Controlador { get => new ControladorServico(); }

        public CadastroServico()
        {
            InitializeComponent();
            tbQuantidade.Text = "1";
        }

        protected override IEditavel Editar()
        {
            tbNome.Text = entidade.Nome;
            tbTaxa.Text = entidade.Taxa.ToString();

            return this;
        }

        public override Servico GetNovaEntidade()
        {
            var nome = tbNome.Text;
            Double.TryParse(tbTaxa.Text, out double taxa);

            return new Servico(nome, taxa);
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            Int32.TryParse(tbQuantidade.Text, out int quantidade);

            for (int i = 0; i < quantidade; i++)
                if (!Salva(mostraSucesso: false))
                    return;

            TelaPrincipal.Instancia.FormAtivo = new GerenciamentoServico();
        }
    }
}
