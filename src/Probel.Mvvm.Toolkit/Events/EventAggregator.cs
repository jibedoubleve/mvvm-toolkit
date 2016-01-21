namespace Probel.Mvvm.Toolkit.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    /// <summary>
    /// Is in charge of dispatching the events from the originator to the subscribers
    /// </summary>
    public class EventAggregator
    {
        #region Fields

        private readonly Dictionary<Type, List<WeakReference>> EventRepository = new Dictionary<Type, List<WeakReference>>();
        private readonly object locker = new object();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Publish an event that will be handled
        /// </summary>
        /// <typeparam name="TEventContext">The type of the context of the event</typeparam>
        /// <param name="context">The context of the event</param>
        public void Publish<TEventContext>(TEventContext context)
        {
            if (EventRepository.Count == 0) { return; }

            var subscribers = (from evt in EventRepository
                               where evt.Key == typeof(IEventHandler<>).MakeGenericType(typeof(TEventContext))
                               select evt.Value).SingleOrDefault();

            if (subscribers != null)
            {
                foreach (var subscriber in subscribers)
                {
                    if (subscriber.IsAlive) { HandleEvent(context, subscriber); }
                    else { subscribers.Remove(subscriber); }
                }
            }
        }

        /// <summary>
        /// Indicates the provided instance subscribe to the event flow. Remember that to be able to handle an event, 
        /// the subscriber shoud implement <see cref="IEventHandler{TEventContext}"/>
        /// </summary>
        /// <param name="subscriber">This instance of the subscriber</param>
        public void Subscribe(object subscriber)
        {
            lock (locker)
            {
                var weakref = new WeakReference(subscriber);
                var handlers = GetEventHandlers(subscriber);

                foreach (var handler in handlers)
                {
                    if (!Exist(handler)) { this.AddHandler(handler, weakref); }
                    else { UpdateHandler(handler, weakref); }
                }
            }
        }

        private void AddHandler(Type @event, WeakReference weakref)
        {
            var reflist = new List<WeakReference>();
            reflist.Add(weakref);
            EventRepository.Add(@event, reflist);
        }

        private bool Exist(Type handler)
        {
            if (EventRepository.Count != 0)
            {
                return (from evt in EventRepository
                        where evt.Key == handler
                        select evt).Count() > 0;
            }
            else { return false; }
        }

        private IEnumerable<Type> GetEventHandlers(object subscriber)
        {
            return (from i in subscriber.GetType().GetInterfaces()
                    where i.GetTypeInfo().IsGenericType
                       && i.GetGenericTypeDefinition() == typeof(IEventHandler<>)
                    select i).ToList();
        }

        private void HandleEvent<TEvent>(TEvent @event, WeakReference subscriber)
        {
            var handler = subscriber.Target as IEventHandler<TEvent>;
            if (handler != null)
            {
                var ctx = SynchronizationContext.Current == null
                    ? new SynchronizationContext()
                    : SynchronizationContext.Current;

                ctx.Post(s => handler.HandleEvent(@event), null);
            }
        }

        private void UpdateHandler(Type handler, WeakReference weakref)
        {
            if (EventRepository.Count != 0)
            {
                var @event = (from evt in EventRepository
                              where evt.Key == handler
                              select evt).Single();
                @event.Value.Add(weakref);
            }
        }

        #endregion Methods
    }
}