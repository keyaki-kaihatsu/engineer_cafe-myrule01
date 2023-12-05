namespace EngineerCafe
{
    public interface IDialogViewListener
    {
        void OnCloseButtonClicked(DialogView dialogView);
    }

    public class DialogView : BaseView
    {
        #region -- Public Properties --

        public IDialogViewListener _listener;

        #endregion

        #region -- Public --

        public void OnCloseButtonClick()
        {
            if (_listener != null) _listener.OnCloseButtonClicked(this);
        }

        #endregion
    }
}