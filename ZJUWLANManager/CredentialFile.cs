﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZJUWLANManager
{
    class CredentialFile
    {
        private AccountList _mAccountList;
        private const string DefaultFileName = @"%AppData%\ZJUWLANManager\CredentialArchieve.bin";
        public string FileName { get; }

        public CredentialFile(string fileName)
        {
            FileName = fileName;
            _mAccountList=new AccountList();
        }

        public CredentialFile(AccountList list)
        {
            _mAccountList = new AccountList(list);
            FileName = DefaultFileName;
        }

        public CredentialFile(AccountList list, string fileName)
        {
            FileName = fileName;
            _mAccountList = new AccountList(list);
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
