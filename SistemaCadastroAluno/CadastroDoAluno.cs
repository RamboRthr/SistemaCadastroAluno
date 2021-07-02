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
        List<string> listaNomes = new List<string>();
        List<DateTime> listaDataNascimento = new List<DateTime>();
        List<string> listaAno = new List<string>();
        List<char> listaSexo = new List<char>();
        List<string> listaNomeResp1 = new List<string>();
        List<string> listaCPFResp1 = new List<string>();
        List<string> listaNomeResp2 = new List<string>();
        List<string> listaCPFResp2 = new List<string>();
        bool novo;

        private void CadastroDoAluno_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (listaNomes.Contains(txtNomeAluno.Text))
            {
                novo = false;
                
            }
            else
            {
                novo = true;
                
            }
            if (novo)
            {
                if (TudoPreenchido())
                {
                    SalvarDados();
                    listAlunos.Items.Add(txtNomeAluno.Text);
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos para realizar o cadastro.");
                }
            }
            else
            {
                MessageBox.Show("Limpe os dados para cadastrar um novo aluno.");
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

        private void SalvarDados()
        {
            listaNomes.Add(txtNomeAluno.Text);
            listaDataNascimento.Add(dataNascimento.Value);
            listaAno.Add(txtAno.Text.ToString());
            if (btnFem.Checked)
            {
                listaSexo.Add('F');

            }
            else if (btnMasc.Checked)
            {
                listaSexo.Add('M');

            }
            else if (btnOutro.Checked)
            {
                listaSexo.Add('X');

            }

            listaNomeResp1.Add(txtNomeResp1.Text);
            listaNomeResp2.Add(txtNomeResp2.Text);
            listaCPFResp1.Add(CPFResp1.Text);
            listaCPFResp2.Add(CPFResp2.Text);


        }
        private void listAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNomeAluno.Text = listaNomes[listAlunos.SelectedIndex];
            dataNascimento.Value = listaDataNascimento[listAlunos.SelectedIndex];
            txtAno.Text = listaAno[listAlunos.SelectedIndex];
            if (listaSexo[listAlunos.SelectedIndex] == 'F')
            {
                btnFem.Checked = true;
            }
            else if (listaSexo[listAlunos.SelectedIndex] == 'M')
            {
                btnMasc.Checked = true;
            }
            else if (listaSexo[listAlunos.SelectedIndex] == 'X')
            {
                btnOutro.Checked = true;
            }
            txtNomeResp1.Text = listaNomeResp1[listAlunos.SelectedIndex];
            CPFResp1.Text = listaCPFResp1[listAlunos.SelectedIndex];
            txtNomeResp2.Text = listaNomeResp2[listAlunos.SelectedIndex];
            CPFResp2.Text = listaCPFResp2[listAlunos.SelectedIndex];
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
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
            listaNomes.RemoveAt(listAlunos.SelectedIndex);
            listaDataNascimento.RemoveAt(listAlunos.SelectedIndex);
            listaAno.RemoveAt(listAlunos.SelectedIndex);
            listaSexo.RemoveAt(listAlunos.SelectedIndex);
            listaNomeResp1.RemoveAt(listAlunos.SelectedIndex);
            listaNomeResp2.RemoveAt(listAlunos.SelectedIndex);
            listaCPFResp1.RemoveAt(listAlunos.SelectedIndex);
            listaCPFResp2.RemoveAt(listAlunos.SelectedIndex);
            listAlunos.Items.RemoveAt(listAlunos.SelectedIndex);
        }
    }
}
