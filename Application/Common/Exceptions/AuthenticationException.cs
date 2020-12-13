using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class AuthenticationException: Exception
    {
        public AuthenticationException(string message) : base(message)
        {

        }
    }
}
