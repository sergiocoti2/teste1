using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Dependente
    {
        //propriedades..
        public int IdDependente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        //Relacionamento de Associação (TER-1)
        public Funcionario Funcionario { get; set; }

        //construtor default..
        public Dependente()
        {
            //vazio..
        }

        //sobrecarga (overloading) de construtores..
        public Dependente(int idDependente, string nome, DateTime dataNascimento)
        {
            IdDependente = idDependente;
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        //sobrescrita do método ToString()..
        public override string ToString()
        {
            return $"Id: {IdDependente}, Nome: {Nome}, Data de Nasc: {DataNascimento}";
        }
    }
}
