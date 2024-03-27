using SomerenService;
using SomerenModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using SomerenDAL;

//Test comment for git
//New test

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
            ShowDashboardPanel();
        }


        private void ShowDashboardPanel()
        {
            // hide all other panels
            pnlStudents.Hide();
            pnlDrinks.Hide();
            pnlLecturers.Hide();
            pnlRooms.Hide();

            // show dashboard
            pnlDashboard.Show();
        }

        // Show Drinks
        private void ShowDrinksPanel()
        {
            // hide all other panels
            pnlDashboard.Hide();
            pnlStudents.Hide();
            pnlLecturers.Hide();
            pnlRooms.Hide();

            //show drinks
            pnlDrinks.Show();

            try
            {
                // get and display all drinks
                List<Drink> drinks = GetDrinks();
                DisplayDrinks(drinks);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the drinks: " + e.Message);
            }
        }
        private List<Drink> GetDrinks()
        {
            DrinkService drinkService = new DrinkService();
            List<Drink> drinks = drinkService.GetDrinks();
            return drinks;
        }

        public int idCount;

        private void DisplayDrinks(List<Drink> drinks)
        {
            // clear the listview, combobox and textboxes before filling it
            listViewDrinks.Items.Clear();
            selectDrink.Items.Clear();
            selectDrink2.Items.Clear();
            outResult.Text = "/";
            selectDrink.Text = "-- Choose Drink --";
            selectDrink2.Text = "-- Choose Drink --";
            selectAttribute.Text = "-- Choose Attribute --";
            inpNewValue.Text = "";
            inpNewDrinkName.Text = "";
            inpNewDrinkIsAlcoholic.Text = "Is Alcoholic?";
            inpNewDrinkStock.Text = "";
            inpNewDrinkPrice.Text = "";

            idCount = drinks.Count;

            foreach (Drink drink in drinks)
            {
                //add items to listview
                ListViewItem li = new ListViewItem(drink.DrinkType.ToString());
                li.SubItems.Add(drink.IsAlcoholic.ToString());

                //Check Stock amount to display corresponding message
                if (drink.Stock == 0)
                {
                    li.SubItems.Add("stock empty");
                }
                else if (drink.Stock < 10)
                {
                    li.SubItems.Add("stock nearly depleted");
                }
                else
                {
                    li.SubItems.Add("stock sufficient");
                }

                //add rest of items to listview
                li.SubItems.Add(drink.Price.ToString("0.00") + " €");

                //add delete button

                li.Tag = drink;   // link drink object to listview item
                listViewDrinks.Items.Add(li);


                //add items to combobox
                selectDrink.Items.Add(drink.DrinkType);
                selectDrink2.Items.Add(drink.DrinkType);

            }
        }


        // Show Students
        private void ShowStudentsPanel()
        {
            // hide all other panels
            pnlDashboard.Hide();
            pnlDrinks.Hide();
            pnlLecturers.Hide();
            pnlRooms.Hide();

            // show students
            pnlStudents.Show();

            try
            {
                // get and display all students
                List<Student> students = GetStudents();
                DisplayStudents(students);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);
            }
        }

        private List<Student> GetStudents()
        {
            StudentService studentService = new StudentService();
            List<Student> students = studentService.GetStudents();
            return students;
        }

        private void DisplayStudents(List<Student> students)
        {
            // clear the listview before filling it
            listViewStudents.Items.Clear();

            foreach (Student student in students)
            {
                ListViewItem li = new ListViewItem(student.StudentNumber.ToString());
                li.SubItems.Add(student.Class.ToString());
                li.SubItems.Add(student.FirstName.ToString());
                li.SubItems.Add(student.LastName.ToString());
                li.SubItems.Add(student.PhoneNumber.ToString());
                li.SubItems.Add(student.RoomNumber.ToString());
                li.Tag = student;   // link student object to listview item
                listViewStudents.Items.Add(li);
            }
        }


        // Show Lecturers
        private void ShowLecturersPanel()
        {
            // hide all other panels

            pnlDashboard.Hide();
            pnlStudents.Hide();
            pnlDrinks.Hide();
            pnlRooms.Hide();

            // show lecturer panel

            pnlLecturers.Show();

            try
            {
                // get and display all lecturers
                List<Lecturer> lecturers = GetLecturers();
                DisplayLecturers(lecturers);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the lecturers: " + e.Message);
            }
        }

        private List<Lecturer> GetLecturers()
        {
            LecturerService lecturerService = new LecturerService();
            List<Lecturer> lecturers = lecturerService.GetLecturers();
            return lecturers;
        }

        private void DisplayLecturers(List<Lecturer> lecturers)
        {
            // clear the listview before filling it
            listViewLecturers.Items.Clear();

            foreach (Lecturer lecturer in lecturers)
            {
                ListViewItem li = new ListViewItem(lecturer.FirstName.ToString());
                li.SubItems.Add(lecturer.LastName.ToString());
                li.SubItems.Add(lecturer.PhoneNumber.ToString());

                //Convert birthdate to age

                int age = DateTime.Now.Year - lecturer.Birthdate.Year;

                if (lecturer.Birthdate.AddYears(age) > DateTime.Today)
                {
                    age--;
                }

                li.SubItems.Add(age.ToString());

                li.Tag = lecturer;   // link student object to listview item
                listViewLecturers.Items.Add(li);
            }

        }


        // Show Rooms
        private void ShowRoomsPanel()
        {
            // hide all other panels

            pnlDashboard.Hide();
            pnlStudents.Hide();
            pnlDrinks.Hide();
            pnlLecturers.Hide();

            // show rooms panel

            pnlRooms.Show();

            try
            {
                // get and display all rooms
                List<Room> rooms = GetRooms();
                DisplayRooms(rooms);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the rooms: " + e.Message);
            }
        }

        private List<Room> GetRooms()
        {
            RoomService roomService = new();
            return roomService.GetRooms();
        }

        private void DisplayRooms(List<Room> rooms)
        {
            // clear the listview before filling it
            listViewRooms.Items.Clear();

            foreach (Room room in rooms)
            {
                ListViewItem li = new ListViewItem(room.RoomNumber.ToString());
                li.SubItems.Add(room.NumberOfBeds.ToString());
                li.SubItems.Add(room.BuildingID.ToString());

                li.Tag = room;   // link room object to listview item
                listViewRooms.Items.Add(li);
            }

        }


        private void dashboardToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            ShowDashboardPanel();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStudentsPanel();
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLecturersPanel();
        }

        private void drinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDrinksPanel();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRoomsPanel();
        }

        //Button to update drink values
        private void btnChangeDrink_Click(object sender, EventArgs e)
        {
            //Call method
            DrinkDao dao = new DrinkDao();

            string drink = selectDrink.Text;
            string attribute = selectAttribute.Text;
            string value = inpNewValue.Text;

            outResult.Text = dao.ChangeDrinkValue(drink, attribute, value);

            if (outResult.Text == "Update successful")
            {
                selectDrink.Text = "-- Choose Drink --";
                selectAttribute.Text = "-- Choose Attribute --";
                inpNewValue.Text = "";
            }


        }

        private void btnNewDrink_Click(object sender, EventArgs e)
        {

            DrinkDao dao = new DrinkDao();

            string drinkName = inpNewDrinkName.Text;

            bool isAlcoholic;

            if (inpNewDrinkIsAlcoholic.Text == "Yes")
            {
                isAlcoholic = true;
            }
            else
            {
                isAlcoholic = false;
            }

            int stock = int.Parse(inpNewDrinkStock.Text);

            decimal price = decimal.Parse(inpNewDrinkPrice.Text);

            outResult.Text = dao.AddNewDrink(drinkName, isAlcoholic, stock, price, idCount);

            if (outResult.Text == "Insert successful")
            {
                inpNewDrinkName.Text = "";
                inpNewDrinkIsAlcoholic.Text = "Is Alcoholic?";
                inpNewDrinkStock.Text = "";
                inpNewDrinkPrice.Text = "";
            }
        }

        private void btnDeleteDrink_Click(object sender, EventArgs e)
        {
            DrinkDao dao = new DrinkDao();

            string drink = selectDrink2.Text;

            outResult.Text = dao.DeleteDrink(drink);
        }
    }
}