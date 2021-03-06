using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Dang.Infrastruct.DB;

namespace Dang.Context
{
    public class DangContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var skinMaps = new[] {
                "ssss"
            };

            var mappingInterface = typeof(IEntityTypeConfiguration<>);

            var mappingTypes = typeof(DangContext).GetTypeInfo().Assembly.GetTypes();

            var mi = modelBuilder.GetType().GetMethods()
            .Single(
                e=>e.Name == ""
                && e.ContainsGenericParameters
                && e.GetParameters().SingleOrDefault()?.ParameterType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));

            foreach (var mappingType in mappingTypes)
            {
                if (skinMaps.Any(x => x.Equals(mappingType.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }

                var genericTypeArg = mappingType.GetInterfaces().Single().GenericTypeArguments.Single();

                var genericEntityMethod = mi.MakeGenericMethod(genericTypeArg);

                var mapper = Activator.CreateInstance(mappingType);

                var entityBuilder = genericEntityMethod.Invoke(modelBuilder,new[] { mapper });
            }

            base.OnModelCreating(modelBuilder);
        }

        //创建日志工厂
        private static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] {
            new DebugLoggerProvider()
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 从 appsetting.json 中获取配置信息
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

#if DEBUG
            optionsBuilder.UseLoggerFactory(MyLoggerFactory).UseMySql(DbConfig.InitConn(config.GetConnectionString("DefaultConnection_file"), config.GetConnectionString("DefaultConnection")));

#else
            optionsBuilder.UseMySql(DbConfig.InitConn(config.GetConnectionString("DefaultConnection_file"), config.GetConnectionString("DefaultConnection"))).ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));

#endif
        }
    }
}
