using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizQuick
{
    public class TodoItemManager
    {
        IRestService restService;

        public TodoItemManager(IRestService service)
        {
            restService = service;
        }

        public Task<JsonLogin> GetTaskAsync(string usuario, string contrasena)
        {
            return restService.RefreshDataAsync(usuario, contrasena);
        }

    }
}
