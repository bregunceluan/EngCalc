using engcalc.mcp.server.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace engcalc.mcp.server.Clients;

public class EngcalcApiClient
{
    private readonly HttpClient _httpClient;

    public EngcalcApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DimensionamentoResponse?> GetDimensionamentoAsync(DimensionamentoRequest request)
    {
        var url = "api/Dimensionamento/viga";

        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            return null!;
        }

        var result = await response.Content.ReadFromJsonAsync<DimensionamentoResponse>();

        return result;

    }
}
