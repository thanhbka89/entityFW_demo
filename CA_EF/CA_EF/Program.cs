using CA_EF.CodeFirst;
using CA_EF.LinQSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_EF
{
    class Program
    {
        learningsqlEntities db;

        public Program()
        {
            db = new learningsqlEntities();

            // them moi 2 material
            //AddMaterial(new DEPARTMENT
            //{                
            //    NAME = "Demo"                
            //});

            //AddMaterial(new DEPARTMENT
            //{                                
            //    NAME = "Mod"
            //});

            // get tat ca du lieu trong bang Material trong database
            var materials = db.DEPARTMENTs.ToList();

            // in cac material ra
            foreach (var item in materials)
            {
                Console.WriteLine("Stt: " + item.DEPT_ID);
                Console.WriteLine("Name: " + item.NAME);                
                Console.WriteLine("---------------------");
            }

            Console.WriteLine("LinQ To Entity");
            LinQToEntity();

        }

        public void LinQToEntity()
        {            
            var query = from p in db.PRODUCTs
                        //where p.PRODUCT_CD == "LOAN"
                        select p.NAME;

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        public void AddMaterial(DEPARTMENT material)
        {
            db.DEPARTMENTs.Add(material);
            db.SaveChanges();
        }

        public void EditMaterial(DEPARTMENT newMaterial)
        {
            var material = db.DEPARTMENTs.Where(m => m.DEPT_ID == newMaterial.DEPT_ID).FirstOrDefault();            
            material.NAME = newMaterial.NAME;           
            db.Entry(material).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        static void Main(string[] args)
        {
            new Program();

            Console.WriteLine(">>>>> Code First from Database <<<<<");
            using(var db = new DBCodeFirst())
            {
                //insert
                //var product = new Product { ProductName = "SP Test" };
                //db.Products.Add(product);
                //db.SaveChanges();

                // Display all Products from the database 
                var query = from b in db.Products
                            orderby b.ProductID
                            select b;

                Console.WriteLine("All products in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.ProductName);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }


            Console.WriteLine("============ CODE FIRST ============");
            using(var test = new TestEF())
            {
                var data = test.my_table.ToList();
                foreach(var item in data)
                {
                    Console.WriteLine(item.id + " : " + item.name);
                }
            }

            /*LinQ SQL*/
            Console.WriteLine("======== LinQ SQL ===========");
            using ( var db = new DBTestDataContext() )
            {
                //insert
                //Member mem = new Member();
                //mem.Id = 2;
                //mem.Name = "linq sql 2";
                //mem.Age = 12;
                //mem.Address = "hanoi";
                //db.Members.InsertOnSubmit(mem);
                //db.SubmitChanges();

                var name = from table in db.Members
                               //where table.Id == 0
                           select table.Name;

                foreach (var a in name)
                {
                    Console.WriteLine(a);
                }
            }                            

            Console.ReadKey();
        }
    }
}
