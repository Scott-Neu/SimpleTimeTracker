using MigSharp;
using System;

namespace SimpleTimeTracker.DataMigrations.Migrations
{
    /// <summary>
    /// Seed the default admin user if not exists
    /// </summary>
    [MigrationExport]
    internal class Migration201704171033 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            // add the default admin user

            db.Execute(context =>
            {
                var id = Guid.NewGuid();
                var hashedPwd = "$2b$10$.Zi2ETauYUYspmJyJFXDKueAp.deloyZNCpsn4pU1SrMUyOOSGHWm";
                var date = DateTimeOffset.Now;
                var command = context.Connection.CreateCommand();
                command.Transaction = context.Transaction;
                command.CommandText = " IF NOT EXISTS (SELECT Id FROM ApplicationUser WHERE IsActive = 1 AND IsDefaultUser = 1) "
                + " BEGIN "
                + " INSERT INTO ApplicationUser (Id,Email,FirstName,MiddleName,LastName,Suffix,HireDate,TermDate,Password,IsDefaultUser,DateAdded,DateEdited,UserAddedId,UserEditedId,IsActive) "
                + $" VALUES ('{id}','admin@admin.com','Admin','','User','','{date.ToString()}',NULL,'{hashedPwd}',1,'{date.ToString()}','{date.ToString()}','{Guid.Empty}','{Guid.Empty}',1); "
                + " INSERT INTO Claim (Id,ApplicationUserId,ClaimType,DateAdded,DateEdited,UserAddedId,UserEditedId,IsActive) "
                + $" VALUES ('{Guid.NewGuid()}','{id}',1,'{date.ToString()}','{date.ToString()}','{Guid.Empty}','{Guid.Empty}',1); "
                + " END "
                ;
                command.ExecuteNonQuery();
            });
        }

        public void Down(IDatabase db)
        {
            // delete the default admin user
            db.Execute(context =>
            {
                var id = Guid.NewGuid();
                var date = DateTimeOffset.Now;
                var command = context.Connection.CreateCommand();
                command.Transaction = context.Transaction;
                command.CommandText = " DELETE FROM ApplicationUser WHERE IsActive = 1 AND IsDefaultUser = 1";
                command.ExecuteNonQuery();
            });
        }
    }
}
