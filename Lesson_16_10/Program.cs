using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lesson_16_10
{
    struct Grandmother
    {
        private string name;
        private byte age;
        private List<string> disease;
        private List<string> drugs;
        private bool isCryingInTheStreet;
        private bool withoutDisease;
        private string allInfo;
        public Grandmother(string userName, byte userAge)
        {
            name = userName;
            age = userAge;
            disease = new List<string>();
            drugs = new List<string>();
            isCryingInTheStreet = true;
            withoutDisease = true;
            allInfo = "";
        }

        public void setDisease(string[] userDisease)
        {
            if (userDisease.Length != 1 && userDisease[0] != "Нет")
            {
                for (int i = 0; i < userDisease.Length; i++)
                {
                    withoutDisease = false;
                    disease.Add(userDisease[i]);
                }
            }
        }
        public void setDrugs(string[] userDrugs)
        {
            for (int i = 0; i < userDrugs.Length; i++)
            {
                drugs.Add(userDrugs[i]);
            }
        }
        public void setIsCryingInTheStreet()
        {
            isCryingInTheStreet = false;
        }
        public List<string> getDisease()
        {
            return disease;
        }
        public void addDisease(string userDisease)
        {
            withoutDisease = false;
            disease.Add(userDisease);
        }
        public List<string> getDrugs()
        {
            return drugs;
        }
        public bool getWithoutDiseas()
        {
            return withoutDisease;
        }
        public bool getIsCryingInTheStreet()
        {
            return isCryingInTheStreet;
        }
        public string getName()
        {
            return name;
        }
        public void setAllInfo()
        {
            allInfo += name + " " + age + "\n";
            foreach (string currentDisease in disease)
            {
                allInfo += currentDisease + " ";
            }
            allInfo += "\n";
            foreach (string currentMedicine in drugs)
            {
                allInfo += currentMedicine + " ";
            }
        }
        public string getAllInfo()
        {
            setAllInfo();
            return allInfo;
        }
    }
    struct Hospital
    {
        private string title;
        private List<string> treatableDiseases;
        private List<string> grandmotherInHospital;
        private int capacity;
        private int maxCapacity;
        public Hospital(string userTitle, int userMaxCapacity)
        {
            title = userTitle;
            treatableDiseases = new List<string>();
            grandmotherInHospital = new List<string>();
            capacity = 0;
            maxCapacity = userMaxCapacity;
        }
        public void setTreatableDiseases(string[] userTreatableDiseases)
        {
            for (int i = 0; i < userTreatableDiseases.Length; i++)
            {
                treatableDiseases.Add(userTreatableDiseases[i]);
            }
        }
        public void setCapacityToMaxValue()
        {
            capacity = int.MaxValue;
        }
        public void addGrandmotherInHospital(ref Grandmother userGrandmother)
        {
            capacity += 1;
            string info = userGrandmother.getAllInfo();
            grandmotherInHospital.Add(info);
        }
        public List<string> getTreatableDiseases()
        {
            return treatableDiseases;
        }
        public List<string> getGrandmotherInHospital()
        {
            return grandmotherInHospital;
        }
        public int getCapacity()
        {
            return capacity;
        }
        public string getTitle()
        {
            return title;
        }
    }
    struct Classmate
    {
        private string allInfoInString;
        private string surname;
        private string name;
        private int yearOfBirth;
        private string exams;
        private byte examPoint;
        public Classmate(string userSurname, string userName, string userYearOfBirth, string userExams, string userExamPoint)
        {
            //Для инициализации всех объектов
            surname = userSurname;
            name = userName;
            yearOfBirth = System.Convert.ToInt32(userYearOfBirth);
            exams = userExams;
            examPoint = System.Convert.ToByte(userExamPoint);
            allInfoInString = surname + " " + name + " " + yearOfBirth + " " + exams + " " + examPoint;
        }
        public string getSurname()
        {
            return surname;
        }
        public string getName()
        {
            return name;
        }
        public int getYearOfBirth()
        {
            return yearOfBirth;
        }
        public string getExams()
        {
            return exams;
        }
        public byte getExamPoint()
        {
            return examPoint;
        }
        public string getAllInfoInStrig()
        {
            return allInfoInString;
        }
    }


    struct Employee
    {
        private Convert check;
        private string name;
        private string position;
        private byte degreeOfInsolence;
        private bool isStupid;
        private List<Employee> familiars;
        public Employee(string userName, string userPosition, byte userDegreeOfInsolence, bool userIsStupid)
        {
            name = userName;
            position = userPosition;
            degreeOfInsolence = userDegreeOfInsolence;
            isStupid = userIsStupid;
            familiars = new List<Employee>();
            check = new Convert();
        }
        public void setReadyFamiliars(Employee[] userFamiliars)
        {
            for (int i = 0; i < userFamiliars.Length; i++)
            {
                familiars.Add(userFamiliars[i]);
            }
        }
        public void addFamiliars(Employee[] posibleAcquaintances)
        {
            for (int i = 0; i < posibleAcquaintances.Length; i++)
            {
                Console.WriteLine("Если сотрудник знаком с ним, то введите 1, иначе введите 0");
                byte userChoice = check.CheckTheByteNumber();
                while (userChoice > 1)
                {
                    Console.WriteLine("Вы ввели не верно. Введите 0 или 1");
                    userChoice = check.CheckTheByteNumber();
                }
                if (userChoice == 1)
                {
                    familiars.Add(posibleAcquaintances[i]);
                }
            }
        }
        public bool employeeKnowSbFromTheTable(List<Employee> person)
        {
            for (int i = 0; i < 4; i++)
            {
                foreach (Employee posibleAcquaintances in person[i].getFamiliars())
                {
                    if (posibleAcquaintances.getName() == this.name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public List<Employee> getFamiliars()
        {
            return familiars;
        }
        public string getName()
        {
            return name;
        }
        public bool getIsStupid()
        {
            return isStupid;
        }
        public byte getDegreeOfInsolence()
        {
            return degreeOfInsolence;
        }
    }
    struct Table
    {
        private byte countOfPlaces;
        private List<Employee> employeesAtTheTable;
        public Table(bool isCreate)
        {
            countOfPlaces = 0;
            employeesAtTheTable = new List<Employee>();
            employeesAtTheTable.Add(new Employee("", "", 0, false));
            employeesAtTheTable.Add(new Employee("", "", 0, false));
            employeesAtTheTable.Add(new Employee("", "", 0, false));
            employeesAtTheTable.Add(new Employee("", "", 0, false));
        }
        public bool addEmployeeAtTheTable(Employee person)
        {
            if (employeesAtTheTable[0].getName() == "")
            {
                Console.WriteLine(person.getName());
                employeesAtTheTable.Add(person);
                return true;
            }
            bool employeeKnowSbFromTheTable = person.employeeKnowSbFromTheTable(employeesAtTheTable);
            if (employeeKnowSbFromTheTable)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (employeesAtTheTable[i].getName() != "" && !person.getIsStupid())
                    {
                        employeesAtTheTable.Add(person);
                        return true;
                    }
                }
                if (person.getDegreeOfInsolence() > 0 && employeesAtTheTable[3].getName() != "" && !person.getIsStupid())
                {
                    employeesAtTheTable.Add(person);
                }
            }
            else if (person.getIsStupid())
            {
                for (int i = 0; i < 3; i++)
                {
                    if (employeesAtTheTable[i].getName() != "" && !person.getIsStupid())
                    {
                        employeesAtTheTable.Add(person);
                        return true;
                    }
                }
                if (person.getDegreeOfInsolence() > 0 && employeesAtTheTable[3].getName() != "")
                {
                    employeesAtTheTable[3] = person;
                }
            }
            return false;
        }
        public List<Employee> getEmployeesAtTheTable()
        {
            return employeesAtTheTable;
        }
        class Ex1
        {
            public void doEx1()
            {
                int[] team_1 = new int[5];
                int[] team_2 = new int[5];
                Console.WriteLine("Введите значения 1-ой команды:");
                for (int i = 0; i < 5; i++)
                {
                    if (!Int32.TryParse(Console.ReadLine(), out int point) | !(point <= 9) | !(point >= 0))
                    {
                        Console.WriteLine("Неверный формат");
                        i--;
                    }
                    else
                    {
                        team_1[i] = point;
                        Console.WriteLine(team_1[i]);
                    }
                }
                Console.WriteLine("Введите значения 2-ой команды:");
                for (int i = 0; i < 5; i++)
                {
                    if ((!Int32.TryParse(Console.ReadLine(), out int point)) | !(point <= 9) | !(point >= 0))
                    {
                        Console.WriteLine("Неверный формат");
                        i--;
                    }
                    else
                    {
                        team_2[i] = point;
                        Console.WriteLine(team_2[i]);
                    }
                }
                ComparePointsTeams(ref team_1, ref team_2);
            }
            static void ComparePointsTeams(ref int[] team_1, ref int[] team_2)
            {
                int count_team_1 = 0;
                int count_team_2 = 0;
                for (int i = 0; i < team_1.Length; i++)
                {
                    if (team_1[i] == 5)
                    {
                        count_team_1 += 1;
                    }
                    if (team_2[i] == 5)
                    {
                        count_team_2 += 1;
                    }
                }
                if (count_team_1 == count_team_2)
                {
                    Console.WriteLine("Drinks All Round! Free Beers on Bjorg!");
                }
                else
                {
                    Console.WriteLine("Ой, Бьорг - пончик! Ни для кого пива!");
                }
            }

        }
        class Ex3
        {
            private Convert check = new Convert();
            private Dictionary<string, Classmate> studentList = new Dictionary<string, Classmate>();
            private string pathToFile = @".\..\..\resources\students.txt";

            private void setFileStudents()
            {
                if (!File.Exists(pathToFile))
                {
                    Console.WriteLine("Ошибка. Файл students не найден на указанном пути!\n Хотите создать новый файл students?\n0 - No\n1 - Yes");
                    if (check.CheckTheByteNumber() == 1)
                    {
                        try
                        {
                            File.Create(pathToFile).Close();
                            setFileStudents();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Что-то пошло не так...");
                        }
                    }
                    else
                    {
                        setFileStudents();
                    }
                }
            }
            private void setStudentList()
            {
                string[] informationAboutStudent = File.ReadAllLines(pathToFile);
                Classmate student;
                for (int i = 0; i < informationAboutStudent.Length; i++)
                {
                    string[] infoAboutStudent = informationAboutStudent[i].Split(' ');
                    student = new Classmate(infoAboutStudent[0], infoAboutStudent[1], infoAboutStudent[2], infoAboutStudent[3], infoAboutStudent[4]);
                    studentList.Add(student.getSurname() + " " + student.getName(), student);
                }
            }
            private string InputUserInformationAboutStudent()
            {
                string information = "";
                Console.WriteLine("Введите фамилию:");
                information += "\n" + Console.ReadLine() + " ";
                Console.WriteLine("Введите имя:");
                information += Console.ReadLine() + " ";
                Console.WriteLine("Введите год рождения:");
                information += check.CheckTheIntNumber() + " ";
                Console.WriteLine("Введите экзамен, который сдавал студент:");
                information += Console.ReadLine() + " ";
                Console.WriteLine("Введите баллы по этому экзамену:");
                information += check.CheckTheByteNumber() + " ";
                return information;
            }

            private void addStudentToListAndFile()
            {
                string informationAboutStudent = InputUserInformationAboutStudent();
                File.AppendAllText(pathToFile, informationAboutStudent);
                string[] massiveInformationAboutStudent = informationAboutStudent.Split(' ');
                Classmate student = new Classmate(massiveInformationAboutStudent[0], massiveInformationAboutStudent[1], massiveInformationAboutStudent[2], massiveInformationAboutStudent[3], massiveInformationAboutStudent[4]);
                studentList.Add(student.getSurname() + " " + student.getName(), student);
            }
            private void deleteStudentFromList()
            {
                Console.WriteLine("Введите фамилию и имя студента, которого хотите удалить из списка");
                string studentSurnameToBeDeleted = Console.ReadLine();
                string studentNameToBeDeleted = Console.ReadLine();
                studentList.Remove(studentSurnameToBeDeleted + " " + studentNameToBeDeleted);
                string informationAboutAllStudents = "";
                foreach (var student in studentList)
                {
                    if (student.Key != (studentSurnameToBeDeleted + " " + studentNameToBeDeleted))
                    {
                        informationAboutAllStudents += student.Value.getAllInfoInStrig() + "\n";
                    }
                }
                Console.WriteLine(informationAboutAllStudents);
                File.WriteAllText(pathToFile, informationAboutAllStudents);
            }
            private void sortStudentsByExamPoint()
            {
                studentList = studentList.OrderBy(studentList => studentList.Value.getExamPoint()).ToDictionary(studentList => studentList.Key, studentList => studentList.Value);
            }
            public void DoEx3()
            {
                setFileStudents();
                setStudentList();
                Console.WriteLine("Введите команду:\nНовый студент|Удалить|Сортировать\nЕсли хотите закончить работу со списком, то введите команду 'выйти'");
                string userChoice = Console.ReadLine().ToLower();
                while (userChoice != "выйти")
                {
                    if (userChoice == "новый студент")
                    {
                        addStudentToListAndFile();
                    }
                    else if (userChoice == "удалить")
                    {
                        deleteStudentFromList();
                    }
                    else if (userChoice == "сортировать")
                    {
                        sortStudentsByExamPoint();
                        Console.WriteLine("Сортировка по возрастанию:");
                        foreach (var student in studentList)
                        {
                            Console.WriteLine(student.Value.getAllInfoInStrig());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Такой команды не существует");
                    }
                    Console.WriteLine("Введите команду:");
                    userChoice = Console.ReadLine().ToLower();
                }
            }
        }
        class Ex4
        {
            private Convert check = new Convert();
            private Queue<Employee> employeesQueue = new Queue<Employee>();
            private Stack<Table>
            tablesStack = new Stack<Table>();
            private List<Employee> losers = new List<Employee>();
            private int countOfTable;
            private Employee createEmployee()
            {
                Console.WriteLine("Введите имя:");
                string name = Console.ReadLine();
                Console.WriteLine("Введите должность:");
                string position = Console.ReadLine();
                Console.WriteLine("Введите степень наглости сотрудника(от 0 до 10):");
                byte degreeOfInsolence = check.CheckTheByteNumber();
                while (degreeOfInsolence > 10)
                {
                    degreeOfInsolence = check.CheckTheByteNumber();
                }
                Console.WriteLine("Тупой ли сотрудник(Да - 0, Нет - 1)?");
                byte userChoiceAboutStupid = check.CheckTheByteNumber();
                while (userChoiceAboutStupid > 1)
                {
                    userChoiceAboutStupid = check.CheckTheByteNumber();
                }
                bool isStupid = false;
                if (userChoiceAboutStupid == 0)
                {
                    isStupid = true;
                }
                return (new Employee(name, position, degreeOfInsolence, isStupid));
            }
            private void addEmployeeToEmployeesQueue(Employee person)
            {
                employeesQueue.Enqueue(person);
            }
            private void setEmployeesQueue()
            {
                Console.WriteLine("Если хотите закончить ввод пользователей, то введите 'выйти'\nЕсли хотите воспользоваться готовым списком, то введите 'готовый список'");
                string userChoise = Console.ReadLine();
                if (userChoise == "готовый список")
                {
                    Employee employee1 = new Employee("Майк", "Боксер", 10, false);
                    Employee employee2 = new Employee("Билли", "Dungeon Master", 10, false);
                    Employee employee3 = new Employee("Гарри", "Стрелок", 5, true);
                    Employee employee4 = new Employee("Путин", "Президент", 0, false);
                    Employee employee5 = new Employee("Донателло", "Черепашка-ниндзя", 0, false);
                    Employee[] massEmploy1 = { employee3, employee4 };
                    Employee[] massEmploy2 = { employee5, employee1 };
                    Employee[] massEmploy3 = { employee1 };
                    Employee[] massEmploy4 = { employee5 };
                    Employee[] massEmploy5 = { employee4 };
                    employee1.setReadyFamiliars(massEmploy1);
                    employee2.setReadyFamiliars(massEmploy2);
                    employee3.setReadyFamiliars(massEmploy3);
                    employee4.setReadyFamiliars(massEmploy4);
                    employee5.setReadyFamiliars(massEmploy5);
                    employeesQueue.Enqueue(employee1);
                    employeesQueue.Enqueue(employee2);
                    employeesQueue.Enqueue(employee3);
                    employeesQueue.Enqueue(employee4);
                    employeesQueue.Enqueue(employee5);
                }
                else
                {
                    while (userChoise != "выйти")
                    {
                        addEmployeeToEmployeesQueue(createEmployee());
                        userChoise = Console.ReadLine();
                    }
                    Employee[] massOfAllEmployee = new Employee[employeesQueue.Count];
                    for (int i = 0; i < massOfAllEmployee.Length; i++)
                    {
                        Employee currentEmployee = employeesQueue.Dequeue();
                        massOfAllEmployee[i] = currentEmployee;
                        employeesQueue.Enqueue(currentEmployee);
                    }
                    for (int i = 0; i < employeesQueue.Count; i++)
                    {
                        Employee currentEmployee = employeesQueue.Dequeue();
                        currentEmployee.addFamiliars(massOfAllEmployee);
                        employeesQueue.Enqueue(currentEmployee);
                    }
                }
            }
            private void setTable()
            {
                Console.WriteLine("Введите кол-во столов:");
                countOfTable = check.CheckTheIntNumber();
                for (int i = 0; i < countOfTable; i++)
                {
                    tablesStack.Push(new Table(true));
                }
            }
            private void sortTablesStack()
            {
                Queue<Employee> copyOfEmployeesQueueStack = new Queue<Employee>(employeesQueue);
                int countOfEmployee = copyOfEmployeesQueueStack.Count;
                Employee[] massEmployeesQueue = new Employee[countOfEmployee];
                for (int i = 0; i < countOfEmployee; i++)
                {
                    massEmployeesQueue[i] = copyOfEmployeesQueueStack.Dequeue();
                }
                for (int i = 0; i < countOfEmployee; i++)
                {
                    if (massEmployeesQueue[i].getDegreeOfInsolence() > 0)
                    {
                        int newPlaceInQueue = massEmployeesQueue[i].getDegreeOfInsolence() + i;
                        if (newPlaceInQueue > countOfEmployee)
                        {
                            newPlaceInQueue = countOfEmployee;
                        }
                        Employee rotate = massEmployeesQueue[i];
                        massEmployeesQueue[i] = massEmployeesQueue[newPlaceInQueue - 1];
                        massEmployeesQueue[newPlaceInQueue - 1] = rotate;
                    }
                }
                for (int i = 0; i < countOfEmployee; i++)
                {
                    copyOfEmployeesQueueStack.Enqueue(massEmployeesQueue[i]);
                }
                employeesQueue = new Queue<Employee>(copyOfEmployeesQueueStack);
            }
            private void seatEmployee()
            {
                for (int i = 0; i < employeesQueue.Count; i++)
                {
                    Employee currentEmployee = employeesQueue.Dequeue();
                    bool isSeating = false;
                    Stack<Table> copyOfTablesStack = new Stack<Table>(tablesStack);
                    for (int j = 0; j < countOfTable; j++)
                    {
                        Table currentTable = copyOfTablesStack.Pop();
                        bool currentEmployeeHaveFamiliars = currentTable.addEmployeeAtTheTable(currentEmployee);
                        if (currentEmployeeHaveFamiliars && !currentEmployee.getIsStupid())
                        {
                            isSeating = true;
                            break;
                        }
                    }
                    if (!isSeating)
                    {
                        losers.Add(currentEmployee);
                    }
                }
            }
            public void doEx4()
            {
                setEmployeesQueue();
                setTable();
                sortTablesStack();
                seatEmployee();
                for (int i = 0; i < countOfTable; i++)
                {
                    Table currentTable = tablesStack.Pop();
                    List<Employee> currentTableEmployee = currentTable.getEmployeesAtTheTable();
                    if (currentTableEmployee == null)
                    {
                        Console.WriteLine("За " + (i + 1) + " столом никого нет");
                    }
                    else
                    {
                        foreach (Employee currentEmployee in currentTableEmployee)
                        {
                            Console.WriteLine(currentEmployee.getName());
                        }
                    }
                }
            }
        }
        class Ex5
        {
            private string pathToGrandma = @".\..\..\resources\grandma.txt";
            private string pathToHospital = @".\..\..\resources\hospitals.txt";
            private Queue<Grandmother> grandmaQueue = new Queue<Grandmother>();
            private Stack<Hospital> hospitals = new Stack<Hospital>();
            private int countOfElementInGrandmaQueue = 0;
            private void setGrandmaFromFile()
            {
                string[] informationAboutGrandma = File.ReadAllLines(pathToGrandma);
                Grandmother grandma;
                for (int i = 0; i < informationAboutGrandma.Length; i += 3)
                {
                    string[] infoAboutGrandma = informationAboutGrandma[i].Split(' ');
                    grandma = new Grandmother(infoAboutGrandma[0], System.Convert.ToByte(infoAboutGrandma[1]));
                    infoAboutGrandma = informationAboutGrandma[i + 1].Split(' ');
                    grandma.setDisease(infoAboutGrandma);
                    infoAboutGrandma = informationAboutGrandma[i + 2].Split(' ');
                    grandma.setDrugs(infoAboutGrandma);
                    grandmaQueue.Enqueue(grandma);
                    countOfElementInGrandmaQueue++;
                }
            }
            private void setHospitalsFromFile()
            {
                string[] informationAboutHospital = File.ReadAllLines(pathToHospital);
                Hospital hospital;
                for (int i = 0; i < informationAboutHospital.Length - 1; i += 3)
                {
                    string hospitalTitle = informationAboutHospital[i];
                    string[] hospitalTreatableDiseases = informationAboutHospital[i + 1].Split(' ');
                    int hospitalCapacity = System.Convert.ToInt32(informationAboutHospital[i + 2]);
                    hospital = new Hospital(hospitalTitle, hospitalCapacity);
                    hospital.setTreatableDiseases(hospitalTreatableDiseases);
                    hospitals.Push(hospital);
                }
            }
            private Stack<Hospital> copyGrandmaQueue()
            {
                return hospitals;
            }
            private void DistributionOfGrandma()
            {
                for (int i = 0; i < countOfElementInGrandmaQueue; i++)
                {
                    Stack<Hospital> copyHospitals = new Stack<Hospital>(hospitals);
                    Grandmother currentGrandma = grandmaQueue.Dequeue();
                    int minCapacity = int.MaxValue;
                    Hospital hospitalWithMinCapacity = new Hospital("name", 8000000);
                    hospitalWithMinCapacity.setCapacityToMaxValue();
                    double diseasesThatAreTreatedInTheHospital = 0;
                    int countOfHospitals = copyHospitals.Count;
                    while (copyHospitals.Count != 0)
                    {
                        Hospital currentHospital = copyHospitals.Pop();
                        foreach (string disease in currentGrandma.getDisease())
                        {

                            if (currentHospital.getTreatableDiseases().Contains(disease))
                            {
                                diseasesThatAreTreatedInTheHospital++;
                            }
                        }
                        if (minCapacity > currentHospital.getCapacity())
                        {
                            minCapacity = currentHospital.getCapacity();
                            hospitalWithMinCapacity = currentHospital;
                        }
                        if (diseasesThatAreTreatedInTheHospital == 0)
                        {
                            continue;
                        }
                        if ((diseasesThatAreTreatedInTheHospital / currentHospital.getTreatableDiseases().Count) >= (1 / 2))
                        {
                            currentHospital.addGrandmotherInHospital(ref currentGrandma);
                            break;
                        }
                        else
                        {
                            currentGrandma.setIsCryingInTheStreet();
                        }
                        diseasesThatAreTreatedInTheHospital = 0;
                    }
                    if (currentGrandma.getWithoutDiseas())
                    {
                        hospitalWithMinCapacity.addGrandmotherInHospital(ref currentGrandma);
                    }
                }
            }
            public void doEx5()
            {
                setGrandmaFromFile();
                setHospitalsFromFile();
                DistributionOfGrandma();
                foreach (Hospital hospital in hospitals)
                {
                    Console.WriteLine(hospital.getTitle() + ":");
                    foreach (string info in hospital.getGrandmotherInHospital())
                    {
                        Console.WriteLine(info);
                    }
                }
            }
        }
        class ClassWork
        {
            private static Convert check = new Convert();
            static void Main(string[] args)
            {
                Console.WriteLine("Введите номер задания");
                byte userChoice = check.CheckTheByteNumber();
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("ex 1");
                        Ex1 ex1 = new Ex1();
                        ex1.doEx1();
                        break;
                    case 2:
                        Console.WriteLine("ex 2");
                        break;
                    case 3:
                        Console.WriteLine("ex 3");
                        new Ex3().DoEx3();
                        break;
                    case 4:
                        Console.WriteLine("ex 4");
                        new Ex4().doEx4();
                        break;
                    case 5:
                        Console.WriteLine("ex 5");
                        new Ex5().doEx5();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}