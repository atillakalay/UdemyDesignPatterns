namespace WebApp.ChainOfResponsibility.ChainOfResponsibility
{
    public abstract class Processhandler : IProcessHandler
    {
        private IProcessHandler _nextProcessHandler;

        public virtual object Handle(object o)
        {
            if (_nextProcessHandler != null)
            {
                return _nextProcessHandler.Handle(o);
            }
            return null;
        }

        public IProcessHandler SetNext(IProcessHandler processHandler)
        {
            _nextProcessHandler = processHandler;
            return _nextProcessHandler;
        }
    }
}