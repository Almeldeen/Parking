using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace Parking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        [HttpPost("create-checkout-session")]
        public ActionResult CreateCheckoutSession()
        {
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
        {
          new SessionLineItemOptions
          {
            PriceData = new SessionLineItemPriceDataOptions
            {
              UnitAmount = 2000,
              Currency = "usd",
              ProductData = new SessionLineItemPriceDataProductDataOptions
              {
                Name = "T-shirt",
              },
            },
            Quantity = 1,
          },
        },
                PaymentIntentData = new SessionPaymentIntentDataOptions
                {
                    CaptureMethod = "automatic",  // or "manual" if you want to manually capture payments later
                },
                Mode = "payment",
                SuccessUrl = "https://localhost:7064/sucsess",
                CancelUrl = "http://localhost:4242/cancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return Ok(session.Url);

        }
        [HttpPost("refund-payment")]
        public ActionResult RefundPayment(string paymentIntentId)
        {
            var options = new RefundCreateOptions
            {
                PaymentIntent = paymentIntentId,
            };

            var service = new RefundService();
            Refund refund = service.Create(options);

            return Ok(refund);
        }
        [HttpPost("sucsess")]
        public ActionResult sucsess(string sessionid)
        {
            var service = new SessionService();
            Session session = service.Get(sessionid);
            
            var paymentIntentId = session.PaymentIntentId;

            return Ok(paymentIntentId);
        }
    }
}
