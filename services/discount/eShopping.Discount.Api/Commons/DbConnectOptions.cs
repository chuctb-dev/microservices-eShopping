using eShopping.SharedKernel.Options;
using System.ComponentModel.DataAnnotations;

namespace eShopping.Discount.Api.Commons
{
    public sealed class DbConnectOptions : IAppOptions
    {
        public static string ConfigSectionPath => "DatabaseSettings";

        [Required]
        public string ConnectionString { get; private init; }
    }
}