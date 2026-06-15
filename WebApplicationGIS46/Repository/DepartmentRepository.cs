using WebApplicationGIS46.Models;

namespace WebApplicationGIS46.Repository
{
    public class DepartmentRepository : IDepartmentRepo
    {
        ITIContext context;
        public DepartmentRepository(ITIContext _ctx)
        {
            context = _ctx;// new ITIContext();
        }
        //CRUD
        public void Add(Department entity)
        {
            context.Departments.Add(entity);
        }

        public void Delete(int id)
        {
            Department dept = GetById(id);
            context.Departments.Remove(dept);
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department entity)
        {
            Department dept=GetById(entity.Id);
            dept.Name=entity.Name;
            dept.ManagerName=entity.ManagerName;
        }
    }
}
