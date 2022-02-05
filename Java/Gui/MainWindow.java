import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.*;
import java.util.*;



public class MainWindow extends JFrame {
    private final static int constraint = 350;
    private final static String statusHead = " Status: ";
    private static SearchWindow searchWindow = null;
    private static AboutWindow aboutWindow = null;
    private static Font globalFont = null;


    public MainWindow() throws HeadlessException {
        JFrame self = this;
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        JLabel status = new JLabel(statusHead);
        DefaultListModel<Employee> listModel = new DefaultListModel();
        JList listView = new JList(listModel);
        JScrollPane scrollPane = new JScrollPane(listView);

        JPanel formPanel = new JPanel();
        formPanel.setLayout(new BoxLayout(formPanel, BoxLayout.Y_AXIS));

        listView.addKeyListener(new KeyListener() {
            @Override
            public void keyTyped(KeyEvent e) {

            }

            @Override
            public void keyPressed(KeyEvent e) {
                switch (e.getKeyCode()) {
                    case KeyEvent.VK_DELETE: {
                        if (!listView.isSelectionEmpty()) {
                            Employee employee = (Employee) listView.getSelectedValue();
                            if(employee.isDeleted()) {
                                status.setText(statusHead + "object is already deleted");
                                return;
                            }
                            if (JOptionPane.showConfirmDialog(null, "Delete this object?") == 0) {
                                employee.setDeleted(true);
                                status.setText(statusHead + "object " + employee.getTabNumFormat() + " deleted");
                            } else
                                status.setText(statusHead + "deleting refused");
                        }
                    }
                }
            }

            @Override
            public void keyReleased(KeyEvent e) {

            }
        });

        JTextField depNumInput = new JTextField();
        JTextField fioInput = new JTextField();
        JTextField salaryInput = new JTextField();

        JButton submit = new JButton("Submit");

        JLabel label1 = new JLabel("Department number:");

        JLabel label2 = new JLabel("Full name:");

        JLabel label3 = new JLabel("Salary:");

        formPanel.add(label1);
        formPanel.add(depNumInput);
        formPanel.add(label2);
        formPanel.add(fioInput);
        formPanel.add(label3);
        formPanel.add(salaryInput);


        submit.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try {
                    int depNum = Integer.parseInt(depNumInput.getText());
                    double salary = Double.parseDouble(salaryInput.getText());
                    String fio = fioInput.getText();

                    listModel.addElement(new Employee(depNum, fio, salary));
                    depNumInput.setText("");
                    fioInput.setText("");
                    salaryInput.setText("");
                    status.setText(statusHead + "input succeed");
                } catch (IllegalArgumentException ignored) {
                    status.setText(statusHead + "input error, check input data");
                }
            }
        });

        JMenuBar menuBar = new JMenuBar();
        JMenu fileMenu = new JMenu("File");
        JMenuItem load = new JMenuItem("Load");
        JMenuItem save = new JMenuItem("Save as");
        JMenuItem exit = new JMenuItem("Exit");
        JMenu sortMenu = new JMenu("Sort by...");
        JMenuItem byDepNum = new JMenuItem("dep.num.");
        JMenuItem byFio = new JMenuItem("full name");
        JMenuItem byHireDate = new JMenuItem("hire date");
        JMenu searchMenu = new JMenu("Search by...");
        JMenuItem sByFio = new JMenuItem("full name");
        JMenuItem sByDep = new JMenuItem("department number");
        JMenuItem sByDate = new JMenuItem("hare date");
        JMenu view = new JMenu("View");
        JMenuItem font_b = new JMenuItem("Font");
        JMenu lookAndFeel = new JMenu("Look and feel");
        JMenu help = new JMenu("Help");
        JMenuItem about = new JMenuItem("About");

        fileMenu.add(load);
        fileMenu.add(save);
        fileMenu.add(new JSeparator());
        fileMenu.add(exit);
        sortMenu.add(byDepNum);
        sortMenu.add(byFio);
        sortMenu.add(byHireDate);
        searchMenu.add(sByFio);
        searchMenu.add(sByDep);
        searchMenu.add(sByDate);
        view.add(font_b);
        view.add(lookAndFeel);
        menuBar.add(fileMenu);
        menuBar.add(sortMenu);
        menuBar.add(searchMenu);
        menuBar.add(view);
        setJMenuBar(menuBar);
        help.add(about);
        fileMenu.add(help);


        //region view-> look and feel
        ButtonGroup radiogroup = new ButtonGroup();
        UIManager.LookAndFeelInfo[] plafs =
                UIManager.getInstalledLookAndFeels();
        for(int i = 0; i < plafs.length; i++) {
            String plafName = plafs[i].getName();
            final String plafClassName = plafs[i].getClassName();
            JMenuItem item = lookAndFeel.add(new JRadioButtonMenuItem(plafName));
            item.addActionListener(new ActionListener() {
                public void actionPerformed(ActionEvent e) {
                    try {

                        UIManager.setLookAndFeel(plafClassName);

                        SwingUtilities.updateComponentTreeUI(self);

                    }
                    catch(Exception ex) { System.err.println(ex); }
                }

            });

            // Only allow one menu item to be selected at once
            radiogroup.add(item);
        }
        //endregion

        FontChooser f = new FontChooser(self);

        font_b.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                final FontChooser chooser = new FontChooser(self);
                chooser.setVisible(true);
                Font font = chooser.getSelectedFont();
                //region change font
                status.setFont(font);;
                 fileMenu.setFont(font);
                 load.setFont(font);
                 save.setFont(font);
                 exit.setFont(font);
                 sortMenu.setFont(font);
                 byDepNum.setFont(font);
                 byFio.setFont(font);
                 byHireDate.setFont(font);
                 searchMenu.setFont(font);
                 sByFio.setFont(font);
                 sByDep.setFont(font);
                 sByDate.setFont(font);
                 font_b.setFont(font);
                 view.setFont(font);
                 lookAndFeel.setFont(font);
                 help.setFont(font);
                 about.setFont(font);
                depNumInput.setFont(font);
                fioInput.setFont(font);
                salaryInput.setFont(font);
                submit.setFont(font);
                label1.setFont(font);
                label2.setFont(font);
                label3.setFont(font);
                globalFont = font;
                //endregion
            }
        });

        about.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                //listView.clearSelection();
                if(aboutWindow == null) {
                    //searchWindow.dispose();
                    aboutWindow = new AboutWindow(globalFont);
                }
                else {
                    //searchWindow.dispose();
                    aboutWindow.dispose();
                    aboutWindow = new AboutWindow(globalFont);
                }
            }
        });

        load.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JFileChooser fileChooser = new JFileChooser();
                int result = fileChooser.showOpenDialog(self);
                if (result != JFileChooser.APPROVE_OPTION) {
                    return;
                }
                File file = fileChooser.getSelectedFile();
                try {
                    FileInputStream fis = new FileInputStream(file);
                    ObjectInputStream ois = new ObjectInputStream(fis);
                    ArrayList<Employee> empsList = (ArrayList) ois.readObject();
                    ois.close();
                    fis.close();
                    listModel.clear();
                    for (Employee emp : empsList) {
                        if (!emp.isDeleted())
                            listModel.addElement(emp);
                    }
                    status.setText(statusHead + "loaded file \"" + file.getName() + '\"');
                } catch (IOException | ClassNotFoundException e1) {
                    status.setText(statusHead + e1.getMessage());
                }
            }
        });

        save.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JFileChooser fileChooser = new JFileChooser();
                int result = fileChooser.showSaveDialog(self);
                if (result != JFileChooser.APPROVE_OPTION) {
                    return;
                }
                File file = fileChooser.getSelectedFile();
                try {
                    FileOutputStream fos = new FileOutputStream(file);
                    ObjectOutputStream oos = new ObjectOutputStream(fos);
                    ArrayList<Employee> emps = new ArrayList<>();
                    for (int i = 0; i < listModel.size(); i++) {
                        emps.add(listModel.get(i));
                    }
                    oos.writeObject(emps);
                    oos.close();
                    fos.close();
                    status.setText(statusHead + "list saved as \"" + file.getName() + '\"');
                } catch (IOException e1) {
                    status.setText(statusHead + e1.getMessage());
                }
            }
        });

        exit.addActionListener(new AbstractAction() {
            @Override
            public void actionPerformed(ActionEvent e) {
                System.exit(0);
            }
        });

        byDepNum.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                java.util.List<Employee> tempList = new ArrayList<>();
                for (int i = 0; i < listModel.size(); i++)
                    tempList.add(listModel.get(i));
                listModel.clear();
                tempList.sort(new Comparator<Employee>() {
                    @Override
                    public int compare(Employee o1, Employee o2) {
                        return Integer.compare(o1.getDepNum(), o2.getDepNum());
                    }
                });
                for (Employee emp : tempList)
                    listModel.addElement(emp);

                status.setText(statusHead + "sorted by dep.num.");
            }
        });

        byFio.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                java.util.List<Employee> tempList = new ArrayList<>();
                for (int i = 0; i < listModel.size(); i++)
                    tempList.add(listModel.get(i));
                listModel.clear();
                tempList.sort(new Comparator<Employee>() {
                    @Override
                    public int compare(Employee o1, Employee o2) {
                        return o1.getFio().compareTo(o2.getFio());
                    }
                });
                for (Employee emp : tempList)
                    listModel.addElement(emp);

                status.setText(statusHead + "sorted by full name");
            }
        });

        byHireDate.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                java.util.List<Employee> tempList = new ArrayList<>();
                for (int i = 0; i < listModel.size(); i++)
                    tempList.add(listModel.get(i));
                listModel.clear();
                tempList.sort(new Comparator<Employee>() {
                    @Override
                    public int compare(Employee o1, Employee o2) {
                        return (o1.getHireDate()).compareTo(o2.getHireDate());
                    }
                });
                for (Employee emp : tempList)
                    listModel.addElement(emp);

                status.setText(statusHead + "sorted by hire date");
            }
        });

        sByFio.addActionListener(new AbstractAction() {
            @Override
            public void actionPerformed(ActionEvent e) {
                listView.clearSelection();
                if(searchWindow == null)
                    searchWindow = new SearchWindow(listView, listModel, 'f', globalFont);
                else {
                    searchWindow.dispose();
                    searchWindow = new SearchWindow(listView, listModel, 'f', globalFont);
                }
                status.setText(statusHead + "searching");
            }
        });

        sByDep.addActionListener(new AbstractAction() {
            @Override
            public void actionPerformed(ActionEvent e) {
                listView.clearSelection();
                if(searchWindow == null)
                    searchWindow = new SearchWindow(listView, listModel, 'n', globalFont);
                else {
                    searchWindow.dispose();
                    searchWindow = new SearchWindow(listView, listModel, 'n', globalFont);
                }
                status.setText(statusHead + "searching");
            }
        });

        sByDate.addActionListener(new AbstractAction() {
            @Override
            public void actionPerformed(ActionEvent e) {
                listView.clearSelection();
                if(searchWindow == null) {
                    //aboutWindow.dispose();
                    searchWindow = new SearchWindow(listView, listModel, 'd', globalFont);
                }
                else {
                    //aboutWindow.dispose();
                    searchWindow.dispose();
                    searchWindow = new SearchWindow(listView, listModel, 'd', globalFont);
                }
                status.setText(statusHead + "searching");
            }
        });


        KeyListener enterKL = new KeyListener() {
            @Override
            public void keyTyped(KeyEvent e) {

            }

            @Override
            public void keyPressed(KeyEvent e) {
                switch (e.getKeyCode()) {
                    case KeyEvent.VK_ENTER: {
                        submit.doClick();
                    }
                }
            }

            @Override
            public void keyReleased(KeyEvent e) {

            }
        };
        depNumInput.addKeyListener(enterKL);
        fioInput.addKeyListener(enterKL);
        salaryInput.addKeyListener(enterKL);

        JPanel panel = new JPanel();
        panel.setLayout(new BorderLayout());
        panel.add(scrollPane, BorderLayout.NORTH);

        JPanel southPanel = new JPanel(new BorderLayout());
        JPanel southButtonPanel = new JPanel();
        southButtonPanel.setLayout(new BoxLayout(southButtonPanel, BoxLayout.X_AXIS));
        southButtonPanel.add(submit);
        southButtonPanel.add(status);
        southPanel.add(formPanel, BorderLayout.CENTER);
        southPanel.add(southButtonPanel, BorderLayout.SOUTH);
        panel.add(southPanel, BorderLayout.SOUTH);

        setSize(new Dimension(2 * constraint, constraint));
        setResizable(true);
        setContentPane(panel);
        setVisible(true);
    }
}