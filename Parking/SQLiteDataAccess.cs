using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Parking
{
    public class SQLiteDataAccess
    {
        public static List<ParkingCarsModel> LoadParkingCars()
        {
           
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var res = cnn.Query("select * from ParkingCars", new DynamicParameters()).Select(row => new ParkingCarsModel((int)row.CarId,(int)row.PaymentAmount,(int)row.ParkingPlaceId,row.ParkingDate)).ToList();
                return res;

            }  
        }

        public static List<CarModel> LoadCars()
        {
           
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var res = cnn.Query("select * from Cars", new DynamicParameters()).Select(row => new CarModel((int)row.ID,(int)row.HasMembership)).ToList();
                return res;

            }
        }

        public static List<ParkingPlaceModel> LoadParkingPlace()
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var res = cnn.Query<ParkingPlaceModel>("select * from ParkingPlace", new DynamicParameters()).ToList();
                return res;

            }
        }

        public static void EnterParkingLot(ParkingCarsModel car)
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var res =
                    cnn.Execute(
                        @"INSERT INTO ParkingCars(ParkingDate,CarId,PaymentAmount,ParkingPlaceId) VALUES (@date,@CarId,@PaymentAmount,@ParkingPlaceId)",car);


            }
            UpdateParkingOccupation(car.ParkingPlaceId, Parking.Form1.pAction.Take);
        }


        public static void UpdateParkingOccupation(int parkingId, Parking.Form1.pAction A)
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var res = cnn.Execute(@"UPDATE ParkingPlace 
                                        SET isEmpty = @A
                                        WHERE ID = @Id", new{id=parkingId,A=(int)A});


            }
        }
        public static void AffectAll(int isEmpty)
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var res = cnn.Execute(@"UPDATE ParkingPlace 
                                        SET isEmpty = @A", new {  A = isEmpty });


            }
        }
        public static void Reset()
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var res = cnn.Execute("DELETE FROM ParkingCars;");


            }
        }
        
        public static bool TestConn()
        {
            
            try
            {
                using (var conn = new SQLiteConnection(LoadConnectionString()))
                {
                   conn.Open(); 
                return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static string LoadConnectionString(string id="Main")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
