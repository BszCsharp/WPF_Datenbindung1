using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WpfApplicationNWind
{
    class Product: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnProrpertyChanged(PropertyChangedEventArgs e)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        private int productId;
       
        public int ProductId
        {
            get { return productId; }
            set { 
                productId = value;
                OnProrpertyChanged(new PropertyChangedEventArgs("ProductId"));
            }
        }
        private String productName;

        public String ProductName
        {
            get { return productName; }
            set { 
                productName = value;
                OnProrpertyChanged(new PropertyChangedEventArgs("ProductName"));
            }
        }
        private decimal unitPrice;

        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { 
                unitPrice = value;
                OnProrpertyChanged(new PropertyChangedEventArgs("UnitPrice"));
            }
        }

        public Product()
        {
            
        }

        public Product(Int32 productId,String productName,decimal unitPrice)
        {
            this.ProductName = productName;
            this.UnitPrice = unitPrice;
            this.ProductId = productId;
        }

        
    }
}
