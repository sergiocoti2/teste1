using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //sqlserver..
using System.Configuration; //importando..

namespace Projeto.Repository
{
    public class Conexao
    {
        //atributos..
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlTransaction tr;

        //método para abrir conexão com o banco de dados..
        protected void OpenConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["aula"].ConnectionString);
            con.Open(); //conectado..
        }

        //método para desconectar do banco de dados..
        protected void CloseConnection()
        {
            con.Close(); //desconectado..
        }

    }
}
