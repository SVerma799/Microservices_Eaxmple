using Mango.Services.Coupons.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.Coupons.Api.Data
{
    /// <summary>
    /// App Db Context for the interaction with the Db.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class AppDbContext: DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the coupons.
        /// </summary>
        /// <value>
        /// The coupons.
        /// </value>
        public DbSet<Coupon> Coupons { get; set; }


        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// <para>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run. However, it will still run when creating a compiled model.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and
        /// examples.
        /// </para>
        /// </remarks>
        /// SV: If you want to insert the data into the db without having an empty database. You can insert the data to tables using this method.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// SV: It is very important to pass  the modelbuilder to the base class because
            /// SV: things might work now but later when added Identity User it will start creating problems.
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Coupon>().HasData(new Coupon()
            {
                CouponId = Guid.NewGuid(),
                CouponCode = "10OFF",
                DiscountAmont = 10,
                MinAmount = 100,
                LastUpdated = DateTime.Now,
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon()
            {
                CouponId = Guid.NewGuid(),
                CouponCode = "20OFF",
                DiscountAmont = 20,
                MinAmount = 1000,
                LastUpdated = DateTime.Now,
            });
        }
    }
}
