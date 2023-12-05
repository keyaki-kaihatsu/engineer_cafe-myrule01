namespace EngineerCafe
{
    public interface IMainViewListener : IBaseViewListener
    {
        void OnDialogButtonClicked(MainView mainView);
    }

    public class MainView : BaseView
    {
        #region -- Private Properties --

        IMainViewListener Listener => _listener as IMainViewListener;

        #endregion

        #region -- Public --

        public void OnDialogButtonClick()
        {
            if (Listener != null) Listener.OnDialogButtonClicked(this);
        }

        #endregion
    }
}