using System.Collections.Generic;
using UnityEngine;

namespace EngineerCafe
{
    public class MainController : MonoBehaviour, IMainViewListener, IDialogViewListener
    {
        #region -- Private Properties --

        [Header("UI")]

        [SerializeField] Canvas _canvas;

         List<BaseView> _viewList = new List<BaseView>();

        #endregion

        #region -- IMainViewListener --

        public void OnDialogButtonClicked(MainView mainView)
        {
            var dialogView = AddView<DialogView>("Prefabs/Views/DialogView", "dialog");
            dialogView._listener = this;
        }

        #endregion

        #region -- IDialogViewListener --

        public void OnCloseButtonClicked(DialogView dialogView)
        {
            RemoveView(dialogView._viewId);
        }

        #endregion

        #region -- Override --

        void Start()
        {
            var mainView = AddView<MainView>("Prefabs/Views/MainView", "main");
            mainView._listener = this;
        }

        #endregion

        #region -- Private --

        T AddView<T>(string path, string viewId) where T : BaseView
        {
            var viewPrefab = Resources.Load<T>(path);
            var view = Instantiate(viewPrefab);
            view.transform.SetParent(_canvas.transform, false);
            view._viewId = viewId;
            _viewList.Add(view);
            return view;
        }

        void RemoveView(string viewId)
        {
            var view = _viewList.Find(view => view._viewId == viewId);
            _viewList.Remove(view);
            Destroy(view.gameObject);
        }

        #endregion
    }
}