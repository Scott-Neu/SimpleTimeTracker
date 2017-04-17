using MigSharp;
using System;
using System.Data;

namespace SimpleTimeTracker.DataMigrations.Migrations
{
    /// <summary>
    /// Create the claim table
    /// </summary>
    [MigrationExport]
    internal class Migration201704170919 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            db.CreateTable("Claim")
                .WithPrimaryKeyColumn("Id", DbType.Guid)
                .WithNotNullableColumn("ApplicationUserId", DbType.Guid)
                .WithNotNullableColumn("ClaimType", DbType.Int16)

                .WithNotNullableColumn("DateAdded", DbType.DateTimeOffset)
                .WithNotNullableColumn("DateEdited", DbType.DateTimeOffset)
                .WithNotNullableColumn("UserAddedId", DbType.Guid)
                .WithNotNullableColumn("UserEditedId", DbType.Guid)
                .WithNotNullableColumn("IsActive", DbType.Boolean);

            db.Tables["Claim"].AddForeignKeyTo("ApplicationUser", "FK_Claim_ApplicationUser").Through("ApplicationUserId", "Id").CascadeOnDelete();
        }

        public void Down(IDatabase db)
        {
            db.Tables["Claim"].Drop();

        }
    }
}
