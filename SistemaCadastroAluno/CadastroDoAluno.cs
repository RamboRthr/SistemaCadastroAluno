using SistemaCadastroAluno.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaCadastroAluno
{
    public partial class CadastroDoAluno : Form
    {
        public CadastroDoAluno()
        {
            InitializeComponent();
        }

        List<CadastroAluno> cadastros = new List<CadastroAluno>();
        List<string> listaNomes = new List<string>();
        bool novo;

        private void CadastroDoAluno_Load(object sender, EventArgs e)
        {
            novo = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string charSexo = "";

            if (btnFem.Checked)
            {
                charSexo = "F";
            }
            else if (btnMasc.Checked)
            {
                charSexo = "M";
            }
            else if (btnOutro.Checked)
            {
                charSexo = "X";
            }
            if (novo)
            {
                CadastroAluno cadastroAluno = new CadastroAluno();
                if (TudoPreenchido())
                {
                    SalvarDados(charSexo, cadastroAluno);
                    listAlunos.Items.Add(txtNomeAluno.Text);
                    listaNomes.Add(cadastroAluno.Nome);
                    novo = false;
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos para realizar o cadastro.");
                }
            }
            else
            {
                if (listaNomes.Contains(txtNomeAluno.Text))
                {
                    MessageBox.Show("Selecione algum cadastro na lista para atualizar ou insira outros dados para cadastrar o aluno.");
                }
                else
                {
                    if (listAlunos.SelectedIndex >= 0)
                    {
                        cadastros[listAlunos.SelectedIndex].Nome = txtNomeResp1.Text;
                        cadastros[listAlunos.SelectedIndex].DataNascimento = dataNascimento.Value;
                        cadastros[listAlunos.SelectedIndex].AnoEscolar = txtAno.Text;
                        cadastros[listAlunos.SelectedIndex].Sexo = charSexo.ToString();
                        cadastros[listAlunos.SelectedIndex].NomeResp1 = txtNomeResp1.Text;
                        cadastros[listAlunos.SelectedIndex].CPFResp1 = CPFResp1.Text;
                        cadastros[listAlunos.SelectedIndex].NomeResp2 = txtNomeResp2.Text;
                        cadastros[listAlunos.SelectedIndex].CPFResp2 = CPFResp2.Text;
                    }
                    else
                    {
                        MessageBox.Show("Selecione um cadastro na lista para atualizar.");
                    }
                    
                }
                
            }   
        }
        private bool TudoPreenchido()
        {
            
            if (!String.IsNullOrEmpty(txtNomeAluno.Text) && !String.IsNullOrEmpty(dataNascimento.Text) &&
                !String.IsNullOrEmpty(txtAno.Text))
            {
                if (txtNomeResp1.Text == "" && txtNomeResp2.Text == "" && CPFResp1.Text == "" && CPFResp2.Text == "")
                {
                    return false;
                        }
                else {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void SalvarDados(string sexo, CadastroAluno cadastro)
        {
            cadastro.Nome = txtNomeResp1.Text;
            cadastro.DataNascimento = dataNascimento.Value;
            cadastro.AnoEscolar = txtAno.Text;
            cadastro.Sexo = sexo.ToString();
            cadastro.NomeResp1 = txtNomeResp1.Text;
            cadastro.CPFResp1 = CPFResp1.Text;
            cadastro.NomeResp2 = txtNomeResp2.Text;
            cadastro.CPFResp2 = CPFResp2.Text;

        }
        private void listAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            novo = false;
            
            if (listAlunos.SelectedIndex >= 0)
            {
                txtNomeAluno.Text = cadastros[listAlunos.SelectedIndex].Nome;
                dataNascimento.Value = cadastros[listAlunos.SelectedIndex].DataNascimento;
                txtAno.Text = cadastros[listAlunos.SelectedIndex].AnoEscolar;
                if (cadastros[listAlunos.SelectedIndex].Sexo == "F")
                {
                    btnFem.Checked = true;
                }
                else if (cadastros[listAlunos.SelectedIndex].Sexo == "M")
                {
                    btnMasc.Checked = true;
                }
                else if (cadastros[listAlunos.SelectedIndex].Sexo == "X")
                {
                    btnOutro.Checked = true;
                }
                txtNomeResp1.Text = cadastros[listAlunos.SelectedIndex].NomeResp1;
                CPFResp1.Text = cadastros[listAlunos.SelectedIndex].CPFResp1;
                txtNomeResp2.Text = cadastros[listAlunos.SelectedIndex].NomeResp2;
                CPFResp2.Text = cadastros[listAlunos.SelectedIndex].CPFResp2;
            }
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            novo = true;
            txtNomeAluno.Text = "";
            dataNascimento.Value = DateTime.Today;
            txtAno.Text = "";
            btnFem.Checked = false;
            btnMasc.Checked = false;
            btnOutro.Checked = false;
            txtNomeResp1.Text = "";
            CPFResp1.Text = "";
            txtNomeResp2.Text = "";
            CPFResp2.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            cadastros.RemoveAt(listAlunos.SelectedIndex);

            txtNomeAluno.Text = "";
            dataNascimento.Value = DateTime.Today;
            txtAno.Text = "";
            btnFem.Checked = false;
            btnMasc.Checked = false;
            btnOutro.Checked = false;
            txtNomeResp1.Text = "";
            CPFResp1.Text = "";
            txtNomeResp2.Text = "";
            CPFResp2.Text = "";
        }
    }
}
