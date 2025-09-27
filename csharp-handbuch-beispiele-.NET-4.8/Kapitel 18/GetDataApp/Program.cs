using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDataApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(@"C:\TempData"))
                Directory.CreateDirectory(@"C:\TempData");

            SqlConnection con = new SqlConnection("Server=.;database=Northwind;Integrated Security=sspi");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Products");

            da = new SqlDataAdapter("SELECT * FROM Categories", con);
            da.Fill(ds, "Categories");

            da = new SqlDataAdapter("SELECT * FROM [Order Details]", con);
            da.Fill(ds, "OrderDetails");

            ds.WriteXml(@"C:\TempData\Elements.xml");

            DataColumn colMaster = ds.Tables["Categories"].Columns["CategoryID"];
            DataColumn colDetail = ds.Tables["Products"].Columns["CategoryID"];
            var rel = new DataRelation("relCategoryProducts", colMaster, colDetail);
            ds.Relations.Add(rel);

            DataColumn colMaster1 = ds.Tables["Products"].Columns["ProductID"];
            DataColumn colDetail1 = ds.Tables["OrderDetails"].Columns["ProductID"];
            var rel1 = new DataRelation("relProductOrderDetails", colMaster1, colDetail1);
            ds.Relations.Add(rel1);

            ds.WriteXmlSchema(@"C:\TempData\ElementsSchema.xsd");
        }
    }
}
