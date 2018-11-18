using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class CarModel
    {
        public int ID { get; set; }
        public int HasMembership { get; set; }

        public CarModel(int _id,int _isMember)
        {
            ID = _id;
            HasMembership = _isMember;
        }
    }
}
