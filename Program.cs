using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LinqWs;


var addressList = new AddressList();
var addresses = addressList.Addresses; 

void WriteCollectionToConsole<T>(Func<IEnumerable<T>> func)
{
    Console.WriteLine(func.Method.Name);
    System.Console.WriteLine("------------------------------");
    
    var QueryResult = func.Invoke().ToList();

    QueryResult.ForEach(item => Console.WriteLine(item));
    System.Console.WriteLine($"Count of results: {QueryResult.Count}");

    System.Console.WriteLine();
}

IEnumerable<Address> HungarianAddressesWithQuerySyntax()
{
    // SELECT *
    // FROM Addresses
    // WHERE Country = "Hungary" -- SQL

    return from address in addresses
           where address.Country == CountryType.Hungary
           select address;
}

IEnumerable<Address> HungarianAddressesWithMethodSyntax()
{
    return addresses
        .Where(address => address.Country == CountryType.Hungary);

}

IEnumerable<String> StreetNamesLongerThan15Chars()
{
    return addresses
        .Where(address => address.Street.Length > 15)
        .Select(address => address.Street);
}

IEnumerable<String> CityNamesOrdered()
{
    return addresses
        .OrderBy(address => address.City)
        .Select(address => address.City);
}

IEnumerable<String> CityNamesAndZipCodesOrdered()
{
    return addresses
        .OrderBy(address => address.City)
        .ThenBy(address => address.ZipCode)
        .Select(address => $"{address.City} ({address.ZipCode})");
}


IEnumerable<String> GroupedCountries()
{
    var groupedCountries = addresses.GroupBy(address => address.Country);

    foreach (var country in groupedCountries)
    {
        yield return ($"{country.Key} {country.Count()}");
    }
}

IEnumerable<Address> AddressWithMaxHouseNumber()
{
    int maxHouseNumber = addresses
        .Max(address => address.HouseNumber);
    return addresses
        .Where(address => address.HouseNumber == maxHouseNumber);
}

WriteCollectionToConsole(HungarianAddressesWithQuerySyntax);
WriteCollectionToConsole(HungarianAddressesWithMethodSyntax);

WriteCollectionToConsole(StreetNamesLongerThan15Chars);
WriteCollectionToConsole(CityNamesOrdered);
WriteCollectionToConsole(CityNamesAndZipCodesOrdered);

WriteCollectionToConsole(GroupedCountries);
WriteCollectionToConsole(AddressWithMaxHouseNumber);