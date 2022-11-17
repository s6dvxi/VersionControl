using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Minta_ZH_II
{
    public partial class Form1 : Form
    {
        List<Product> _products = new List<Product>();
        public Form1()
        {
            InitializeComponent();
            GetProducts();
            ColumnMaker();
        }

        private string GetXML(string filename)
        {
            using(var sr = new StreamReader(filename, Encoding.Default))
            {
                var xml = sr.ReadToEnd();
                return xml;
            }
        }

        private void GetProducts()
        {
            var xml = new XmlDocument();
            xml.LoadXml(GetXML("Menu.xml"));

            foreach (XmlElement element in xml.DocumentElement)
            {
                var name = element.SelectSingleNode("name").InnerText;
                var calories = element.SelectSingleNode("calories").InnerText;
                var description = element.SelectSingleNode("description").InnerText;
                var type = element.SelectSingleNode("type").InnerText;

                if (type == "food")
                {
                    var p = new Food()
                    {
                        Title = name,
                        Calories = int.Parse(calories),
                        Description = description
                    };
                    _products.Add(p);
                }
                else
                {
                    var p = new Drink
                    {
                        Title = name,
                        Calories = int.Parse(calories)
                    };
                    _products.Add(p);
                }
            }            
        }
        private void ColumnMaker()
        {
            var topPos = 0;
            var sortedProducts = from x in _products
                                 orderby x.Title
                                 select x;

            foreach (var item in sortedProducts)
            {
                item.Left = 2;
                item.Top = topPos;
                Controls.Add(item);
                topPos += item.Height + 2;
            }
        }
    }
}
