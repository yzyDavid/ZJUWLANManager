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
        private Account _mAccount;

        public AccountView(Account account)
        {
            _mAccount = new Account(account);
            Initialize();
        }

        private AccountView() { }

        private void Initialize()
        {
            Height = 80;
            Width = 280;
            Margin = new Thickness(10);
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Top;
            ColumnDefinitions.Add(new ColumnDefinition());

            var usernameBlock = new TextBlock();
            var passwordBlock = new PasswordBox();
            var fontFmy = new FontFamily("Segoe UI");

            usernameBlock.FontFamily = fontFmy;
            usernameBlock.FontSize = 14;
            usernameBlock.Text = _mAccount.Username;

            passwordBlock.Password = _mAccount.Password;
            passwordBlock.FontFamily = fontFmy;
            passwordBlock.FontSize = 14;
            passwordBlock.PasswordRevealMode = PasswordRevealMode.Hidden;
            passwordBlock.IsEnabled = false;

            Children.Add(usernameBlock);
            Children.Add(passwordBlock);
            usernameBlock.SetValue(Grid.RowProperty, 0);
            passwordBlock.SetValue(Grid.RowProperty, 0);
            usernameBlock.SetValue(Grid.ColumnProperty, 0);
            usernameBlock.SetValue(Grid.ColumnProperty, 1);
        }
    }
}
