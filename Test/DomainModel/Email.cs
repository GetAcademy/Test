using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Email
    {
        public string To { get; set; }
        public string HtmlContent { get; set; }

        public Email()
        {
            
        }

        public Email(string to, string htmlContent)
        {
            To = to;
            HtmlContent = htmlContent;
        }
    }
}
