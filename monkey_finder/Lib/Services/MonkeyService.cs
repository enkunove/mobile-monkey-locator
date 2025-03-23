using monkey_finder.Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace monkey_finder.Lib.Services
{
    public class MonkeyService
    {
        HttpClient HttpClient;
        List<MonkeyModel> monkeyList = new();

        public MonkeyService()
        {
            HttpClient = new HttpClient();
        }
        public async Task<List<MonkeyModel>> GetMonkeys()
        {
            if (monkeyList.Count > 0)
            {
                return monkeyList;
            }
            var url = "https://www.montemagno.com/monkeys.json";
            var response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                monkeyList = await response.Content.ReadFromJsonAsync<List<MonkeyModel>>();
            }
            return monkeyList;
        }

    }
}
