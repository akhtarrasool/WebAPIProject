
namespace WebAPIProject.Entities
{
    public static class Constants
    {
        public static class ResponseMessages
        {
            public static string Training_Save_Success = "Training saved successfully!";
            public static string Training_Save_Error = "An unhandled error occured.";
            public static string Training_Save_Date_Invalid = "Invalid date(s).";
            public static string Training_Save_Date_Valid = "Valid dates.";
            public static string Training_Save_Date_Diff = "End date must be equal or greater than start date.";
        }
    }
}
