using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.UserDataAccounts.SystemAccess;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace ZJUWLANManager
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
//            TextUsername.Text = "Username";
//            TextPassword.Password = "Password";
            _mCurrentAccount = new Account();
#if DEBUG
            TextUsername.Text = @"18158519680@zjua.xy";
            TextPassword.Password = "";
#endif
            LoadTextCredential();
        }

        private Account _mCurrentAccount;
        private AccountList _mAccountList;

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            await new Login(_mCurrentAccount).DoLogin();
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var account = new Account(TextUsername.Text,TextPassword.Password);
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadTextCredential();
        }

        private void TextPassword_TextChanged(object sender, RoutedEventArgs routedEventArgs)
        {
            LoadTextCredential();
        }

        private void UpdateListView()
        {
            foreach (Account account in _mAccountList)
            {
                var view=new AccountView();
            }
        }

        /// <summary>
        /// 列表实现后应该移除这种方法
        /// </summary>
        private void LoadTextCredential()
        {
            _mCurrentAccount.Username = TextUsername.Text;
            _mCurrentAccount.Password = TextPassword.Password;
            // catch (NullReferenceException)
            //            {
            //                Debug.WriteLine("NullReferenceException thrown in method LoadTextCredential!");
            //
            //            }
        }
    }
}
