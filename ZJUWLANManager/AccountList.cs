using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZJUWLANManager
{
    /// <summary>
    /// the Data list of all Credentials.
    /// </summary>
    class AccountList : List<Account>
    {
        public AccountList()
        {
        }

        public AccountList(AccountList list)
        {
            foreach (Account account in list)
            {
                this.Add(account);
            }
        }
    }
}
