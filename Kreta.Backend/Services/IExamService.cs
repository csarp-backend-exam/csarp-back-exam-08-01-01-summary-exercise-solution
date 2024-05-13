using Kreta.Shared.Models;
using Kreta.Shared.Models.SchoolCitizens;

namespace Kreta.Backend.Services
{
    public interface IExamService
    {
        IQueryable<Subject> GetListOfSubjectSortByName();
        public IQueryable<SubjectName> GetSubjectNameSortedDescending();
        public IQueryable<Student> GetStudentSortedByBirthDay();
        public IQueryable<NameAndBirthPlace> GetTeacherNameSorted();
        public IQueryable<Teacher> GetWomanTeacher();
        public IQueryable<Teacher> GetTeacherBorInOctober();
        public IQueryable<NameAndBirthPlace> GetWomanTeacherWhoHasAddress();
    }
}
