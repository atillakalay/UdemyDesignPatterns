using Microsoft.AspNetCore.Mvc;

namespace WebApp.Command.Commands
{
    public interface ITableActionCommand
    {
        IActionResult Execute();
    }
}
