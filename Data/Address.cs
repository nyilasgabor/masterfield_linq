

namespace LinqWs
{
    internal class Address
    {
        public CountryType Country { get; private set; }
        public string ZipCode { get; private set; } 
        public string City { get; private set; }
        public string Street { get; private set; }
        public int HouseNumber { get; private set; }

        public Address(CountryType country, string zipCode, string city, string street, int houseNumber)
        {
            Country = country;
            ZipCode = zipCode;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{Country}: {ZipCode} {City}, {Street} {HouseNumber}.";
        }
        
    }
}
