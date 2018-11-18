using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class ParkingCarsModel
    {
        public int CarId { get; set; }
        public int PaymentAmount { get; set; }
        public int ParkingPlaceId { get; set; }
        public string date { get; set; }
        public DateTime MyDate { get; set; }

        public ParkingCarsModel(int _id,int _money,int _parkid,string _date)
        {
            CarId = _id;
            PaymentAmount = _money;
            ParkingPlaceId = _parkid;
            date = _date;
            MyDate = DateTime.Now;
        }
       
        public DateTime getDate()
        {
            return Convert.ToDateTime(date);
        }

        public static int TotalRevenue(List<ParkingCarsModel> list)
        {
              
           var res = list.Sum(x => x.PaymentAmount);
           return res;
            
        }

        public static int Last30Days(List<ParkingCarsModel> list)
        {
            var test = list.Select(x => x.date).ToList();
            var res = list.Where(x => DateTime.ParseExact(x.date, "dd/MM/yyyy", CultureInfo.InvariantCulture) >= DateTime.Today.AddDays(-30)).Sum(x=> x.PaymentAmount);
          // var test = DateTime.ParseExact(x.date, "dd/MM/yy", CultureInfo.InvariantCulture);
            return res;

        }

    }
}
