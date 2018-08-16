using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Presentation.Models; //camada de modelo..
using Projeto.Business; //camada de regras de negócio..
using Projeto.Entities; //classes de entidade..

namespace Projeto.Presentation.Controllers
{
    public class FuncionarioController : Controller
    {
        //atributo..
        private FuncionarioBusiness business;

        //construtor..
        public FuncionarioController()
        {
            //espaço de memória..
            business = new FuncionarioBusiness();
        }

        // GET: Funcionario/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // POST: Funcionario/Cadastro
        [HttpPost] //recebe o submit enviado pelo formulário
        public ActionResult Cadastro(FuncionarioCadastroViewModel model)
        {
            try
            {
                //verificar se os dados da model 
                //passaram nas regras de validação..
                if(ModelState.IsValid)
                {
                    Funcionario f = new Funcionario();
                    f.Nome = model.Nome;
                    f.Salario = model.Salario;
                    f.DataAdmissao = model.DataAdmissao;

                    //gravando..
                    business.Cadastrar(f);

                    ViewBag.Mensagem = $"Funcionário {f.Nome}, cadastrado com sucesso.";
                    ModelState.Clear(); //limpa os campos do formulário..
                }
            }
            catch(Exception e)
            {
                //exibir mensagem de erro..
                ViewBag.Mensagem = e.Message;
            }

            return View();
        }

        // GET: Funcionario/Consulta
        public ActionResult Consulta()
        {
            return View(ObterConsultaDeFuncionarios());
        }

        // GET: Funcionario/Exclusao?id={0}
        public ActionResult Exclusao(int id)
        {
            try
            {
                business.Excluir(id);
                ViewBag.Mensagem = "Funcionário excluído com sucesso.";
            }
            catch(Exception e)
            {
                //mensagem de erro..
                ViewBag.Mensagem = e.Message;
            }

            //retornando para a página..
            return View("Consulta", ObterConsultaDeFuncionarios());
        }

        // GET: Funcionario/Edicao?id={0}
        public ActionResult Edicao(int id)
        {
            //instanciando um objeto da classe de modelo..
            FuncionarioEdicaoViewModel model = new FuncionarioEdicaoViewModel();

            try
            {
                //buscar o funcionario pelo id..
                Funcionario f = business.ObterPorId(id);
                model.IdFuncionario = f.IdFuncionario;
                model.Nome = f.Nome;
                model.Salario = f.Salario;
                model.DataAdmissao = f.DataAdmissao;
            }
            catch(Exception e)
            {
                //exibindo mensagem de erro..
                ViewBag.Mensagem = e.Message;
            }

            //enviando a model..
            return View(model); //abrir página..
        }

        [HttpPost] //recebe o SUBMIT do formulário
        public ActionResult Edicao(FuncionarioEdicaoViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Funcionario f = new Funcionario();
                    f.IdFuncionario = model.IdFuncionario;
                    f.Nome = model.Nome;
                    f.Salario = model.Salario;
                    f.DataAdmissao = model.DataAdmissao;

                    business.Atualizar(f); //atualizando..

                    ViewBag.Mensagem = "Funcionário atualizado com sucesso.";
                }
                catch(Exception e)
                {
                    //exibindo mensagem de erro..
                    ViewBag.Mensagem = e.Message;
                }
            }

            return View();
        }

        //método para retornar os dados da consulta..
        private List<FuncionarioConsultaViewModel> ObterConsultaDeFuncionarios()
        {
            //declarando uma lista..
            List<FuncionarioConsultaViewModel> lista = new List<FuncionarioConsultaViewModel>();

            try
            {
                //varrendo a consulta de funcionarios..
                foreach (Funcionario f in business.Consultar())
                {
                    FuncionarioConsultaViewModel model = new FuncionarioConsultaViewModel();
                    model.IdFuncionario = f.IdFuncionario;
                    model.Nome = f.Nome;
                    model.Salario = f.Salario;
                    model.DataAdmissao = f.DataAdmissao;

                    lista.Add(model); //adicionando..
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