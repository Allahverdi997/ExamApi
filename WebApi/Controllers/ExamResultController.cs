using Application.Abstraction.Service.Core.Exam;
using Application.Attributes;
using Application.Models.Request.Core;
using Application.Models.Request.Core.Exam;
using Application.Models.Response.Core;
using Application.Models.Response.Core.Exam;
using Microsoft.AspNetCore.Mvc;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultService _examResultService;

        public ExamResultController(IExamResultService examResultService)
        {
            _examResultService = examResultService;
        }

        [Anonym]
        [HttpGet("list")]
        public async Task<ActionResult<BaseResponseModel<List<ExamResultResponse>>>> GetList([FromQuery] PagingRequest pagingRequest)
        {
            var model = await _examResultService.GetDataListAsync<ExamResultResponse>(null, pagingRequest);

            if (model.Success)
                return Ok(model);

            return BadRequest(model);
        }


        [Anonym]
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel<ExamResultResponse>>> Get(int id)
        {
            var model = await _examResultService.GetDataAsync<ExamResultResponse>(id);

            if (model.Success)
                return Ok(model);

            return BadRequest(model);
        }

        [HttpPut()]
        [RoleSecure("admin")]
        public async Task<ActionResult<BaseResponseModel<LessonInfoResponse>>> Save(ExamResultRequest request)
        {
            var model = await _examResultService.SaveDataAsync<ExamResultResponse>(request);

            if (model.Success)
                return Ok(model);

            return BadRequest(model);
        }
    }
}
