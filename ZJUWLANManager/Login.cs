using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace ZJUWLANManager
{
    class Login
    {
        private Account _mAccount;

        public Login()
        {
            _mAccount = new Account();
        }

        public Login(Account mAccount)
        {
            _mAccount = new Account();
            _mAccount.Username = mAccount.Username;
            _mAccount.Password = mAccount.Password;
        }

        public Login(string username, string password)
        {
            _mAccount.Username = username;
            _mAccount.Password = password;
        }

        /// <summary>
        /// 约定成功登陆返回0，不成功返回错误代码，未知返回-1
        /// </summary>
        /// <returns></returns>
        public async Task<int> DoLogin()
        {
            var httpClient = new HttpClient();
            var requestUrl = "https://net.zju.edu.cn/cgi-bin/srun_portal";
            var formcontent = new HttpFormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("action","login"),
                new KeyValuePair<string, string>("username",_mAccount.Username),
                new KeyValuePair<string, string>("password",_mAccount.Password),
                new KeyValuePair<string, string>("ac_id","3"),
                new KeyValuePair<string, string>("type","1"),
                new KeyValuePair<string, string>("wbaredirect",@"http://www.qsc.zju.edu.cn/"),
                new KeyValuePair<string, string>("mac","undefined"),
                new KeyValuePair<string, string>("user_ip",""),
                new KeyValuePair<string, string>("is_ldap","1"),
                new KeyValuePair<string, string>("local_auth","1"),
            });
            var response = await httpClient.PostAsync(new Uri(requestUrl), formcontent);
            var responseString=await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseString);

            return -1;
        }
    }
}
