class Employee {
    private String Name;
    private String Job;
    private int Salary;

    public Employee() { }

    public Employee(String Name, String Job, int Salary)
    {

        this.Name = Name;
        this.Job = Job;
        this.Salary = Salary;

    }

    public void setName(String Name) { this.Name = Name; }
    public void setJob(String Job) { this.Job = Job; }
    public void setSalary(int Salary) { this.Salary = Salary; }

    public String getName() { return Name; }
    public String getJob() { return Job; }
    public int getSalary() { return Salary; }

    public int compare(Employee e1, Employee e2) {
        return e1.getSalary() - e2.getSalary();
    }
}
