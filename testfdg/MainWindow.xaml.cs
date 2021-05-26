using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Assignmen03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users;
        private bool isAscending;

        public MainWindow()
        {
            InitializeComponent();

            Users = new ObservableCollection<User>();

            Users.Add(new User { Name = "Dave", Password = "1DavePwd" });
            Users.Add(new User { Name = "Steve", Password = "2StevePwd" });
            Users.Add(new User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = Users;
            head.Click += Test_Click;
        }
        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
            }
        }



        private void Test_Click(object sender, RoutedEventArgs e)
        {
            //temp = isAscending ? new ObservableCollection<User>(temp.OrderBy(x => x.Name)) :
            //                     new ObservableCollection<User>(temp.OrderByDescending(x => x.Name));
            if (!isAscending)
            {
                var sortedUsers = Users.OrderBy(x => x.Name).ToList();
                Users = new ObservableCollection<User>(sortedUsers);
                uxList.ItemsSource = null;
                uxList.ItemsSource = Users;
                isAscending = true;
            }
            else
            {                    
                var sortedUsers = Users.OrderByDescending(x => x.Name).ToList();
                Users = new ObservableCollection<User>(sortedUsers);
                uxList.ItemsSource = null;
                uxList.ItemsSource = Users;
                isAscending = false;
            }

        }
    }

    public class User 
    {
        private string name;
        
        public string Name
        {
            get => name; set
            {
                name = value;
            }
        }
        public string Password { get; set; }
    }
}
