export class UserModel {
    Id: string;
    FirstName: string;
    MiddleName: string;
    LastName: string;
    Suffix: string;
    Email: string;
    HireDate: Date;
    TermDate: Date;
    Password: string;
    IsActive: boolean;
    Roles: string[];

    isSiteAdmin(): boolean {
        return (this.Roles.indexOf("SiteAdmin") > -1);
    }

    isUserAdmin(): boolean {
        if (this.isSiteAdmin) return true;
        return (this.Roles.indexOf("UserAdmin") > -1);
    }

    isConfigurationAdmin(): boolean {
        if (this.isSiteAdmin) return true;
        return (this.Roles.indexOf("ConfigurationAdmin") > -1);
    }
}