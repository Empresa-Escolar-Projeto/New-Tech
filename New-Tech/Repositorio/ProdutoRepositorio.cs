using MySql.Data.MySqlClient;
using System.Data;
using New_Tech.Models;



namespace New_Tech.Repositorio
{
    public class ProdutoRepositorio (IConfiguration configuration)
    {
        private readonly string _conexaoMySQL = configuration.GetConnectionString("ConexaoMySQL");

        public void Cadastrar( Produto produto)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO Produtos(Nome,Descricao,Preco,Quantidade) values(@Nome,@Descricao,@Preco,@Quantidade)", conexao);
                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = produto.Nome;
                cmd.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = produto.Descricao;
                cmd.Parameters.Add("@Preco", MySqlDbType.Decimal).Value = produto.Preco;
                cmd.Parameters.Add("@Quantidade", MySqlDbType.UInt32).Value = produto.Quantidade;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }
    }
}
