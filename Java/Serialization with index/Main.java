import java.io.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.Date;
import java.util.Scanner;

public class Main {

    public static void main(String[] args){
        try {
            if ( args.length >= 1 ) {
                if ( args[0].equals("-?") || args[0].equals("-h")) {
                    System.out.println(
                            "Syntax:\n" +
                                    "\t-a  [file [encoding]] - append data\n" +
                                    "\t-az [file [encoding]] - append data, compress every record\n" +
                                    "\t-d                    - clear all data\n" +
                                    "\t-dk  {d|n|a} key      - clear data by key\n" +
                                    "\t-p                    - print data unsorted\n" +
                                    "\t-ps  {d|n|a}          - print data sorted by isbn/author/name\n" +
                                    "\t-psr {d|n|a}          - print data reverse sorted by isbn/author/name\n" +
                                    "\t-f   {d|n|a} key      - find record by key\n"+
                                    "\t-fr  {d|n|a} key      - find records > key\n"+
                                    "\t-fl  {d|n|a} key      - find records < key\n"+
                                    "\t-?, -h                - command line syntax\n"
                    );
                }
                else if ( args[0].equals( "-a" )) {
                    // Append file with new object from System.in
                    // -a [file [encoding]]
                    appendFile( args, false );
                }
                else if ( args[0].equals( "-az" )) {
                    // Append file with compressed new object from System.in
                    // -az [file [encoding]]
                    appendFile( args, true );
                }
                else if ( args[0].equals( "-p" )) {
                    // Prints data file
                    printFile();
                }
                else if ( args[0].equals( "-ps" )) {
                    // Prints data file sorted by key
                    if ( !printFile( args, false ) ) {
                        System.exit(1);
                    }
                    // printFile(args,false);

                }
                else if ( args[0].equals( "-psr" )) {
                    // Prints data file reverse-sorted by key
                    if ( !printFile( args, true ) ) {
                        System.exit(1);
                    }
                    //printFile(args,true);
                }
                else if ( args[0].equals( "-d" )) {
                    // delete files
                    if ( args.length != 1 ) {
                        System.err.println("Invalid number of arguments");
                        System.exit(1);;
                    }
                    deleteFile();
                }
                else if ( args[0].equals( "-dk" )) {
                    // Delete records by key
                    if ( !deleteFile( args ) ) {
                        System.exit(1);
                    }
                    // deleteFile( args );
                }
                else if ( args[0].equals( "-f" )) {
                    // Find record(s) by key
                    if ( !findByKey( args )) {
                        System.exit(1);
                    }
                    //findByKey(args);
                }
                else if ( args[0].equals( "-fr" )) {
                    // Find record(s) by key large then key
                    if ( !findByKey( args, new KeyCompReverse() ) ) {
                        System.exit(1);
                    }
                    findByKey( args, new KeyCompReverse() );
                }
                else if ( args[0].equals( "-fl" )) {
                    // Find record(s) by key less then key
                    if ( !findByKey( args, new KeyComp() ) ) {
                        System.exit(1);
                    }
                    findByKey( args, new KeyComp());
                }
                else {
                    System.err.println( "Option is not realised: " + args[0] );
                    System.exit(1);
                }
            }
            else {
                System.err.println( "Employee: Nothing to do!" );
            }
        }
        catch ( Exception e ) {
            System.err.println( "Run/time error: " + e );
            System.exit(1);
        }
        System.out.println( "Employee finished..." );
        System.exit(0);

    }
    static final String filename = "Employee.dat";

    static final String filenameBak = "Employee.~dat";
    static final String idxname     = "Employee.idx";
    static final String idxnameBak  = "Employee.~idx";

    private static Scanner fin = new Scanner( System.in );
    private static String encoding = "Cp866";
    private static PrintStream employeeOut = System.out;


    static Employee read_emp( Scanner fin ) throws IOException {
        return Employee.nextRead( fin, employeeOut )
                ? Employee.read( fin, employeeOut ) : null;
    }

    private static void deleteBackup() {
        new File( filenameBak ).delete();
        new File( idxnameBak ).delete();
    }

    static void deleteFile() {
        deleteBackup();
        new File( filename ).delete();
        new File( idxname ).delete();
    }

    private static void backup() {
        deleteBackup();
        new File( filename ).renameTo( new File( filenameBak ));
        new File( idxname ).renameTo( new File( idxnameBak ));
    }

    static void appendFile( String[] args, Boolean zipped )
            throws FileNotFoundException, IOException, ClassNotFoundException,
            KeyNotUniqueException {
        if ( args.length >= 2 ) {
            FileInputStream stdin = new FileInputStream( args[1] );
            System.setIn( stdin );
            if (args.length == 3) {
                encoding = args[2];
            }
            // hide output:
            employeeOut = new PrintStream("nul");
        }
        appendFile( zipped );
    }

    static void appendFile( Boolean zipped )
            throws FileNotFoundException, IOException, ClassNotFoundException,
            KeyNotUniqueException {
        Scanner fin = new Scanner( System.in, encoding );
        employeeOut.println( "Enter book data: " );
        try ( Index idx = Index.load( idxname );
              RandomAccessFile raf = new RandomAccessFile( filename, "rw" )) {
            for(;;) {
                Employee book = read_emp( fin );
                if ( book == null )
                    break;
                //idx.test( book );
                long pos = Buffer.writeObject( raf, book, zipped );
                idx.put( book, pos );
            }
        }
    }

    static boolean deleteFile( String[] args )
            throws ClassNotFoundException, IOException, KeyNotUniqueException {
        //-dk  {i|a|n} key      - clear data by key
        if ( args.length != 3 ) {
            System.err.println( "Invalid number of arguments" );
            return false;
        }
        long[] poss = null;
       /* try ( Index idx = Index.load( idxname )) {
            IndexBase pidx = indexByArg( args[1], idx );
            if ( pidx == null ) {
                return false;
            }

            if ( !pidx.contains(args[2]) ) {
                System.err.println( "Key not found: " + args[2] );
                return false;
            }

            poss = pidx.get(args[2]);
        }*/
        backup();
        //Arrays.sort( poss );
        try ( Index idx = Index.load( idxname );
              RandomAccessFile fileBak= new RandomAccessFile(filenameBak, "rw");
              RandomAccessFile file = new RandomAccessFile( filename, "rw")) {
            boolean[] wasZipped = new boolean[] {false};
            long pos;
            while (( pos = fileBak.getFilePointer()) < fileBak.length() ) {
                Employee emp = (Employee)
                        Buffer.readObject( fileBak, pos, wasZipped );
                if(args[1].equals("d")) {
                    if (!emp.department_num.equals(args[2])/*Arrays.binarySearch(poss, pos) < 0*/) { // if not found in deleted
                        long ptr = Buffer.writeObject(file, emp, wasZipped[0]);
                        idx.put(emp, ptr);
                    }
                }
                else if(args[1].equals("n")) {
                    if (!emp.name.equals(args[2])/*Arrays.binarySearch(poss, pos) < 0*/) { // if not found in deleted
                        long ptr = Buffer.writeObject(file, emp, wasZipped[0]);
                        idx.put(emp, ptr);
                    }
                }
                else if(args[1].equals("a")) {
                    if (!emp.admission.equals(args[2])/*Arrays.binarySearch(poss, pos) < 0*/) { // if not found in deleted
                        long ptr = Buffer.writeObject(file, emp, wasZipped[0]);
                        idx.put(emp, ptr);
                    }
                }

            }
        }
        return true;
    }


    private static void printRecord( RandomAccessFile raf, long pos )
            throws ClassNotFoundException, IOException {
        boolean[] wasZipped = new boolean[] {false};
        Employee emp = (Employee) Buffer.readObject( raf, pos, wasZipped );
        if ( wasZipped[0] ) {
            System.out.print( " compressed" );
        }
        System.out.println( " record at position "+ pos + ": \n" + emp );
    }

    private static void printRecord( RandomAccessFile raf, String key,
                                     IndexBase pidx, Boolean is_f) throws ClassNotFoundException, IOException {

        long[] poss = pidx.get( key );

        if(!is_f ) {
            for (long pos : poss) {
                System.out.print("*** Key: " + key + " points to");
                printRecord(raf, pos);
                if(poss.length>1) {
                    break;
                    //System.exit(1);
                }
            }
        }
        else{
            for (long pos : poss) {
                System.out.print("*** Key: " + key + " points to");
                printRecord(raf, pos);
                if(poss.length>1) {
                    break;
                    //System.exit(1);
                }
            }
        }
    }

    static void printFile()
            throws FileNotFoundException, IOException, ClassNotFoundException {
        long pos;
        int rec = 0;
        try ( RandomAccessFile raf = new RandomAccessFile( filename, "rw" )) {
            while (( pos = raf.getFilePointer()) < raf.length() ) {
                System.out.print( "#" + (++rec ));
                printRecord( raf, pos );
            }
            System.out.flush();
        }
    }

    private static IndexBase indexByArg( String arg, Index idx ) {
        IndexBase pidx = null;
        if ( arg.equals("d")) {
            pidx = idx.department_num;
        }
        else if ( arg.equals("n")) {
            pidx = idx.name;
        }
        else if ( arg.equals("a")) {
            pidx = idx.admission;
        }
        else {
            System.err.println( "Invalid index specified: " + arg );
        }
        return pidx;
    }




    static boolean printFile( String[] args, boolean reverse )
            throws ClassNotFoundException, IOException {
        if ( args.length != 2 ) {
            System.err.println( "Invalid number of arguments" );
            return false;
        }

        try ( Index idx = Index.load( idxname );
              RandomAccessFile raf = new RandomAccessFile( filename, "rw" )) {
            IndexBase pidx = indexByArg( args[1], idx );
            if ( pidx == null ) {
                return false;
            }
            long pos;
            int cxet = 0;
            boolean[] WasZipped = new boolean[]{false};
            ArrayList<Employee> mapp = new ArrayList<Employee>();
            while((pos = raf.getFilePointer()) < raf.length()) {
                if(args[1].equals("d")) {
                    Employee b = (Employee) Buffer.readObject(raf, pos, WasZipped);
                    pidx.put(b.department_num, pos);
                }
                if(args[1].equals("n")) {
                    Employee b = (Employee) Buffer.readObject(raf, pos, WasZipped);
                    pidx.put(b.name, pos);
                }
                if(args[1].equals("a")) {
                    Employee b = (Employee) Buffer.readObject(raf, pos, WasZipped);
                    pidx.put(b.admission, pos);
                }
            }
            String[] keys;
            if(args[1].equals("n") || args[1].equals("d")) {
                keys =
                        pidx.getKeys(reverse ? new KeyCompReverse() : new KeyComp());
            }
            else{
                keys =
                        pidx.getKeys(reverse ? new KeyCompReverse() : new KeyComp());
            }

            for ( String key : keys ) {
                printRecord( raf, key, pidx, false );

            }

            System.exit(1);
        }
        return true;
    }


    static boolean findByKey( String[] args )
            throws ClassNotFoundException, IOException {
        if ( args.length != 3 ) {
            System.err.println( "Invalid number of arguments" );
            return false;
        }

        try ( Index idx = Index.load( idxname );

              RandomAccessFile raf = new RandomAccessFile( filename, "rw" )) {
            IndexBase pidx = indexByArg( args[1], idx );
            long pos = 0;
            boolean[] WasZipped = new boolean[]{false};
            while((pos = raf.getFilePointer()) < raf.length()) {
                if(args[1].equals("d")) {
                    Employee b = (Employee) Buffer.readObject(raf, pos, WasZipped);
                    pidx.put(b.department_num, pos);
                }
                else if(args[1].equals("n")){
                    Employee b = (Employee) Buffer.readObject(raf, pos, WasZipped);
                    pidx.put(b.name, pos);
                }
                else if(args[1].equals("a")){
                    Employee b = (Employee) Buffer.readObject(raf, pos, WasZipped);
                    pidx.put(b.admission, pos);
                }
            }
            if ( !pidx.contains(args[2]) ) {
                System.err.println( "Key not found: " + args[2] );
                return false;
            }
            printRecord( raf, args[2], pidx, true );
            //System.exit(1);
        }
        return true;
    }

    static boolean findByKey( String[] args, Comparator<String> comp )
            throws ClassNotFoundException, IOException {
        if ( args.length != 3 ) {
            System.err.println( "Invalid number of arguments" );
            return false;
        }
        try ( Index idx = Index.load( idxname );
              RandomAccessFile raf = new RandomAccessFile( filename, "rw" )) {
            IndexBase pidx = indexByArg( args[1], idx );
            long pos;
            boolean[] WasZipped = new boolean[]{false};
            //ArrayList<Date> datearray = new ArrayList<Date>();
            while((pos = raf.getFilePointer()) < raf.length()) {
                if(args[1].equals("d")) {
                    Employee b = (Employee) Buffer.readObject(raf, pos, WasZipped);
                    pidx.put(b.department_num, pos);
                }
                else if(args[1].equals("n")){
                    Employee b = (Employee) Buffer.readObject(raf, pos, WasZipped);
                    pidx.put(b.name, pos);
                }
                else if(args[1].equals("a")){
                    Employee b = (Employee) Buffer.readObject(raf, pos, WasZipped);
                    pidx.put(b.admission, pos);
                }
            }

            if ( !pidx.contains(args[2]) ) {
                System.err.println( "Key not found: " + args[2] );
                return false;
            }

                String[] keys = pidx.getKeys(comp);
                // System.out.println(keys[0].length());
                for (int i = 0; i < keys.length; i++) {
                    String key = keys[i];
                    int c = comp.compare(key, args[2]);
                    if (c < 0) {
                        printRecord(raf, key, pidx, false);
                    }
                }
                System.exit(1);

        }
        return true;
    }

}
