using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shopping.Web.Pages
{
    public class CheckoutModel(IBasketService basketService, ILogger<CheckoutModel> logger) : PageModel
    {
        [BindProperty]
        public BasketCheckoutModel Order { get; set; } = default!;

        public ShoppingCartModel Cart { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await basketService.LoadUserBasket();


            return Page();
        }

        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            logger.LogInformation("Checkout button clicked");

            var basket = await basketService.LoadUserBasket();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.CustomerId = new Guid("58c49479-ec65-4de2-86e7-033c54691aab");
            Order.UserName = Cart.UserName;
            Order.TotalPrice = Cart.TotalPrice;

            return RedirectToPage("Confirmation", "OrderSubmitted");
        }
    }
}
