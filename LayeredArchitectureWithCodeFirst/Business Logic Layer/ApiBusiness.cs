using Entities1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Net.Http;
using Newtonsoft.Json;

namespace Business_Logic_Layer
{
    public class ApiBusiness
    {
        private  string _apiUrl = "https://jsonplaceholder.typicode.com/posts";

        public  async Task<List<Post>> GetAllPost()
        {
            
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(_apiUrl);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                List<Post> resultContent = JsonConvert.DeserializeObject<List<Post>>(resultContentString);
                return resultContent;
            }



        }

        public async Task<Post> GetPostById(int id)
        {
            var url = _apiUrl + "/" + id;
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(url);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                Post resultContent = JsonConvert.DeserializeObject<Post>(resultContentString);
                return resultContent;
            }
        }

    }
}
