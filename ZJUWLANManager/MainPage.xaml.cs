using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            MCurrentAccount = new Account();
            MAccountList = new ObservableCollection<Account>();
            TextUsername.PlaceholderText = @"Enter Username here.";
            TextPassword.PlaceholderText = @"Enter your Password here.";

            TextUsername.Text = "";
            TextPassword.Password = "";
#if DEBUG
            TextUsername.Text = @"18158519680@zjua.xy";
            TextPassword.Password = "";
#endif
            LoadTextCredential();
        }

        public Account MCurrentAccount { get; }
        public ObservableCollection<Account> MAccountList { get; }

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            await new Login(MCurrentAccount).DoLogin();
//#if DEBUG
//            ListSavedCredentials.Items.Add(_mCurrentAccount);
//#endif
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var account = new Account(TextUsername.Text,TextPassword.Password);
            MAccountList.Add(account);
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

        /// <summary>
        /// 列表实现后应该移除这种方法
        /// 也许不必，_mCurrentAccount 可用于保存文本框中输入的凭据
        /// </summary>
        private void LoadTextCredential()
        {
            MCurrentAccount.Username = TextUsername.Text;
            MCurrentAccount.Password = TextPassword.Password;
        }
    }
}
