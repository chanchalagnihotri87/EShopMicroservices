namespace Shopping.Web.Services;

public interface IOrderingService
{

    [Get("/ordering-service/orders?pageNumber{pageIndex}&pageSize={pageSize}")]
    Task<GetOrdersResponse> GetOrders(int pageIndex = 0, int pageSize = 10);

    [Get("/ordering-service/orders/customer/{customerId}")]
    Task<GetOrdersByCustomerResponse> GetOrdersByCustomer(Guid customerId);

    [Get("/ordering-service/orders/{orderName}")]
    Task<GetOrdersByNameResponse> GetOrdersByName(string orderName);
}
