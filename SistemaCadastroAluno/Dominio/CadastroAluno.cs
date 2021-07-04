using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCadastroAluno.Dominio
{
    class CadastroAluno
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string AnoEscolar { get; set; }
        public string Sexo { get; set; }
        public string NomeResp1 { get; set; }
        public string CPFResp1 { get; set; }
        public string NomeResp2 { get; set; }
        public string CPFResp2 { get; set; }

        public CadastroAluno( string nome, DateTime dataNascimento, string ano, string sexo, string nomeResp1, string cpfResp1, string nomeResp2, string cpfResp2)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            AnoEscolar = ano;
            Sexo = sexo;
            NomeResp1 = nomeResp1;
            CPFResp1 = cpfResp1;
            NomeResp2 = nomeResp2;
            CPFResp2 = cpfResp2;
        }
    }
}
