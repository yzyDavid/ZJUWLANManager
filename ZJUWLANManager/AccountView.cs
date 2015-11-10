using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ZJUWLANManager
{
    /// <summary>
    /// A single Grid of a Credential in the list displayed
    /// </summary>
    class AccountView : Grid
    {
        public AccountView()
        {
            var usernameBlock = new RichTextBlock();
            var passwordBlock = new RichTextBlock();
            var fontFmy = new FontFamily("Segoe UI");
            usernameBlock.FontFamily = fontFmy;
            usernameBlock.FontSize = 14;
        }
    }
}
