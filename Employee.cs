/*
* Name: Wai Lit Yeung 
* Program: Business Information Technology
* Course: ADEV-3009 Data Structure and Algorithms
* Created: 10 Sept 2023
* Updated:
*
*/
namespace TestLibrary
{
    public class Employee : IComparable<Employee>
    {
        int employeeID;
        string? firstName = null;
        string? lastName = null;

        /// <summary>
        /// EmployeeID
        /// </summary>
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        /// <summary>
        /// FirstName
        /// </summary>
        public string? FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        /// <summary>
        /// LastName
        /// </summary>
        public string? LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        /// <summary>
        /// Employee Constructor with 3 parameters
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public Employee(int employeeID, string? firstName = null, string? lastName = null)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        /// <summary>
        /// CompareTo
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Employee? other) => other == null ? 1 : this.employeeID.CompareTo(other.employeeID);


        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{EmployeeID} {FirstName ?? "null"} {LastName ?? "null"}";
        //{
        //    return this.employeeID.ToString() + " " + (this.firstName == null ? "null" : this.firstName) + " " + (this.lastName == null ? "null" : this.lastName);
        //}

    }
}
