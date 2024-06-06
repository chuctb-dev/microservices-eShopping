using eShopping.SharedKernel.Options;
using System.ComponentModel.DataAnnotations;

namespace eShopping.Basket.Core.AppSettings
{
    public sealed class GrpcConnectOptions : IAppOptions
    {
        public static string ConfigSectionPath => "GrpcSettings";

        [Required]
        public string DiscountUrl { get; private init; }
    }
}
