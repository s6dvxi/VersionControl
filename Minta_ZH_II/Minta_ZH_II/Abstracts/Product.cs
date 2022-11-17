using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minta_ZH_II
{
    public abstract class Product : Button
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                Text = Title;
            }
        }

        private int _calories;
        public int Calories
        {
            get { return _calories; }
            set
            {
                _calories = value;
                Display();
            }
        }
        protected abstract void Display();

        public Product()
        {
            Width = 150;
            Height = 50;
        }
    }
}
