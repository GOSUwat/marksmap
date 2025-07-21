using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.MapControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapController : ControllerBase
    {
        private readonly IMapInterface _service;

        public MapController(IMapInterface controller)
        {
            _service = controller;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<MarkerData>>> GetAll()
        {
            List<MarkerData> markers = await _service.GetMarksAsync();
            if (markers.Count == 0)
            {
                return NotFound();
            }
            return markers;
        }

        [HttpDelete("Remove/{guid}")]
        public async Task<ActionResult> RemoveMarker(Guid guid)
        {
            return Ok(await _service.DeleteMarkerAsync(guid));
        }

        [HttpPost("CreateMarker")]
        public async Task<ActionResult<Guid>> CreateMarker(MarkerData marker)
        {
            return await _service.CreateMarkerAsync(marker);
        }
    }
}