namespace UpgradeHelpers.WebMap
{
    /// <summary>
    /// Classes implementing this interface can be used to register Surrogates using the 
    /// plugin intrastructure
    /// </summary>
    public interface  ISurrogateRegistration
    {
        void Register();
    }
}