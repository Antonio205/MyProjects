

import java.io.*;

class Connector {

    private String filename;

    Connector( String filename ) {
        this.filename = filename;
    }

    void write( Pet[] pets) throws IOException {
        FileOutputStream fos = new FileOutputStream (filename);
        try ( ObjectOutputStream oos = new ObjectOutputStream( fos )) {
            oos.writeInt( pets.length );
            for (Pet pet : pets) {
                oos.writeObject(pet);
            }
            oos.flush();
        }
    }

    Pet[] read() throws IOException, ClassNotFoundException {
        FileInputStream fis = new FileInputStream(filename);
        try ( ObjectInputStream oin = new ObjectInputStream(fis)) {
            int length = oin.readInt();
            Pet[] result = new Pet[length];
            for ( int i = 0; i < length; i++ ) {
                result[i] = (Pet) oin.readObject();
            }
            return result;
        }
    }

}