using System;
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
            try
            {
                int.Parse(carId.Text);
            }
            catch
            {
                return;
            }
            var userDateTime = (dateTimePicker1.Value); //DD/MM/YYYY
            var day = String.Format("{0:dd}/{0:MM}/{0:yyyy}", userDateTime);
            int userCarId= int.Parse(carId.Text);
           var duplicate = ParkingCarsData.Where(x => x.date == day && userCarId == x.CarId).ToList();
            if (duplicate.Count > 0)
            {
                MessageBox.Show(userCarId + " is already registered for that action for that date \r\n a combination of CarId and Date must be unique", "Error - Data isn't unique",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var res = SQLiteDataAccess.LoadCars();
            var isMember = res.Any(x => x.ID == userCarId && x.HasMembership == 1);
            var isWinter = new[] { 12, 1, 2, 3 }.Contains(userDateTime.Month);
            var pay = isWinter == true || isMember == true ? 20 : 40;
           
           

            var carEnters = new ParkingCarsModel(userCarId, pay, ParkingPlaceModel.nextAvailable(parkingPlaceData), day);
            SQLiteDataAccess.EnterParkingLot(carEnters);
            UpdateView();  
        }

        private void CarOut_Click(object sender, EventArgs e)
        {
            //var test = ParkingCarsData.Where(x => x.CarId == 123).ToList();
            try
            {
                int.Parse(CarLeavesBox.Text);
            }
            catch
            {
                return;
            }
            var parkingid = ParkingCarsData.Where(x => x.CarId == int.Parse(CarLeavesBox.Text)).ToList();
            if (parkingid.Count == 0)
            {
                MessageBox.Show("There is no such a car in the Parking lot", "Error - Data doesn't exist",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var placeId = parkingid[parkingid.Count-1].ParkingPlaceId;
            SQLiteDataAccess.UpdateParkingOccupation(placeId,pAction.Free);
            UpdateView();
        }

      

        public void emptyText(object sender, EventArgs e)
        {
            var txt = (TextBox) sender;
            txt.Text = "";
        }

        private void btnParkId_Click(object sender, EventArgs e)
        {
            try
            {
                int.Parse(CarLeavesBox.Text);
            }
            catch
            {
                return;
            }
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
