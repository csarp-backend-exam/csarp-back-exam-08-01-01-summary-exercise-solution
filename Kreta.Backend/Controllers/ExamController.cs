using Kreta.Backend.Services;
using Kreta.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Kreta.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet("ListOfSubjectSortByName")]
        public IActionResult GetListOfSubjectSortByName()
        {
            return Ok(_examService.GetListOfSubjectSortByName().Select(subject =>subject.ToDto()));
        }

        [HttpGet("SubjectNameSortedDescending")]
        public IActionResult GetGetSubjectNameSortedDescending()
        {
            return Ok(_examService.GetSubjectNameSortedDescending());
        }

        [HttpGet("StudentSortedByBirthDay")]
        public IActionResult GetStudentSortedByBirthDay()
        {
            return Ok(_examService.GetStudentSortedByBirthDay());
        }

        [HttpGet("TeacherNameSorted")]
        public IActionResult GetTeacherNameSorted()
        {
            return Ok(_examService.GetTeacherNameSorted());
        }

        [HttpGet("WomanTeacher")]
        public IActionResult GetWomanTeacher()
        {
            return Ok(_examService.GetWomanTeacher());
        }

        [HttpGet("TeacherBorInOctober")]
        public IActionResult GetTeacherBorInOctober()
        {
            return Ok(_examService.GetTeacherBorInOctober());
        }

        [HttpGet("WomanTeacherWhoHasAddress")]
        public IActionResult WomanTeacherWhoHasAddress()
        {
            return Ok(_examService.GetWomanTeacherWhoHasAddress());
        }

    }
}
