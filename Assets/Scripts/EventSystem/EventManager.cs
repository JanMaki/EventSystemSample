using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace EventSystem
{
    /**
     * イベントの管理用のクラス
     */
    public class EventManager
    {
        // <EventのType, <プライオリティ, <実行メソッド, 実行インスタンス>>>
        private readonly Dictionary<Type, Dictionary<EventPriority,Dictionary<MethodInfo, IListener>>> _handlersDictionary = 
            new Dictionary<Type, Dictionary<EventPriority,Dictionary<MethodInfo, IListener>>>();
        
        /**
         * リスナーを受け取ってHandlerを登録する
         *
         * @param listener 対象のリスナー
         */
        public void RegisterEventHandlers(IListener listener)
        {
            //すべてのメソッドを確認
            Type type = listener.GetType();
            foreach (var method in type.GetMethods())
            {
                //メソッドの属性の確認
                EventHandler handler = (EventHandler) Attribute.GetCustomAttribute(method, typeof(EventHandler));
                if (handler == null)
                {
                    continue;
                }
                //引数の確認
                // 引数の数
                if (method.GetParameters().Length != 1)
                {
                    return;
                }
                //　引数がイベントか確認
                Type parameterType = method.GetParameters()[0].ParameterType;
                if (!parameterType.IsSubclassOf(typeof(Event)))
                {
                    continue;
                }
                //辞書に登録
                EventPriority priority = handler.Priority;
                var priorityDictionary = _handlersDictionary.ContainsKey(parameterType) ? 
                    _handlersDictionary[parameterType] : new Dictionary<EventPriority, Dictionary<MethodInfo, IListener>>();
                var dictionary = priorityDictionary.ContainsKey(priority) ? 
                    priorityDictionary[priority] : new Dictionary<MethodInfo, IListener>();
                dictionary.Add(method, listener);
                priorityDictionary[priority] = dictionary;
                _handlersDictionary[parameterType] = priorityDictionary;
            }
        }

        /**
         * イベントを着火する
     *
         * @param e 着火するイベント
         */
        public void CallEvent(Event e)
        {
            //イベントに対する物ががあるかを確認
            if (!_handlersDictionary.ContainsKey(e.GetType()))
            {
                return;
            }
            //プライオリティごとに実行する
            var priorityDictionary = _handlersDictionary[e.GetType()]; 
            foreach (var obj in Enum.GetValues(typeof(EventPriority)))
            {
                //プライオリティに対するものがあるかを確認
                EventPriority priority = (EventPriority) obj;
                if (!priorityDictionary.ContainsKey(priority))
                {
                    continue;
                }
                //メソッドを取得する
                foreach (var method in priorityDictionary[priority])
                {
                    //メソッドとインスタンスを渡して実行する。引数は着火したイベント
                    method.Key.Invoke(method.Value, new object[] {e});
                }
            }
        }
    }
}