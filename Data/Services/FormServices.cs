using Newtonsoft.Json;  //Giving the reference of the package so that we can use it's method
using ReferenceForCoursework.Data.Models;  //Giving the path of the files that are in Model folder i.e. AddForm.cs and Hobby.cs, Allowing us to use it
using ReferenceForCoursework.Data.Utils;  //Giving the path of the files that is in Utils folder i.e. FormUtils.cs, allowing us to use it's methods

namespace ReferenceForCoursework.Data.Services;

// Service class responsible for handling operations like Saving, Retrieving overall Manipulating related to form data.
public class FormServices
{
    // Saves user Input in Form to a JSON file.
    public static void SaveFormDataInJson(AddForm form)
    {
        // Gets the file path where form data will be stored from ApplicationFilePath method
        // in FormUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.ApplicationFilePath();
        try // Deserialize existing JSON data from the file into a list of AddForm objects called formList.
        {
            List<AddForm> formList; // object of List of AddForm i.e. formList
            string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

            // If the existingJSONData variable is empty, initialize a new list; otherwise, deserialize the data.
            if (string.IsNullOrEmpty(existingJsonData))
            {
                formList = new List<AddForm>();
            }
            else
            {
                formList = JsonConvert.DeserializeObject<List<AddForm>>(existingJsonData);
            }
            // Add the current form to the list.
            formList.Add(form);

            // Serialize the updated list of form data to JSON format with formatting Indented and store it in a variable formJsonData
            string formJsonData = JsonConvert.SerializeObject(formList, Formatting.Indented);

            // Write the JSON data back to the file.
            File.WriteAllText(filePath, formJsonData);
        }
        catch(Exception ex)
        {
            // Handle exceptions by displaying an alert with the error message.
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            App.Current.MainPage.DisplayAlert("Error", $"Error Saving Data", "OK");
        }
    }

    // Retrieves form data from the JSON file.
    public static List<AddForm> RetrieveFormData()
    {
        // Gets the file path where form data is stored from ApplicationFilePath method
        // in FormUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.ApplicationFilePath();
        try
        {
            string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

            // If the existing JSON data is empty, return an empty list;
            // otherwise, deserialize the data into a list of AddForm objects.
            if (string.IsNullOrEmpty(existingJsonData))
            {
                return new List<AddForm>();
            }
            return JsonConvert.DeserializeObject<List<AddForm>>(existingJsonData);
        }
        catch (Exception ex)
        {
            // Handle exceptions by displaying an alert with the error message.
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            App.Current.MainPage.DisplayAlert("Error", "Error Retrieving Data from Json", "OK");
            return new List<AddForm>();
        }
    }
}
