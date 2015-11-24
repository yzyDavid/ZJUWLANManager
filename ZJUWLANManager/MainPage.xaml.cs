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
    /// check if your test-purpose not removed before push to remote.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MCurrentAccount = new Account();
            MAccountList = new List<Account>();
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
        public List<Account> MAccountList { get; }

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            await new Login(MCurrentAccount).DoLogin();
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// TODO:按下Add按钮后应先验证是否重复
        /// </summary>
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var account = new Account(MCurrentAccount);
            MAccountList.Add(account);
            UpdateListView();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.ListSavedCredentials.SelectedItem;
            UpdateListView();
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
            Debug.WriteLine("before num of items = {0}", ListSavedCredentials.Items.Count);
            if (ListSavedCredentials.Items != null)
            {
                //                foreach (object acc in ListSavedCredentials.Items)
                //                {
                //                    ListSavedCredentials.Items.Remove(acc);
                //                }
                ListSavedCredentials.Items.Clear();
            }

            foreach (var account in MAccountList)
            {
                var view = new AccountView(account);
                Debug.Assert(ListSavedCredentials.Items != null, "ListSavedCredentials.Items != null");
                ListSavedCredentials.Items.Add(view);
            }
            Debug.WriteLine("after  num of items = {0}", ListSavedCredentials.Items.Count);
            ;   //for setting breeakpoint here.
        }

        /// <summary>
        /// 列表实现后应该移除这种方法
        /// 也许不必，_mCurrentAccount 可用于保存文本框中输入的凭据
        /// </summary>
        private void LoadTextCredential(bool isUpdateFromUItoBackend = true)
        {
            if (isUpdateFromUItoBackend)
            {
                MCurrentAccount.Username = TextUsername.Text;
                MCurrentAccount.Password = TextPassword.Password;
            }
            else
            {
                TextUsername.Text = MCurrentAccount.Username;
                TextPassword.Password = MCurrentAccount.Password;
            }
        }

        public void OnAccountGridTapped(object sender, TappedRoutedEventArgs e)
        {
            var accView = sender as AccountView;
            LoadTextCredential(false);
        }
    }
}
