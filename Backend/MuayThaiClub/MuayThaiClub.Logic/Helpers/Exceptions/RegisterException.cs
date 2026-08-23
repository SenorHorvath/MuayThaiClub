using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Logic.Helpers.Exceptions
{
  internal class RegisterException : Exception
  {
    public RegisterException()
    {
    }

    public RegisterException(string? message) : base(message)
    {
    }

    public RegisterException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected RegisterException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}
