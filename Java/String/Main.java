import java.lang.Object;
import java.util.Scanner;
import java.io.File;
import        javax.script.ScriptEngineManager;
import javax.script.ScriptEngine;
import javax.script.ScriptException;
import java.io.*;
class Main {
    public static void main(String[] args) throws IOException, ScriptException {
// int i,x,n;
        var file = new File("input.txt");

        try (Scanner reader = new Scanner(file)) {
            while (reader.hasNext()) {
                String next_string = reader.nextLine();
                ScriptEngineManager manager = new ScriptEngineManager();
                ScriptEngine engine = manager.getEngineByName("js");
                Object result = engine.eval(next_string);
                System.out.println(result);
            }
        }
        catch (FileNotFoundException | ScriptException e) {
            e.printStackTrace();


        }
    }
}