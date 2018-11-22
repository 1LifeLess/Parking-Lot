﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;

namespace Parking
{
    public class SQLiteDataAccess
    {
        public static List<ParkingCarsModel> LoadParkingCars()
        {
           
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var res = cnn.Query("select * from ParkingCars", new DynamicParameters()).Select(row => new ParkingCarsModel((int)row.CarId,(int)row.PaymentAmount,(int)row.ParkingPlaceId,row.ParkingDate,row.DroveAwayDate)).ToList();
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
                        @"INSERT INTO ParkingCars(ParkingDate,CarId,PaymentAmount,ParkingPlaceId,DroveAwayDate) VALUES (@ParkingDate,@CarId,@PaymentAmount,@ParkingPlaceId,@DroveAwayDate)", car);


            }
           
        }


        public static void LeaveParkingLot(int CarId,string LeaveDate)
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var res = cnn.Execute(@"UPDATE ParkingCars
                                        SET DroveAwayDate = @leave
                                        WHERE CarId = @CarPlate AND DroveAwayDate IS NULL", new{CarPlate=CarId, leave = LeaveDate});


            }
        }
       /* public static void AffectAll(int isEmpty)
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var res = cnn.Execute(@"UPDATE ParkingPlace 
                                        SET isEmpty = @A", new {  A = isEmpty });


            }
        }*/
        public static void Reset()
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var res = cnn.Execute("DELETE FROM ParkingCars;");
                var res2 = cnn.Execute("UPDATE ParkingPlace set isEmpty=1;");

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
