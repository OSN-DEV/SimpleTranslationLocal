﻿using OsnCsLib.File;
using SimpleTranslationLocal.Data.DataModel;

namespace SimpleTranslationLocal.Func.Import {
    abstract class IDictionaryParser {

        #region Declaration
        protected string _file;

        /// <summary>
        /// 件数カウントのコールバック
        /// </summary>
        /// <param name="count"></param>
        public delegate void GetRowCountCallback(long count);
        #endregion

        #region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="file">対象のファイル</param>
        public IDictionaryParser(string file) {
            if (!System.IO.File.Exists(file)) {
                throw new System.Exception($"File({file}) not found!");
            }
            this._file = file;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// get total row count
        /// </summary>
        /// <returns>row count</returns>
        public abstract long GetRowCount(GetRowCountCallback callback);

        /// <summary>
        /// parse data
        /// </summary>
        /// <returns>ワードデータ</returns>
        public abstract WordData Read();
        #endregion

    }
}
