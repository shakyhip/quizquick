using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizQuick
{
    public interface IRestService
    {
        Task<JsonLogin> RefreshDataAsync(string usuario, string contrasena);
    }
}
