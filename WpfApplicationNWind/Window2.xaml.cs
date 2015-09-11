using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplicationNWind
{
    /// <summary>
    /// Interaktionslogik für Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Product prod = new Product(0, "Unknown", 0.00m);
        public Window2()
        {
            InitializeComponent();
            grid1.DataContext = prod;
        }

        private void ButtonSuchen_Click(object sender, RoutedEventArgs e)
        {
            SqlConnectionStringBuilder bldr = new SqlConnectionStringBuilder();

            bldr.DataSource = @"(local)";
            bldr.InitialCatalog = "NwindSQL";
            bldr.IntegratedSecurity = true;
            //Data Source=RG6\RG6_SQL05;Initial Catalog=Northwind;Integrated Security=True
            SqlConnection con = new SqlConnection(bldr.ConnectionString);

            con.Open();
            String sqlString = "Select ProductId, ProductName, UnitPrice From Products Where ProductId =  " + textBoxProductId.Text;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sqlString;
            SqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                    prod.ProductId = (int)reader[0];
                    prod.ProductName = (string)reader[1];
                    prod.UnitPrice = (decimal)reader[2];
            }
            else
            {

                textBoxProductId.Text = textBoxProductId.Text + ": Satz nicht gefunden";
             }
            reader.Close();
            con.Close();
        }
        
    }
}
