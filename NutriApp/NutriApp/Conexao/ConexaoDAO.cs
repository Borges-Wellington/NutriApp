using System;
using NutriApp.Dominio;
using NutriApp.Percistencia;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySql.Data.MySqlClient;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutriApp.Conexao
{
    public class ConexaoDAO : IDisposable
    {
        public MySqlConnection conexao;
        public MySqlCommand _cmd;
        public string _stringConexao;

        
        public ConexaoDAO()
        {
            _stringConexao = @"server=192.168.1.100;port=3306;database=Nutri; Uid=root; pwd=well1448;";
            //_stringConexao = @"server=" + server + ";port=" + porta + ";database=" + banco + ";Uid=" + usuario + ";pwd=" + senha + ";";
            conexao = new MySqlConnection(_stringConexao);

            try
            {


                conexao.Open();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                
            }
        }

        public void Dispose()
        {
            conexao.Close();
        }
        public MySqlDataReader ExecutaLeitura(string SqlQuery)
        {
            _cmd = new MySqlCommand(SqlQuery, conexao);
            return _cmd.ExecuteReader();
        }

        public int ExecutaComando(string sqlQuery)
        {
            _cmd = new MySqlCommand(sqlQuery, conexao);
            return _cmd.ExecuteNonQuery();
        }

       
    }
}
