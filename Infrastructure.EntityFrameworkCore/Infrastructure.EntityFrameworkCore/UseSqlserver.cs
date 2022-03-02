namespace SSToolkit.Infrastructure.EntityFrameworkCore
{
    using Microsoft.EntityFrameworkCore;
    using SSToolkit.Fundamental.Extensions;

    public static partial class ExtensionHelpers
    {
        /// <summary>
        /// Use Sql Server with Configuration <see cref="EntityFrameworkConfiguration"/> 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="configuration">EntityFrameworkConfiguration</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DbContextOptionsBuilder AddSqlServer(
            this DbContextOptionsBuilder source,
            EntityFrameworkConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (configuration.ConnectionString.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(configuration.ConnectionString));
            }

            source.UseSqlServer(configuration.ConnectionString);

            if (configuration.EnableSensitiveDataLogging)
            {
                source.EnableSensitiveDataLogging();
            }

            if (configuration.EnableSensitiveDataLogging)
            {
                source.EnableDetailedErrors();
            }

            return source;
        }

        /// <summary>
        /// Use Sql Server with simple connection string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DbContextOptionsBuilder AddSqlServer(
            this DbContextOptionsBuilder source,
            string connectionString)
        {
            return source.AddSqlServer(new EntityFrameworkConfiguration()
            {
                ConnectionString = connectionString
            });
        }
    }
}
