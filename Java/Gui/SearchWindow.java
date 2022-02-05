import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.text.SimpleDateFormat;
import java.util.*;

public class SearchWindow extends JFrame {
    private final static int constraint = 100;

    public SearchWindow(JList list, DefaultListModel<Employee> listModel, char c, Font f) throws HeadlessException {
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);

        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.Y_AXIS));
        if(c == 'f') {
            JLabel label1 = new JLabel("Full name:");
            if(f!=null){
                label1.setFont(f);
            }
            mainPanel.add(label1);
        }
        else if (c == 'd') {
            JLabel label1 = new JLabel("Hare date:");
            if(f!=null){
                label1.setFont(f);
            }
            mainPanel.add(label1);
        }
        else{
            JLabel label1 = new JLabel("Department number:");
            if(f!=null){
                label1.setFont(f);
            }
            mainPanel.add(label1);
        }
        JTextField searchField = new JTextField();
        mainPanel.add(searchField);

        JButton search = new JButton("Search");
        if(f!=null){
            search.setFont(f);
        }
        mainPanel.add(search);

        search.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try {
                    int[] indices = null;
                    java.util.List<Employee> tempList = new ArrayList<>();

                    for (int i = 0; i < listModel.size(); i++)
                        tempList.add(listModel.get(i));

                    for (Employee emp : tempList)
                        if(c == 'f') {
                            if (emp.getFio().equals(searchField.getText())) {
                                indices = insertValue(indices, listModel.indexOf(emp));
                            }
                        }
                        else if(c == 'n') {
                            if (emp.getDepNum() == (Integer.parseInt(searchField.getText()))) {
                                indices = insertValue(indices, listModel.indexOf(emp));
                            }
                        }
                        else if(c == 'd') {
                            SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
                            if (dateFormat.format(emp.getHireDate()).equals(searchField.getText())) {
                                indices = insertValue(indices, listModel.indexOf(emp));
                            }
                        }

                    list.setSelectedIndices(indices);
                } catch (NullPointerException ignored) {

                }
            }
        });

        searchField.addKeyListener(new KeyListener() {
            @Override
            public void keyTyped(KeyEvent e) {

            }

            @Override
            public void keyPressed(KeyEvent e) {
                switch (e.getKeyCode()) {
                    case KeyEvent.VK_ENTER: {
                        search.doClick();
                    }
                }
            }

            @Override
            public void keyReleased(KeyEvent e) {

            }
        });

        setResizable(false);
        setSize(new Dimension(2 * constraint, constraint));
        setContentPane(mainPanel);
        setVisible(true);
    }

    private static int[] insertValue(int[] arr, int value) {
        int length = (arr == null) ? 0 : arr.length;
        int[] result = new int[length + 1];
        for (int i = 0; i < length; i++) {
            result[i] = arr[i];
        }
        result[length] = value;
        return result;
    }
}