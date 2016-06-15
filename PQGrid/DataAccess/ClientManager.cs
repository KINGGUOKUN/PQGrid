using DapperExtensions;
using PQGrid.Infrusture;
using PQGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PQGrid.DataAccess
{
    public class ClientManager
    {
        #region Private Fields

        private readonly IDatabase _database = DatabaseFactory.CreateDatabase();

        #endregion

        #region Public Methods

        public IEnumerable<Client> GetClientPageList(int pageIndex, int pageSize, ref int count)
        {
            count = _database.Count<Client>(Predicates.Field<Client>(x => x.ID, Operator.Eq, null, true));

            return _database.GetPage<Client>(Predicates.Field<Client>(x => x.ID, Operator.Eq, null, true),
                new List<ISort>() { Predicates.Sort<Client>(x => x.Mobile)}, pageIndex - 1, pageSize);
        }

        #endregion
    }
}