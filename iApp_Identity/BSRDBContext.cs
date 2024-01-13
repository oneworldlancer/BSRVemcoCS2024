
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BSRVemcoCS.iApp_Identity
    {

    public partial class BSRDBContext : IdentityDbContext<AppCore_IdentityUser , AppCore_IdentityRole , string>
    {

        public BSRDBContext ( DbContextOptions<BSRDBContext> options ) : base ( options )
        {

        }


        protected override void OnModelCreating ( ModelBuilder builder )
        {

            base.OnModelCreating ( builder );

            var keysProperties =
                builder.Model.GetEntityTypes ( )
                .Select ( x => x.FindPrimaryKey ( ) )
                .SelectMany ( x => x.Properties );

            foreach ( var property in keysProperties )
            {
                property.ValueGenerated = ValueGenerated.OnAdd;
            }
        }

    }
}
