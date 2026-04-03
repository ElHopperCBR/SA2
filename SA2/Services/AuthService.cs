using Microsoft.EntityFrameworkCore;
using SA2.Classes.Entidades;
using SA2.Data;

namespace SA2.Services;

public class AuthService
{
    private readonly AlunoDbContext _dbContext;

    public AuthService(AlunoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Aluno?> ValidarLoginAsync(string email, string senha)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            return null;

        var aluno = await _dbContext.Alunos
            .FirstOrDefaultAsync(a => a.Email == email && a.Senha == senha);

        return aluno;
    }
}