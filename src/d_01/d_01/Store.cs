using System;
using System.Collections.Generic;

namespace d_01
{
    public class Store
    {
        private Storage _storage;
        private List<CashRegister> _cashRegisters;

        public List<CashRegister> CashRegisters => new List<CashRegister>(_cashRegisters);

        public Store(int storageCapacity, int cashRegistersAmount)
        {
            _storage = new Storage(storageCapacity);
            if (cashRegistersAmount < 0)
                cashRegistersAmount = 0;
            _cashRegisters = new List<CashRegister>(cashRegistersAmount);
            for (int index = 0; index < cashRegistersAmount; ++index)
            {
                _cashRegisters.Add(new CashRegister($"Register #{index + 1}"));
            }
        }

        public void ProceedQueues()
        {
            foreach (var cashRegister in _cashRegisters)
            {
                var customer = cashRegister.First();
                while (customer != null)
                {
                    customer.Pay(_storage.GetGoods(customer.GoodsAmount));
                    if (customer.GoodsAmount != 0)
                    {
                        Console.WriteLine("{0}, Customer #{1} ({2} items left in cart)",
                            customer.Name,
                            customer.SerialNumber,
                            customer.GoodsAmount);
                        return;
                    }
                    cashRegister.Next();
                    customer = cashRegister.First();
                }
            }
        }

        public bool IsOpen() => !_storage.IsEmpty();
    }
}