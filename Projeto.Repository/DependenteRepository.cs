using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Projeto.Entities;

namespace Projeto.Repository
{
    public class DependenteRepository : Conexao
    {
        //método para inserir um dependente no banco de dados..
        public void Insert(Dependente d)
        {
            OpenConnection();

            string query = "insert into Dependente(Nome, DataNascimento, IdFuncionario) "
                         + "values(@Nome, @DataNascimento, @IdFuncionario)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", d.Nome);
            cmd.Parameters.AddWithValue("@DataNascimento", d.DataNascimento);
            cmd.Parameters.AddWithValue("@IdFuncionario", d.Funcionario.IdFuncionario);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        //método para atualizar o dependente no banco de dados..
        public void Update(Dependente d)
        {
            OpenConnection();

            string query = "update Dependente set Nome = @Nome, DataNascimento = @DataNascimento, "
                         + "IdFuncionario = @IdFuncionario where IdDependente = @IdDependente";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdDependente", d.IdDependente);
            cmd.Parameters.AddWithValue("@Nome", d.Nome);
            cmd.Parameters.AddWithValue("@DataNascimento", d.DataNascimento);
            cmd.Parameters.AddWithValue("@IdFuncionario", d.Funcionario.IdFuncionario);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        //método para excluir o dependente..
        public void Delete(int idDependente)
        {
            OpenConnection();

            string query = "delete from Dependente where IdDependente = @IdDependente";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdDependente", idDependente);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        //método para listar todos os dependentes..
        public List<Dependente> FindAll()
        {
            OpenConnection();

            string query = "select d.IdDependente, d.Nome, d.DataNascimento, "
                         + "f.IdFuncionario, f.Nome as NomeFuncionario, "
                         + "f.Salario, f.DataAdmissao "
                         + "from Dependente d inner join Funcionario f "
                         + "on f.IdFuncionario = d.IdFuncionario";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Dependente> lista = new List<Dependente>();

            while(dr.Read())
            {
                Dependente d = new Dependente();
                d.Funcionario = new Funcionario();

                d.IdDependente = Convert.ToInt32(dr["IdDependente"]);
                d.Nome = Convert.ToString(dr["Nome"]);
                d.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]);
                d.Funcionario.IdFuncionario = Convert.ToInt32(dr["IdFuncionario"]);
                d.Funcionario.Nome = Convert.ToString(dr["NomeFuncionario"]);
                d.Funcionario.Salario = Convert.ToDecimal(dr["Salario"]);
                d.Funcionario.DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]);

                lista.Add(d);
            }

            CloseConnection();
            return lista;
        }

        //método para obter 1 Dependente pelo id..
        public Dependente FindById(int idDependente)
        {
            OpenConnection();

            string query = "select d.IdDependente, d.Nome, d.DataNascimento, "
                        + "f.IdFuncionario, f.Nome as NomeFuncionario, "
                        + "f.Salario, f.DataAdmissao "
                        + "from Dependente d inner join Funcionario f "
                        + "on f.IdFuncionario = d.IdFuncionario "
                        + "where IdDependente = @IdDependente";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdDependente", idDependente);
            dr = cmd.ExecuteReader();

            Dependente d = null;

            if(dr.Read())
            {
                d = new Dependente();
                d.Funcionario = new Funcionario();

                d.IdDependente = Convert.ToInt32(dr["IdDependente"]);
                d.Nome = Convert.ToString(dr["Nome"]);
                d.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]);
                d.Funcionario.IdFuncionario = Convert.ToInt32(dr["IdFuncionario"]);
                d.Funcionario.Nome = Convert.ToString(dr["NomeFuncionario"]);
                d.Funcionario.Salario = Convert.ToDecimal(dr["Salario"]);
                d.Funcionario.DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]);
            }

            CloseConnection();
            return d;
        }

    }
}
