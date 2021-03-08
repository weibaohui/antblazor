using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using antblazor.module;
using AntDesign.TableModels;
using AntDesign;
using Microsoft.AspNetCore.Components;

namespace antblazor.Pages
{
    public partial class Tables
    {
        [Inject] private HttpClient Http { get; set; }
        private WeatherForecast[] forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
            forecasts.ForEach(k => k.fillData());
        }

        private void OnRowClickForecast(RowData<WeatherForecast> row)
        {
            Console.WriteLine($"row {row.Data.Summary} was clicked.");
        }
    }
}