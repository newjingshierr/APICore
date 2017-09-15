
using System.Linq;
using System.Web.Http;
using RestAPI.Models;
using System.Collections.Generic;


namespace RestAPI.Controllers
{
    [RoutePrefix("api/news")]
    public class NewsController : ApiController
    {
        [HttpGet]
        [Route("Items")]
        public List<am_news> Items(int index = 0, int pageSize = 5)
        {
            using (AmAPIContent content = new AmAPIContent())
            {
                
                var result = content.Am_News.OrderByDescending(o => o.PublishDate).Take(pageSize*(index+1)).Skip(pageSize*(index)).ToList();

                return result;

            }

        }

        [HttpGet]
        [Route("Item")]
        public am_news Item(string ID)
        {
            using (AmAPIContent content = new AmAPIContent())
            {

                var result = content.Am_News.FirstOrDefault(o => o.ID.ToString() == ID);

                return result;

            }

        }
    }
}
