

import java.io.Serializable;
import java.text.DateFormat;
import java.util.Date;

public abstract class Pet implements Serializable {
    final Date creationDate = new Date();

    String getCreationDate() {
        DateFormat dateFormatter = DateFormat.getDateTimeInstance(
                DateFormat.DEFAULT, DateFormat.DEFAULT, AppLocale.get());
        String dateOut = dateFormatter.format(creationDate);
        return dateOut;
    }

    String name;
    int age;

    Pet(){}

    Pet(String name, int age) throws IllegalArgumentException {
        if (name.length() < 1) {
            throw new IllegalArgumentException("Empty Name");
        } else this.name = name;
        if (age < 0) {
            throw new IllegalArgumentException(("Negative age"));
        } else this.age = age;
    }

    private String info = "";

    public String getInfo() {
        return info;
    }

    void setInfo(String info) {
        this.info = info;
    }
    abstract String GetPetType();

    public String toString() {
        return AppLocale.getString(AppLocale.pet) + ": " + name + " " +
                AppLocale.getString(AppLocale.type) + ": " + GetPetType() + " " +
                AppLocale.getString(AppLocale.info) + ": " + info + " " +
                AppLocale.getString(AppLocale.creation) + ": " + getCreationDate();
    }
}
