using eShopping.SharedKernel.Options;
using System.ComponentModel.DataAnnotations;

namespace eShopping.Catalog.Core.AppSettings
{
    public sealed class DbConnectOptions : IAppOptions
    {
        public static string ConfigSectionPath => "DatabaseSettings";

        [Required]
        public string ConnectionString { get; private init; }
        [Required]
        public string DatabaseName { get; private init; }
        [Required]
        public string ProductsCollection { get; private init; }
        [Required]
        public string BrandsCollection { get; private init; }
        [Required]
        public string TypesCollection { get; private init; }
    }
}