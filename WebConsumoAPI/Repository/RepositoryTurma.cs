using Microsoft.CodeAnalysis.Operations;
using Newtonsoft.Json;
using System.Text;
using WebConsumoAPI.Interfaces;
using WebConsumoAPI.Models;

namespace WebConsumoAPI.Repository
{
    public class RepositoryTurma : ITurma
    {
        private readonly string uprApi = "https://localhost:44349/api/Turma";  
     

        //Implementação

        public IEnumerable<TurmaModel> BuscaAllTurmas()
        {
            var retorno = new List<TurmaModel>();
            var retornoErro = new List<TurmaModel>();

            try
            {
                using var cliente = new HttpClient();
                var resposta = cliente.GetStringAsync(uprApi);
                resposta.Wait();
                retorno = JsonConvert.DeserializeObject<TurmaModel[]>(resposta.Result).ToList();
            }
            catch
            {
                return retornoErro;
            }
            return retorno;
        }
        public TurmaModel BuscaTurmaByID(int turma_id)
        {
            var retorno = new TurmaModel();

            try
            {
                string teste = uprApi + "/id?id=" + turma_id;
                using var cliente = new HttpClient();
                var resposta = cliente.GetStringAsync(uprApi + "/id?id=" + turma_id);
                resposta.Wait();
                retorno = JsonConvert.DeserializeObject<TurmaModel>(resposta.Result);
                retorno.id = turma_id;
            }
            catch
            {
                throw;
            }
            return retorno;
        }
        public string AdicionaTurma(TurmaModel turma)
        {
            string resposta_Api;
            
            try
            {
                
                using var cliente = new HttpClient();
                string jsonObjeto = JsonConvert.SerializeObject(turma);
                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                var resposta = cliente.PostAsync(uprApi, content);
                resposta.Wait();
                var retorno = resposta.Result.Content.ReadAsStringAsync();
                resposta_Api = retorno.Result;
                return resposta_Api;                
            }
            catch
            {                
                throw;
            }
            
        }
        public string AtualizarTurma(TurmaModel turma, int id)
        {
            string resposta_API = "Algo deu Errado!";
            try
            {
                using var cliente = new HttpClient();
                string jsonObjeto = JsonConvert.SerializeObject(turma);
                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                var resposta = cliente.PutAsync(uprApi+ "?id="+id, content);                
                resposta.Wait();
                var retorno = resposta.Result.Content.ReadAsStringAsync();
                resposta_API = retorno.Result;
                return resposta_API;
            }
            catch
            {
                throw;
            }
            
        }     
        
        public string DeletarTurma(int id)
        {
            string TurmaAlterada;
            
            try
            {
                using var cliente = new HttpClient();
                var teste = uprApi + "/id?turma_id=" + id;
                var resposta = cliente.DeleteAsync(uprApi+ "/id?turma_id=" + id);
                resposta.Wait();
                var retorno = resposta.Result.Content.ReadAsStringAsync();
                TurmaAlterada = retorno.Result;
                
            }
            catch
            {
                throw;
            }
            return TurmaAlterada;
        }
    }
}
