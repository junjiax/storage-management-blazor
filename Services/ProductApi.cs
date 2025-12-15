using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class ProductApi
{
    private readonly ApiClient apiClient;

    public ProductApi(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    // public Task<ApiResponse<ProductResponse>?> AddAsync(ProductRequest request, CancellationToken ct = default)
    //     => apiClient.PostAsync<ProductRequest, ApiResponse<ProductResponse>>("product", request, ct);
    public Task<ApiResponse<ProductResponse>?> AddAsync(ProductWithUploadImgRequest request, CancellationToken ct = default)
    {
        // Build multipart form data to match backend [FromForm] ProductWithUploadImgRequest
        var content = new MultipartFormDataContent();

        if (request.CategoryId.HasValue)
            content.Add(new StringContent(request.CategoryId.Value.ToString()), nameof(request.CategoryId));

        if (request.SupplierId.HasValue)
            content.Add(new StringContent(request.SupplierId.Value.ToString()), nameof(request.SupplierId));

        if (!string.IsNullOrEmpty(request.ProductName))
            content.Add(new StringContent(request.ProductName), nameof(request.ProductName));

        if (!string.IsNullOrEmpty(request.Barcode))
            content.Add(new StringContent(request.Barcode), nameof(request.Barcode));

        content.Add(new StringContent(request.Price.ToString(System.Globalization.CultureInfo.InvariantCulture)), nameof(request.Price));

        if (!string.IsNullOrEmpty(request.Unit))
            content.Add(new StringContent(request.Unit), nameof(request.Unit));

        if (request.ImageFile != null)
        {
            var maxBytes = 5 * 1024 * 1024;
            var stream = request.ImageFile.OpenReadStream(maxBytes);
            var sc = new StreamContent(stream);
            sc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(request.ImageFile.ContentType);
            content.Add(sc, nameof(request.ImageFile), request.ImageFile.Name);
        }

        return apiClient.PostMultipartAsync<ApiResponse<ProductResponse>>("product/upload", content, ct);
    }

    public Task<ApiResponse<ProductResponse>?> UpdateWithUploadAsync(ProductWithUploadImgRequest request, int id, CancellationToken ct = default)
    {
        var content = new MultipartFormDataContent();

        if (request.CategoryId.HasValue)
            content.Add(new StringContent(request.CategoryId.Value.ToString()), nameof(request.CategoryId));

        if (request.SupplierId.HasValue)
            content.Add(new StringContent(request.SupplierId.Value.ToString()), nameof(request.SupplierId));

        if (!string.IsNullOrEmpty(request.ProductName))
            content.Add(new StringContent(request.ProductName), nameof(request.ProductName));

        if (!string.IsNullOrEmpty(request.Barcode))
            content.Add(new StringContent(request.Barcode), nameof(request.Barcode));

        content.Add(new StringContent(request.Price.ToString(System.Globalization.CultureInfo.InvariantCulture)), nameof(request.Price));

        if (!string.IsNullOrEmpty(request.Unit))
            content.Add(new StringContent(request.Unit), nameof(request.Unit));

        if (request.ImageFile != null)
        {
            var maxBytes = 5 * 1024 * 1024;
            var stream = request.ImageFile.OpenReadStream(maxBytes);
            var sc = new StreamContent(stream);
            sc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(request.ImageFile.ContentType);
            content.Add(sc, nameof(request.ImageFile), request.ImageFile.Name);
        }

        return apiClient.PutMultipartAsync<ApiResponse<ProductResponse>>($"product/{id}/upload", content, ct);
    }

    public Task<ApiResponse<List<ProductResponse>>?> GetAllAsync(CancellationToken ct = default)
        => apiClient.GetAsync<ApiResponse<List<ProductResponse>>>("product", ct);

    public Task<ApiResponse<ProductResponse>?> UpdateAsync(ProductWithUploadImgRequest request, int id, CancellationToken ct = default)
        => apiClient.PutAsync<ProductWithUploadImgRequest, ApiResponse<ProductResponse>>($"product/{id}", request, ct);

    public Task<ApiResponse<ProductResponse>?> GetByIdAsync(int id, CancellationToken ct = default)
        => apiClient.GetByIdAsync<ApiResponse<ProductResponse>>("product", id, ct);

    public Task<ApiResponse<bool>?> DeleteAsync(int id, CancellationToken ct = default)
        => apiClient.DeleteAsync<ApiResponse<bool>>("product", id, ct);

    // => apiClient.GetAsync<ApiResponse<ProductResponse>>($"product/{id}", ct);

    public Task<ApiResponse<List<ProductResponse>>?> GetByCategoryAsync(int categoryId, CancellationToken ct = default)
        => apiClient.GetAsync<ApiResponse<List<ProductResponse>>>($"product/category/{categoryId}", ct);
}
