package z_4;

public class Main {

    public static void main(String[] args) {
	// write your code here
        NonLinearEquation eq = new NonLinearEquation(args[0]);

        System.out.println(eq.getSolution(Double.parseDouble(args[1]), Double.parseDouble(args[2])));

    }
}
