using BikeDataModels;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLogic
{
    public class Connection
    {
        ODataClient client = new ODataClient("http://145.24.222.220/v1/");
        public IEnumerable<trommel> Trommels;

        public Connection()
        {
            Simple.OData.Client.V3Adapter.Reference();
            Trommels = client.For<trommel>("trommels").Filter(t => true).FindEntriesAsync().Result;
            /*foreach (var trommel in trommels)
            {
                Console.WriteLine(trommel.street);

            }*/
        }
    }
}
