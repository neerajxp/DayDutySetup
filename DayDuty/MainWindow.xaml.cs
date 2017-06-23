using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DayDuty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connect_DB_Click(object sender, RoutedEventArgs e)
        {
            //Get full folder path where database file exists using the relative path if required
            string dbpath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"MyDatabase"));
            //Register this path in DataDirectory
            AppDomain.CurrentDomain.SetData("DataDirectory", dbpath);

            SqlConnection cn = new SqlConnection();
            //Use the DAtaDirectory path to connect to database
            cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True;Connect Timeout=30";
            cn.Open();
            MessageBox.Show(string.Format("Connection status is -> {0}", cn.State.ToString()));
        }
    }
}