using RNlavaJato.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNlavaJato.Repository
{
    public class LavaJatoRepository
    {
        private string connectionString;

        public LavaJatoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void FazerUpload(LavaJatoData dados)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO ServicosPrestadosLavaJato (Data, Hora, NomeCliente, EmailCliente, TelefoneCliente, EnderecoCliente, TipoServico, ValorServico, FuncionarioResponsavel, PlacaVeiculo, Observacoes)
                             VALUES (@Data, @Hora, @NomeCliente, @EmailCliente, @TelefoneCliente, @EnderecoCliente, @TipoServico, @ValorServico, @FuncionarioResponsavel, @PlacaVeiculo, @Observacoes)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Data", dados.Data);
                    command.Parameters.AddWithValue("@Hora", dados.Hora);
                    command.Parameters.AddWithValue("@NomeCliente", dados.NomeCliente);
                    command.Parameters.AddWithValue("@EmailCliente", dados.EmailCliente);
                    command.Parameters.AddWithValue("@TelefoneCliente", dados.TelefoneCliente);
                    command.Parameters.AddWithValue("@EnderecoCliente", dados.EnderecoCliente);
                    command.Parameters.AddWithValue("@TipoServico", dados.TipoServico);
                    command.Parameters.AddWithValue("@ValorServico", dados.ValorServico);
                    command.Parameters.AddWithValue("@FuncionarioResponsavel", dados.FuncionarioResponsavel);
                    command.Parameters.AddWithValue("@PlacaVeiculo", dados.PlacaVeiculo);
                    command.Parameters.AddWithValue("@Observacoes", dados.Observacoes);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable LerDados()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {?
                string query = "SELECT * FROM ServicosPrestadosLavaJato";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
    }
}
