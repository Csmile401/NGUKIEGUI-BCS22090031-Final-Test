using Newtonsoft.Json;

namespace NGU_KIE_GUI_BCS22090031_FinalTest_Question_3.Model
{
    
    public class PostRecord
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }

}
