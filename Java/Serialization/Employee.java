
import java.io.Serializable;
import java.util.Date;
import java.util.Scanner;

public class Employee implements Serializable {
    String tabel_num;
    String department_num;
    String name;
    String salary;
    String admission;
    String allowance_percent;
    String income_tax;

    public static Employee read( Scanner fin ) {
        Employee emp = new Employee();
        emp.tabel_num = fin.nextLine();
        if ( ! fin.hasNextLine()) return null;
        emp.department_num = fin.nextLine();
        if ( ! fin.hasNextLine()) return null;
        emp.name = fin.nextLine();
        if ( ! fin.hasNextLine()) return null;
        emp.salary = fin.nextLine();
        if ( ! fin.hasNextLine()) return null;
        emp.admission = fin.nextLine();
        if ( ! fin.hasNextLine()) return null;
        emp.allowance_percent = fin.nextLine();
        if ( ! fin.hasNextLine()) return null;
        emp.income_tax = fin.nextLine();
        return emp;
    }

    public Employee() {
    }

    public String toString() {
        return new String (
                tabel_num + "|" +
                        department_num + "|" +
                        name + "|" +
                        salary + "|" +
                        admission + "|" +
                        allowance_percent + "|" +
                        income_tax
        );
    }
}


