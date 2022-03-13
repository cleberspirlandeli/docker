using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;

namespace ArquivoTexto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoTextoController : ControllerBase
    {
        ILogger<ArquivoTextoController> _logger;

        public ArquivoTextoController(ILogger<ArquivoTextoController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Criar Arquivo de Texto
        /// </summary>
        /// <param name="text">Texto a ser inserido no arquivo</param>
        /// <returns>Nome do arquivo</returns>
        [HttpPost("{text}")]
        public IActionResult Post(string text)
        {
            try
            {
                var diretorio = @"D:\Estudos\Docker\ApiTexto\ArquivoTexto\ArquivoTexto\docs\";

                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                var nomeArquivo = $"{text}.{Guid.NewGuid()}.txt";

                var arquivo = new StreamWriter($"{diretorio}{nomeArquivo}", false, Encoding.Default);
                arquivo.WriteLine(text);
                arquivo.WriteLine($"Dia/Hora: {DateTime.Now}");
                arquivo.Dispose();

                return Ok(new { arquivo = nomeArquivo });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
