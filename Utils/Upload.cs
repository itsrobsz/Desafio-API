using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace APISistemaVeterinario.Utils
{
    public static class Upload
    {
        // Upload - retorna apenas o nome do arquivo para salvar no banco
        public static string UploadFile(IFormFile arquivo, string[] extensoesPermitidas, string diretorio)
        { 
            // Verifica as pastas a serem salvas
            try
            {
                // Determina onde será o arquivo
                var pasta = Path.Combine("StaticFiles", diretorio);
                var caminho = Path.Combine(Directory.GetCurrentDirectory(), pasta);

                // Verifica a existência de um arquivo para ser salvo
                if(arquivo.Length > 0)
                {
                    // Pega o nome do arquivo
                    string nomeArquivo = ContentDispositionHeaderValue.Parse(arquivo.ContentDisposition).FileName.Trim('"');

                    // Valida se a extensão é permitida
                    if (ValidarExtensao(extensoesPermitidas, nomeArquivo))
                    {
                        var extensao = RetonarExtensao(nomeArquivo);

                        // Impede que nomes de arquivo sejam duplicados
                        // Guid - Identificador exclusivo
                        var novoNome = $"{Guid.NewGuid()}.{extensao}";
                        var caminhoCompleto = Path.Combine(caminho, novoNome);

                        // Salva efitivamente o arquivo na aplicação
                        using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                        {
                            arquivo.CopyTo(stream);
                        }

                        return novoNome;
                    }
                }
                // Caso a stream não seja feita
                return "";
            }

            catch (System.Exception ex)
            {

                return ex.Message;
            }
        }


        // Validar Extensão de Arquivo
        public static bool ValidarExtensao(string[] extensoesPermitidas, string nomeArquivo)
        {
            string extensao = RetonarExtensao(nomeArquivo);

            // Verifica se a extensão do arquivo tá dentro das permitidas 
            foreach(string ext in extensoesPermitidas)
            {
                if (ext == extensao)
                {
                    return true;
                }
            }
            return false;
        }

        // Retornar a extensão 
        public static string RetonarExtensao(string nomeArquivo)
        {
            // arqu.ivo.jpeg = 3
            // length - 1 (o indice é sempre menos 1 do tamanho da array)

            string[] dados = nomeArquivo.Split('.');

            // retorna o último índice da array, que é a extensão
            return dados[dados.Length - 1];
        }

    }
}
