using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities; //importando..
using Projeto.Repository; //importando..

namespace Projeto.Business
{
    public class FuncionarioBusiness
    {
        //atributo..
        private FuncionarioRepository repository;

        //construtor..
        public FuncionarioBusiness()
        {
            //instanciar o repositorio..
            repository = new FuncionarioRepository();
        }

        public void Cadastrar(Funcionario f)
        {
            repository.Insert(f);
        }

        public void Atualizar(Funcionario f)
        {
            repository.Update(f);
        }

        public void Excluir(int idFuncionario)
        {
            repository.Delete(idFuncionario);
        }

        public List<Funcionario> Consultar()
        {
            return repository.FindAll();
        }

        public Funcionario ObterPorId(int idFuncionario)
        {
            return repository.FindById(idFuncionario);
        }

    }
}
