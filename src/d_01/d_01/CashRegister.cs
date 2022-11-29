using System;
using System.Collections.Generic;
using System.Linq;

namespace d_01
{
    public class CashRegister : IEquatable<CashRegister>
    {
        public string Name { get; }
        public int CustomersCount => _customers.Count;

        public int GoodsCount
        {
            get
            {
                return _customers.Sum(customer => customer.GoodsAmount);
            }
        }
        private Queue<Customer> _customers;

        public CashRegister(string name)
        {
            Name = name;
            _customers = new Queue<Customer>();
        }

        public void AddToQueue(Customer customer)
        {
            _customers.Enqueue(customer);
        }

        public Customer First()
        {
            if (_customers.Count > 0)
                return _customers.Peek();
            return null;
        }

        public void Next()
        {
            if (_customers.Count > 0)
                _customers.Dequeue();
        }

        public bool Equals(CashRegister other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CashRegister)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}