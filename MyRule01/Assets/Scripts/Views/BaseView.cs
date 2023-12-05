using System;
using UnityEngine;

namespace EngineerCafe
{
    public interface IBaseViewListener
    {
    }

    /// <summary>
    /// Viewの基底クラス
    /// </summary>
    public class BaseView : MonoBehaviour
    {
        #region -- Public Properties --

        /// <summary>
        /// View ID
        /// </summary>
        [NonSerialized] public string _viewId;

        /// <summary>
        /// コールバック受取側
        /// </summary>
        public IBaseViewListener _listener;

        #endregion
    }
}