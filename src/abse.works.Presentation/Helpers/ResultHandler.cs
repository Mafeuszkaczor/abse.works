using abse.works.Application.Common;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace abse.works.Web.Helpers
{
    public class ResultHandler
    {
        private readonly INotyfService _notyfService;
        public ResultHandler(INotyfService notyfService)
        {
            _notyfService = notyfService;
        }

        public T Handle<T>(Response<T> response)
        {
            if (response.Success && response.Message != null)
            {
                _notyfService.Success(response.Message);
            }
            else if (response.Warning)
            {
                _notyfService.Warning(response.Message);
            }
            else if (!response.Success)
            {
                _notyfService.Error(response.Message);
            }

            return response.Data;
        }

        public void Handle(Result response)
        {
            if (response.Success && response.Message != null)
            {
                _notyfService.Success(response.Message);
            }
            else
            {
                _notyfService.Error(response.Message);
            }
        }
    }
}
