using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MyApp.Services.BusinessCard
{
    public class BusinessCardService : IBusinessCardService
    {
        protected string URL { get; }

        protected int TimeoutSeconds { get; }

        protected string CardTemplate { get; }

        public BusinessCardService()
        {
            URL = "https://business-card-webservice.herokuapp.com/api/businesscard/generate/as/pdf";
            TimeoutSeconds = 10;
            CardTemplate = "templates/business_card.mustache.html";
        }

        async Task<byte[]> IBusinessCardService.GeneratePDF(GenerateParameter parameter)
        {
            using (var api = new HttpClient()
            {
                BaseAddress = new Uri(URL),
                Timeout = new TimeSpan(0, 0, TimeoutSeconds)
            })
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("template", CardTemplate);
                query.Add("name", parameter.Name);
                query.Add("company", parameter.Organization);

                var response = api.GetAsync("?" + query.ToString()).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var exception = new ApplicationException("Business card generation error");
                    exception.Data.Add("StatusCode", response.StatusCode);
                    exception.Data.Add("ReasonPhrase", response.ReasonPhrase);
                    exception.Data.Add("Detail", await response.Content.ReadAsStringAsync());
                    throw exception;
                }

                return await response.Content.ReadAsByteArrayAsync();
            }
        }
    }
}
