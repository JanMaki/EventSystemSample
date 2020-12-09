namespace EventSystem
{
    /**
     * キャンセル可能なイベントにつけるインターフェース
     */
    public interface ICancelable
    {
        void SetCanceled(bool b);
        bool IsCanceled();
    }
}