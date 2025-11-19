using Application.Abstraction.Service.Core.Auth;
using Application.Abstraction.Service.Core.Exam;
using Application.Attributes;
using Application.Models.Request.Core;
using Application.Models.Request.Core.Exam;
using Application.Models.Response.Core;
using Application.Models.Response.Core.Exam;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _examResultService;

        public LessonController(ILessonService lessonService)
        {
            _examResultService = lessonService;
        }

        [Anonym]
        [HttpGet("list")]
        public async Task<ActionResult<BaseResponseModel<List<LessonInfoResponse>>>> GetList([FromQuery]PagingRequest pagingRequest)
        {
            var model= await _examResultService.GetDataListAsync<LessonInfoResponse>(null, pagingRequest);

            if (model.Success)
                return Ok(model);

            return BadRequest(model);
        }


        [Anonym]
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel<LessonInfoResponse>>> Get(int id)
        {
            var model = await _examResultService.GetDataAsync<LessonInfoResponse>(id);

            if (model.Success)
                return Ok(model);

            return BadRequest(model);
        }

        [HttpPut()]
        [RoleSecure("admin")]
        public async Task<ActionResult<BaseResponseModel<LessonInfoResponse>>> Save(LessonInfoRequest request)
        {
            var model = await _examResultService.SaveDataAsync<LessonInfoResponse>(request);

            if (model.Success)
                return Ok(model);

            return BadRequest(model);
        }
    }
}
