using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using PAYROLL.Services;
using Newtonsoft.Json;
using PAYROLL.Models.LoginModels;

namespace PAYROLL.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class CustomAuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext c)
        {

            var headers = c.Request.Headers;
            IEnumerable<string> keyvalue = new List<string>();
            headers.TryGetValues("dem-api-subscription-key", out keyvalue);

            if (!keyvalue.Any())
            {
                var response = c.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Your Subscription key is empty!");
                c.Response = response;
            }
            else
            {

                //var encryptedKey = Encryption.Encrypt(" {\"Username\":\"user\",\"Password\":\"pass\"}", "saltBea");
                var decryptedModel = JsonConvert.DeserializeObject<UserModel>(Encryption.Decrypt(keyvalue.FirstOrDefault(), "saltBea"));
                if(decryptedModel.UserName!= "user"||decryptedModel.Password!="pass")
                {
                    var response = c.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Your Subscription key is incorrect!");
                    c.Response = response;
                }

            }


            base.OnActionExecuting(c);

        }

    }
}