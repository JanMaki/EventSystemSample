using System;

using Event = EventSystem.Event;

/**
 * ゲームスタート時に着火させるイベント
 */
public class GameStartEvent : Event
{
    /**
     * ここにイベントごとの独自の機能を書く
     */
    private String _startMessage = "";
    public void SetStartMessage(String message)
    {
        _startMessage = message;
    }

    public String GETStartMessage()
    {
        return _startMessage;
    }
}