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
                    listAlunos.Items.Add(cadastroAluno.ToString());
                    novo = false;
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos para realizar o cadastro.");
                }
            }
            else
            {
                if (listAlunos.SelectedIndex >= 0)
                {
                    cadastros[listAlunos.SelectedIndex].Nome = txtNomeAluno.Text;
                    cadastros[listAlunos.SelectedIndex].DataNascimento = dataNascimento.Value;
                    cadastros[listAlunos.SelectedIndex].AnoEscolar = txtAno.Text;
                    cadastros[listAlunos.SelectedIndex].Sexo = charSexo.ToString();
                    cadastros[listAlunos.SelectedIndex].NomeResp1 = txtNomeResp1.Text;
                    cadastros[listAlunos.SelectedIndex].CPFResp1 = CPFResp1.Text;
                    cadastros[listAlunos.SelectedIndex].NomeResp2 = txtNomeResp2.Text;
                    cadastros[listAlunos.SelectedIndex].CPFResp2 = CPFResp2.Text;
                    listAlunos.Items[listAlunos.SelectedIndex] = txtNomeAluno.Text;
                }
                else
                {
                    MessageBox.Show("Selecione um cadastro na lista para atualizar.");
                }

            }   
        }

        private bool TudoPreenchido()
        {
            
            if (!String.IsNullOrEmpty(txtNomeAluno.Text) && !String.IsNullOrEmpty(txtAno.Text))
            {
                if (btnFem.Checked || btnMasc.Checked || btnOutro.Checked)
                {
                    if (!String.IsNullOrEmpty(txtNomeResp1.Text) && !String.IsNullOrEmpty(CPFResp1.Text) && String.IsNullOrEmpty(txtNomeResp2.Text) && String.IsNullOrEmpty(CPFResp2.Text))
                    {
                        return true;
                    }
                    else if (String.IsNullOrEmpty(txtNomeResp1.Text) && String.IsNullOrEmpty(CPFResp1.Text) && !String.IsNullOrEmpty(txtNomeResp2.Text) && !String.IsNullOrEmpty(CPFResp2.Text))
                    {
                        return true;
                    }
                    else if (!String.IsNullOrEmpty(txtNomeResp1.Text) && !String.IsNullOrEmpty(CPFResp1.Text) && !String.IsNullOrEmpty(txtNomeResp2.Text) && !String.IsNullOrEmpty(CPFResp2.Text))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Não preenchido");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                return false;
            }
        }

        private void SalvarDados(string sexo, CadastroAluno cadastro)
        {
            cadastro.Nome = txtNomeAluno.Text;
            cadastro.DataNascimento = dataNascimento.Value;
            cadastro.AnoEscolar = txtAno.Text;
            cadastro.Sexo = sexo.ToString();
            cadastro.NomeResp1 = txtNomeResp1.Text;
            cadastro.CPFResp1 = CPFResp1.Text;
            cadastro.NomeResp2 = txtNomeResp2.Text;
            cadastro.CPFResp2 = CPFResp2.Text;
            cadastros.Add(cadastro);

        }

        private void listAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            novo = false;
            btnExcluir.Enabled = true;
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
            listAlunos.Items.RemoveAt(listAlunos.SelectedIndex);

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

            btnExcluir.Enabled = true;
        }

        
    }
}
