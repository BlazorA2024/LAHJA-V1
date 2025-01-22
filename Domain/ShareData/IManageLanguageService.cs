namespace Domain.ShareData
{
    public interface IManageLanguageService
    {
        Task<string> GetLanguageAsync();
        //Task SetLanguageAsync(string languageCode);
        Task<bool> CheckIsLanguage(LanguagesCode code);
        Task SetLanguageAsync(LanguagesCode code);
    }
}
