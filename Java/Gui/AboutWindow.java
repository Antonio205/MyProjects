import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.text.SimpleDateFormat;
import java.util.ArrayList;

public class AboutWindow extends JFrame {

    private final static int constraint = 400;

    public AboutWindow(Font g_font) throws HeadlessException {
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        JPanel mainPanel = new JPanel();

        mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.PAGE_AXIS));
        JLabel  label1 = new JLabel ("Student: Anton Uminsky, " +
                "Group: 15, " +
                "Course: 2 " + "\n" );

        label1.setHorizontalTextPosition(SwingConstants.LEFT);
        label1.setFont(new Font("Arial", Font.BOLD, 30));
        if(g_font!=null) {
            label1.setFont(g_font);
        }

        JLabel  label2 = new JLabel("Faculty: FAMCS, " +
                "BSU" + "\n");
        JLabel  label3 = new JLabel("Task: Make GUI java application.");
        label2.setFont(new Font("Arial", Font.BOLD, 30));
        if(g_font!=null) {
            label2.setFont(g_font);
        }
        label3.setFont(new Font("Arial", Font.BOLD, 30));
        if(g_font!=null) {
            label3.setFont(g_font);
        }


        mainPanel.add(label1);
        mainPanel.add(label2);
        mainPanel.add(label3);
        setResizable(false);
        setSize(new Dimension(2 * constraint, constraint));
        setContentPane(mainPanel);
        setVisible(true);
    }
}
