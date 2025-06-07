using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameServer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string RoomId { get; private set; } = string.Empty;
        public string QrCodeImage { get; private set; } = string.Empty;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            RoomId = Guid.NewGuid().ToString("N");
            var url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/Chat?roomId={RoomId}";
            using var qrGenerator = new QRCoder.QRCodeGenerator();
            using var qrData = qrGenerator.CreateQrCode(url, QRCoder.QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new QRCoder.PngByteQRCode(qrData);
            var qrBytes = qrCode.GetGraphic(20);
            QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(qrBytes);
        }
    }
}
