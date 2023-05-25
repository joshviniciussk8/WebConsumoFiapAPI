using WebConsumoAPI.Models;

namespace WebConsumoAPI.Interfaces
{
    public interface IAluno
    {
        IEnumerable<AlunoModel> BuscaAlunosAsync(); 
        AlunoModel BuscaAlunoAsync(int id);
        string AdicionaAsync(AlunoModel aluno);
        string AtualizarAsync(AlunoModel aluno, int id);
        AlunoModel DeletarAsync(int id);
    }
}
