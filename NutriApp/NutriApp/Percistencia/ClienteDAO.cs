using System;
using NutriApp.Conexao;
using NutriApp.Percistencia;
using MySql.Data.MySqlClient;

namespace NutriApp.Dominio
{
    class ClienteDAO
    {
        private string _sql;
        private MySqlCommand _cmd;
        private ConexaoDAO _minhaConexao;
        private int _linhasAlteradas;

        public int ver_se_existe(ClienteBO cliBO)
        {
            int id = 0;
            using (_minhaConexao = new ConexaoDAO())
            {
                string select = "select * from Cliente where Cpf= '" + cliBO.Cpf + "'";
                MySqlDataReader reader = _minhaConexao.ExecutaLeitura(select);

                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["Id_Cliente"]);
                }

                reader.Dispose();

                return id;
            }
        }
        public ClienteBO Select(string cpf)
        {
            ClienteBO cliBO = new ClienteBO();
            using (_minhaConexao = new ConexaoDAO())
            {
                string select = "select * from Cliente where cpf='" + cpf + "'";
                MySqlDataReader reader = _minhaConexao.ExecutaLeitura(select);

                if (reader.Read())
                {
                    cliBO.Cpf = cpf;
                    cliBO.Nome = reader["Nome"].ToString();
                    cliBO.Id_Cliente = reader["Id_Cliente"].ToString();
                    cliBO.Email = reader["Email"].ToString();
                    cliBO.Telefone = reader["Telefone"].ToString();
                }

                reader.Dispose();

                return cliBO;
            }
        }


    }
}
