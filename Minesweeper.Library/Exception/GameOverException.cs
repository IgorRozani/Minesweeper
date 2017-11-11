using System.Runtime.Serialization;

namespace Minesweeper.Library.Exception
{
    public class GameOverException : System.Exception
    {
        public GameOverException()
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
