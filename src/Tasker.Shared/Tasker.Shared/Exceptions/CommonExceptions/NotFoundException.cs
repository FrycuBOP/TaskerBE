namespace Tasker.Shared.Exceptions.CommonExceptions
{
    public class NotFoundException : TaskerBaseException
    {
        public NotFoundException(string msg)
        {
            ExceptionMessage = msg;
        }
        public override string ExceptionMessage { get; }

        public override int StatusCode => 404;
    }
}
