using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Xml;
using WebApplicationGIS46.Models;

namespace WebApplicationGIS46.Repository
{
    public class EmpRepoFromMemeory : IEmployeeRepo
    {
        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return new List<Employee>() { 
                new Employee(){ Id=1,Name="Ahmed",ImageURL="m.png"},
                new Employee(){ Id=2,Name="Model",ImageURL="m.png"},
            };
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
