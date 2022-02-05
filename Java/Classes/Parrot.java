

import java.io.Serializable;

public class Parrot extends Pet implements Serializable {
    private static final long serialVersionUID = 1L;
    Parrot(String name, int age) throws IllegalArgumentException {
        super(name, age);
    }
    public Parrot(){}

    @Override
    String GetPetType() {
        return AppLocale.getString(AppLocale.parrot);
    }
}