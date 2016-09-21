using System.Runtime.Serialization;

namespace Minesweeper.Domain.Exception
{
    public class GameOverException : System.Exception
    {
        public GameOverException() : base(Properties.Resources.GameOverMessage)
        {
        }

        public GameOverException(string message) : base(message)
        {
        }

        public GameOverException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected GameOverException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
