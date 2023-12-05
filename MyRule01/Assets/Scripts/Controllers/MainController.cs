using System.Collections.Generic;
using UnityEngine;

namespace EngineerCafe
{
    public class MainController : MonoBehaviour, IMainViewListener, IDialogViewListener
    {
        #region -- Private Properties --

        [Header("UI")]

        [SerializeField] Canvas _canvas; // Viewを表示するCanvas

        /// <summary>
        /// Viewリスト
        /// </summary>
         List<BaseView> _viewList = new List<BaseView>();

        #endregion

        #region -- IMainViewListener --

        public void OnDialogButtonClicked(MainView mainView)
        {
            var dialogView = AddView<DialogView>("Prefabs/Views/DialogView", "dialog"); // Viewの生成と追加
            dialogView._listener = this; // コールバックの設定
        }

        #endregion

        #region -- IDialogViewListener --

        public void OnCloseButtonClicked(DialogView dialogView)
        {
            RemoveView(dialogView._viewId); // Viewの破棄
        }

        #endregion

        #region -- Override --

        void Start()
        {
            var mainView = AddView<MainView>("Prefabs/Views/MainView", "main"); // Viewの生成と追加
            mainView._listener = this; // コールバックの設定
        }

        #endregion

        #region -- Private --

        /// <summary>
        /// Viewの生成と追加
        /// </summary>
        /// <typeparam name="T">Viewの型</typeparam>
        /// <param name="path">プレハブのパス</param>
        /// <param name="viewId">View ID</param>
        /// <returns>View（インスタンス）</returns>
        T AddView<T>(string path, string viewId) where T : BaseView
        {
            var viewPrefab = Resources.Load<T>(path); // Assets/Resources/Views からViewのプレハブを読み込み
            var view = Instantiate(viewPrefab); // プレハブをインスタンス化
            view.transform.SetParent(_canvas.transform, false); // Canvasに貼り付け
            view._viewId = viewId; // View IDの設定
            _viewList.Add(view); // Viewリストに追加
            return view;
        }

        /// <summary>
        /// Viewの破棄
        /// </summary>
        /// <param name="viewId">View ID</param>
        void RemoveView(string viewId)
        {
            var view = _viewList.Find(view => view._viewId == viewId); // View探し
            _viewList.Remove(view); // Viewリストから破棄
            Destroy(view.gameObject); // GameObjectの破棄
        }

        #endregion
    }
}