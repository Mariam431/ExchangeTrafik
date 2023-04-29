using ExchangeTrafik.Models.CurrencyModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExchangeTrafik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetURLFromOptionsController : ControllerBase
    {
            private readonly RatesDbContext _dbContext;
            public GetURLFromOptionsController(RatesDbContext dbContext)
            {
                _dbContext = dbContext;
            }
        [HttpGet("GetURL")]
        public async Task<string> Get(int id)
            {
                var option = await _dbContext.Options.FindAsync(id);
                if (option == null)
                {
                    return "Not found";
                }
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Header1", option.Headers);
                httpClient.DefaultRequestHeaders.Add("Header2", "");
                var response = await httpClient.GetAsync(option.Url);
                var responseBody = await response.Content.ReadAsStringAsync();
                var transactionLog = new TransactionLog
                {
                    UserId = 1, 
                    RequestUrl = option.Url,
                    ResponseLog = responseBody,
                    CreatedDate = DateTime.Now,
                    TransactionType = true
                };
                _dbContext.Add(transactionLog);
                await _dbContext.SaveChangesAsync();
                return responseBody;
        }
    }
}
