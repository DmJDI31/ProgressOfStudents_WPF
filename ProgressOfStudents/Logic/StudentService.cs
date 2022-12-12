using ProgressOfStudents.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProgressOfStudents.Logic
{
    public class StudentService
    {
        private readonly DataBaseContext dataBase;
        public StudentService()
        {
            dataBase = new DataBaseContext();
        }
        public IEnumerable<Students> Get ()
        {
            return dataBase.Students.ToList();
        }
        public void Deleted(Students student)
        {
            dataBase.Students.Remove(student);
            dataBase.SaveChanges();
        }
        public void Update(Students student)
        {
            dataBase.Update(student);
            dataBase.SaveChanges();
        }
        public void Create(Students student)
        {
            dataBase.Add(student);
            dataBase.SaveChanges();
        }
        
    }
}
