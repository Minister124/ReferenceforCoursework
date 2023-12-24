using Newtonsoft.Json; //Giving the reference of the package so that we can use it's method
using ReferenceForCoursework.Data.Models; //Giving the path of the files that are in Model folder i.e. AddForm.cs and Hobby.cs, Allowing us to use it
using ReferenceForCoursework.Data.Utils;  //Giving the path of the files that is in Utils folder i.e. FormUtils.cs, allowing us to use it's methods

// This class provides methods for saving, retrieving, and manipulating hobby data.
namespace ReferenceForCoursework.Data.Services;

public class HobbyServices
{
    // Saves lists of hobby data Injected to a JSON file.
    public static void SaveHobbiesToJson(List<Hobby> hobby){
        // Gets the file path where form data will be stored from ApplicationFilePath method
        // in FormUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.HobbiesFilePath();

        // Serialize the list of hobbies to JSON format with formatting Indented and store it in Variable jsonData
        string jsonData = JsonConvert.SerializeObject(hobby, Formatting.Indented);

        // Write the JSON data to the file given from filePath variable and data from jsonData variable.
        File.WriteAllText(filePath, jsonData);
    }

    //This method Injects the data Into the Json File Manually by creating the multiple objects and Passing it to the list only if the data inside the file is empty.
    public static void InjectSampleHobbiesData()
    {
        // Gets the file path where hobby data will be stored from HobbiesFilePath method
        // in FormUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.HobbiesFilePath();

        // Read existing data from the file and store it in variable existingData
        var existingData = File.ReadAllText(filePath);

        // If the file is empty, injects a list of sample hobby data in a object of List<Hobby> called sampleHobbies first and saves it in a Json File by calling method SaveHobbiesToJson.
        if (string.IsNullOrEmpty(existingData)){
            List<Hobby> sampleHobbies = new List<Hobby>
            {
                new Hobby { Name = "Reading" },
                new Hobby { Name = "Cooking" },
                new Hobby { Name = "Gardening" },
                new Hobby { Name = "Coding" },
                new Hobby { Name = "Dancing"},
                new Hobby { Name = "Singing"},
                new Hobby { Name = "Travelling"},
            };
            SaveHobbiesToJson(sampleHobbies); // Save the sample hobby data to the JSON file by calling SaveHobbiesToJson Method and passing sampleHobbies as it Argument.
        }
    }

    // Retrieves hobby data from the JSON file.
    public static List<Hobby> RetrieveHobbiesData()
    {
        // Gets the file path where hobby data is stored from HobbiesFilePath method
        // in FormUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.HobbiesFilePath();
         try{
            string existingJsonData = File.ReadAllText(filePath); // Read existing JSON data from the file.

            // If the existing JSON data is empty, return an empty list;
            // otherwise, deserialize the data into a list of Hobby objects.
            if (string.IsNullOrEmpty(existingJsonData))
            {
                return new List<Hobby>();
            }
            return JsonConvert.DeserializeObject<List<Hobby>>(existingJsonData);
         }
         catch(Exception ex)
        {
            // Handle exceptions by displaying an alert with the error message.
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            return new List<Hobby>();
         }
    }

    // Retrieves a specific hobby by its Id.
    public static Hobby GetHobbyById(Guid id)
    {
        List<Hobby> hobbies = RetrieveHobbiesData(); // Retrieves the list of hobbies and stores it in hobbies object

        // Return the first hobby with the specified Id.
        return hobbies.FirstOrDefault(x => x.Id == id); //creating arrow function and checking whether the Id of Hobbies is equal to the id of parameter that recieves value later on.
    }

    // Edits the name of a specific hobby.
    public static List<Hobby> EditHobby(Guid id, string newName)
    {
        // Retrieve the list of hobbies.
        List<Hobby> hobbies = RetrieveHobbiesData();
        // Find the hobby with the specified Id.
        Hobby editHobby = hobbies.FirstOrDefault(x => x.Id == id);
        // If the hobby is not found, throw an exception.
        if (editHobby == null){
            throw new Exception("Hobby not found");
        }
        // Update the name of the hobby.
        editHobby.Name = newName;
        SaveHobbiesToJson(hobbies); // Save the updated list of hobbies to the JSON file by calling method SaveHobbiesToJson
        return hobbies;  // Return the updated list of hobbies.
    }
}
