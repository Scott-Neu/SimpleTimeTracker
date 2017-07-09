using MigSharp;
using System.Data;

namespace SimpleTimeTracker.DataMigrations.Migrations
{
    /// <summary>
    /// Create the ApplicationUser table
    /// </summary>
    [MigrationExport]
    internal class Migration201704170835 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            db.CreateTable("ApplicationUser")
                .WithPrimaryKeyColumn("Id", DbType.Guid)
                .WithNotNullableColumn("Email", DbType.String).OfSize(500)
                .WithNotNullableColumn("FirstName", DbType.String).OfSize(100)
                .WithNotNullableColumn("MiddleName", DbType.String).OfSize(100)
                .WithNotNullableColumn("LastName", DbType.String).OfSize(100)
                .WithNotNullableColumn("Suffix", DbType.String).OfSize(10)
                .WithNotNullableColumn("HireDate", DbType.DateTimeOffset)
                .WithNullableColumn("TermDate", DbType.DateTimeOffset)
                .WithNotNullableColumn("Password", DbType.String).OfSize(250)
                .WithNotNullableColumn("IsDefaultUser", DbType.Boolean)

                .WithNotNullableColumn("DateAdded", DbType.DateTimeOffset)
                .WithNotNullableColumn("DateEdited", DbType.DateTimeOffset)
                .WithNotNullableColumn("UserAddedId", DbType.Guid)
                .WithNotNullableColumn("UserEditedId", DbType.Guid)
                .WithNotNullableColumn("IsActive", DbType.Boolean);
        }

        public void Down(IDatabase db)
        {
            db.Tables["ApplicationUser"].Drop();
        }
    }
}
