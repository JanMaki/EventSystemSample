namespace EventSystem
{
    /**
     * Handlerのプライオリティの列挙
     * Lowestから順番に実行される
     * ＊Monitorでイベントに変更を加えるのは非推奨！！！！
     */
    public enum EventPriority
    {
        Lowest,
        Low,
        Normal,
        High,
        Hightest,
        Monitor
    }
}