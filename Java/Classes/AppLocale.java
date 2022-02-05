
import java.util.*;

class AppLocale
{
    private static final String strMsg = "Msg";
    private static Locale loc = Locale.getDefault();
    private static ResourceBundle res = ResourceBundle.getBundle(AppLocale.strMsg, AppLocale.loc);

    static Locale get()
    {
        return AppLocale.loc;
    }

    static void set(Locale loc_)
    {
        AppLocale.loc = loc_;
        res = ResourceBundle.getBundle(AppLocale.strMsg, AppLocale.loc);
    }

    static ResourceBundle getBundle() { return AppLocale.res; }

    static String getString(String key)
    {
        return AppLocale.res.getString(key);
    }

    static final String pet="pet";
    static final String type="type";
    static final String info="info";
    static final String creation="creation";
    static final String purebred_cat="purebred_cat";
    static final String purebred_dog="purebred_dog";
    static final String war_dog="war_dog";
    static final String rare_parrot="rare_parrot";
    static final String dog="dog";
    static final String parrot="parrot";
    static final String cat="cat";
}