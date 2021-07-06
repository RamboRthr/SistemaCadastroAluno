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

        public override string ToString()
        {
            return $"{Nome} - {DataNascimento} - {AnoEscolar}";
        }
    }
}
