using Microsoft.Win32;
using RNlavaJato.Entidades;
using RNlavaJato.Infra;
using RNlavaJato.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RNlavaJato
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string connectionString;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             // Cria uma instância do OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            // Define o filtro de arquivos para limitar o tipo de arquivos que o usuário pode selecionar
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";

            // Abre a janela de diálogo para permitir ao usuário selecionar um arquivo
            bool? result = openFileDialog.ShowDialog();

            // Verifica se o usuário selecionou um arquivo
            if (result == true)
            {
                // Obtém o caminho completo do arquivo selecionado
                string arquivoSelecionado = openFileDialog.FileName;

                try
                {
                    // Realize aqui a lógica para fazer o upload do arquivo para o servidor ou banco de dados
                    string connectionString = "Data Source=SEU_SERVIDOR;Initial Catalog=SUA_BASE_DE_DADOS;Integrated Security=True";

                    LavaJatoRepository repository = new LavaJatoRepository(connectionString);

                    List<LavaJatoData> dadosLidos = ExcelProcessor.LerDadosDoExcel(arquivoSelecionado);

                    foreach (var dados in dadosLidos)
                    {
                        repository.FazerUpload(dados);
                    }

                    // Neste exemplo, apenas exibiremos o caminho do arquivo selecionado
                    MessageBox.Show($"Arquivo selecionado: {arquivoSelecionado}", "Upload realizado com sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao fazer o upload do arquivo: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        public void FazerUpload(LavaJatoData dados)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO LavaJato (Data, Hora, NomeCliente, EmailCliente, TelefoneCliente, EnderecoCliente, TipoServico, ValorServico, FuncionarioResponsavel, Observacoes)
                             VALUES (@Data, @Hora, @NomeCliente, @EmailCliente, @TelefoneCliente, @EnderecoCliente, @TipoServico, @ValorServico, @FuncionarioResponsavel, @Observacoes)";

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
                    command.Parameters.AddWithValue("@Observacoes", dados.Observacoes);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
