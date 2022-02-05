
import java.io.IOException;
import java.io.PrintStream;
import java.io.Serializable;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.Scanner;

public class Employee implements Serializable {
    String tabel_num;
    static final String P_tabel_num= "Tabel number:";
    String department_num;
    static final String P_department_num= "Department number:";
    String name;
    static final String P_name = "Name:";
    String salary;
    static final String P_salary = "Salary:";
    String admission;
    static final String P_admission = "Admission:";
    String allowance_percent;
    static final String P_allowance_percent = "Allowance percent:";
    String income_tax;
    static final String P_income_tax = "Income tax:";


    private static GregorianCalendar curCalendar = new GregorianCalendar();

    public static Boolean nextRead( Scanner fin, PrintStream out ) {
        return nextRead( P_tabel_num, fin, out );
    }

    public static Boolean validNumbers(String str){
        String regex = "\\d+";
        return str.matches(regex);

    }

    public static Boolean validPercent(String str){
        String regex = "^((0|((\\d?\\d?)?)|100))";
        return str.matches(regex);
    }

    static Boolean nextRead( final String prompt, Scanner fin, PrintStream out ) {
        out.print( prompt );
        //out.print( ": " );
        return fin.hasNextLine();
    }

    public static boolean isNumeric(String str) {
        try {
            Double.parseDouble(str);
            return true;
        } catch(NumberFormatException e){
            return false;
        }
    }

    public static boolean isValidDate(String inDate) {
        SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
        dateFormat.setLenient(false);
        try {
            dateFormat.parse(inDate.trim());
        } catch (ParseException pe) {
            return false;
        }
        return true;
    }

    public static final String departmentDel = ",";
    public static Employee read( Scanner fin, PrintStream out )
            throws IOException {
        Employee emp = new Employee();
        emp.tabel_num = fin.nextLine();
       if ( !validNumbers( emp.tabel_num ) ) {
            throw new IOException("");
        }
        if ( ! nextRead( P_department_num, fin, out )) return null;
        emp.department_num = fin.nextLine();
        if ( !validNumbers( emp.department_num ) ) {
            throw new IOException("");
        }
        if ( ! nextRead( P_name, fin, out )) return null;
        emp.name = fin.nextLine();
        if ( ! nextRead( P_salary, fin, out )) return null;
        emp.salary = fin.nextLine();
        if ( !isNumeric( emp.salary ) ) {
            throw new IOException("");
        }
        if ( ! nextRead( P_admission, fin, out )) return null;
        emp.admission = fin.nextLine();
        if ( !isValidDate( emp.admission ) ) {
            throw new IOException("");
        }
        if ( ! nextRead( P_allowance_percent, fin, out )) return null;
        emp.allowance_percent = fin.nextLine();
        if ( !validPercent( emp.allowance_percent ) ) {
            throw new IOException("");
        }
        if ( ! nextRead( P_income_tax, fin, out )) return null;
        emp.income_tax = fin.nextLine();
        if ( !isNumeric( emp.income_tax ) ) {
            throw new IOException("");
        }
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


