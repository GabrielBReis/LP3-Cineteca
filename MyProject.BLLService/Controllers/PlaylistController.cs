using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.MODEL;
using MyProject.BLL;


namespace MyProject.BLLService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {

        [HttpGet(Name = "GetPlaylist")]
        public ActionResult<List<Playlist>> GetPlaylist()
        {
            try
            {
                List<Playlist> list = PlaylistRepository.GetAll();
                if (list != null) { return Ok(list); }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetPlaylistById")]
        public ActionResult<Playlist> GetPlaylistById(int id)
        {
            try
            {
                Playlist _playlist = PlaylistRepository.GetById(id);
                if (_playlist != null) { return Ok(_playlist); }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost(Name = "AddPlaylist")]
        public ActionResult<Playlist> AddPlaylist(Playlist cliente)
        {
            try
            {
                Playlist _playlist = PlaylistRepository.Add(cliente);
                if (_playlist != null)
                {
                    return Ok(_playlist);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(Name = "DeletePlaylist")]
        public ActionResult DeletePlaylist(int Id)
        {
            try
            {
                var cliente = PlaylistRepository.GetById(Id);
                PlaylistRepository.Excluir(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
