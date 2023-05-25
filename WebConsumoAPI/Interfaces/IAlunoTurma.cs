using WebConsumoAPI.Models;

namespace WebConsumoAPI.Interfaces
{
    public interface IAlunoTurma
    {
        IEnumerable<AlunoTurmaModel> BuscaAlunosTurmaAsync();
        IEnumerable<AlunoTurmaModel> BuscaAlunoTurmaByAluno(int aluno_id);
        IEnumerable<AlunoTurmaModel> BuscaAlunoTurmaByTurma(int turma_id);
        AlunoTurmaModel BuscaAlunoTurmaCompleto(int turma_id, int aluno_id);        
        string AdicionaAsync(AlunoTurmaModel request);
        string DeletarAsync(int turma_id, int aluno_id);
        
    }
}
