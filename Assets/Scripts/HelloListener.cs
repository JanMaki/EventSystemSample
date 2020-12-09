using EventSystem;
using UnityEngine;

/**
 * Helloって言うリスナーのサンプル
 */
public class HelloListener : IListener
{
    /**
     * ゲームスタートのイベント(GameStartEvent)着火時に実行される
     *
     * 実行順が真ん中
    */
    [EventHandler]
    public void OnHello(GameStartEvent e)
    {
         Send("hello");
    }

    /**
     * ゲームスタートのイベント(GameStartEvent)着火時に実行される
     *
     * 実行されるの順番が早い
     */
    [EventHandler(Priority = EventPriority.Low)]
    public void LowHello(GameStartEvent e)
    {
        Send("hello low");
    }
    
    
    /**
     * ゲームスタートのイベント(GameStartEvent)着火時に実行される
     *
     * 実行されるの順番が遅い
     */
    [EventHandler(Priority = EventPriority.High)]
    public void HighHello(GameStartEvent e)
    { Send("high hello"); 
    }

    /**
     * ログを出すだけの関数
     *
     * EventHandlerを持たないメソッドは、イベントで実行されない
     */
    public void Send(string str)
    {
        Debug.Log(str);
    }
}
