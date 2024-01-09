using BusinessLayer.Interfaces;
using ModelLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class AddressBusiness : IAddressBusiness
    {
        private readonly IAddressRepo addressRepo;

        public AddressBusiness(IAddressRepo addressRepo)
        {
            this.addressRepo = addressRepo;
        }

        public string AddAddress(int userId, AddressModel address)
        {
            return this.addressRepo.AddAddress(userId, address);
        }

        public IEnumerable<AddressModel> GetAllAddresses()
        {
            return this.addressRepo.GetAllAddresses();
        }

        public string DeleteAddress(int id)
        {
            return this.addressRepo.DeleteAddress(id);
        }

        public string UpdateAddress(int userId, AddressModel address)
        {
            return this.addressRepo.UpdateAddress(userId, address);
        }
    }
}
