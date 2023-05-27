namespace MysqlWebApi
{
    public class SimpleMiddleware
    {
        private RequestDelegate _next;
        public SimpleMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path;
            context.Response.Headers.Add("coustom-header", path);
            if(path.Contains("GetUserById"))
            {
                context.Response.Redirect("htttp://alx.pl/", true);
            }
            await _next(context);
        }
    }
}
