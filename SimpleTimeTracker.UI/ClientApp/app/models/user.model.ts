export class UserModel {
    FirstName: string;
    LastName: string;
    Email: string;
    Roles: string[];

    //constructor() { }

    //constructor(token: string) {
    //    this.FirstName = token.given_name;
    //    this.LastName = token.family_name;
    //    this.Email = token.sub;
    //    this.Roles = token.Roles;
    //}

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