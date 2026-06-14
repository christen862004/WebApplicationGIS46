using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

namespace WebApplicationGIS46.Models
{
    //DIP +IOC
    interface ISort
    {
        void Sort(int[] arr);
    }
    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //Sort using BubbleSort alg
        }
    }
    class SelectionSort:ISort
    {
        public void Sort(int[] arr)
        {

        }
    }
    class ChrisSort : ISort
    {
        public void Sort(int[] arr)
        {
            throw new NotImplementedException();
        }
    }
    //Depency
    //DIP (dont high level[myList] class depend on low level class[bubble Sort] , based oin abstrratcion , interface
    //IOC (dont 2 class tigh couple ,make it lossly couple)
    class MyList
    {
        int[] arr;
        ISort sortRef=null;
        public MyList(ISort _sortAlg)//Depency Inject//ask pass ISort interface(constirutor )
        {
            arr = new int[10];
            sortRef = _sortAlg;//new BubbleSort(); //wrong
        }
        public void SortList()//method parameter ask about Isort
        {
            sortRef.Sort(arr);
        }
    }
    class Test1
    {
        public void M()
        {
            MyList l1=new MyList(new BubbleSort());
            MyList l2=new MyList(new SelectionSort());
            MyList l3=new MyList(new ChrisSort());
            
        }
    }














    class Parent
    {
        public virtual void Read()
        {

        }
    }
    class Child : Parent
    {
        public override void Read()
        {
            base.Read();
        }
        public void Save()
        {

        }
    }

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
            //Parent p = new Child();
            //p.Read();
            
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
