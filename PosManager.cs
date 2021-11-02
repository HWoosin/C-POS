using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 편의점POS
{
    class PosManager
    {
        public static List<UProduct> UPDS = new List<UProduct>();
        public static List<TDeliver> TDVER = new List<TDeliver>();
        public static List<COrder> COD = new List<COrder>();
        public static List<Order> OD = new List<Order>();
        public static List<Cusbuy> CB = new List<Cusbuy>();



        static PosManager()
        {
            Load();
        }
        public static void Load()
        {
            try
            {
                string UPDSOutput = File.ReadAllText(@"./UProducts.xml");
                XElement UPDSXElement = XElement.Parse(UPDSOutput);

                UPDS = (from item in UPDSXElement.Descendants("product")
                        select new UProduct()
                        {
                            Code = item.Element("code").Value,
                            Name = item.Element("name").Value,
                            Maker = item.Element("maker").Value,
                            Count = int.Parse(item.Element("count").Value),
                            Price = int.Parse(item.Element("price").Value)

                        }).ToList<UProduct>();


                string TDVERSOutput = File.ReadAllText(@"./Delivered.xml");
                XElement TDVERSXElement = XElement.Parse(TDVERSOutput);

                TDVER = (from item in TDVERSXElement.Descendants("delivered")
                         select new TDeliver()
                         {
                             Dcode = item.Element("dcode").Value
                         }).ToList<TDeliver>();

                string CODSOutput = File.ReadAllText(@"./COrder.xml");
                XElement CODSXElement = XElement.Parse(CODSOutput);

                COD = (from item in CODSXElement.Descendants("product")
                       select new COrder()
                        {
                            Code = item.Element("code").Value,
                            Name = item.Element("name").Value,
                            Maker = item.Element("maker").Value,
                            Count = int.Parse(item.Element("count").Value),
                            Price = int.Parse(item.Element("price").Value)



                       }).ToList<COrder>();

                string ODSOutput = File.ReadAllText(@"./Ordered.xml");
                XElement ODSXElement = XElement.Parse(ODSOutput);

                OD = (from item in ODSXElement.Descendants("product")
                       select new Order()
                       {
                           Code = item.Element("code").Value,
                           Name = item.Element("name").Value,
                           Maker = item.Element("maker").Value,
                           Count = int.Parse(item.Element("count").Value),
                           Price = int.Parse(item.Element("price").Value)



                       }).ToList<Order>();

                string CBOutput = File.ReadAllText(@"./CutomerBuy.xml");
                XElement CBXElement = XElement.Parse(CBOutput);

                CB = (from item in CBXElement.Descendants("buy")
                      select new Cusbuy()
                      {
                          Code = item.Element("code").Value,
                          Name = item.Element("name").Value,
                          Price = int.Parse(item.Element("price").Value),
                          Count = int.Parse(item.Element("count").Value),
                          Totalprice = int.Parse(item.Element("total").Value)



                      }).ToList<Cusbuy>();


            }
            catch (FileNotFoundException ex)
            {
                Save();
            }
            
        }




        public static void Save()
        {
            
            string UPDSOutput = "";
            UPDSOutput += "<products>\n";
            foreach (var item in UPDS)
            {
                UPDSOutput += "<product>\n";

                UPDSOutput += "<code>" + item.Code + "</code>\n";
                UPDSOutput += "<name>" + item.Name + "</name>\n";
                UPDSOutput += "<maker>" + item.Maker + "</maker>\n";
                UPDSOutput += "<count>" + item.Count + "</count>\n";
                UPDSOutput += "<price>" + item.Price + "</price>\n";

                UPDSOutput += "</product>\n";
            }
            UPDSOutput += "</products>";

            string CODSOutput = "";
            CODSOutput += "<products>\n";
            foreach (var item in COD)
            {
                CODSOutput += "<product>\n";

                CODSOutput += "<code>" + item.Code + "</code>\n";
                CODSOutput += "<name>" + item.Name + "</name>\n";
                CODSOutput += "<maker>" + item.Maker + "</maker>\n";
                CODSOutput += "<count>" + item.Count + "</count>\n";
                CODSOutput += "<price>" + item.Price + "</price>\n";

                CODSOutput += "</product>\n";
            }
            CODSOutput += "</products>";


            string TDVERSOutput = "";
            TDVERSOutput += "<tdeliver>\n";
            foreach (var item in TDVER)
            {
                TDVERSOutput += "<delivered>\n";
                TDVERSOutput += "<dcode>\n" + item.Dcode + "</dcode>\n";
                TDVERSOutput += "</delivered>\n";
            }
            TDVERSOutput += "</tdeliver>";
            
            
            string ODSOutput = "";
            ODSOutput += "<products>\n";
            foreach (var item in OD)
            {
                ODSOutput += "<product>\n";
                ODSOutput += "<code>" + item.Code + "</code>\n";
                ODSOutput += "<name>" + item.Name + "</name>\n";
                ODSOutput += "<maker>" + item.Maker + "</maker>\n";
                ODSOutput += "<count>" + item.Count + "</count>\n";
                ODSOutput += "<price>" + item.Price + "</price>\n";
                ODSOutput += "</product>\n";
            }
            ODSOutput += "</products>";
            
            
            string CBOutput = "";
            CBOutput += "<buys>\n";
            foreach (var item in CB)
            {
                CBOutput += "<buy>\n";
                CBOutput += "<code>" + item.Code + "</code>\n";
                CBOutput += "<name>" + item.Name + "</name>\n";
                CBOutput += "<price>" + item.Price + "</price>\n";
                CBOutput += "<count>" + item.Count + "</count>\n";
                CBOutput += "<total>" + item.Totalprice + "</total>\n";
                CBOutput += "</buy>\n";
            }
            CBOutput += "</buys>";
            
            File.WriteAllText(@"./COrder.xml", CODSOutput);
            File.WriteAllText(@"./CutomerBuy.xml", CBOutput);
            File.WriteAllText(@"./Ordered.xml", ODSOutput);
            File.WriteAllText(@"./Delivered.xml", TDVERSOutput);
            File.WriteAllText(@"./UProducts.xml", UPDSOutput);
            
        }
    }
}
