using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.MapControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapController : ControllerBase
    {
        private readonly IMapInterface<MarkerData,Guid> _service;

        public MapController(IMapInterface<MarkerData,Guid> controller)
        {
            _service = controller;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Dictionary<Guid,MarkerData>>> GetAll()
        {
            Dictionary<Guid,MarkerData> markers = await _service.GetMarksAsync();
            if (markers.Count == 0)
            {
                return NotFound();
            }
            return markers;
        }

        [HttpDelete("Remove/{guid}")]
        public async Task<ActionResult> RemoveMarker(Guid guid)
        {
            if (await _service.DeleteMarkerAsync(guid))
            {
                return Ok();
            }
            return NotFound();
            
        }

        [HttpPost("CreateMarker")]
        public async Task<ActionResult<Guid>> CreateMarker(MarkerData marker)
        {
            return await _service.CreateMarkerAsync(marker);
        }
    }
}