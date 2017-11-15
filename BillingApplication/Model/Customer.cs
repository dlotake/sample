using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BillingApplication.Models
{
    class Customer
    {
        private int _CustomerId;
        public int CustomerId
        {
            get { return _CustomerId; }
            set { _CustomerId = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Address;
        public string Address
        {
            get { return Address; }
            set { Address = value; }
        }
        private string _MobileNumber;

        public string MobileNumber
        {
            get { return _MobileNumber; }
            set { _MobileNumber = value; }
        }
        private string _GSTNumber;

        public string GSTNumber
        {
            get { return _GSTNumber; }
            set { _GSTNumber = value; }
        }
        private bool _IsDeleted;

        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }
    }
}
