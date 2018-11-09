static final String newLine = System.getProperty("line.separator");

    public static void main(String[] args) {

        File resultsFile = new File("results.txt");
        if (resultsFile.exists()) resultsFile.delete();

        ArrayList<Employee> EList = new ArrayList<>();

        readData(EList);
        showData("Employees data from data.txt: ", EList);   
        
        if (EList.size() > 0) {
            
            EList.sort(Comparator.comparing(Employee::getSalary).reversed());
            showData("Sorted list by salary: ", EList);
            
            try (FileWriter writer = new FileWriter("results.txt", true)) {

                writer.write(newLine + "People earn most working in \"" + EList.get(0).getJob() + "\" job." + newLine);

                writer.write(newLine + "People earn least working in \"" + EList.get(EList.size() - 1).getJob() + "\" job." + newLine);    

            } catch (IOException ex) {
                System.out.println("Error writing to file!");
            }
            
            totalSalary(EList);
        }     
    }

    private static void showData(String name, ArrayList<Employee> eList) {

        try (FileWriter writer = new FileWriter("results.txt", true)) {

            if (eList.size() > 0) {

                writer.write(newLine);
                writer.write(name + newLine);
                writer.write("----------------------------------------------|" + newLine);
                writer.write("|      Name      |      Job      |   Salary   |" + newLine);
                writer.write("----------------------------------------------|" + newLine);

                for (int i = 0; i < eList.size(); i++) {

                    writer.write(String.format("| %-14s | %-13s | %-10d |", eList.get(i).getName(),
                            eList.get(i).getJob(), eList.get(i).getSalary()) + newLine);

                }
                writer.write("----------------------------------------------|" + newLine);
            }
            else
                writer.write("It's empty!");


        } catch (IOException ex) {
            System.out.println("Error writing to file!");
        }

    }

    private static void readData(ArrayList<Employee> EList) {

        String line = null;

        try {

            BufferedReader reader = new BufferedReader(new FileReader("data.txt"));

            while ((line = reader.readLine()) != null)
            {

                String[] data = line.split(";");

                Employee e = new Employee();
                e.setName(data[0].trim());
                e.setJob(data[1].trim());
                e.setSalary(Integer.parseInt(data[2].trim()));

                EList.add(e);

            }

            reader.close();

        } catch (IOException ex) {
            System.out.println("Error reading from file");
        }

    }

    private static void totalSalary(ArrayList<Employee> EList) {
        
        int totalSalary = 0;
        
        try (FileWriter writer = new FileWriter("results.txt", true)) {
            
            for (int i = 0; i < EList.size(); i++) {
                
                totalSalary += EList.get(i).getSalary();
                
            }
            
            writer.write(newLine + "Total salary from all jobs: " + totalSalary + "€" + newLine);
                    
        } catch (IOException ex) {
            System.out.println("Error writing to file!");
        }
        
    }
