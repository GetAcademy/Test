using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class ConfirmationEmail : Email
    {
        public ConfirmationEmail(string emailAddress, Guid confirmationCode)
            :base(emailAddress, null)
        {
            var url = $"www.vårtjeneste.com/verify?email={emailAddress}&code={confirmationCode}";
            HtmlContent = $"<a href=\"https://{url}\">Trykk her for å verifisere</a>";
        }
    }
}
