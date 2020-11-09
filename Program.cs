using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Registrador
{
    static class Program
    {
        static void Main(string[] args)
        {
            //{path}, {path2}, {grupo}
            Registrador(args[0], args[1], args[2]);

        }

        public static void Registrador(string members, string subjects, string groupsGiven){
            //taking info and setting them on lists.
            List<string> membersList = File.ReadAllLines(members).ToList();
            List<string> subjectsList = File.ReadAllLines(subjects).ToList();
            int groups = Convert.ToInt32(groupsGiven);

            membersList.Shuffle();
            subjectsList.Shuffle();
            
            //Basic logic to know how many people are going into a group.
            int membersAndGroups = membersList.Count / groups;
            int memberswithoutgroup = membersList.Count % groups;
            //same thing, but with subjects.
            int subjectsAndGroups = subjectsList.Count / groups;
            int subjectswithoutuse = subjectsList.Count % groups;

            if(membersList.Count != 0 && subjectsList.Count > groups){


                for(int i = 0; i < groups; i++){
                    Console.Write($"Group: {i + 1}.- ");

                    Console.WriteLine();

                    for(int a = 0; a < membersAndGroups; a++){
                        Console.WriteLine(membersList[0]);
                        membersList.RemoveAt(0);
                    }

                    if(memberswithoutgroup > 0){

                        Console.WriteLine(membersList[0]);
                        membersList.RemoveAt(0);
                        memberswithoutgroup--;

                    }
                    Console.Write($"Subjects: {i + 1}.- ");
                    Console.WriteLine();

                    for(int q = 0; q < subjectsAndGroups; q++){
                        Console.WriteLine("------" + subjectsList[0]);
                        subjectsList.RemoveAt(0);
                    }

                    if(subjectswithoutuse > 0){

                        Console.WriteLine(subjectsList[0]);
                        subjectsList.RemoveAt(0);
                        subjectswithoutuse--;

                    }
                }
                
            }else{
                Console.WriteLine("Wrong data. Change the file and try again.");
            }

            Console.ReadKey();

        }

        private static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)  
        {  
            Random rng = new Random();
            int n = list.Count;  
            while(n>1){
                n--;
                int k = rng.Next(n+1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            
        }
        
              
               
    }
}
