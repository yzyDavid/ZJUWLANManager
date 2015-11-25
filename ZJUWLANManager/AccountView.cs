using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace ZJUWLANManager
{
    /// <summary>
    /// A single Grid of a Credential in the list displayed
    /// </summary>
    class AccountView : Grid
    {
        public Account MAccount { get; }

        public AccountView(Account account)
        {
            MAccount = new Account(account);
            Initialize();
        }

        private AccountView()
        {
            MAccount = new Account();
        }

        private void Initialize()
        {
            Height = 80;
            Width = 400;
            Margin = new Thickness(10);
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Top;
            var cd1 = new ColumnDefinition();
            var cd2 = new ColumnDefinition();
            cd1.Width=new GridLength(5,GridUnitType.Star);
            cd2.Width=new GridLength(3,GridUnitType.Star);
            ColumnDefinitions.Add(cd1); 
            ColumnDefinitions.Add(cd2); 

            var usernameBlock = new TextBlock();
            var passwordBlock = new PasswordBox();
            var fontFmy = new FontFamily("Segoe UI");

            usernameBlock.FontFamily = fontFmy;
            usernameBlock.FontSize = 14;
            usernameBlock.Text = MAccount.Username;

            passwordBlock.Password = MAccount.Password;
            passwordBlock.FontFamily = fontFmy;
            passwordBlock.FontSize = 14;
            passwordBlock.PasswordRevealMode = PasswordRevealMode.Hidden;
            passwordBlock.IsEnabled = false;

            usernameBlock.SetValue(Grid.RowProperty, 0);
            passwordBlock.SetValue(Grid.RowProperty, 0);
            usernameBlock.SetValue(Grid.ColumnProperty, 0);
            passwordBlock.SetValue(Grid.ColumnProperty, 1);
            Children.Add(usernameBlock);
            Children.Add(passwordBlock);

//            this.Tapped += this.Parent.OnAccountGridTapped;
        }
    }
}
