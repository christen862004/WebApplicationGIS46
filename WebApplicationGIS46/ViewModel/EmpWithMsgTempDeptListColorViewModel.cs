namespace WebApplicationGIS46.ViewModel
{
    public class EmpWithMsgTempDeptListColorViewModel
    {
        //Some Proiperty from employee ,hidde table struvte
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        //Some Extran
        public int Temp { get; set; }
        public string Msg { get; set; }
        public string Color { get; set; }
        //megre
        public List<string> Departments { get; set; }
    }
}
