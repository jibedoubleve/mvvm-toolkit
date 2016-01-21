namespace Probel.Mvvm.Toolkit.Events
{
    /// <summary>
    /// Implementation of the handling process for the spevified event context
    /// </summary>
    /// <typeparam name="TEventContext"></typeparam>
    public interface IEventHandler<TEventContext>
    {
        #region Methods

        /// <summary>
        /// When implementation, provides the action to be executed to handle the event
        /// </summary>
        /// <param name="context">The context of the event</param>
        void HandleEvent(TEventContext context);

        #endregion Methods
    }
}