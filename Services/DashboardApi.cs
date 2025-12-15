using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class DashboardApi
{
   private readonly ApiClient apiClient;

   public DashboardApi(ApiClient apiClient)
   {
      this.apiClient = apiClient;
   }

   public Task<ApiResponse<SimpleReportResponse>?> GetSimpleReportAsync(
    SimpleReportRequest request,
    CancellationToken ct = default)
   {
      var url =
          $"report/simple-report?StartDate={request.StartDate}&EndDate={request.EndDate}";

      return apiClient.GetAsync<ApiResponse<SimpleReportResponse>>(url, ct);
   }

   public Task<ApiResponse<ROByMothResponse>?> GetROByMonthAsync(
   SimpleReportRequest request,
   CancellationToken ct = default)
   {
      var url =
          $"report/revenue-by-month?StartDate={request.StartDate}&EndDate={request.EndDate}";

      return apiClient.GetAsync<ApiResponse<ROByMothResponse>>(url, ct);
   }

   public Task<ApiResponse<RatioPByCResponse>?> GetRatioPByCAsync(
   SimpleReportRequest request,
   CancellationToken ct = default)
   {
      var url =
          $"report/ratio-by-category?StartDate={request.StartDate}&EndDate={request.EndDate}";

      return apiClient.GetAsync<ApiResponse<RatioPByCResponse>>(url, ct);
   }

}

