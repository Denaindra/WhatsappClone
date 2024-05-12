using Newtonsoft.Json;

namespace MAUIMobileStarterKit.Models.API.Response
{
    public class ThreadInfoResponseModel
    {
        public long idT { get; set; }

        public long idCU { get; set; }

        public long[] idOU { get; set; }
    }

}
