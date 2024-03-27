using System;

namespace SomerenModel
{
    public class Student
    {
        public int StudentNumber { get; set; }      // database id
        public string Class { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }   
        public int RoomNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}