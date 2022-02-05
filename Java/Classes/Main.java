
import java.io.*;
import java.util.Locale;

public class Main {



    static Locale createLocale( String[] args )	{
        if ( args.length == 2 ) {
            return new Locale( args[0], args[1] );
        } else if( args.length == 4 ) {
            return new Locale( args[2], args[3] );
        }
        return null;
    }

    static void setupConsole(String[] args) {
        if ( args.length >= 2 ) {
            if ( args[0].compareTo("-encoding")== 0 ) {
                try {
                    System.setOut( new PrintStream( System.out, true, args[1] ));
                } catch ( UnsupportedEncodingException ex ) {
                    System.err.println( "Unsupported encoding: " + args[1] );
                    System.exit(1);
                }
            }
        }
    }

    public static void main(String[] args) {

        setupConsole(args);
        if (args.length == 0) {
            Locale loc = createLocale(new String[]{"ru", "Ru"});
            AppLocale.set(loc);
        }
        else {
            Locale loc = createLocale(args);
            AppLocale.set(loc);
        }

        var pets = new Pet[4];
        pets[0] = new Dog("Johny", 7);
        pets[0].setInfo(AppLocale.getString(AppLocale.purebred_dog));

        pets[1] = new Cat("Tom", 3);
        pets[1].setInfo(AppLocale.getString(AppLocale.purebred_cat));

        pets[2] = new Parrot("Jack", 1);
        pets[2].setInfo(AppLocale.getString(AppLocale.rare_parrot));

        pets[3] = new Dog("Rex", 4);
        pets[3].setInfo(AppLocale.getString(AppLocale.war_dog));


       /* setupConsole( args );
        Locale loc = createLocale( args );
        if ( loc == null ) {
            System.err.println(
                    "Invalid argument(s)\n" +
                            "Syntax: [-encoding ENCODING_ID] language country\n" +
                            "Example: -encoding Cp855 be BY" );
            System.exit(1);
        }
        AppLocale.set( loc );
        Connector con = new Connector("pets.dat");

        Pet[] p;
        con.write(pets);
        p = con.read();
        System.out.println(
                AppLocale.getString( AppLocale.the_band ) + ":" );
        for ( Pet n : pets ) {
            System.out.println( n );
        }*/
        try {
            Connector con = new Connector("pets.dat.txt");
            con.write(pets);
            Pet[] p;
            p = con.read();

            for ( Pet pet : p ) {
                //System.out.println(pet.name);
                //System.out.println(pet.getCreationDate());
                System.out.println(pet);
            }
        }
        catch ( Exception e ) {
            System.err.println(e);
        }
    }

}
