using Microsoft.Extensions.Options;
using RooftopRepairs.Interfaces;
using RooftopRepairs.Models;
using System.Reflection.Metadata.Ecma335;

namespace RooftopRepairs.Helpers
{
    public class OptionsService : IOptionsService
    {
        public OptionsService(IOptions<MailOptions> options)
        {
            setOptions(options.Value);
        }
        private MailOptions _mailOptions;
        public MailOptions GetOptions() { return _mailOptions; }

        private void setOptions(MailOptions options)
        {
            _mailOptions = options;
        }
    }
}
