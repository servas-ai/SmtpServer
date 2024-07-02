using System;

namespace SmtpServer.StateMachine
{
    internal sealed class SmtpStateTransition
    {
        readonly Func<SmtpSessionContext, bool> _canAcceptDelegate;
        readonly Func<SmtpSessionContext, SmtpStateId> _transitionDelegate;

        internal SmtpStateTransition(Func<SmtpSessionContext, bool> canAcceptDelegate, Func<SmtpSessionContext, SmtpStateId> transitionDelegate)
        {
            _canAcceptDelegate = canAcceptDelegate;
            _transitionDelegate = transitionDelegate;
        }

        internal bool CanAccept(SmtpSessionContext context)
        {
            Console.WriteLine("STATE TRANSITION: Can Accept: " + _canAcceptDelegate.Method.Name);
            return _canAcceptDelegate(context);
        }

        internal SmtpStateId Transition(SmtpSessionContext context)
        {
            return _transitionDelegate(context);
        }
    }
}