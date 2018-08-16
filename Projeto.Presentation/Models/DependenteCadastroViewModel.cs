using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Projeto.Entities;
using Projeto.Business;

namespace Projeto.Presentation.Models
{
    public class DependenteCadastroViewModel
    {
        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do dependente.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do dependente.")]
        public DateTime DataNascimento { get; set; }

        //propriedade para resgatar o id do funcionario selecionado..
        [Required(ErrorMessage = "Por favor, selecione o funcionário.")]
        public int IdFuncionario { get; set; }

        //propriedade para exibir os funcionários..
        public List<SelectListItem> ListagemDeFuncionarios
        {
            get
            {
                //declarar uma lista para criar as opções do campo dropdownlist
                List<SelectListItem> lista = new List<SelectListItem>();

                FuncionarioBusiness business = new FuncionarioBusiness();
                foreach(Funcionario f in business.Consultar())
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = f.IdFuncionario.ToString(); //valor do campo..
                    item.Text = f.Nome; //texto exibido no campo..

                    lista.Add(item);
                }

                //retornando a lista..
                return lista;
            }
        }
    }
}