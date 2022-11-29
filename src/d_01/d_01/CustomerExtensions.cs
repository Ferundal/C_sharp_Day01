using System.Collections.Generic;

namespace d_01
{
    public static class CustomerExtensions 
    {
        public static CashRegister LessCustomersCashRegister(List<CashRegister> cashRegisters)
        {
            if (cashRegisters == null || cashRegisters.Count == 0)
                return null;
            CashRegister lessCustomersCashRegister = cashRegisters[0];
            for (int index = 1; index < cashRegisters.Count; ++index)
            {
                if (lessCustomersCashRegister.CustomersCount > cashRegisters[index].CustomersCount)
                {
                    lessCustomersCashRegister = cashRegisters[index];
                }
            }
            return lessCustomersCashRegister;
        }
        
        public static CashRegister LessGoodsCashRegister(List<CashRegister> cashRegisters)
        {
            if (cashRegisters == null || cashRegisters.Count == 0)
                return null;
            CashRegister lessGoodsCashRegister = cashRegisters[0];
            for (int index = 1; index < cashRegisters.Count; ++index)
            {
                if (lessGoodsCashRegister.GoodsCount > cashRegisters[index].GoodsCount)
                {
                    lessGoodsCashRegister = cashRegisters[index];
                }
            }
            return lessGoodsCashRegister;
        }
    }
}