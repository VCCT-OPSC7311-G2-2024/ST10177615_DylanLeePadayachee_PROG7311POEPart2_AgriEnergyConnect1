    namespace AgriEnergyConnect1.Models
    {
        public class ErrorViewModel
        {
            public string RequestId { get; set; } // Removed nullable annotation

            public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        }
    }