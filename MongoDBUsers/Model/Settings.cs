namespace MongoDBUsers.Model
{

    //The settings class contains properties defined in the appsettings.json file and is used for accessing application settings via objects
    public class Settings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}