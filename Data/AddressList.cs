namespace LinqWs
{
    internal class AddressList
    {
        public List<Address> Addresses { get; private set; }

        public AddressList()
        {
            Addresses = new List<Address>
            {
                new Address(CountryType.Hungary, "1116", "Budapest", "Nándorfejérvári út", 31),
                new Address(CountryType.Hungary, "1026", "Budapest", "Kelemen László utca", 2),
                new Address(CountryType.Hungary, "1035", "Budapest", "Hunor utca", 20),
                new Address(CountryType.Austria, "2351", "Wiener Neudorf", "Brauhausstraße", 6),
                new Address(CountryType.Austria, "3013", "Pressbaum ", "Bartbergstraße", 5),
                new Address(CountryType.Slovakia, "08001", "Prešov", "Levočská", 6127),
                new Address(CountryType.Slovakia, "02601", "Dolný", "Mokradská", 12),
                new Address(CountryType.Germany, "37444", "Sankt Andreasberg", "Leipziger Straße", 60),
                new Address(CountryType.Germany, "23970", "Benz", "An der Alster", 43),
                new Address(CountryType.France, "59000", "Lille", "Chemin Challet", 20),
            };
        }
    }
}