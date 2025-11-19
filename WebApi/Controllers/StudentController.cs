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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Anonym]
        [HttpGet("list")]
        public async Task<ActionResult<BaseResponseModel<List<StudentResponse>>>> GetList([FromQuery] PagingRequest pagingRequest)
        {
            var model = await _studentService.GetDataListAsync<StudentResponse>(null, pagingRequest);

            if (model.Success)
                return Ok(model);

            return BadRequest(model);
        }


        [Anonym]
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel<StudentResponse>>> Get(int id)
        {
            var model = await _studentService.GetDataAsync<StudentResponse>(id);

            if (model.Success)
                return Ok(model);

            return BadRequest(model);
        }

        [HttpPut()]
        [RoleSecure("admin")]
        public async Task<ActionResult<BaseResponseModel<LessonInfoResponse>>> Save(StudentRequest request)
        {
            var model = await _studentService.SaveDataAsync<StudentResponse>(request);

            if (model.Success)
                return Ok(model);

            return BadRequest(model);
        }
    }
}
