using System.Collections.Generic;

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
                Add(account);
            }
        }
    }
}
