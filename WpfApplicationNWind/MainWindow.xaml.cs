using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
namespace WpfApplicationNWind
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product p = new Product();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonSuchen_Click(object sender, RoutedEventArgs e)
        {
            SqlConnectionStringBuilder bldr = new SqlConnectionStringBuilder();
            
            bldr.DataSource = @"(local)";
            bldr.InitialCatalog ="NwindSQL";
            bldr.IntegratedSecurity = true;
            //Data Source=RG6\RG6_SQL05;Initial Catalog=Northwind;Integrated Security=True
            SqlConnection con = new SqlConnection(bldr.ConnectionString);
         
            con.Open();
            String sqlString = "Select ProductId, ProductName, UnitPrice From Products Where ProductId =  " + textBoxProductId.Text;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sqlString;
            SqlDataReader reader = cmd.ExecuteReader();
            grid1.DataContext = null; 
            if (reader.Read())
            {
                
                Product prod = new Product((int)reader[0],
                    (string) reader[1], (decimal) reader[2]);

                grid1.DataContext = prod;
            }
            else
            {
               
                //grid1.DataContext = null;
                textBoxProductId.Text = textBoxProductId.Text +":Satz nicht gefunden";
                //txtBlockProdName.Text = String.Empty;
                //txtBlockUnitPrice.Text = String.Empty;
            }
            reader.Close();
            con.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
