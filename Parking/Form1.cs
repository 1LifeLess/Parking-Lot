﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Parking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateView();
 
        }

    

        public static List<ParkingPlaceModel> parkingPlaceData;
        public static List<ParkingCarsModel> ParkingCarsData;
       public   enum pAction
        {
           
            Take=0,
         Free=1
        }
        
        public void UpdateView()
        {

     
           parkingPlaceData = SQLiteDataAccess.LoadParkingPlace();
           ParkingCarsData = SQLiteDataAccess.LoadParkingCars();
            dataGridView1.Rows[0].Cells[1].Value = ParkingPlaceModel.nextAvailable(parkingPlaceData);
            var space = ParkingPlaceModel.spaceLeft(parkingPlaceData);
            dataGridView1.Rows[0].Cells[0].Value = space;
            dataGridView1.Rows[0].Cells[2].Value = ParkingCarsModel.TotalRevenue(ParkingCarsData);
            dataGridView1.Rows[0].Cells[3].Value = ParkingCarsModel.Last30Days(ParkingCarsData);
            if (space == 0)
            {
                label1.Visible = true;
                label1.Text = "Parking Lot is Full";
                label1.ForeColor = Color.DarkRed;
                
            }
            else if (space == 100)
            {
                label1.Visible = true;
                label1.Text = "Parking Lot is Empty";
                label1.ForeColor = Color.DarkGreen;
            }
        }

        private void CarIn_Click(object sender, EventArgs e)
        {
             int userCarId = 0;
            try
            {
                userCarId = int.Parse(carId.Text);
            }
            catch
            {
                return;
            }
            //Check if the car is already at the parking lot
            var alreadyExists =
                ParkingCarsData.Where(x => x.CarId == userCarId && String.IsNullOrEmpty(x.DroveAwayDate) == true).ToList();

            if (alreadyExists.Count > 0)
            {
                //var obj = alreadyExists[0]; 
                MessageBox.Show(userCarId + " is already parking at the parking place: " + alreadyExists[0].ParkingPlaceId + ".", "Error - Invalid Action",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var duplicate = ParkingCarsData.Any(x => x.ParkingDate == GetDay() && userCarId == x.CarId);

            if (duplicate==true)
            {
                //var obj = alreadyExists[0]; 
                MessageBox.Show("This car plate is already register for that date: a car can park only once per date.", "Error - Logic out of boundary",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                   // .Select(x => x.ParkingPlaceId).Take(1);
          
            //int userCarId= int.Parse(carId.Text);
            
           
            //Checks if carId has memberShip on Cars Table
            var res = SQLiteDataAccess.LoadCars();
            var isMember = res.Any(x => x.ID == userCarId && x.HasMembership == 1);

            //checks if the month on the user date picker is one of winter's months
            var isWinter = new[] { 12, 1, 2, 3 }.Contains(dateTimePicker1.Value.Month);
            var pay = isWinter == true || isMember == true ? 20 : 40;
           
           
            //Creates an obj row to insert to DB
            var carEnters = new ParkingCarsModel(userCarId, pay, ParkingPlaceModel.nextAvailable(parkingPlaceData), GetDay());
            SQLiteDataAccess.EnterParkingLot(carEnters);
            UpdateView();  
        }

        private void CarOut_Click(object sender, EventArgs e)
        {
            //var test = ParkingCarsData.Where(x => x.CarId == 123).ToList();
            var CarId = 0;
            try
            {
                CarId = int.Parse(CarLeavesBox.Text);
            }
            catch
            {
                return;
            }
            var rows = ParkingCarsData.Where(x => x.CarId == CarId && String.IsNullOrEmpty(x.DroveAwayDate)==true).ToList();
            if (rows.Count == 0)
            {
                MessageBox.Show("There is no such a car in the Parking lot", "Error - Data doesn't exist",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                var inDate = DateTime.ParseExact(rows[0].ParkingDate, "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
            if (inDate > dateTimePicker1.Value)
            {
                MessageBox.Show("A car can't leave on a date which is earlier than: " + inDate + ".", "Error - Invalid Action",
   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }
           // var latestActivity = CarIdRows.Where(x => String.IsNullOrEmpty(x.DroveAwayDate) == true).ToList();

            SQLiteDataAccess.LeaveParkingLot(rows[0].CarId, GetDay());
            UpdateView();
        }

      
        //Clear form TextBox placeHolders upon Click Event
        public void ClearText(object sender, EventArgs e)
        {
            var txt = (TextBox) sender;
            txt.Text = "";
        }

        //Converts Date to DD/MM/YYYY text which is SQLite date convention and type   
        public string GetDay()
        {
            var userDateTime = (dateTimePicker1.Value); //DD/MM/YYYY
            var day = String.Format("{0:dd}/{0:MM}/{0:yyyy}", userDateTime);
            return day;
        }

        private void btnParkId_Click(object sender, EventArgs e)
        {
           
            lvParkId.Items.Clear();
            lvParkId.ForeColor = lvParkId.ForeColor ==Color.DodgerBlue ? Color.DarkOliveGreen : Color.DodgerBlue;
            var parkObj = parkingPlaceData.Where(x => x.ID == int.Parse(ParkId.Text)).ToList();
            var status = parkObj[0].IsEmpty==1 ? "Free" : "Occupied";
            var floor = parkObj[0].Floor.ToString();
            string[] row = { status, floor };
            var listViewItem = new ListViewItem(row);
            //listViewItem.SubItems.Add("1");
            lvParkId.Items.Add(listViewItem);
       
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
             SQLiteDataAccess.AffectAll(0);
             UpdateView();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SQLiteDataAccess.AffectAll(1);
            UpdateView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SQLiteDataAccess.Reset();
            UpdateView();
        }
    }
}
