using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Funcionario
    {
        //proproedades..
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }

        //Relacionamento de Associação (TER-Muitos)
        public List<Dependente> Dependentes { get; set; }

        //construtor default..
        public Funcionario()
        {
            //vazio
        }

        //sobrecarga (overloading) de construtor
        public Funcionario(int idFuncionario, string nome, decimal salario, DateTime dataAdmissao)
        {
            IdFuncionario = idFuncionario;
            Nome = nome;
            Salario = salario;
            DataAdmissao = dataAdmissao;
        }

        //sobrescrita do método ToString()..
        public override string ToString()
        {
            return $"Id: {IdFuncionario}, Nome: {Nome}, Salário: {Salario}, Admissão: {DataAdmissao}";
        }
    }
}
