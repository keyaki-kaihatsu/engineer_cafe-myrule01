namespace EngineerCafe
{
    public interface IMainViewListener
    {
        void OnDialogButtonClicked(MainView mainView);
    }

    public class MainView : BaseView
    {
        #region -- Public Properties --

        public IMainViewListener _listener;

        #endregion

        #region -- Public --

        public void OnDialogButtonClick()
        {
            if (_listener != null) _listener.OnDialogButtonClicked(this);
        }

        #endregion
    }
}