using Microsoft.CodeAnalysis.Operations;
using Microsoft.Extensions.WebEncoders.Testing;
using Newtonsoft.Json;
using System.Text;
using WebConsumoAPI.Interfaces;
using WebConsumoAPI.Models;

namespace WebConsumoAPI.Repository
{
    public class RepositoryAluno : IAluno
    {
        private readonly string uprApi = "https://localhost:44349/api/Alunos";
        public string AdicionaAsync(AlunoModel aluno)
        {
            string Resposta_API;
            
            try
            {
                using var cliente = new HttpClient();
                string jsonObjeto = JsonConvert.SerializeObject(aluno);
                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                var resposta = cliente.PostAsync(uprApi+"/Novo", content);
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

        public string AtualizarAsync(AlunoModel aluno, int id)
        {
            string Resposta_API;
            try
            {
                
                using var cliente = new HttpClient();
                string jsonObjeto = JsonConvert.SerializeObject(aluno);
                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                var resposta = cliente.PutAsync(uprApi+"/Alterar?id="+id, content);
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

        public AlunoModel BuscaAlunoAsync(int id)
        {
            var retorno = new AlunoModel();

            try
            {
                string teste = uprApi + "/id?id=" + id;
                using var cliente = new HttpClient();
                var resposta = cliente.GetStringAsync(uprApi+"/id?id="+id);
                resposta.Wait();
                retorno = JsonConvert.DeserializeObject<AlunoModel>(resposta.Result);
                retorno.id = id;
            }
            catch
            {
                throw;
            }
            return retorno;
        }

        public IEnumerable<AlunoModel> BuscaAlunosAsync()
        {
            var retorno = new List<AlunoModel>();
            var retornoErro = new List<AlunoModel>();
            try
            {
                using var cliente = new HttpClient();                
                var resposta = cliente.GetStringAsync(uprApi);
                resposta.Wait();
                retorno = JsonConvert.DeserializeObject<AlunoModel[]>(resposta.Result).ToList();
            }
            catch
            {
                return retornoErro;
            }
            return retorno;
        }

        public AlunoModel DeletarAsync(int id)
        {
            var alunoAlterado = new AlunoModel();
            alunoAlterado.id = id;
            try
            {
                using var cliente = new HttpClient();
                
                var resposta = cliente.DeleteAsync(uprApi+ "/id?aluno_id="+id);
                resposta.Wait();
                if (resposta.Result.IsSuccessStatusCode)
                {
                    var retorno = resposta.Result.Content.ReadAsStringAsync();
                    //alunoAlterado = JsonConvert.DeserializeObject<AlunoModel>(retorno.Result);
                }
            }
            catch
            {
                throw;
            }
            return alunoAlterado;
        }
    }
}
