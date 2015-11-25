using System;
using Windows.Data.Json;
using System.Runtime.Serialization.Json;
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
        public List<Account> MAccountList { get; }
        public string FileName { get; }
        private JsonArray JsonList { get; set; }
        private const string DefaultFileName = @"%AppData%\ZJUWLANManager\CredentialArchieve.bin";

        public CredentialFile(List<Account> list)
        {
            MAccountList = list;
            FileName = DefaultFileName;
            JsonList = new JsonArray();
        }

        public CredentialFile(List<Account> list, string fileName)
        {
            FileName = fileName;
            MAccountList = list;
            JsonList = new JsonArray();
        }

//        private void UpdateJson()
//        {
//            JsonList.Clear();
//            foreach (var acc in MAccountList)
//            {
//            }
//        }

        public bool Save()
        {
            JsonList = MAccountList.ToJsonArray();
            return false;
        }

        public bool Load()
        {
            return false;
        }
    }
}
