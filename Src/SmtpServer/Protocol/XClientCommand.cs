using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using SmtpServer.IO;

namespace SmtpServer.Protocol
{
    public sealed class XClientCommand : SmtpCommand
    {
        public const string Command = "XCLIENT";

        /// <summary>
        /// Constructor.
        /// </summary>
        public XClientCommand() : base(Command) { }

        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="context">The execution context to operate on.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns true if the command executed successfully such that the transition to the next state should occurr, false 
        /// if the current state is to be maintained.</returns>
        internal override async Task<bool> ExecuteAsync(SmtpSessionContext context, CancellationToken cancellationToken)
        {
            // TODO: implement XCLIENT support
            // For now, we ignore the XCLIENT command and return the expected response.
            // No internal state is altered.
            // @see https://www.postfix.org/XCLIENT_README.html Section "XCLIENT Example"
            var version = typeof(SmtpSession).GetTypeInfo().Assembly.GetName().Version;
            context.Pipe.Output.WriteLine($"220 {context.ServerOptions.ServerName} v{version} ESMTP ready");
            await context.Pipe.Output.FlushAsync(cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}