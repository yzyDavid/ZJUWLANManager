using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZJUWLANManager
{
    /// <summary>
    /// 每个CredentialFile实例和一个List_Account实例绑定
    /// </summary>
    class CredentialFile
    {
        private List<Account> _mAccountList;
        private const string DefaultFileName = @"%AppData%\ZJUWLANManager\CredentialArchieve.bin";
        public string FileName { get; }

        public CredentialFile(string fileName)
        {
            FileName = fileName;
            _mAccountList=new List<Account>();
        }

        public CredentialFile(List<Account> list)
        {
            _mAccountList = new List<Account>(list);
            FileName = DefaultFileName;
        }

        public CredentialFile(List<Account> list, string fileName)
        {
            FileName = fileName;
            _mAccountList = new List<Account>(list);
        }

        public bool Save()
        {
            return false;
        }

        public bool Load()
        {
            return false;
        }
    }
}
