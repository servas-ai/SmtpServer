using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using SmtpServer.IO;

namespace SmtpServer.Protocol
{
    public sealed class XClientCommand : SmtpCommand
    {
        public const string Command = "XCLIENT";
        private Dictionary<string, string> _parameters;

        /// <summary>
        /// Constructor.
        /// </summary>
        public XClientCommand(Dictionary<string, string> parameters) : base(Command)
        {
            _parameters = parameters;
        }

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
            Console.WriteLine("[>] RECEIVED XCLIENT COMMAND, IGNORING IT.");
            Console.WriteLine("[>] XCLIENT PARAMETERS:");
            foreach (var parameter in _parameters)
            {
                Console.WriteLine($"\t[>] {parameter.Key}={parameter.Value}");
            }
            Console.WriteLine("[>] END OF XCLIENT PARAMETERS.");
            var version = typeof(SmtpSession).GetTypeInfo().Assembly.GetName().Version;
            context.Pipe.Output.WriteLine($"220 {context.ServerOptions.ServerName} v{version} ESMTP ready");
            return true;
        }
    }
}