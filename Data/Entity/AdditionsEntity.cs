﻿using OsnLib.Data.Sqlite;
using System;

namespace SimpleTranslationLocal.Data.Entity {
    class AdditionsEntity : BaseEntity {

        #region Declaration
        /// <summary>
        /// Column Names
        /// </summary>
        static class Cols {
            public static readonly String Id = "id";
            public static readonly String MeaningId = "meaning_id";
            public static readonly String Type = "type";
            public static readonly String Data = "data";
            public static readonly String CreateAt = "create_at";
            public static readonly String UpdateAt = "update_at";
        }
        #endregion

        #region Public Property
        public static readonly string TableName = "additions";

        /// <summary>
        /// id
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 意味ID
        /// </summary>
        public int MeaningId { set; get; }

        /// <summary>
        /// 種別
        /// </summary>
        public string Type { set; get; }

        /// <summary>
        /// データ
        /// </summary>
        public string Data { set; get; }
        #endregion

        #region Constructor
        public AdditionsEntity(DictionaryDatabase database) : base(database) { }
        #endregion

        #region Public Method
        public override void DeleteBySourceId(long id) {
            var sql = new SqlBuilder();
            sql.AppendSql($"DELETE FROM {TableName}")
                .AppendSql($"WHERE {Cols.Id} IN (")
                .AppendSql($"    SELECT t1.{Cols.Id}")
                .AppendSql($"      FROM {TableName} t1")
                .AppendSql($"     INNER JOIN {MeaningsEntity.TableName} t2 ON ")
                .AppendSql($"           t1.{Cols.MeaningId} = t2.{WordsEntity.Cols.Id}")
                .AppendSql($"     INNER JOIN {WordsEntity.TableName} t3 ON ")
                .AppendSql($"           t2.{MeaningsEntity.Cols.WordId} = t3.{WordsEntity.Cols.Id} ")
                .AppendSql($"     WHERE t3.{WordsEntity.Cols.SourceId} = {id}")
                .AppendSql($")");
            base.Database.ExecuteNonQuery(sql);
        }

        public override bool Create() {
            var sql = new SqlBuilder();
            sql.AppendSql($"CREATE TABLE {TableName} (")
                .AppendSql($" {Cols.Id}             INTEGER PRIMARY KEY AUTOINCREMENT")
                .AppendSql($",{Cols.MeaningId}      INTEGER NOT NULL")
                .AppendSql($",{Cols.Type}           TEXT    NOT NULL")
                .AppendSql($",{Cols.Data}           TEXT")
                .AppendSql($",{Cols.CreateAt}       INTEGER")
                .AppendSql($",{Cols.UpdateAt}       INTEGER")
                .Append(")");
            return 0 < base.Database.ExecuteNonQuery(sql);
        }

        public override long Insert() {
            var sql = new SqlBuilder();
            sql.AppendSql($"INSERT INTO {TableName}")
                .AppendSql("(")
                .AppendSql($" {Cols.MeaningId}")
                .AppendSql($",{Cols.Type}")
                .AppendSql($",{Cols.Data}")
                .AppendSql($",{Cols.CreateAt}")
                .AppendSql($",{Cols.UpdateAt}")
                .AppendSql(")")
                .AppendSql("VALUES")
                .AppendSql("(")
                .AppendSql($" @{Cols.MeaningId}")
                .AppendSql($",@{Cols.Type}")
                .AppendSql($",@{Cols.Data}")
                .AppendSql(",datetime('now', 'localtime')")
                .AppendSql(",datetime('now', 'localtime')")
                .AppendSql(")");
            var paramList = new ParameterList();
            paramList.Add($"@{Cols.MeaningId}", this.MeaningId);
            paramList.Add($"@{Cols.Type}", this.Type);
            paramList.Add($"@{Cols.Data}", this.Data);
            return base.Database.Insert(sql, paramList);
        }
        #endregion

    }
}
