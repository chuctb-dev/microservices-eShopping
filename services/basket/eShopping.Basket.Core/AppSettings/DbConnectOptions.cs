using eShopping.SharedKernel.Options;
using System.ComponentModel.DataAnnotations;

namespace eShopping.Basket.Core.AppSettings
{
    public sealed class DbConnectOptions : IAppOptions
    {
        public static string ConfigSectionPath => "CacheSettings";

        [Required]
        public string ConnectionString { get; private init; }
    }
}