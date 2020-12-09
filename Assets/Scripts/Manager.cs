using EventSystem;
using UnityEngine;

/**
 * ゲームのマネージャー
 * イベントのサンプル用
 */
public class Manager : MonoBehaviour
{
    private EventManager _eventManager;
    
    /**
     * スタート時処理
     */
    void Start()
    {
        //イベント機能のマネージャーの呼び出し
        _eventManager = new EventManager();
        
        //リスナーの登録
        _eventManager.RegisterEventHandlers(new HelloListener()); //リスナーサンプル
        _eventManager.RegisterEventHandlers(new HelloListener2());　//リスナーサンプルその２

        //イベントの着火
        GameStartEvent e = new GameStartEvent();
        _eventManager.CallEvent(e);
        //イベントからの取り出し
        print(e.GETStartMessage());
    }
}
