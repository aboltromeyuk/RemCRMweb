using RemCRMdal.AplicationDAL;
using RemCRMdal.ClientsDAL;
using RemCRMdal.DevicesDAL;
using RemCRMdal.OrdersDAL;
using RemCRMviewModel.Clients;
using RemCRMviewModel.Devices;
using RemCRMviewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMbl.Services
{
    public class OrderService
    {
        public ApplicationContext Context { get; set; }

        public void AddOrder(OrderViewModel order)              //Add order
        {
            Context.AddOrder(new Order
            {
                Number = order.Number,
                Type = order.Type,
                Status = order.Status,
                Prepayment = order.Prepayment,
                Deadline = order.Deadline,
                PriceWill = order.PriceWill,
                Quickly = order.Quickly,
                Client = new Client
                {
                    Type = order.Client.Type,
                    Surname = order.Client.Surname,
                    Name = order.Client.Name,
                    Middlename = order.Client.Middlename,
                    TelNumber = order.Client.TelNumber,
                    Address = order.Client.Address,
                    Comment = order.Client.Comment,
                    Email = order.Client.Email
                },
                Device = new Device
                {
                    Type = order.Device.Type,
                    Brand = order.Device.Brand,
                    Equipment = order.Device.Equipment,
                    Model = order.Device.Model,
                    SerialNumber = order.Device.SerialNumber,
                    Appearance = order.Device.Appearance,
                    Defect = order.Device.Defect
                }
            });
        }

        public List<OrderViewModel> GetAllOrders()          //Get all order
        {
            var result = new List<OrderViewModel>();

            foreach(var item in Context.GetAllOrders())
            {
                result.Add(new OrderViewModel
                {
                     Id = item.Id,
                     Type = item.Type,
                     Status = item.Status,
                     Quickly = item.Quickly,
                     PriceWill = item.PriceWill,
                     Prepayment = item.Prepayment,
                     Number = item.Number,
                     Deadline = item.Deadline,
                    Device = new DeviceViewModel
                    {
                        Id = item.Device.Id,
                        Type = item.Device.Type,
                        SerialNumber = item.Device.SerialNumber,
                        Model = item.Device.Model,
                        Equipment = item.Device.Equipment,
                        Defect = item.Device.Defect,
                        Brand = item.Device.Brand,
                        Appearance = item.Device.Appearance
                    },
                    Client = new ClientViewModel
                     {
                         Id=item.Client.Id,
                         Type=item.Client.Type,
                         Surname=item.Client.Surname,
                         Name=item.Client.Name,
                         Middlename=item.Client.Middlename,
                         TelNumber=item.Client.TelNumber,
                         Email=item.Client.Email,
                         Address=item.Client.Address,
                         Comment=item.Client.Comment
                     }
                });
            }

            return result;
        }

        public OrderViewModel GetOrder(string numberOrder)           //Get order by number
        {
            var order = Context.GetOrder(numberOrder);

            var result = new OrderViewModel
            {
                 Id = order.Id,
                 Type = order.Type,
                 Status = order.Status,
                 Quickly = order.Quickly,
                 PriceWill = order.PriceWill,
                 Prepayment = order.Prepayment,
                 Number = order.Number,
                 Deadline = order.Deadline,
                 Device = new DeviceViewModel
                 {
                     Id = order.Device.Id,
                     Type = order.Device.Type,
                     SerialNumber = order.Device.SerialNumber,
                     Model = order.Device.Model,
                     Appearance = order.Device.Appearance,
                     Brand = order.Device.Brand,
                     Defect = order.Device.Defect,
                     Equipment = order.Device.Equipment
                 },
                 Client = new ClientViewModel
                 {
                      Id = order.Client.Id,
                      Type = order.Client.Type,
                      Address = order.Client.Address,
                      Comment = order.Client.Comment,
                      Email = order.Client.Email,
                      Surname = order.Client.Surname,
                      Name = order.Client.Name,
                      Middlename = order.Client.Middlename,
                      TelNumber = order.Client.TelNumber
                 }
            };

            return result;
        }

        public void UpdateOrder(OrderViewModel order)           //Update order
        {
            Context.UpdateOrder(new Order
            {
                Id = order.Id,
                Type = order.Type,
                Status = order.Status,
                Quickly = order.Quickly,
                PriceWill = order.PriceWill,
                Prepayment = order.Prepayment,
                Number = order.Number,
                Deadline = order.Deadline,
                Device = new Device
                {
                    Id = order.Device.Id,
                    Type = order.Device.Type,
                    SerialNumber = order.Device.SerialNumber,
                    Model = order.Device.Model,
                    Appearance = order.Device.Appearance,
                    Brand = order.Device.Brand,
                    Defect = order.Device.Defect,
                    Equipment = order.Device.Equipment
                },
                Client = new Client
                {
                    Id = order.Client.Id,
                    Type = order.Client.Type,
                    Address = order.Client.Address,
                    Comment = order.Client.Comment,
                    Email = order.Client.Email,
                    Surname = order.Client.Surname,
                    Name = order.Client.Name,
                    Middlename = order.Client.Middlename,
                    TelNumber = order.Client.TelNumber
                }
            }); 
        }

        public void DeleteOrder(string numderOrder)         //Delete order
        {
            Context.DeleteOrder(numderOrder);
        }
    } 
}
