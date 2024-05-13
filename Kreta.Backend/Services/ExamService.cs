using Kreta.Backend.Repos.Managers;
using Kreta.Shared.Models;
using Kreta.Shared.Models.SchoolCitizens;

namespace Kreta.Backend.Services
{
    public class ExamService : IExamService
    {
        private readonly IRepositoryManager _repositoryManager;
        public ExamService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        //•	A tantárgyak listája nevük szerinti sorrendben!
        public IQueryable<Subject> GetListOfSubjectSortByName()
        {
            return _repositoryManager
                .SubjectRepo
                .FindAll()
                .OrderBy(subject => subject.SubjectName);
        }

        // •	Tantárgyak neve és rövid neve nevük szerinti fordított sorrendben!
        public IQueryable<SubjectName> GetSubjectNameSortedDescending()
        {
            return _repositoryManager
                    .SubjectRepo
                    .FindAll()
                    .OrderByDescending(subject => subject.SubjectName)
                    .Select
                    (
                            subject => new SubjectName
                            {
                                NameOfSubject= subject.SubjectName,
                                ShortName= subject.ShortName,
                            }
                    );

        }

        // •	Diákok listája, amelyben az idősebb diákok vannak a lista elején!
        public IQueryable<Student> GetStudentSortedByBirthDay()
        {
            return _repositoryManager
                .StudentRepo
                .FindAll()
                .OrderBy(student => student.BirthDay);
        }

        // •	Tanárok neve és születési helye abécé szerinti fordított sorrendben!
        public IQueryable<NameAndBirthPlace> GetTeacherNameSorted()
        {
            return _repositoryManager
                .TeacherRepo
                .FindAll()
                .OrderBy(teacher => teacher.LastName)
                .ThenBy(teacher => teacher.FirstName)
                .Select(teacher => new NameAndBirthPlace 
                    { 
                        LastName= teacher.LastName,
                        FirstName= teacher.FirstName,
                        BirthPlace=teacher.PlaceOfBirth,
                    }
                );
        }

        // •	A női tanárok listája!
        public IQueryable<Teacher> GetWomanTeacher()
        {
            return _repositoryManager
                .TeacherRepo
                .FindAll()
                .Where(teacher => teacher.IsWoman);
        }

        // •	Azok a tanárok, akik októberben ünneplik születésnapjukat!
        public IQueryable<Teacher> GetTeacherBorInOctober()
        {
            return _repositoryManager
                .TeacherRepo
                .FindAll()
                .Where(teacher => teacher.BirthDay.Month == 10);
        }

        // •	Azok a női tanárok neve és születési ideje, akiknek adott a lakcímük!
        public IQueryable<NameAndBirthPlace> GetWomanTeacherWhoHasAddress()
        {
            return _repositoryManager
                .TeacherRepo
                .FindAll()
                .Where(teacher => teacher.IsWoman && teacher.AddressId != null)
                .Select(teacher => new NameAndBirthPlace
                    {
                        LastName = teacher.LastName,
                        FirstName = teacher.FirstName,
                        BirthPlace = teacher.PlaceOfBirth,
                    }
                );
        }
    }
}
