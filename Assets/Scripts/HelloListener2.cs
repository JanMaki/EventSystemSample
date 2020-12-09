using EventSystem;

public class HelloListener2 : IListener
{
        /**
         * ゲームスタートのイベント(GameStartEvent)着火時に実行される
         *
         * スタートのメッセージを変更する
         *
         * PriorityがLowestのため、この変更は優先されない（先に実行される）
         */
        [EventHandler(Priority = EventPriority.Lowest)]
        public void onStart(GameStartEvent e)
        {
                e.SetStartMessage("Hello World");
        }
        
        /**
         * ゲームスタートのイベント(GameStartEvent)着火時に実行される
         *
         * スタートのメッセージを変更する
         *
         * PriorityがHightestのため、この変更が優先される（後から実行される）
         */
        [EventHandler(Priority = EventPriority.Hightest)]
        public void onStartHigh(GameStartEvent e)
        {
            e.SetStartMessage("はろーわーるど");
        }
}