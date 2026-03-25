using SA2.Classes.Entidades;
using SA2.Data;

namespace SA2.Classes.Serv;

public class AlunoService
{
    private readonly AlunoDbContext _dbContext;

    public AlunoService(AlunoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ResultadoCadastro> CadastrarAlunoAsync(Aluno aluno)
    {
        try
        {
            // Validação básica
            if (string.IsNullOrWhiteSpace(aluno.Nome))
            {
                return new ResultadoCadastro
                {
                    Sucesso = false,
                    Mensagem = "Por favor, informe o nome do aluno."
                };
            }

            if (aluno.RegistroAluno <= 0)
            {
                return new ResultadoCadastro
                {
                    Sucesso = false,
                    Mensagem = "Por favor, informe um RA válido."
                };
            }

            if (aluno.CursoId <= 0)
            {
                return new ResultadoCadastro
                {
                    Sucesso = false,
                    Mensagem = "Por favor, selecione um curso."
                };
            }

            // Define os status padrão para novos cadastros
            aluno.StatusWifi = "Inativo";
            aluno.StatusAction = "Aguardando aprovação";

            // Adiciona o aluno ao banco de dados
            _dbContext.Alunos.Add(aluno);
            await _dbContext.SaveChangesAsync();

            return new ResultadoCadastro
            {
                Sucesso = true,
                Mensagem = "Aluno cadastrado com sucesso!"
            };
        }
        catch (Exception ex)
        {
            return new ResultadoCadastro
            {
                Sucesso = false,
                Mensagem = $"Erro ao cadastrar aluno: {ex.Message}"
            };
        }
    }
}
