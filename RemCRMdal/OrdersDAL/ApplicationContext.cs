using RemCRMdal.OrdersDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMdal.AplicationDAL
{
    public partial class ApplicationContext : DbContext
    {
        public void AddOrder(Order order)                                           //Adding order
        {
            using (var db = new ApplicationContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public List<Order> GetAllOrders()                                           //Get all orders
        {
            var result = new List<Order>();
            
            using (var db = new ApplicationContext())
            {
                result = db.Orders.Include("Client").Include("Device").ToList();
            }

            return result;
        }

        public Order GetOrder(string numberOrder)                                        //Get order by number
        {
            var result = new Order();

            using (var db = new ApplicationContext())
            {
                result = db.Orders.Where(x => x.Number == numberOrder).Include("Client").Include("Device").Single();
            }

            return result;
        }

        public void UpdateOrder(Order order)                                        //Update order
        {
            var _order = new Order();
            using (var db = new ApplicationContext())
            {
                _order = db.Orders.Where(x => x.Number == order.Number).Include("Client").Include("Device").Single();

                if (_order != null)
                {
                    _order.Type = order.Type;
                    _order.Status = order.Status;
                    _order.PriceWill = order.PriceWill;
                    _order.Prepayment = order.Prepayment;
                    _order.Deadline = order.Deadline;

                    _order.Client.Surname = order.Client.Surname;
                    _order.Client.Name = order.Client.Name;
                    _order.Client.Middlename = order.Client.Middlename;
                    _order.Client.TelNumber = order.Client.TelNumber;
                    _order.Client.Type = order.Client.Type;
                    _order.Client.Address = order.Client.Address;
                    _order.Client.Comment = order.Client.Comment;
                    _order.Client.Email = order.Client.Email;

                    _order.Device.Type = order.Client.Type;
                    _order.Device.SerialNumber = order.Device.SerialNumber;
                    _order.Device.Model = order.Device.Model;
                    _order.Device.Equipment = order.Device.Equipment;
                    _order.Device.Defect = order.Device.Defect;
                    _order.Device.Brand = order.Device.Brand;
                    _order.Device.Appearance = order.Device.Appearance;

                    db.Entry(_order).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteOrder(string numberOrder)
        {
            using (var db=new ApplicationContext())
            {
                var delOrder = db.Orders.Where(x => x.Number == numberOrder).Include("Client").Include("Device").Single();
                if(delOrder!=null) db.Orders.Remove(delOrder);
                db.SaveChanges();
            }
        }
    }
}
