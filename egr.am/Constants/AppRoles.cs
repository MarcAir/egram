namespace egr.am.Constants
{
    public static class AppRoles
    {   
        //Admin AppRoles hierarchy and definitions
        //Global Admin
        public const string SuperAdmin = "SuperAdmin";

        //local admin
        public const string VendorAdmin = "VendorAdmin";
        public const string StoreFrontAdmin = "StoreFrontAdmin";
        
        //shallow local admin
        public const string EndUserAdmin = "EndUserAdmin";


        //admin AppRoles action Type

        public const string ProductOfferingsAdminAction = SuperAdmin;


    }
}