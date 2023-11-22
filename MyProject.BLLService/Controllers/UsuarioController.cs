using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.MODEL;
using MyProject.BLL;

namespace MyProject.BLLService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuario")]
        public ActionResult<List<Usuario>> GetUsuario()
        {
            try
            {
                List<Usuario> list = UsuarioRepository.GetAll();
                if (list != null) { return Ok(list); }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetUsuarioById")]
        public ActionResult<Usuario> GetUsuarioById(int id)
        {
            try
            {
                Usuario _usuario = UsuarioRepository.GetById(id);
                if (_usuario != null) { return Ok(_usuario); }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(Name = "AddUsuario")]
        public ActionResult<Usuario> AddUsuario(Usuario usuario)
        {
            try
            {
                Usuario _usuario = UsuarioRepository.Add(usuario);
                if (_usuario != null)
                {
                    return Ok(_usuario);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut(Name = "UpdateUsuario")]
        public ActionResult<Usuario> UpdateUsuario(Usuario usuario)
        {
            try
            {
                Usuario _usuario = new Usuario();
                _usuario.Id = usuario.Id;
                _usuario.Nome = usuario.Nome;
                _usuario.Login = usuario.Login;
                _usuario.Senha = usuario.Senha;

                UsuarioRepository.Update(_usuario);
                return Ok(_usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete(Name = "DeleteUsuario")]
        public ActionResult DeleteUsuario(int Id)
        {
            try
            {
                var usuario = UsuarioRepository.GetById(Id);
                UsuarioRepository.Excluir(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
