﻿using Controladores.PessoaModule;
using Controladores.Shared;
using Dominio.PessoaModule;
using Dominio.PessoaModule.ClienteModule;
using System;
using System.Windows.Forms;
using WindowsApp.Shared;

namespace WindowsApp.ClienteModule
{
    public partial class CadastroClientePJ : CadastroEntidade<ClientePJ>//Form//
    {
        public override Controlador<ClientePJ> Controlador { get => new ControladorClientePJ(); }

        public CadastroClientePJ()
        {
            InitializeComponent();
            dgvMotoristas.ConfigurarGrid(ConfigurarColunas());
        }

        protected override IEditavel Editar()
        {
            tbNome.Text = entidade.Nome;
            tbTelefone.Text = entidade.Telefone;
            tbEndereco.Text = entidade.Endereco;
            tbCNPJ.Text = entidade.Documento;
            AtualizarListMotoristas();
            return this;
        }

        public DataGridViewColumn[] ConfigurarColunas()
        {
            return new DataGridViewColumn[]
            {
            new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},
            new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"}
            };
        }

        private void AtualizarListMotoristas()
        {
            dgvMotoristas.DataSource = Controlador.GetById(entidade.Id).Motoristas;
        }

        public override ClientePJ GetNovaEntidade()
        {
            var nome = tbNome.Text;
            var telefone = tbTelefone.Text;
            var endereco = tbEndereco.Text;
            var documento = tbCNPJ.Text;
            var email = tb_email.Text;

            return new ClientePJ(nome, telefone, endereco, documento, email);
        }
        private MotoristaEmpresa GetMotoristaSelecionado()
        {
            return entidade.Motoristas.Find(x => x.Id == dgvMotoristas.GetIdSelecionado());
        }

        private void HabilitarBotoes(bool estado)
        {
            bt_editar_motorista.Enabled = estado;
            bt_remover_motorista.Enabled = estado;
        }

        #region Eventos
        private void btAdicionar_Click(object sender, EventArgs e)
        {
            if (Salva())
                TelaPrincipal.Instancia.FormAtivo = new GerenciamentoCliente();
        }
        private void bt_add_motorista_click(object sender, EventArgs e)
        {
            if (entidade == null)
            {
                MessageBox.Show("Primeiro cadastre a Empresa");
                return;
            }
            TelaPrincipal.Instancia.FormAtivo = new CadastroMotorista(entidade);
        }
        private void bt_editar_motorista_Click(object sender, EventArgs e)
        {
            TelaPrincipal.Instancia.FormAtivo = (Form)new CadastroMotorista(entidade).ConfigurarEditar(GetMotoristaSelecionado());
            HabilitarBotoes(false);
        }
        private void bt_remover_motorista_Click(object sender, EventArgs e)
        {
            new ControladorMotorista().Excluir(GetMotoristaSelecionado().Id);
            HabilitarBotoes(false);
            AtualizarListMotoristas();
        }
        private void CadastroClientePJ_Load(object sender, EventArgs e)
        {
            dgvMotoristas.ClearSelection();
            HabilitarBotoes(false);
        }

        private void dgvMotoristas_SelectionChanged(object sender, EventArgs e)
        {
            HabilitarBotoes(true);
        }
        #endregion

    }
}
