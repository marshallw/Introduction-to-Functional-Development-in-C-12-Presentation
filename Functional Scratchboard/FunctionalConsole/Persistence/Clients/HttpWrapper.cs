namespace Persistence.Clients;

public class HttpWrapper
{
    public HttpClient _httpClient {get; init;}

    public HttpWrapper(HttpClient client) => (_httpClient) = (client);
    public virtual async Task<Result<T, HttpClientFailureResponse>> PostJsonAsync<T>(Uri uri, object body, string authToken, IDictionary<string, string> headers, CancellationToken cancellationToken)
    {
        try
        {
            var request = CreateHttpRequestMessage(HttpMethod.Post, uri, body, authToken, headers);

            using (var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false))
            {
                
                var content = response.Content == null ? string.Empty : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                
                if (!response.IsSuccessStatusCode)
                {
                    return Result.Failure<T, HttpClientFailureResponse>(new HttpClientFailureResponse(response.StatusCode, content));
                }

                return Result.Success<T, HttpClientFailureResponse>(JsonConvert.DeserializeObject<T>(content));
            }
        }
        catch(TaskCanceledException ex)
        {
            return Result.Failure<T, HttpClientFailureResponse>(new HttpClientFailureResponse(ex, System.Net.HttpStatusCode.RequestTimeout));
        }
        catch (Exception ex) when (ex is HttpRequestException || ex is JsonSerializationException)
        {
            return Result.Failure<T, HttpClientFailureResponse>(new HttpClientFailureResponse(ex));
        }
    }}