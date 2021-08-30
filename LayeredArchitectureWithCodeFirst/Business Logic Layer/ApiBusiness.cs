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
                List<ApiEntity> resultContent = JsonConvert.DeserializeObject<List<ApiEntity>>(resultContentString);
                List<Post> postList = new List<Post>();
                foreach (var content in resultContent)
                {
                    postList.Add((new Post()
                    {
                        PostId = content.Id,
                        Body = content.Body,
                        Title = content.Title,
                        UserId = content.UserId
                    }));
                }
                return postList;
            }



        }

        public async Task<ApiEntity> GetPostById(int id)
        {
            var url = _apiUrl + "/" + id;
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(url);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                ApiEntity resultContent = JsonConvert.DeserializeObject<ApiEntity>(resultContentString);
               var post=((new Post()
                {
                    PostId = resultContent.Id,
                    Body = resultContent.Body,
                    Title = resultContent.Title,
                    UserId = resultContent.UserId
                }));
                return resultContent;
            }
        }

    }
}
