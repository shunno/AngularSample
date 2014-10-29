using Data.Infrastructure;
using Data.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    #region Interface
    public interface IStudentService
    {
        void Save(Student student);
        void Update(Student student);
        void Delete(Student student);
        IEnumerable<Student> Get();
        Student GetById(int id);

        void Commit();

    }
    #endregion
    public class StudentService : IStudentService
    {

        private IStudentRepository _studentRepository;
        private IUnitOfWork _UnitOfWork;
        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            this._studentRepository = studentRepository;
            this._UnitOfWork = unitOfWork;
        }

        public void Save( Student student)
        {
            _studentRepository.Add(student);
        }

        public void Update(Student student)
        {
            _studentRepository.Update(student);
        }

        public void Delete(Student student)
        {
            _studentRepository.Delete(student);
        }

        public IEnumerable<Student> Get()
        {
           return _studentRepository.GetAll().ToList();
        }

        
        public void Commit()
        {
            CommitOperation commitOperation = CommitOperation.GetCommitOperation;
            try
            {
                
                _UnitOfWork.Commit();
            }
            catch (Exception)
            {

                commitOperation.Success = false;
            }
        }


        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }
    }
}
