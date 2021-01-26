﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace SimpleTranslationLocal.UI.Import {
    class ImportMockViewModel : IImportViewModel {
        #region Property
        private string _eijiroFile = @"D:\OneDriveForBusiness\OneDrive - TK\storage\tools\Mouse Dictionary\EIJIRO-1448_ForTest.TXT";
        public override string EijiroFile {
            get { return this._eijiroFile; }
            set { this.SetProperty(ref this._eijiroFile, value); }
        }


        private string _dictionaryFile = @"D:\OneDriveForBusiness\OneDrive - TK\storage\tools\Mouse Dictionary\dictionary.json";
        public override string DictionaryFile {
            get { return this._dictionaryFile; }
            set { this.SetProperty(ref this._dictionaryFile, value); }
        }
        #endregion

        #region Constructor
        public ImportMockViewModel(Window owner, Action OnOkClick) : base(owner, OnOkClick) {

        }
        #endregion
    }
}