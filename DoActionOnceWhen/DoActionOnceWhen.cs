using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AB.Utilities
{

    /// <summary>
    /// Class used for triggering an action based on a condition; once
    /// <example>
    /// var debugOnce = DoActionOnceWhen.Do(() => Console.WriteLine("debug")); 
    /// debugOnce.When(() => hasBeenError && userLoggedIn); 
    /// </example>
    /// </summary>
    public class DoActionOnceWhen
    {
        /// <summary>
        /// Factory for OnceWhenTrue
        /// </summary>
        /// <param name="action">What to do when this is true</param>
        /// <returns>New object that holds the action</returns>
        public static DoActionOnceWhen Do(Action action)
        {
            if (action == null) {
                return null;
            }
            return new DoActionOnceWhen(action);
        }

        /// <summary>
        /// Need to be continually called using a condition
        /// This will only force the associated action to be called ONCE
        /// Until a reset is made
        /// </summary>
        /// <param name="condition">The condition for this Action</param>
        public bool When(Func<bool> condition)
        {
            if (!actionHasFired) {
                if (condition()) {
                    Action();
                    actionHasFired = true;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Enable the action to fire again if condition is true
        /// </summary>
        public void Reset() { actionHasFired = false; }

        private Action Action { get; set; }

        private DoActionOnceWhen(Action action)
        {
            this.Action = action;
        }

        private bool actionHasFired;
    }

}
