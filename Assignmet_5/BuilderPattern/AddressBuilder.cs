using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class Address
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }
        public string Country { get; }
        public Address(string street, string city, string state, string zipCode, string country)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }
    }
    public class AddressBuilder
    {
        private string _street;
        private string _city;
        private string _state;
        private string _zipCode;
        private string _country;

        public AddressBuilder SetStreet(string street)
        {
            _street = street;
            return this;
        }

        public AddressBuilder SetCity(string city)
        {
            _city = city;
            return this;
        }

        public AddressBuilder SetState(string state)
        {
            _state = state;
            return this;
        }

        public AddressBuilder SetZipCode(string zipCode)
        {
            _zipCode = zipCode;
            return this;
        }

        public AddressBuilder SetCountry(string country)
        {
            _country = country;
            return this;
        }

        public Address Build()
        {
            if (string.IsNullOrWhiteSpace(_street) || string.IsNullOrWhiteSpace(_city))
            {
                throw new ArgumentException("Street and City fields cannot be null or empty.");
            }
            return new Address(_street, _city, _state, _zipCode, _country);
        }
    }
}
