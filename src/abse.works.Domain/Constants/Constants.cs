namespace abse.works.Domain.Constants
{
    public static class Constants
    {
        public static class Routes
        {
            public const string Base = "";
            public const string Home = "home";
            public const string LoginPage = "login";
            public const string RegisterPage = "register";
            public const string Dashboard = "Dashboard";
            public const string UserProfile = "UserProfile";
            public const string UserAvailability = "UserAvailability";
            public const string JobOfferList = "JobOfferList";
        }

        public static class Messages
        {
            public const string DownloadError = "Nie udało się pobrać danch";
            public const string SaveSuccess = "Zapisano dane!";
            public const string SaveError = "Nie udało się zapisać zmian";
            public const string NoSave = "Brak zmian do zapisu";
            public const string ValidationError = "Niepoprawne wartości";
            public const string ValidationNull= "Wprowadź dane";
            public const string ValidationFormat = "Niepoprawny format";
            public const string ValidationLength = "Zbyt długi ciąg znaków";
            public const string Applied = "Zaaplikowano na ofertę";
        }
    }
}
