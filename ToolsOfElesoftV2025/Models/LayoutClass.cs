using Microsoft.AspNetCore.Mvc.Filters;
namespace ToolsOfElesoftV2025.Models
{
    public class LayoutClass : ActionFilterAttribute
    {

        ElesoftiToolsContext db = new ElesoftiToolsContext();
        #pragma warning disable
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //اجرا برای قبل از اکشن
            string UserAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();

            string IpString = context.HttpContext.Connection.RemoteIpAddress.ToString();

            //ساخت ایجنت کوتاه
            string[] Arr = UserAgent.Split(')');

            //ذخیره اطلاعات بازدید در دیتابیس
            Tview tview = new Tview();

            tview.Date = DateTime.Now;
            tview.Deviece = UserAgent;
            tview.DevieceAsShort = Arr[0] + ")";
            tview.IpAddress = IpString;

            db.Tviews.Add(tview);
            try
            {
                db.SaveChanges();
            }
            catch
            {

            }

        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //اجرا برای بعد از اکشن
        }
    }
}
