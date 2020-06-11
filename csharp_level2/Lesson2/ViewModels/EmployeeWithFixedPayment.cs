namespace Lesson2.ViewModels
{
    public class EmployeeWithFixedPayment : Employee
    {
        public EmployeeWithFixedPayment(string fio, int fixedPayment) : base(fio)
        {
            FixedPayment = fixedPayment;
        }
        public int FixedPayment { get; set; }
        public override double CalculateSalary()
        {
            return FixedPayment;
        }
    }
}