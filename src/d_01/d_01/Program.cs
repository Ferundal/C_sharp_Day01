using System;
using System.Collections.Generic;
using d_01;
Console.WriteLine("----------ex00----------");
Storage storage = new Storage(10);
Console.WriteLine($"{storage.IsEmpty()}");
storage = new Storage(0);
Console.WriteLine($"{storage.IsEmpty()}");

Console.WriteLine("----------ex01----------");
var customer1 = new Customer("Andrew", 1);
Console.WriteLine(customer1.ToString());
var customer2 = new Customer("Andrew", 1);
var customer3 = new Customer("Boba", 1);
Customer nullCustomer = null;
Console.WriteLine($"customer1 == customer2 = {customer1 == customer2}");
Console.WriteLine($"customer1 == customer3 = {customer1 == customer3}");
Console.WriteLine($"customer1 == nullCustomer = {customer1 == nullCustomer}");
Console.WriteLine($"nullCustomer == customer2 = {nullCustomer == customer2}");
Console.WriteLine($"nullCustomer == nullCustomer = {nullCustomer == nullCustomer}");
Console.WriteLine($"customer1 != customer2 = {customer1 != customer2}");
Console.WriteLine($"customer1 != customer3 = {customer1 != customer3}");
Console.WriteLine($"customer1 != nullCustomer = {customer1 != nullCustomer}");
Console.WriteLine($"nullCustomer != customer2 = {nullCustomer != customer2}");
Console.WriteLine($"nullCustomer != nullCustomer = {nullCustomer != nullCustomer}");

Console.WriteLine("----------ex02----------");
customer1.FillCart(15);
customer2.FillCart(15);
customer3.FillCart(15);
Console.WriteLine($"{customer1} ({customer1.GoodsAmount} items in the cart)");
Console.WriteLine($"{customer2} ({customer2.GoodsAmount} items in the cart)");
Console.WriteLine($"{customer3} ({customer3.GoodsAmount} items in the cart)");

Console.WriteLine("----------ex03----------");
CashRegister cashRegister1 = new CashRegister("Register #1");
Console.WriteLine($"{cashRegister1}");

Console.WriteLine("----------ex04----------");
Store store = new Store(200, 5);
Console.WriteLine($"{store.IsOpen()}");
store = new Store(0, 0);
Console.WriteLine($"{store.IsOpen()}");

Console.WriteLine("----------ex05----------");
customer1 = new Customer("Buba", 1);
customer2 = new Customer("Pepe", 2);
customer3 = new Customer("Vova", 3);
customer1.FillCart(1);
customer2.FillCart(1);
customer3.FillCart(100);
cashRegister1.AddToQueue(customer1);
cashRegister1.AddToQueue(customer2);
Console.WriteLine("{0}: {1} ({2}), {3} ({4})",
    cashRegister1.Name, customer1.Name, customer1.GoodsAmount, customer2.Name, customer2.GoodsAmount);
var cashRegister2 = new CashRegister("Register #2");
cashRegister2.AddToQueue(customer3);
Console.WriteLine("{0}: {1} ({2})",
    cashRegister2.Name, customer3.Name, customer3.GoodsAmount);
List<CashRegister> cashRegisters = new List<CashRegister>();
cashRegisters.Add(cashRegister1);
cashRegisters.Add(cashRegister2);
Console.WriteLine("Less Customers: {0}", 
    CustomerExtensions.LessCustomersCashRegister(cashRegisters).Name);
Console.WriteLine("Less Goods: {0}", 
    CustomerExtensions.LessGoodsCashRegister(cashRegisters).Name);
Console.WriteLine("----------ex06----------");
Customer[] customers = new Customer[10];
for (int index = 0; index < customers.Length; ++index)
{
    customers[index] = new Customer($"UnicName{index}", index);
}
Console.WriteLine("-------LessCustomers----");
store = new Store(40, 3);
cashRegisters = store.CashRegisters;
while (store.IsOpen())
{
    foreach (var customer in customers)
    {
        customer.FillCart(7);
        var cashRegister = CustomerExtensions.LessCustomersCashRegister(cashRegisters);
        Console.WriteLine("{0}, Customer #{1} ({2} items in cart) - {3} ({4} people with {5} items behind)",
            customer.Name, 
            customer.SerialNumber, 
            customer.GoodsAmount, 
            cashRegister.Name, 
            cashRegister.CustomersCount, 
            cashRegister.GoodsCount);
        cashRegister.AddToQueue(customer);
    }
    store.ProceedQueues();
}
Console.WriteLine("-------LessGoods--------");
store = new Store(40, 3);
cashRegisters = store.CashRegisters;
while (store.IsOpen())
{
    foreach (var customer in customers)
    {
        customer.FillCart(7);
        var cashRegister = CustomerExtensions.LessGoodsCashRegister(cashRegisters);
        Console.WriteLine("{0}, Customer #{1} ({2} items in cart) - {3} ({4} people with {5} items behind)",
            customer.Name, 
            customer.SerialNumber, 
            customer.GoodsAmount, 
            cashRegister.Name, 
            cashRegister.CustomersCount, 
            cashRegister.GoodsCount);
        cashRegister.AddToQueue(customer);
    }
    store.ProceedQueues();
}