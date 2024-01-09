using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using ModelLayer;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Services
{
    public class AddressRepo : IAddressRepo
    {
        private readonly IConfiguration configuration;

        public AddressRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public string AddAddress(int userId, AddressModel address)
        {
            if (userId > 0)
            {
                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
                {
                    SqlCommand cmd = new SqlCommand("uspAddAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@CustName", address.CustName);
                    cmd.Parameters.AddWithValue("@CustMobNo", address.CustMobNo);
                    cmd.Parameters.AddWithValue("@Address", address.Address);
                    cmd.Parameters.AddWithValue("@City", address.City);
                    cmd.Parameters.AddWithValue("@State", address.State);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "Address Added Successfully..................";
            }
            else
            {
                return null;
            }
        }


        public IEnumerable<AddressModel> GetAllAddresses()
        {
            List<AddressModel> lstAddress = new List<AddressModel>();

            using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
            {
                SqlCommand cmd = new SqlCommand("uspAddressList", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    AddressModel address = new AddressModel();

                    address.UserId = rdr.GetInt32("UserId");
                    address.CustName = rdr["CustName"].ToString();
                    address.CustMobNo = (long) rdr.GetInt64("CustMobNo");
                    address.Address = rdr["Address"].ToString();
                    address.City = rdr["City"].ToString();
                    address.State = rdr["State"].ToString();
                    lstAddress.Add(address);
                }
                con.Close();
            }
            return lstAddress;
        }


        public string DeleteAddress(int id)
        {
            if (id >= 1)
            {
                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
                {
                    SqlCommand cmd = new SqlCommand("uspDeleteAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdrId", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "Address Deleted Successfully......................";
            }
            else
            {
                return null;
            }
        }


        public string UpdateAddress(int userId, AddressModel address)
        {
            if (address != null)
            {
                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
                {
                    SqlCommand cmd = new SqlCommand("uspUpdateAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdrId", address.AdrId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@CustName", address.CustName);
                    cmd.Parameters.AddWithValue("@CustMobNo", address.CustMobNo);
                    cmd.Parameters.AddWithValue("@Address", address.Address);
                    cmd.Parameters.AddWithValue("@City", address.City);
                    cmd.Parameters.AddWithValue("@State", address.State);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "Address is Updated Successfully..........";
            }
            else
            {
                return null;
            }
        }
    }
}
