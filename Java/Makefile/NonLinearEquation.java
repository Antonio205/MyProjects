package z_4;

import java.util.ArrayList;
import java.util.List;

class NonLinearEquation {
    private int[] powers;
    private int[] odds;


    NonLinearEquation(String equation){
        equation = equation.substring(0, equation.indexOf('='));
        //String[] val = equation.split("\\dx\\^|\\+\\dx\\^|-\\dx\\^");
        //String[] tokens = equation.split("x\\^\\d\\s*");
        var tokens = equation.split("\\+");

        ArrayList<String> new_tokens = new ArrayList<String>(tokens.length);
         int j = 0;
        for(int i = 0; i < tokens.length; i++){
            if(tokens[i].contains("-")){
                var nt = tokens[i].split("-");
                new_tokens.add(nt[0]);
                new_tokens.add("-" + nt[1]);
            }
            else new_tokens.add(tokens[i]);


        }

        powers = new int[new_tokens.size()];
        odds = new int[new_tokens.size()];
        int i = 0;
        for (var token: new_tokens) {
            String[] pair;
            var flag = false;
            if(token.contains("-")){
                flag = true;
                token = token.substring(1, token.length());
            }

            if(token.matches("\\dx\\^\\d|x\\^\\d|\\dx|x|-x")) {
                pair = token.split("x\\^|x");
                if(pair[0].length() != 0)
                    odds[i] = Integer.parseInt(pair[0]);
                else odds[i] = 1;

                if(pair.length > 1)
                    powers[i] = Integer.parseInt(pair[1]);
                else powers[i] = 1;
                if(flag)
                    odds[i] *= -1;
                i++;
            }
            else{
                odds[i] = Integer.parseInt(token);
                powers[i] = 0;
                i++;
            }
        }
    }
    private double calculate(double x){
        double answer = 0;
        for(int i = 0; i < odds.length; i++)
            answer += odds[i] * Math.pow(x, powers[i]);
        return answer;
    }
    double getSolution(double segment_start, double segment_end) {
        assert segment_start <= segment_end: "Invalid interval!. Segment start < segment end.";

        var a = segment_start;
        var b = segment_end;
        if(calculate(a) == 0)
            return a;
        if(calculate(b) == 0)
            return b;
        if(Math.signum(calculate(a)) != Math.signum(calculate(b)))
            while(true){
                var c = (a + b) / 2;
                var function_value = calculate(c);
                if(Math.abs(function_value) > 1.0E-8){
                    if(Math.signum(function_value) == Math.signum(a))
                        a = c;
                    else b = c;
                }
                else return c;
            }
        else throw new ArithmeticException("Invalid interval. Value on intervals ends must be opposite!");
    }


}
