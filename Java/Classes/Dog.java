
import java.io.Serializable;

public class Dog extends Pet implements Serializable {
    private static final long serialVersionUID = 1L;
    Dog(String name, int age) throws IllegalArgumentException {
        super(name, age);
    }
    public Dog(){}

    @Override
    String GetPetType() {
        return AppLocale.getString(AppLocale.dog);
    }
}
