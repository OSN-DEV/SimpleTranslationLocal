﻿using OsnLib.Data.Sqlite;
using SimpleTranslationLocal.Data.DataModel;
using System;

namespace SimpleTranslationLocal.Data.Repo.Entity {
    class WordsEntity : BaseEntity{
        #region Declaration
        /// <summary>
        /// Column Names
        /// </summary>
        public static class Cols {
            public static readonly String Id = "id";
            public static readonly String SourceId = "source_id";
            public static readonly String Word = "word";
            public static readonly String Pronunciation = "pronunciation";
            public static readonly String Syllable = "syllable";
            public static readonly String Kana = "kana";
            public static readonly String Level = "level";
            public static readonly String Change = "change";
            public static readonly String CreateAt = "create_at";
            public static readonly String UpdateAt = "update_at";
        }
        #endregion

        #region Public Property
        public static readonly string TableName = "words";
        /// <summary>
        /// id
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// ソースID
        /// </summary>
        public int SourceId { set; get; }

        /// <summary>
        /// 用語
        /// </summary>
        public string Word { set; get; }

        /// <summary>
        /// 発音
        /// </summary>
        public string Pronunciation { set; get; }

        /// <summary>
        /// 音節
        /// </summary>
        public string Syllable { set; get; }

        /// <summary>
        /// よみがな
        /// </summary>
        public string Kana { set; get; }

        /// <summary>
        /// レベル
        /// </summary>
        public int Level { set; get; }

        /// <summary>
        /// 変化
        /// </summary>
        public string Change { set; get; }
        #endregion

        #region Constructor
        public WordsEntity(DictionaryDatabase database) : base(database) { }
        #endregion

        #region Public Method
        public override void DeleteBySourceId(long id) {
            var sql = new SqlBuilder();
            sql.AppendSql($"DELETE FROM {TableName}")
                .AppendSql($"WHERE {Cols.SourceId} = {id}");
            base.Database.ExecuteNonQuery(sql);
        }

        public override bool Create() {
            var sql = new SqlBuilder();
            sql.AppendSql($"CREATE TABLE {TableName} (")
                .AppendSql($" {Cols.Id}             INTEGER PRIMARY KEY AUTOINCREMENT")
                .AppendSql($",{Cols.SourceId}       INTEGER NOT NULL")
                .AppendSql($",{Cols.Word}           TEXT    NOT NULL")
                .AppendSql($",{Cols.Pronunciation}  TEXT")
                .AppendSql($",{Cols.Syllable}       TEXT")
                .AppendSql($",{Cols.Kana}           TEXT")
                .AppendSql($",{Cols.Level}          INTEGER")
                .AppendSql($",{Cols.Change}           TEXT")
                .AppendSql($",{Cols.CreateAt}       INTEGER")
                .AppendSql($",{Cols.UpdateAt}       INTEGER")
                .Append(")");
            return 0 < base.Database.ExecuteNonQuery(sql);
        }

        public override long Insert() {
            var sql = new SqlBuilder();
            sql.AppendSql("INSERT INTO {TableName}")
                .AppendSql("(")
                .AppendSql($" {Cols.SourceId}")
                .AppendSql($",{Cols.Word}")
                .AppendSql($",{Cols.Pronunciation}")
                .AppendSql($",{Cols.Syllable}")
                .AppendSql($",{Cols.Kana}")
                .AppendSql($",{Cols.Level}")
                .AppendSql($",{Cols.Change}")
                .AppendSql($",{Cols.CreateAt}")
                .AppendSql($",{Cols.UpdateAt}")
                .AppendSql(")")
                .AppendSql("VALUES")
                .AppendSql("(")
                .AppendSql($" @{Cols.SourceId}")
                .AppendSql($",@{Cols.Word}")
                .AppendSql($",@{Cols.Pronunciation}")
                .AppendSql($",@{Cols.Syllable}")
                .AppendSql($",@{Cols.Kana}")
                .AppendSql($",@{Cols.Level}")
                .AppendSql($",@{Cols.Change}")
                .AppendSql(",datetime('now', 'localtime')")
                .AppendSql(",datetime('now', 'localtime')")
                .AppendSql(")");
            var paramList = new ParameterList();
            paramList.Add($"@{Cols.SourceId}", this.SourceId);
            paramList.Add($"@{Cols.Word}", this.Word);
            paramList.Add($"@{Cols.Pronunciation}", this.Pronunciation);
            paramList.Add($"@{Cols.Syllable}", this.Syllable);
            paramList.Add($"@{Cols.Kana}", this.Kana);
            paramList.Add($"@{Cols.Level}", this.Level);
            paramList.Add($"@{Cols.Change}", this.Change);
            return base.Database.Insert(sql, paramList);
        }

        /// <summary>
        /// データモデルの値をメンバに設定
        /// </summary>
        /// <param name="data">設定するデータ</param>
        public void SetDataModel(WordData data) {
            this.Word = data.Word;
            this.Pronunciation = data.Pronumciation;
            this.Syllable = data.Syllable;
            this.Kana = data.Kana;
            this.Level = data.Level;
            this.Change = data.Change;
        }
        #endregion
    }
}