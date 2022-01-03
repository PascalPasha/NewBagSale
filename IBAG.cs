using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BagSale
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBAG
    {
        string Id { get; set; }
        string NoTelpon { get; set; }

        [OperationContract]
        string Transaksi(string id, string nama, string noTelp, int jumlah);
        [OperationContract]
        string editTransaksi(string idPemesanan, string namaCustomer, string noTelepon);
        [OperationContract]
        string deleteTransaksi(string id);
        [OperationContract]
        List<Transaksi> Transaksi();

        [OperationContract]
        string Login(string username, string password);
        [OperationContract]
        string Register(string username, string password, string kategori);
        [OperationContract]
        string updateRegister(string username, string password, string kategori, int id);
        [OperationContract]
        string deleteRegister(string username);
        [OperationContract]
        List<DataRegister> dataRegist();
    }

    [DataContract]
    public class DataRegister
    {
        [DataMember(Order = 1)]
        public int id { get; set; }
        [DataMember(Order = 2)]
        public string username { get; set; }
        [DataMember(Order = 3)]
        public string password { get; set; }
        [DataMember(Order = 4)]
        public string kategori { get; set; }

    }

    [DataContract]
    public class Transaksi
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string nama { get; set; }
        [DataMember]
        public string noTelp { get; set; }
        [DataMember]
        public int jumlah { get; set; }
    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
