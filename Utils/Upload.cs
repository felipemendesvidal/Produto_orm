using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Aula6.Utils
{
    public static class Upload
    {
        public static string Local(IFormFile file)
        {
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "")
                     + Path.GetExtension(file.FileName);

            //GetCurrentDirectory - Pega o caminho do diretório atual, aplicação estatica
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(),
                @"wwwRoot\upload\imagem", nomeArquivo);

            //Crio um objeto do tipo FileStream passando o camino do arquivo
            //passo para criar este caminho
            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

            //Executo o comando de criação do arquivo no local informado 
            file.CopyTo(streamImagem);

            return "http://localhost:54821/upload/imagem/" + nomeArquivo;

        }
    }
}
