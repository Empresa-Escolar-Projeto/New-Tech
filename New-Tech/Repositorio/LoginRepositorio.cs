﻿using MySql.Data.MySqlClient;
using System.Data;
using New_Tech.Models;
using System.Configuration;

namespace New_Tech.Repositorio
{
    public class LoginRepositorio (IConfiguration configuration)
    {
        //Cria o construtor... ele lê os campos inseridos no MySQL.
        private readonly string _conexaoMySQL = configuration.GetConnectionString("ConexaoMySQL");


        public Usuario ObterUsuario(string email)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new("SELECT * FROM Usuarios WHERE Email = @Email", conexao);
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = email;


                using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    Usuario usuario = null;

                    if (dr.Read())
                    {
                        usuario = new Usuario
                        {
                            Id = Convert.ToInt32(dr["Id"]),

                            Nome = dr["Nome"].ToString(),

                            Email = dr["Email"].ToString(),

                            Senha = dr["Senha"].ToString()

                        };

                    }
                    return usuario;
                }


            }


        }


    }
}
