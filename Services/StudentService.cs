using CrudLondrisoft.Models;
using CrudLondrisoft.Data;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CrudLondrisoft.Services
{
    public class StudentService : IService<Student,Student>
    {

        private CrudLondrisoftContext Context;

        public StudentService(CrudLondrisoftContext Context)
        {
            this.Context = Context;
        }

        public Student Create(Student Student)
        {
            try
            {
                Context.Add(Student);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Student;
        }

        public Student Delete(int Id)
        {
            var result = Context.Student.SingleOrDefault(x => x.StundentId == Id);
            if (result != null)
            {
                try
                {
                    Context.Student.Remove(result);
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public IEnumerable<Student> FindAll()
        {
            return Context.Student.ToList();
        }

        public Student FindByID(int Id)
        {
            return Context.Student
                .SingleOrDefault(x => x.StundentId == Id);
        }

        public Student Update(Student Student)
        {
            if (!Exists(Student.StundentId)) return null;
            var result = Context.Student.SingleOrDefault(x => x.StundentId == Student.StundentId);
            if (result != null)
            {
                try
                {
                    Context.Entry(result).CurrentValues.SetValues(Student);
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public bool Exists(int Id)
        {
            return Context.Student.Any(x => x.StundentId == Id);
        }
    }
}
