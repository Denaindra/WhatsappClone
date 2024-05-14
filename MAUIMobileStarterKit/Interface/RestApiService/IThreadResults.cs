using MAUIMobileStarterKit.Models.API.Request;
using MAUIMobileStarterKit.Models.API.Response;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Interface.RestApiService
{
    public interface IThreadResults
    {
        [Post("/get_infos_threads.php")]
        Task<ThreadInfoResponseModel[]> GetThreadInfo(ThreadInfoRequestModel loginRequest);

        [Post("/get_one_thread.php")]
        Task<GetOneThreadResponseModal> GetOneThread(GetOneThreadRequestModal getOneThreadRequest);
    }
}
