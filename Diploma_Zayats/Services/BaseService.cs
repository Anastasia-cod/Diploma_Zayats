using Diploma_Zayats.Client;

namespace Diploma_Zayats.Services;

public class BaseService
{
    protected ApiClient _apiClient;

    public BaseService(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }
}