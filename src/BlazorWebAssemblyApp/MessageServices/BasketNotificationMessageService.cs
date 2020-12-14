using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyApp.MessageServices
{
    // ASP.NET Core Blazor WebAssembly - Communication Between Components
    // - https://jasonwatmore.com/post/2020/07/30/aspnet-core-blazor-webassembly-communication-between-components
    public interface IBasketNotificationMessageService
    {
        event Action OnMessage;
        void SendMessage();
        void ClearMessages();
    }

    public class BasketNotificationMessageService : IBasketNotificationMessageService
    {
        public event Action OnMessage;

        public void SendMessage()
        {
            OnMessage?.Invoke();
        }

        public void ClearMessages()
        {
            OnMessage?.Invoke();
        }
    }
}
