using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Presentation.Models;
using Projeto.Business;
using Projeto.Entities;

namespace Projeto.Presentation.Controllers
{
    public class DependenteController : Controller
    {
        //atributo..
        private DependenteBusiness business;

        //construtor..
        public DependenteController()
        {
            business = new DependenteBusiness();
        }

        // GET: Dependente/Cadastro
        public ActionResult Cadastro()
        {
            return View(new DependenteCadastroViewModel());
        }

        [HttpPost]
        public ActionResult Cadastro(DependenteCadastroViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Dependente d = new Dependente();
                    d.Funcionario = new Funcionario();

                    d.Nome = model.Nome;
                    d.DataNascimento = model.DataNascimento;
                    d.Funcionario.IdFuncionario = model.IdFuncionario;

                    business.Cadastrar(d); //gravando..

                    ViewBag.Mensagem = "Funcionário cadastrado com sucesso.";
                    ModelState.Clear(); //limpar os campos do formulário..
                }
                catch(Exception e)
                {
                    //mensagem de erro..
                    ViewBag.Mensagem = e.Message;
                }
            }

            return View(new DependenteCadastroViewModel());
        }

        // GET: Dependente/Consulta
        public ActionResult Consulta()
        {            
            //retornando a lista..
            return View(ObterConsultaDeDependentes());
        }

        // GET: Dependente/Exclusao
        public ActionResult Exclusao(int id)
        {
            try
            {
                //excluindo..
                business.Excluir(id);

                //mensagem de sucesso..
                ViewBag.Mensagem = "Dependente excluido com sucesso.";
            }
            catch(Exception e)
            {
                //exibir mensagem de erro..
                ViewBag.Mensagem = e.Message;
            }

            //redirecionamento..
            return View("Consulta", ObterConsultaDeDependentes());
        }

        // GET: Dependente/Edicao
        public ActionResult Edicao(int id)
        {
            //criando um objeto da classe model..
            DependenteEdicaoViewModel model = new DependenteEdicaoViewModel();

            try
            {
                //buscar o dependente pelo id..
                Dependente d = business.ObterPorId(id);

                model.IdDependente = d.IdDependente;
                model.Nome = d.Nome;
                model.DataNascimento = d.DataNascimento;
                model.IdFuncionario = d.Funcionario.IdFuncionario;
            }
            catch(Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            //enviando..
            return View(model);
        }

        // POST: Dependente/Edicao
        [HttpPost] //recebe o SUBMIT do formulário..
        public ActionResult Edicao(DependenteEdicaoViewModel model)
        {
            if(ModelState.IsValid) //passou nas validações?
            {
                try
                {
                    Dependente d = new Dependente();
                    d.Funcionario = new Funcionario();

                    d.IdDependente = model.IdDependente;
                    d.Nome = model.Nome;
                    d.DataNascimento = model.DataNascimento;
                    d.Funcionario.IdFuncionario = model.IdFuncionario;

                    business.Atualizar(d); //atualizando..

                    ViewBag.Mensagem = "Dependente atualizado com sucesso.";
                }
                catch(Exception e)
                {
                    //exibir mensagem de erro..
                    ViewBag.Mensagem = e.Message;
                }
            }

            return View(new DependenteEdicaoViewModel()); //instanciando..
        }

        //método para retornar uma consulta dos dependentes..
        private List<DependenteConsultaViewModel> ObterConsultaDeDependentes()
        {
            List<DependenteConsultaViewModel> lista = new List<DependenteConsultaViewModel>();

            try
            {
                foreach (Dependente d in business.Consultar())
                {
                    DependenteConsultaViewModel model = new DependenteConsultaViewModel();
                    model.IdDependente = d.IdDependente;
                    model.Nome = d.Nome;
                    model.DataNascimento = d.DataNascimento;
                    model.IdFuncionario = d.Funcionario.IdFuncionario;
                    model.NomeFuncionario = d.Funcionario.Nome;
                    model.Salario = d.Funcionario.Salario;
                    model.DataAdmissao = d.Funcionario.DataAdmissao;

                    lista.Add(model);
                }
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            return lista;
        }

    }
}