using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DockerMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoTextoController : ControllerBase
    {
        private readonly IOptions<AppSettings> _settings;

        public ArquivoTextoController(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        // POST api/<ArquivoTextoController>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">Texto a ser inserido no arquivo</param>
        [HttpPost("text")]
        public IActionResult Create(string text)
        {
            try
            {
                var diretorio = _settings.Value.Diretorio;

                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                var nomeConfig = Regex.Replace(text, @"\s+", "_");

                var nomeArquivo = $"{nomeConfig.ToLower()}.{Guid.NewGuid()}.txt";

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

        // GET api/<ArquivoTextoController>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arquivo"></param>
        [HttpGet("nomeArquivo")]
        public IActionResult Get(string nomeArquivo)
        {
            try
            {
                var diretorio = _settings.Value.Diretorio;

                if (!Directory.Exists(diretorio))
                {
                    return BadRequest($"Could not find directory.");
                }

                if (!System.IO.File.Exists($"{diretorio}{nomeArquivo}"))
                {
                    return BadRequest($"Could not find: {nomeArquivo}.");
                }

                var arquivo = new StreamReader($"{diretorio}{nomeArquivo}", Encoding.Default);

                var obj = new
                {
                    Nome = arquivo.ReadLine(),
                    Data = arquivo.ReadLine()
                };
                
                arquivo.Dispose();

                return Ok(obj);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
