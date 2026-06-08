using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

namespace WebApplicationGIS46.Models
{

    public class TestClass
    {
        private object _viewData;
        public object ViewData
        {
            get { return _viewData; }
            set { _viewData = value; }
        }
        public dynamic ViewBag
        {
            get { return _viewData; }
            set { _viewData = value; }
        }
    }
    class test { 
        public void method()
        {
            TestClass t = new TestClass();
            t.ViewData = "asd";
            t.ViewBag = "ahmed";
            Console.WriteLine(t.ViewData);//asd , ahmede


            Parent<int> p = new Parent<int>();//close create object
                                              //  p.Model
            var xx = "sdfdf";
            dynamic x = 10;
            dynamic name = "ahmed";
            dynamic obj = new Student();
            obj.xyz = "sdasha";//Throw exception
            obj = x + name;
        }
    }

    class Parent<T>
    {
        public T Model { get; set; }
    }
    class Child1<T>:Parent<T>
    {

    }
    class Child2 : Parent<dynamic>
    { }
   
}
