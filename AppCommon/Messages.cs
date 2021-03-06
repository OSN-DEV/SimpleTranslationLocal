﻿using System.Collections.Generic;
using System.Windows;

namespace SimpleTranslationLocal.AppCommon {
    class Messages {
        #region Declaration
        /// <summary>
        /// エラーメッセージID
        /// </summary>
        public enum ErrId {
            Err001,
            Err002,
            Err003,
            Err999
        }
        private readonly static Dictionary<ErrId, string> _errorMessages = new Dictionary<ErrId, string> {
             { ErrId.Err001, "{0}が見つかりません。" }
            ,{ ErrId.Err002, "データベースの作成に失敗しました。\n{0}" }
            ,{ ErrId.Err003, "インポートに失敗しました。\n{0}\n{1}" }
            ,{ ErrId.Err999, "不明なエラーです" }
        };

        public enum InfoId {
            Info001,
            Info999
        }
        private readonly static Dictionary<InfoId, string> _infoMessages = new Dictionary<InfoId, string> {
             { InfoId.Info001, "インポート処理が完了しました。" }
            ,{ InfoId.Info999, "不明な情報です" }
        };
        #endregion

        #region Public Method
        /// <summary>
        /// 情報メッセージを表示
        /// </summary>
        /// <param name="id">メッセージID</param>
        /// <param name="words">代替文字列</param>
        public static void ShowInfo(Window owner, InfoId id, params string[] words) {
            string message = _infoMessages[id];
            for (int i = 0; i < words.Length; i++) {
                message = message.Replace("{" + i + "}", words[i]);
            }
            ShowInfo(owner, message);
        }

        /// <summary>
        /// 情報メッセージを表示
        /// </summary>
        /// <param name="message">メッセージ</param>
        public static void ShowInfo(Window owner, string message) {
            MessageBox.Show(owner, message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// エラーメッセージを表示
        /// </summary>
        /// <param name="id">メッセージID</param>
        /// <param name="text">代替文字列</param>
        public static void ShowError(Window owner, ErrId id, params string[] words) {
            string message = _errorMessages[id];
            for (int i = 0; i < words.Length; i++) {
                message = message.Replace("{" + i + "}", words[i]);
            }
            ShowError(owner, message);
        }

        /// <summary>
        /// エラーメッセージを表示
        /// </summary>
        /// <param name="message">メッセージ</param>
        public static void ShowError(Window owner, string message) {
            if (null == owner) {
                MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                MessageBox.Show(owner, message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
