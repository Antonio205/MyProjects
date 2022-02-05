

import java.io.Serializable;

public class Cat extends Pet implements Serializable {
    private static final long serialVersionUID = 1L;
    Cat(String name, int age) throws IllegalArgumentException {
        super(name, age);
    }
    public Cat(){}
    @Override
    String GetPetType() {
       return AppLocale.getString(AppLocale.cat);
    }
}