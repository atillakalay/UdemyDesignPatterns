using System;

namespace WebApp.ChainOfResponsibility.ChainOfResponsibility
{
    public interface IProcessHandler
    {
        IProcessHandler SetNext(IProcessHandler processHandler);

        Object Handle(Object o);
    }
}