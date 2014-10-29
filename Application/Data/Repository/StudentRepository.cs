using Data.Infrastructure;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{

    #region Interface



    public interface IStudentRepository : IRepository<Student>
    {

    }

    #endregion
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
