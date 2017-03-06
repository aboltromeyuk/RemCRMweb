using RemCRMdal.AplicationDAL;
using RemCRMdal.ClientsDAL;
using RemCRMviewModel.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMbl.Services
{
    public class ClientService
    {
        ApplicationContext Context { get; set; }

        public void AddClient(ClientViewModel client)
        {
            Context.AddClient(new Client
            {
                 Type=client.Type,
                 Surname = client.Surname, 
                 Name = client.Name,
                 Middlename = client.Middlename,
                 Address = client.Address,
                 TelNumber = client.TelNumber,
                 Email = client.Email,
                 Comment = client.Comment
            });
        }
    }
}
