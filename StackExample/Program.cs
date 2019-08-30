using System;
using System.Collections.Generic;

namespace StackExample {

    class Program {

        static Stack<long> stack = new Stack<long>(); //long is 2x of int digit slots

        static bool Calculate() {
            Console.Write("Enter a number or operator. x to calculate, X to quit: ");
            var response = Console.ReadLine();      //read the input and store in variable. Always comes out as string, so parse later for other var type.
            switch(response) {
                case "+": {                  //curly brackets added here to add scope so that variables can be reused
                    var p1 = stack.Pop();
                    var p2 = stack.Pop();
                    var result = p2 + p1;
                    stack.Push(result);
                    break;
                }
                case "-": { 
                    var p1 = stack.Pop();
                    var p2 = stack.Pop();
                    var result = p2 - p1;
                    stack.Push(result);
                    break;
                }
                case "*": {
                    var p1 = stack.Pop();
                    var p2 = stack.Pop();
                    var result = p2 * p1;
                    stack.Push(result);
                    break;
                }
                case "/": {
                    var p1 = stack.Pop();
                    var p2 = stack.Pop();
                    var result = p2 / p1;
                    stack.Push(result);
                    break;
                }
                case "x": {
                    var answer = stack.Pop();
                    Console.WriteLine($"Answer is {answer}");
                    break;
                }
                case "X": {
                    return false;
                }
                default: {
                    var number = long.Parse(response); //parse will take string and convert to long
                    stack.Push(number);
                    break;
                }
            }
            return true;
        }

        static void Main(string[] args) {
            var runAgain = true;
            while(runAgain) {
                runAgain = Calculate();
            }
        }

        static void Test() { //emptied main method by putting the code below in to another method for testing.
            /*
             * Stacks. Push data in, pop data off. Push(i) | i = Pop().
             * 
             * 1 + 2 = 3
             * 1 + (2 * 3) = 7          fine, but needs parenthesis. infix notation, referring to location of operators.
             * 1 2 3 * + = syntax for evaluation order. postfix notation, works well with stacks. 
             *  takes first two numbers, pops them and executes first operation, then returns result to stack.
             *  
             *  1 2 3 * + = 
             *  
             *  3 |
             *  2 |-Stack is build like this
             *  1 |
             *  
             *  Pops the top two (3 and 2) and multiplies, then sends result to top of stack.
             *  
             *  6 |
             *  1 | - stack after first operation. Then does the addition and returns result to top of stack.
             *  
             *  7 | - last item at top of stack is the answer.
             *  
            */


            //1 + (2 * 3)
            //1 2 3 * +
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            var i1 = stack.Pop(); //top of stack and takes out of stack
            var i2 = stack.Pop(); //new top item in stack
            var i3 = i1 * i2;
            stack.Push(i3);
            i1 = stack.Pop();
            i2 = stack.Pop();
            i3 = i1 + i2;
            stack.Push(i3);

            var ans = stack.Pop();
            Console.WriteLine($"Answer = {ans}");

            //
            //-22 / 2 * 7
            //-22 2 / 7 *
            var stack1 = new Stack<int>();
            stack.Push(-22);
            stack.Push(2);
            var j1 = stack.Pop(); //top of stack and takes out of stack
            var j2 = stack.Pop(); //new top item in stack
            var j3 = j2 / j1; //make sure division and subtraction happen in the correct order
            stack.Push(j3);
            stack.Push(7);
            j1 = stack.Pop();
            j2 = stack.Pop();
            j3 = j1 * j2;
            stack.Push(j3);

            var jans = stack.Pop();
            Console.WriteLine($"Answer = {jans}");

        }
    }
}
