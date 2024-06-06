using eShopping.SharedKernel.Options;
using System.ComponentModel.DataAnnotations;

namespace eShopping.Basket.Core.AppSettings
{
    public sealed class EventBusConnectOptions : IAppOptions
    {
        public static string ConfigSectionPath => "EventBusSettings";

        [Required]
        public string HostAddress { get; private init; }
    }
}