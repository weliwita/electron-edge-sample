namespace HelloWorld
{
    using System;
    using System.Threading.Tasks;
    public class Startup
    {
        public async Task<object> Invoke(int startingSalary)
        {
            var person = new Person(startingSalary);
            return new {
                getSalary = (Func<object,Task<object>>)(
                    async (i) => 
                    { 
                        return person.Salary; 
                    }
                ),
                giveRaise = (Func<object,Task<object>>)(
                    async (amount) => 
                    { 
                        person.GiveRaise((int)amount); 
                        return person.Salary;
                    }
                )
            };
        }
    }
    public class Person
    {
        public int Salary { get; private set; }
        public Person(int startingSalary)
        {
            this.Salary = startingSalary;
        }
        public void GiveRaise(int amount)
        {
            this.Salary += amount;
        }
    }
}
