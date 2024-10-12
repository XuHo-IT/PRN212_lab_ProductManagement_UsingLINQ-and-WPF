using BusinessObjects;
using Services;
using System.Windows;
using WpfApp1;

namespace WPFApp
{
    public partial class LoginWindow : Window
    {
        private readonly IAccountService iAccountService;

        public LoginWindow()
        {
            InitializeComponent();
            iAccountService = new AccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Get account details by user ID
            AccountMember account = iAccountService.GetAccountById(txtUser.Text);

            // Check if account exists and password is correct
            if (account != null)
            {
                // Ensure the password is not null and matches the one entered in the password field
                if (!string.IsNullOrEmpty(txtPass.Password) && account.MemberPassword.Equals(txtPass.Password))
                {
                    // Check if the user has the correct role (assuming 1 is the correct role)
                    if (account.MemberRole == 1)
                    {
                        this.Hide();  // Hide the current window
                        Window1 mainWindow = new Window1();
                        mainWindow.Show();  // Show the main window
                    }
                    else
                    {
                        MessageBox.Show("You do not have permission!");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid password!");
                }
            }
            else
            {
                MessageBox.Show("Account not found!");
            }
        }



        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
