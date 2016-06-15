using PQGrid.DataAccess;
using PQGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PQGrid.Controllers
{
    [RoutePrefix("api/clients")]
    public class ClientController : ApiController
    {
        #region Private Fields

        private readonly ClientManager _clientManager = new ClientManager();

        #endregion

        [HttpGet]
        [Route("page")]
        public dynamic GetClients(string pq_datatype, int pq_curpage, int pq_rpp)
        {
            int count = 0;
            var clients = _clientManager.GetClientPageList(pq_curpage, pq_rpp, ref count);

            if (pq_rpp * (pq_curpage - 1) >= count)
            {
                pq_curpage = (int)Math.Ceiling(((double)count) / pq_rpp);
                clients = _clientManager.GetClientPageList(pq_curpage, pq_rpp, ref count);
            }

            return new
            {
                pageIndex = pq_curpage,
                count,
                data = clients
            };
        }
    }
}
