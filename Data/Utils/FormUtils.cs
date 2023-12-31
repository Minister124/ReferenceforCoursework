﻿
// This utility class provides methods for handling file paths related to the application.
namespace ReferenceForCoursework.Data.Utils
{
    public static class FormUtils
    { 
        public static string ApplicationDirectoryPath()   // Returns the path of the directory where application data will be stored.
        {
            string directoryPath = @"Path from your drive to the folder you want to save folder in";  // Define the path to the directory where you want to store your files.
            if (!Directory.Exists(directoryPath))    // If the directory doesn't exist
            {
                Directory.CreateDirectory(directoryPath);  //Create the directory
                return directoryPath;     // Return the path of the directory.
            }
            else
            {
                return directoryPath;   // else return if it is already there
            }
        }

        // Returns the path of the file where form data will be stored.
        public static string ApplicationFilePath()
        {
            string directoryPathCreated = ApplicationDirectoryPath();   // Calling the method ApplicationDirectoryPath That returns the folder created, and storing it in directoryPathCreated variable
            string filePath = Path.Combine(directoryPathCreated, "FormData.json");  // Combine the directory path with the file name to get the complete file path.
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();  // If the file doesn't exist, create it.
                    return filePath;    // Return the path of the file.
                }
                else
                {
                    return filePath;  // Return the path of the file.
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return message;
            }
        }


        // Returns the path of the file where hobby data will be stored.
        public static string HobbiesFilePath()   // This method is used for hobbies data.
        {
            // Similar implementation as ApplicationFilePath.
            string directoryPathCreated = ApplicationDirectoryPath();
            string filePath = Path.Combine(directoryPathCreated, "Hobbies.json");
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                    return filePath;
                }
                else
                {
                    return filePath;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return message;
            }
        }
    }
}
