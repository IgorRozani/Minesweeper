using System.Runtime.Serialization;

namespace Minesweeper.Library.Exception
{
    public class MinesweeperException : System.Exception
    {
        public MinesweeperException()
        {
        }

        public MinesweeperException(string message) : base(message)
        {
        }

        public MinesweeperException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected MinesweeperException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
