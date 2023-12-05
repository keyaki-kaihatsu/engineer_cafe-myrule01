namespace EngineerCafe
{
    public interface IDialogViewListener : IBaseViewListener
    {
        void OnCloseButtonClicked(DialogView dialogView);
    }

    public class DialogView : BaseView
    {
        #region -- Private Properties --

        IDialogViewListener Listener => _listener as IDialogViewListener;

        #endregion

        #region -- Public --

        public void OnCloseButtonClick()
        {
            if (Listener != null) Listener.OnCloseButtonClicked(this);
        }

        #endregion
    }
}