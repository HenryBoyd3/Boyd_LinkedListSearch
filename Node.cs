using System;
using System.Collections.Generic;
using System.Text;

namespace Boyd_LinkedListSearch
{
    class Node
    {
        internal class MetaData
        {
            internal string name;
            internal string genders;
            internal int popularity = 0;
        }

        private static int totalNodes;
        private static int totalMaleNodes;
        private static int totalFemaleNodes;
        private static Node mostPopMale;
        private static Node mostPopFemale;
        public Node next;
        public Node privous;
        public Node firstNameofLetter;
        public Node lastNameofLetter;
        public MetaData Data;


        public Node(string Letter)//for building the first list of just letters
        {
            MetaData data = new MetaData();
            next = null;
            privous = null;
            firstNameofLetter = null;
            lastNameofLetter = null;
            data.name = Letter;
            data.genders = string.Empty;
            data.popularity = 0;
            Data = data;
        }

        public Node(string Name, string Gender, int Pop)
        {
            MetaData data = new MetaData();
            data.name = Name.ToUpper();
            data.genders = Gender.ToUpper();
            data.popularity = Pop;

            //I don't know if I should move this to its own function becuse it is never repeated but it is also in the constrotor
            //and I think that should have less inside of it
            if (Gender == "M" && mostPopMale == null)
            {
                mostPopMale = this;
                totalMaleNodes++;
            }
            else if (Gender == "M" && Pop > mostPopMale.Data.popularity)
            {
                mostPopMale = this;
                totalMaleNodes++;
            }
            else if (Gender == "M")
            {
                totalMaleNodes++;
            }

            if (Gender == "F" && mostPopFemale == null)
            {
                mostPopFemale = this;
                totalFemaleNodes++;
            }
            else if (Gender == "F" && Pop > mostPopFemale.Data.popularity)
            {
                mostPopFemale = this;
                totalFemaleNodes++;
            }
            else if (Gender == "F")
            {
                totalFemaleNodes++;
            }


            next = null;
            privous = null;
            totalNodes++;
            Data = data;
        }

        public string getUserInfo()
        {
             string nameInfo = string.Format("This persons Name is {0}, their gender is {1} and their Popularity is {2}",
                    Data.name, Data.genders, Data.popularity);
            return nameInfo;
        }

        public string TotalNodes()
        {
            return totalNodes.ToString();
        }
        public string TotalMaleNodes()
        {
            return totalMaleNodes.ToString();
        }
        public string TotalFemaleNodes()
        {
            return totalFemaleNodes.ToString();
        }

        public string GetPopMale()
        {
            string popInfo = string.Format ("The most popular Male Name is {0} and their Popularity is {1}",
                mostPopMale.Data.name, mostPopMale.Data.popularity);
            return popInfo;
        }
        public string GetPopFemale()
        {
            string popInfo = string.Format("The most popular Female Name is {0} and their Popularity is {1}",
            mostPopFemale.Data.name, mostPopFemale.Data.popularity);
            return popInfo;
        }

    }
}
