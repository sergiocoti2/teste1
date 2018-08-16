using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //sqlserver..
using Projeto.Entities; //entidades..

namespace Projeto.Repository
{
    public class FuncionarioRepository : Conexao
    {
        //método para inserir um funcionario no banco..
        public void Insert(Funcionario f)
        {
            OpenConnection();

            string query = "insert into Funcionario(Nome, Salario, DataAdmissao) "
                         + "values(@Nome, @Salario, @DataAdmissao)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", f.Nome);
            cmd.Parameters.AddWithValue("@Salario", f.Salario);
            cmd.Parameters.AddWithValue("@DataAdmissao", f.DataAdmissao);
            cmd.ExecuteNonQuery(); //executando..

            CloseConnection();
        }

        //método para atualizar um funcionario no banco..
        public void Update(Funcionario f)
        {
            OpenConnection();

            string query = "update Funcionario set Nome = @Nome, Salario = @Salario, "
                         + "DataAdmissao = @DataAdmissao where IdFuncionario = @IdFuncionario";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdFuncionario", f.IdFuncionario);
            cmd.Parameters.AddWithValue("@Nome", f.Nome);
            cmd.Parameters.AddWithValue("@Salario", f.Salario);
            cmd.Parameters.AddWithValue("@DataAdmissao", f.DataAdmissao);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        //método para excluir o funcionário..
        public void Delete(int idFuncionario)
        {
            OpenConnection();

            string query = "delete from Funcionario where IdFuncionario = @IdFuncionario";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdFuncionario", idFuncionario);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        //método para listar todos os funcionarios..
        public List<Funcionario> FindAll()
        {
            OpenConnection();

            string query = "select * from Funcionario";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Funcionario> lista = new List<Funcionario>();

            while(dr.Read())
            {
                Funcionario f = new Funcionario();

                f.IdFuncionario = Convert.ToInt32(dr["IdFuncionario"]);
                f.Nome = Convert.ToString(dr["Nome"]);
                f.Salario = Convert.ToDecimal(dr["Salario"]);
                f.DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]);

                lista.Add(f); //adicionar na lista..
            }

            CloseConnection();
            return lista;
        }

        //método para consultar 1 funcionario pelo id..
        public Funcionario FindById(int idFuncionario)
        {
            OpenConnection();

            string query = "select * from Funcionario where IdFuncionario = @IdFuncionario";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdFuncionario", idFuncionario);
            dr = cmd.ExecuteReader();

            Funcionario f = null; //vazio..

            if(dr.Read()) //se algum funcionario foi encontrado..
            {
                f = new Funcionario(); //instanciando..

                f.IdFuncionario = Convert.ToInt32(dr["IdFuncionario"]);
                f.Nome = Convert.ToString(dr["Nome"]);
                f.Salario = Convert.ToDecimal(dr["Salario"]);
                f.DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]);
            }

            CloseConnection();
            return f; //retornando funcionario..
        }
    }
}
