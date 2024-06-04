using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LinqWs;

List<Address> addresses = new List<Address>
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

// SELECT *
// FROM Addresses
// WHERE Country = "Hungary" -- SQL

IEnumerable<Address> hungarianAddressesWithQuerySyntax = from address in addresses
                                                         where address.Country == CountryType.Hungary
                                                         select address;

Console.WriteLine(hungarianAddressesWithQuerySyntax.Count());

IEnumerable<Address> hungarianAddressesWithMethodSyntax = addresses
    .Where(address => address.Country == CountryType.Hungary);

Console.WriteLine(hungarianAddressesWithMethodSyntax.Count());

var addressesWithStreetNamesLongerThan15Chars = addresses
    .Where(address => address.Street.Length > 15);

Console.WriteLine(addressesWithStreetNamesLongerThan15Chars.Count());

IEnumerable<string> streetNamesLongerThan15Chars = addresses
    .Where(address => address.Street.Length > 15)
    .Select(address => address.Street);


IEnumerable<string> CityNamesOrdered = addresses
    .OrderBy(address => address.City)
    .Select(address => address.City);

var CityNamesAndZipCodesOrdered = addresses
    .OrderBy(address => address.City)
    .ThenBy(address => address.ZipCode)
    .Select(address => $"{address.City} ({address.ZipCode})")
    .ToList();

Console.WriteLine(streetNamesLongerThan15Chars.Count());

Console.WriteLine(streetNamesLongerThan15Chars.Count());

var groupedCountries = addresses.GroupBy(address => address.Country);

foreach (var country in groupedCountries)
{
    Console.WriteLine($"{country.Key} {country.Count()}");
}

var maxHouseNumber = addresses.Max(address => address.HouseNumber);
var addressWithMaxHouseNumber = addresses.Where(address => address.HouseNumber == maxHouseNumber);

Console.WriteLine(maxHouseNumber);

var biggestNumberOfAddressesPerCountry = addresses
    .GroupBy(address => address.Country)
    .Select(countryGroup => new
    {
        Country = countryGroup.Key,
        Count = countryGroup.Count()
    })
    .OrderByDescending(country => country.Count)
    .First();

Console.WriteLine(biggestNumberOfAddressesPerCountry);