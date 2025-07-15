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

        [HttpGet]
        public async Task<ActionResult<List<MarkerData>>> Get()
        {
            List<MarkerData> markers = await _service.GetMarksAsync();
            if (markers.Count == 0)
            {
                return NotFound();
            }
            return markers;
        }
    }
}