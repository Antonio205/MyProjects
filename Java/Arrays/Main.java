import java.util.HashSet;
import java.util.Random;
import java.util.Scanner;

public class Main {


    public static int [][] removeRow(int [][] m , int n){

        int [][] finalm = new int [m.length-1][m[0].length];

        for (int i = 0; i<finalm.length; i++) {

            for (int j = 0; j<finalm[i].length; j++) {
                if (i<n) {
                    finalm[i][j]=m[i][j];
                }
                if (i>=n) {
                    finalm[i][j]=m[i+1][j];
                }
            }
        }

        return finalm;
    }

    public static int [][] removeColumn(int [][] m , int n){
        int [][] finalm = new int [m.length][m[0].length-1];

        for (int i = 0; i < finalm.length; i++) {
            for (int j = 0; j < finalm[i].length; j++) {
                if (i<n) {
                    finalm[i][j]=m[i][j];
                }
                if (i >= n) {
                    finalm[i][j]=m[i][j + 1];
                }
            }
        }

        return finalm;
    }

    public static void main(String[] args) {
        System.out.print("Enter matrix size, N: ");
        Scanner reader = new Scanner(System.in);
        int n;
        try {
            n = reader.nextInt();
            int[][] matrix = new int[n][n];

            Random rnd = new Random();

            rnd.setSeed( System.currentTimeMillis() );
            //random
            for(int row_index = 0; row_index < n; row_index++)
            {
                for(int column_index = 0; column_index < n; column_index++) {

                    matrix[row_index][column_index] =  (rnd.nextInt() % (n + 1));
                    var cell = matrix[row_index][column_index];
                }
            }
            //your enter
            /*for(int row_index = 0; row_index < n; row_index++)
            {
                for(int column_index = 0; column_index < n; column_index++) {
                    matrix[row_index][column_index] = reader.nextInt();
                }
            }*/

            System.out.println("Matrix is:");
            for(int row_index = 0; row_index < n; row_index++) {
                for (int column_index = 0; column_index < n; column_index++) {
                    var cell = matrix[row_index][column_index];
                    System.out.printf("%6d", cell);
                }
                System.out.println();
            }

            HashSet<Integer> zero_columns = new HashSet<>();
            HashSet<Integer> zero_rows = new HashSet<>();
            boolean is_columns = false;
            boolean is_rows = false;

            //for rows
            for(int  i = 0; i < matrix.length; ++i){
                for(int t = 0; t < matrix[i].length; ++t){
                    if(matrix[i][t] != 0){
                        is_rows = true;
                    }
                }
                if(is_rows == false){
                    zero_rows.add(i);
                }
                is_rows = false;
            }
            for(int i : zero_rows){
                matrix = removeRow(matrix, i);
            }

            //for columns
            for(int  i = 0; i < n; ++i){
                for(int t = 0; t < matrix.length; ++t){
                    if(matrix[t][i] != 0){
                        is_columns = true;
                    }
                }
                if(is_columns == false){

                    zero_columns.add(i);
                }
                is_columns = false;
            }

            for(int i : zero_columns){
                matrix = removeColumn(matrix, i);
            }


            System.out.println("New Matrix:");
            for(int row_index = 0; row_index < matrix.length; row_index++) {
                for (int column_index = 0; column_index < matrix[row_index].length; column_index++) {
                    var cell = matrix[row_index][column_index];
                    System.out.printf("%6d", cell);
                }
                System.out.println();
            }


        }
        catch (Exception ex){
            //System.out.println("Invalid input! Matrix size must be positive integer!");
            System.out.println(ex.toString());
        }
    }
}