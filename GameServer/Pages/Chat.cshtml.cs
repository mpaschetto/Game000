using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameServer.Pages
{
    public class ChatModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string RoomId { get; set; } = string.Empty;

        public void OnGet()
        {
            if (string.IsNullOrEmpty(RoomId))
            {
                RoomId = Guid.NewGuid().ToString("N");
            }
        }
    }
}
