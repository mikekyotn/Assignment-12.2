using System.Runtime.CompilerServices;

namespace Assignment_12._2
{
    //Given the head of a linked list and an integer val,
    //remove all the nodes of the linked list that has Node.val == val, and return the new head.
    //Status: Complete
    //Time complexity: O(n) for iterating recursively through linked list.
    internal class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node(1);
            Node current = head;
            current = AddNode(current, 2);
            current = AddNode(current, 6);
            current = AddNode(current, 3);
            current = AddNode(current, 4);
            current = AddNode(current, 5);
            current = AddNode(current, 6);
            Console.Write("Original: ");
            PrintLL(head);
            Node removed = RemoveValue(head, 6);
            Console.Write("Remove 6: ");
            PrintLL(removed);

            //head = new Node();
            Node head1 = null;
            Console.Write("Original: ");
            PrintLL(head1);
            removed = RemoveValue(head1, 1);
            Console.Write("Remove 1: ");
            PrintLL(removed);

            head = new Node(7);
            current = head;
            current = AddNode(current, 7);
            current = AddNode(current, 7);
            current = AddNode(current, 7);
            Console.Write("Original: ");
            PrintLL(head);
            removed = RemoveValue(head, 7);
            Console.Write("Remove 7: ");
            PrintLL(removed);

            Console.ReadKey();
        }

        public class Node
        {
            public int? data; //make it nullable for test case 2
            public Node next;
            public Node(int data = 0, Node next = null)
            {
                this.data = data;
                this.next = next;
            }
        }

        public static Node RemoveValue(Node startNode, int deleteVal)
        {
            //first find the first non-deleteVal node and assign that to head and current
            //current iterates through till null and if current.next.data=deleteVal
            //then current.next = current.next.next.
            //don't move yet because current.next.next.val may be deleteval so retest till not deleteVal
            //then current = current.next
            if (startNode == null)
            {
                return null;
            }
            while (startNode.data == deleteVal) 
            {
                startNode = startNode.next;
                if (startNode == null)
                    return null;
            }
            Node current = startNode;
            current.next = RemoveValue(current.next, deleteVal);
            return current;          
        }
        static Node AddNode(Node current, int val)
        {
            current.next = new Node(val, null);
            return current.next;
        }
        static void PrintLL(Node startNode)
        {
            Node printNode = startNode;
            while (printNode != null)
            {
                Console.Write(printNode.data);
                printNode = printNode.next;
            }
            Console.WriteLine();
        }
    }
}
