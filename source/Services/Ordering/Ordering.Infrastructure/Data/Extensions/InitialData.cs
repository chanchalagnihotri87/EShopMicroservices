

namespace Ordering.Infrastructure.Data.Extensions;

public class InitialData
{
    public static IEnumerable<Customer> Customers => new List<Customer> {
        Customer.Create(CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c54691aab")),"Chanchal Kumar","chanchalagnihotri1987@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),"Nirdosh Kumar", "nirdoshagnihotri@gmail.com")
    };

    public static IEnumerable<Product> Products => new List<Product> {
        Product.CreateProduct(ProductId.Of(new Guid("12c87792-ec65-4de2-86e7-033c54691aab")),"IPhone X",500),
        Product.CreateProduct(ProductId.Of(new Guid("349dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),"Samsung 10", 400),
        Product.CreateProduct(ProductId.Of(new Guid("56c49479-ec65-4de2-86e7-033c54691aab")),"Huwai Plus",650),
        Product.CreateProduct(ProductId.Of(new Guid("789dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),"Xiaomi Mi", 450)
    };


    public static IEnumerable<Order> OrdersWithItems
    {

        get
        {

            var address1 = Address.Of("Chanchal", "kumar", "chanchalagnihotri1987@gmail.com", "Himachal", "India", "Himachal", "17435");
            var address2 = Address.Of("Nirdosh", "kumar", "nirdoshagnihotri@gmail.com", "Himachal", "India", "Himachal", "17435");

            var payment1 = Payment.Of("Chanchal", "11111111111111111", "12/28", "123", 1);
            var payment2 = Payment.Of("Nirdosh", "22222222222222", "06/30", "123", 2);

            var order1 = Order.CreateOrder(
                OrderId.Of(new Guid("32c49479-ec65-4de2-86e7-033c54691bab")),
                CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c54691aab")),
                OrderName.Of("Order1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1);

            order1.Add(ProductId.Of(new Guid("12c87792-ec65-4de2-86e7-033c54691aab")), 1, 500);
            order1.Add(ProductId.Of(new Guid("349dc8dc-990f-48e0-a37b-e6f2b60b9d7d")), 1, 400);



            var order2 = Order.CreateOrder(
              OrderId.Of(new Guid("84c49479-ec65-4de2-86e7-033c54691bab")),
              CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),
              OrderName.Of("Order2"),
              shippingAddress: address2,
              billingAddress: address2,
              payment2);

            order1.Add(ProductId.Of(new Guid("56c49479-ec65-4de2-86e7-033c54691aab")), 1, 650);
            order1.Add(ProductId.Of(new Guid("789dc8dc-990f-48e0-a37b-e6f2b60b9d7d")), 1, 450);


            return new List<Order> { order1, order2 };
        }
    }

}
