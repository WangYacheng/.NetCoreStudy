using System;
using System.Linq;
using Dang.Application.Interfaces.Base;
using Dang.Common;
using Dang.Domain.Core;
using Dang.Domain.Core.Bus;
using Dang.Infrastruct.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Dang.CrossCutting.IOC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //自动注入服务层
            AutoDIServices(services, typeof(IBaseAppService));
            AutoDIServices(services, typeof(IBaseManageService));

            // 领域通知
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();


            // 命令总线Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // 注入 基础设施层 - 事件溯源
            //services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            //services.AddScoped<IEventStoreService, SqlEventStoreService>();
            //services.AddScoped<EventStoreSQLContext>();
        }

        /// <summary>
        /// 自动注册Services到DI
        /// </summary>
        /// <param name="services"></param>
        /// <param name="baseType"></param>
        static void AutoDIServices(IServiceCollection services, Type baseType)
        {
            var allAssemblies = AppDomain.CurrentDomain.GetCurrentPathAssembly();

            foreach (var assembly in allAssemblies)
            {
                var types = assembly.GetTypes()
                    .Where(type => type.IsClass
                                   && type.BaseType != null
                                   && type.HasImplementedRawGeneric(baseType));
                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces();
                    if (type.Name.StartsWith("BaseAppService"))
                    {
                        continue;
                    }

                    var interfaceType = interfaces.FirstOrDefault(x => x.Name == $"I{type.Name}");
                    if (interfaceType == null)
                    {
                        interfaceType = type;
                    }
                    ServiceDescriptor serviceDescriptor =
                        new ServiceDescriptor(interfaceType, type, ServiceLifetime.Scoped);
                    if (!services.Contains(serviceDescriptor))
                    {
                        services.Add(serviceDescriptor);
                    }
                }
            }
        }
    }
}
