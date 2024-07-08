using System;
using System.Collections;

//Sean Botha - 577288
//Conrad Joubert - 577417
//Edwin le Cointre - 577328
//Frank Peter Smal - 577298
//Justin Gibbon - 577407

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList names = new ArrayList();
            ArrayList employeds = new ArrayList();
            ArrayList yearsAtJobs = new ArrayList();
            ArrayList yearsAtResidences = new ArrayList();
            ArrayList salarys = new ArrayList();
            ArrayList debts = new ArrayList();
            ArrayList numOfChildrens = new ArrayList();

            int applicable = 0;
            int nonApplicable = 0;
            char stop = 'Y';

            Console.WriteLine("What do you want to do today:\n" +
                "1:Capture Details\n" +
                "2:Check credit qualification\n" +
                "3:Show qualification stats\n" +
                "4:Exit the program");
            int option = Convert.ToInt32(Console.ReadLine());

            while (option != 4)
            {
                switch ((options)option)
                {
                    case options.option1:
                        Console.Clear();
                        while (stop == 'Y' || stop == 'y')
                        {
                            Console.WriteLine("Enter the applicant's name");
                            string name = Console.ReadLine();

                            Console.WriteLine("Is the applicant employed:\n1:Yes\n2:No");
                            int employed = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter the amount of years at the job");
                            int yearsAtJob = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter the amount of years at current residence");
                            int yearsAtResidence = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter the salary");
                            int salary = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter the amount of debt");
                            double debt = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine("Enter the amount of children the applicant has");
                            int numOfChildren = Convert.ToInt32(Console.ReadLine());

                            if (checkQuali(employed, yearsAtJob, yearsAtResidence, salary, debt, numOfChildren).Equals(" is applicable"))
                            {
                                names.Add(name);
                                employeds.Add(employed);
                                yearsAtJobs.Add(yearsAtJob);
                                yearsAtResidences.Add(yearsAtResidence);
                                salarys.Add(salary);
                                debts.Add(debt);
                                numOfChildrens.Add(numOfChildren);

                                applicable++;
                            }
                            else if (checkQuali(employed, yearsAtJob, yearsAtResidence, salary, debt, numOfChildren).Equals(" is not applicable"))
                            {
                                names.Add(name);
                                employeds.Add(employed);
                                yearsAtJobs.Add(yearsAtJob);
                                yearsAtResidences.Add(yearsAtResidence);
                                salarys.Add(salary);
                                debts.Add(debt);
                                numOfChildrens.Add(numOfChildren);
                                nonApplicable++;
                            }
                            Console.WriteLine("Do you want to enter another applicant:\nY: Yes\nN: No");
                            stop = Convert.ToChar(Console.ReadLine());
                            Console.Clear();
                        }
                        break;                        

                    case options.option2:
                        Console.Clear();
                        Console.WriteLine("Total applicable: " + applicable);
                        Console.WriteLine("Total non applicable: " + nonApplicable + "\n");
                        break;

                    case options.option3:
                        Console.Clear();
                        Console.WriteLine(showStats(names, employeds, yearsAtJobs, yearsAtResidences, salarys, debts, numOfChildrens) + "\n");
                        break;

                    default:
                        Console.WriteLine("Invalid option has been chosen\n");
                        Console.Clear();
                        break;
                }

                Console.WriteLine("What do you want to do today:\n" +
                                  "1:Capture Details\n" +
                                  "2:Check credit qualification\n" +
                                  "3:Show qualification stats\n" +
                                  "4:Exit the program");
                option = Convert.ToInt32(Console.ReadLine());
            }
        }
        static string checkQuali(int e, int yJ, int yR, double s, double d, int c)
        {
            string app = " is not applicable";
            if (e == 1 && yJ >= 1 && yR >= 2)
            {
                if (s * 2 >= d && c <= 6)
                {
                    app = " is applicable";
                }
            }
            return app;
        }
        static string showStats(ArrayList n, ArrayList e, ArrayList j, ArrayList r, ArrayList s, ArrayList d, ArrayList c)
        {
            string print = "-----------------------------------";
            string em = "";
            string ret = "";

            for (int i = 0; i < n.ToArray().Length; i++)
            {
                if (Convert.ToInt32(e[i]) == 1)
                {
                    em = "Yes";
                }
                else
                {
                    em = "No";
                }

                ret += print + "\nName: " + n[i] + 
                    "\nEmployed: " + em + 
                    "\nYears at job: " + j[i] + 
                    "\nYears at residence: " + r[i] + 
                    "\nSalary: R" + s[i] + 
                    "\nNon-mortgage debt: R" + d[i] + 
                    "\nNumber of children: " + c[i] + "\n";
            }
            return ret;
        }
        enum options
        {
            option1 = 1, option2, option3, option4
        }
    }
}