using System;
using Windows.Data.Json;
using System.IO;
using Windows.Storage.Streams;
using Windows.Storage;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;     //不要用这个namespace
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

        public List<Account> MAccountList
        {
            get { return _mAccountList; }
        }

        public string FileName { get; }
        private JsonArray JsonList { get; set; }
        private const string DefaultFileName = @"%AppData%\ZJUWLANManager\CredentialArchieve.bin";
        private const string DesiredName = @"Credentials.bin";

        public CredentialFile(List<Account> list)
        {
            _mAccountList = list;
            FileName = DefaultFileName;
            JsonList = new JsonArray();
        }

        public CredentialFile(List<Account> list, string fileName)
        {
            FileName = fileName;
            _mAccountList = list;
            JsonList = new JsonArray();
        }

        public async Task<bool> Save()
        {
            JsonList = MAccountList.ToJsonArray();
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            var file = await folder.CreateFileAsync(DesiredName, CreationCollisionOption.ReplaceExisting);
            var fs = await file.OpenStreamForWriteAsync();

            foreach (var acc in MAccountList)
            {
//                fs.WriteAsync(acc.Username,
            }

//            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(JsonArray));
//            ser.WriteObject(fs, JsonList as object);
            return false;
        }

        public async Task<bool> Load()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            var file = await folder.CreateFileAsync(DesiredName, CreationCollisionOption.OpenIfExists);
            var fs = await file.OpenStreamForReadAsync();

//            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(JsonArray));
//            JsonList = (JsonArray)ser.ReadObject(fs);
//            Extensions.FromJsonArray(out _mAccountList, JsonList);
            return false;
        }
    }
}
