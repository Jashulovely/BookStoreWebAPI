using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IAddressRepo
    {
        public string AddAddress(int userId, AddressModel address);
        public IEnumerable<AddressModel> GetAllAddresses();
        public string DeleteAddress(int id);
        public string UpdateAddress(int userId, AddressModel address);
    }
}
