using System.Net.Http.Json;

namespace FindAndRescue.Services
{
    public class RescueService
    {
        HttpClient httpClient;
        public RescueService()
        {
            httpClient = new HttpClient();
        }

        List<Rescue> streetList = new();
        public async Task<List<Rescue>> GetRescues()
        {
            if (streetList?.Count > 0)
                return streetList;

            var url = "https://raw.githubusercontent.com/VasilijBoichuk/FindAndRescueImages/refs/heads/main/RescueSource.json";
            var response = await httpClient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                streetList = await response.Content.ReadFromJsonAsync<List<Rescue>>();
            }

            return streetList;
        }
    }
}
