using Newtonsoft.Json;
using System.Text;
using WebConsumoAPI.Interfaces;
using WebConsumoAPI.Models;

namespace WebConsumoAPI.Repository
{
    public class RepositoryAlunoTurma : IAlunoTurma
    {
        private readonly string uprApi = "https://localhost:44349/api/AlunosTurma";
        public string AdicionaAsync(AlunoTurmaModel request)
        {
            string Resposta_API;

            try
            {
                using var cliente = new HttpClient();
                string jsonObjeto = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                var resposta = cliente.PostAsync(uprApi, content);
                resposta.Wait();
                var retorno = resposta.Result.Content.ReadAsStringAsync();
                Resposta_API = retorno.Result;
                return Resposta_API;


            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<AlunoTurmaModel> BuscaAlunosTurmaAsync()
        {
            var retorno = new List<AlunoTurmaModel>();

            try
            {
                
                using var cliente = new HttpClient();
                var resposta = cliente.GetStringAsync(uprApi);
                resposta.Wait();
                retorno = JsonConvert.DeserializeObject<AlunoTurmaModel[]>(resposta.Result).ToList();

            }
            catch
            {
                throw;
            }
            return retorno;
        }

        public IEnumerable<AlunoTurmaModel> BuscaAlunoTurmaByAluno(int aluno_id)
        {
            var retorno = new List<AlunoTurmaModel>();

            try
            {
                var teste = uprApi + "/id?aluno_id=" + aluno_id;
                using var cliente = new HttpClient();
                var resposta = cliente.GetStringAsync(uprApi + "/id?aluno_id=" + aluno_id);
                resposta.Wait();
                retorno = JsonConvert.DeserializeObject<AlunoTurmaModel[]>(resposta.Result).ToList();
                
            }
            catch
            {
                throw;
            }
            return retorno;
        }

        public AlunoTurmaModel BuscaAlunoTurmaCompleto(int turma_id, int aluno_id)
        {
            var retorno = new AlunoTurmaModel();

            try
            {
                
                using var cliente = new HttpClient();
                var resposta = cliente.GetStringAsync(uprApi + "/turma_id/aluno_id?turma_id="+ turma_id + "&aluno_id=" + aluno_id);
                resposta.Wait();
                retorno = JsonConvert.DeserializeObject<AlunoTurmaModel>(resposta.Result);

            }
            catch
            {
                throw;
            }
            return retorno;
        }

        public IEnumerable<AlunoTurmaModel> BuscaAlunoTurmaByTurma(int turma_id)
        {
            var retorno = new List<AlunoTurmaModel>();

            try
            {
                
                using var cliente = new HttpClient();
                var resposta = cliente.GetStringAsync(uprApi + "/id?id=" + turma_id);
                resposta.Wait();
                retorno = JsonConvert.DeserializeObject<AlunoTurmaModel[]>(resposta.Result).ToList();

            }
            catch
            {
                throw;
            }
            return retorno;
        }
        

        public string DeletarAsync(int turma_id, int aluno_id)
        {
            string alunoAlterado;
            
            try
            {
                using var cliente = new HttpClient();

                var resposta = cliente.DeleteAsync(uprApi + "/id?turma_id="+ turma_id + "&aluno_id=" + aluno_id);
                resposta.Wait();                
                var retorno = resposta.Result.Content.ReadAsStringAsync();
                alunoAlterado = retorno.Result;                    
                
            }
            catch
            {
                throw;
            }
            return alunoAlterado;
        }
    }
}
