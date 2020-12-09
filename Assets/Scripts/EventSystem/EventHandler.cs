using System;

namespace EventSystem
{
    /**
     * リスナーのメソッドにつける属性
     */
    [AttributeUsage(AttributeTargets.Method)]
    public class EventHandler : System.Attribute
    {
        public EventPriority Priority { set; get; } = EventPriority.Normal;
    }
}
