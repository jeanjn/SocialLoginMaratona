using Newtonsoft.Json;

namespace SocialLoginMaratona.Model
{
    /// <summary>
    /// Usuário
    /// </summary>
    public class User
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
