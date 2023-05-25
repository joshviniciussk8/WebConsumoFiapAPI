using WebConsumoAPI.Models;

namespace WebConsumoAPI.Interfaces
{
    public interface ITurma
    {
        IEnumerable<TurmaModel> BuscaAllTurmas();
        TurmaModel BuscaTurmaByID(int id);
        string AdicionaTurma(TurmaModel turma);
        string AtualizarTurma(TurmaModel turma, int id);
        string DeletarTurma(int id);
    }
}
