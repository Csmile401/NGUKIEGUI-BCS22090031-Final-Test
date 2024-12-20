using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using NGU_KIE_GUI_BCS22090031_FinalTest_Question_3.Model;
using System.Threading.Tasks;

namespace NGU_KIE_GUI_BCS22090031_FinalTest_Question_3.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
            };
        }

        public async Task<List<PostRecord>> GetPostsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<PostRecord>>("posts");
        }

        public async Task<PostRecord> AddPostAsync(PostRecord post)
        {
            var response = await _httpClient.PostAsJsonAsync("posts", post);
            return await response.Content.ReadFromJsonAsync<PostRecord>();
        }

        public async Task DeletePostAsync(int id)
        {
            await _httpClient.DeleteAsync($"posts/{id}");
        }
    }
}
