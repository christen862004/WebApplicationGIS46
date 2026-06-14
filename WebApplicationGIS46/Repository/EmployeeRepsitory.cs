using WebApplicationGIS46.Models;

namespace WebApplicationGIS46.Repository
{
    public class EmployeeRepsitory:IEmployeeRepo
    {
        //CRUD (Create -Read - Update -Delete)
        ITIContext context;
        public EmployeeRepsitory()
        {
            context = new ITIContext();
        }
        public void Add(Employee entity)
        {
            context.Employees.Add(entity);
        }

      
        public void Delete(int id)
        {
            Employee emp=GetById(id);
            context.Employees.Remove(emp);
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            Employee emp = context.Employees.FirstOrDefault(e => e.Id == id);
            return emp;
        }

        public void Save()
        {
            context.SaveChanges();
        }

      

        public void Update(Employee entity)
        {
            Employee empFromDB=GetById(entity.Id);
            empFromDB.Name = entity.Name;
            empFromDB.Salary = entity.Salary;
            empFromDB.ImageURL = entity.Name;
            empFromDB.DepartmentId = entity.DepartmentId;

        }
    }
}
