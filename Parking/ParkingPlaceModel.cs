using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
   public class ParkingPlaceModel
    {
        public int ID { get; set; }
        public int IsEmpty { get; set; }
        public int Floor { get; set; }

       public static int spaceLeft(List<ParkingPlaceModel> list)
       {
           var res = list.Count(x => x.IsEmpty == 1);
           
           return res;

       }

       public static int nextAvailable(List<ParkingPlaceModel> list)
       {
           
           var res = list.Where(x => x.IsEmpty == 1).ToList();
           return res.Count>0?res[0].ID:-1;


       }



    }

}
