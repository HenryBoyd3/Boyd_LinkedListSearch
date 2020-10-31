using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;

namespace Boyd_LinkedListSearch
{
    class LinkedList
    {
       private  Node head = null;
       private  Node tail = null;
       private stopwatch sw; 

        public LinkedList(stopwatch stopwatch)
        {
            MakeAlphlist();
            addList();
            sw = stopwatch;
        }

        public Node add(string Name, string Gender, int Pop)
        {
            
            Node currentLetter = FindFirstLetterGroup(Name[0].ToString()); ;
            Node newNameNode = new Node(Name, Gender, Pop);

            if (currentLetter.firstNameofLetter == null)
            {
                currentLetter.firstNameofLetter = newNameNode;
                currentLetter.lastNameofLetter = newNameNode;
                return newNameNode;

            }
            Node currentNode = currentLetter.firstNameofLetter;
            while (currentNode != null)
            {
                Node nextNode = currentNode.next;

                //add to start of the list
                if (currentNode.Data.name.CompareTo(Name.ToUpper()) > 0)
                {

                    newNameNode.next = currentLetter.firstNameofLetter;
                    currentLetter.firstNameofLetter = newNameNode;
                    currentNode.privous = newNameNode;
                    return newNameNode;

                }
                //add to end of list
                else if (nextNode == null)
                {
                    currentNode.next = newNameNode;
                    newNameNode.privous = currentNode;
                    currentLetter.lastNameofLetter = newNameNode;
                    return newNameNode;
                }
                // add to middle of the list
                else if (currentNode.Data.name.CompareTo(Name.ToUpper()) < 0 && nextNode.Data.name.CompareTo(Name.ToUpper()) >= 0)
                {
                    currentNode.next = newNameNode;
                    currentNode.next.privous = currentNode;
                    currentNode.next.next = nextNode;
                    nextNode.privous = currentNode.next;
                    return currentNode.next;
                }
                else
                {
                   currentNode = currentNode.next;
                }
                
            }

            return null;
        }

        public Node search(string Letters) 
        {
            sw.nodesMovedThrough = 0;
            Letters = Letters.ToUpper();
            Node mainLetter = FindFirstLetterGroup(Letters[0].ToString());
            Node currentNode =null;
            if (Letters[1].ToString().CompareTo("M") > 0)
            {
                currentNode = mainLetter.lastNameofLetter;
                while (currentNode != null)
                {
                    sw.nodesMovedThrough++;
                    if (currentNode == null)
                    {

                        return null;
                    }

                    if (currentNode.Data.name.CompareTo(Letters.ToUpper()) == 0)
                    {
                       
                        return currentNode;
                    }

                    currentNode = currentNode.privous;
                }
            }
            else
            {
                currentNode = mainLetter.firstNameofLetter;
                while (currentNode != null)
                {
                    sw.nodesMovedThrough++;
                    if (currentNode == null)
                    {

                        return null;
                    }

                    if (currentNode.Data.name.CompareTo(Letters.ToUpper()) == 0)
                    {
                        return currentNode;
                    }

                    currentNode = currentNode.next;
                }
            }

            return null;

        }
        public Node search(string Letters, string gender)
        {
            sw.nodesMovedThrough = 0;
            Letters = Letters.ToUpper();
            Node mainLetter = FindFirstLetterGroup(Letters[0].ToString());
            Node currentNode = null;
            if (Letters[1].ToString().CompareTo("M") > 0)
            {
                currentNode = mainLetter.lastNameofLetter;
                while (currentNode != null)
                {
                    sw.nodesMovedThrough++;
                    if (currentNode == null)
                    {

                        return null;
                    }

                    if (currentNode.Data.name.CompareTo(Letters.ToUpper()) == 0 && currentNode.Data.genders.CompareTo(gender.ToUpper()) == 0)
                    {

                        return currentNode;
                    }

                    currentNode = currentNode.privous;
                }
            }
            else
            {
                currentNode = mainLetter.firstNameofLetter;
                while (currentNode != null)
                {
                    sw.nodesMovedThrough++;
                    if (currentNode == null)
                    {

                        return null;
                    }

                    if (currentNode.Data.name.CompareTo(Letters.ToUpper()) == 0 && currentNode.Data.genders.CompareTo(gender.ToUpper()) == 0)
                    {
                        return currentNode;
                    }

                    currentNode = currentNode.next;
                }
            }

            return null;

        }

        private void MakeAlphlist()
        {
            Node letterA = new Node("A");
            head = letterA;
            tail = head;

            for (char c = 'B'; c <= 'Z'; c++)
            {

                Node letter = new Node(c.ToString());

                tail.next = letter;
                tail.next.privous = tail;
                tail = tail.next;

            }
        }
        private Node FindFirstLetterGroup(string letter)
        {
            Node current = head;
            if (isHeadNull())
            {
                return null;
            }
            //if first item is the node looking for
            if (current.Data.name[0].ToString() == letter)
            {
                
                return current;
            }
            while (current.next != null)
            {

                current = current.next;
                // to not skip the last item in the list
                if (current.Data.name[0].ToString() == letter)
                {
                    
                    return current;
                }

            }
            return head;
        }

        private void addList()
        {

            string fileName = "yob2019.txt";
            string fileDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = Path.Combine(fileDirectory, fileName);
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
               string[] test = line.Split(",");
                add(test[0], test[1], int.Parse(test[2])); 
            }
        }

        private bool isHeadNull()
        {
            if (head == null)
            {
                return true;
            }
            return false;
        }

        //this is made so if I change anything about how I get the most poplular nodes or total nodes I only need to 
        //change it inside of the node class not 2 places.
        public string getMostPopMale() 
        {
            return head.GetPopMale();
        }
        public string getMostPopFemale() 
        {
            return head.GetPopFemale();
        }
        public string getTotalNodes() 
        {
            return head.TotalNodes();
        }
        public string getTotalMaleNodes() 
        {
            return head.TotalMaleNodes();
        }
        public string getTotalFemaleNodes() 
        {
            return head.TotalFemaleNodes();
        }





    }
}
