using Microsoft.Data.SqlClient;
using System.Data;

namespace ControleCadastro
{
    public partial class Form1 : Form
    {
        // Configure sua connection string aqui
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=SA2AlunosDB;Integrated Security=true;TrustServerCertificate=true;";

        public Form1()
        {
            InitializeComponent();
            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    // Query para buscar os dados
                    string query = "SELECT * FROM dbo.Alunos";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conexao))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Vincular os dados ao DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar se há uma linha selecionada
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, selecione um aluno para aprovar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obter a linha selecionada
                DataGridViewRow linhaSelecionada = dataGridView1.SelectedRows[0];
                
                // Obter o ID do aluno (assumindo que a primeira coluna é o ID)
                int alunoId = Convert.ToInt32(linhaSelecionada.Cells[0].Value);
                
                // Obter o nome do aluno para gerar o email
                string nomeAluno = linhaSelecionada.Cells["Nome"].Value.ToString();
                
                // Gerar email (remover espaços, acentos e converter para minúsculas)
                string email = RemoverAcentos(nomeAluno.Replace(" ", "")).ToLower() + "@senaisp.br";
                
                // Senha padrão
                string senha = "Sen@!sp";

                // Atualizar o banco de dados
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    string query = @"UPDATE dbo.Alunos 
                                   SET StatusWifi = @StatusWifi, 
                                       StatusAction = @StatusAction,
                                       Email = @Email,
                                       Senha = @Senha
                                   WHERE Id = @Id";

                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@StatusWifi", "Ativo");
                        comando.Parameters.AddWithValue("@StatusAction", "Aprovado");
                        comando.Parameters.AddWithValue("@Email", email);
                        comando.Parameters.AddWithValue("@Senha", senha);
                        comando.Parameters.AddWithValue("@Id", alunoId);

                        int linhasAfetadas = comando.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show($"Aluno aprovado com sucesso!\n\nEmail: {email}\nSenha: {senha}", 
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            // Recarregar os dados no DataGridView
                            CarregarDados();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro foi atualizado.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aprovar aluno: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string RemoverAcentos(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            var textoNormalizado = texto.Normalize(System.Text.NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();

            foreach (char c in textoNormalizado)
            {
                var categoriaUnicode = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (categoriaUnicode != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }
    }
}
