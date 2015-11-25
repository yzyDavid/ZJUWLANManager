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
        private JsonObject JsonList { get; }
        private const string DefaultFileName = @"%AppData%\ZJUWLANManager\CredentialArchieve.bin";

        public CredentialFile(List<Account> list)
        {
            MAccountList = list;
            FileName = DefaultFileName;
            JsonList = new JsonObject();
        }

        public CredentialFile(List<Account> list, string fileName)
        {
            FileName = fileName;
            MAccountList = list;
            JsonList = new JsonObject();
        }

        private void UpdateJson()
        {
            JsonList.Clear();
            foreach (var acc in MAccountList)
            {
                JsonList.Add(new KeyValuePair<string, IJsonValue>()
            }
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
