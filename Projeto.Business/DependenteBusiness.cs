using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Repository;

namespace Projeto.Business
{
    public class DependenteBusiness
    {
        //atributo..
        private DependenteRepository repository;

        //construtor..
        public DependenteBusiness()
        {
            repository = new DependenteRepository();
        }

        public void Cadastrar(Dependente d)
        {
            repository.Insert(d);
        }

        public void Atualizar(Dependente d)
        {
            repository.Update(d);
        }

        public void Excluir(int idDependente)
        {
            repository.Delete(idDependente);
        }

        public List<Dependente> Consultar()
        {
            return repository.FindAll();
        }

        public Dependente ObterPorId(int idDependente)
        {
            return repository.FindById(idDependente);
        }

    }
}
