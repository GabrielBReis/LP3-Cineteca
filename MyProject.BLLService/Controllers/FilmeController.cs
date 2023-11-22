using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.MODEL;
using MyProject.BLL;


namespace MyProject.BLLService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        [HttpGet(Name = "GetFilme")]
        public ActionResult<List<Filme>> GetFilme()
        {
            try
            {
                List<Filme> list = FilmeRepository.GetAll();
                if (list != null) { return Ok(list); }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetFilmeById")]
        public ActionResult<Filme> GetFilmeById(int id)
        {
            try
            {
                Filme _filme = FilmeRepository.GetById(id);
                if (_filme != null) { return Ok(_filme); }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost(Name = "AddFilme")]
        public ActionResult<Filme> AddFilme(Filme cliente)
        {
            try
            {
                Filme _filme = FilmeRepository.Add(cliente);
                if (_filme != null)
                {
                    return Ok(_filme);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut(Name = "UpdateFilme")]
        public ActionResult<Filme> UpdateFilme(Filme filme)
        {
            try
            {
                Filme _filme = new Filme();
                _filme.Titulo = filme.Titulo;
                _filme.Ano = filme.Ano;
                _filme.Elenco = filme.Elenco;
                _filme.Descricao = filme.Descricao;

                FilmeRepository.Update(_filme);
                return Ok(_filme);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpDelete(Name = "DeleteFilme")]
        public ActionResult DeleteFilme(int Id)
        {
            try
            {
                var cliente = FilmeRepository.GetById(Id);
                FilmeRepository.Excluir(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
