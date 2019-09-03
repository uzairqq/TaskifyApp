using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.DbServices.Implementation;
using ToDoApp.DbServices.Interfaces;

namespace ToDoApp.DbServices
{
    public class DataAccessRegistry
    {
        public static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(ITodoServices), typeof(TodoServices));
        }
    }
}
