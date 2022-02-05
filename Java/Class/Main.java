

import java.lang.reflect.Array;
import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        System.out.println("Hard code constructor...");
        Rational f1 = new Rational(4, 3);
        System.out.println("f1: " + f1.toString());
        System.out.println("Parsing from string...");
        Rational f2 = Rational.parseFraction("-15/-9");
        System.out.println("f2: " + f2.toString());
        System.out.println("*****************************************************************");
        System.out.println("Checking simple math operations...");
        System.out.println("f1 + f2 = " + f1.add(f2));
        System.out.println("f1 - f2 = " + f1.subtract(f2));
        System.out.println("f1 * f2 = " + f1.multiply(f2));
        System.out.println("f1 / f2 = " + f1.divide(f2));

        System.out.println("foreach in fraction...");
        for(var i : f1) {
            System.out.println(i);
        }
        System.out.println("*****************************************************************");

        System.out.println("Array of fractions, [f1, f2, f3], sorted by numerator, foreach...");
        Rational[] fractions = new Rational[3];
        Rational f3 = new Rational(1, 4);
        fractions[0] = f2;
        fractions[1] = f1;
        fractions[2] = f3;
        Arrays.sort(fractions);
        for (var f : fractions){
            System.out.println("Fraction: " + f.toString());
        }
        System.out.println("*****************************************************************");
        System.out.println("Array of fractions, [f1, f2, f3], sorted by denominator, foreach...");
        Rational.setSortBy(Rational.FractionSortBy.denominator);
        Arrays.sort(fractions);
        for (var f : fractions) {
            System.out.println("Fraction " + f.toString());
        }

    }
}
