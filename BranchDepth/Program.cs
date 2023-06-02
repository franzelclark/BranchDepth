using System;
using System.Collections.Generic;

namespace BranchDepth
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating the given structure
            // 11 total nodes
            Branch root = new Branch();
            Branch branchA = new Branch();
            Branch branchB = new Branch();
            Branch branchC = new Branch();
            Branch branchD = new Branch();
            Branch branchE = new Branch();
            Branch branchF = new Branch();
            Branch branchG = new Branch();
            Branch branchH = new Branch();
            Branch branchI = new Branch();
            Branch branchJ = new Branch();

            // Root                                        DEPTH 1                         O

            root.addBranch(branchA);                        
            root.addBranch(branchB);                    // DEPTH 2                         

            // Node A has 1 child                      
            branchA.addBranch(branchC);                 //  DEPTH 3 

            // Node B has 3 children
            branchB.addBranch(branchD);
            branchB.addBranch(branchE);
            branchB.addBranch(branchF);                 //   DEPTH 3

            // Node D has 1 child
            branchD.addBranch(branchG);                 //  DEPTH 4

            // Node E has 2 children                    
            branchE.addBranch(branchH);                 // DEPTH 4
            branchE.addBranch(branchI);                 // DEPTH 4

            // Node H has 1 child
            branchH.addBranch(branchJ);                 //  DEPTH 5

            // Calculate the depth
            int depth = root.calculateDepth();          // Start at Root
            Console.WriteLine("Depth: " + depth);
        }
    }

    class Branch
    {
        List<Branch> branches;                                  // Tree as a LinkedList

        public Branch()
        {
            branches = new List<Branch>();
        }

        public void addBranch(Branch branch)
        {
            branches.Add(branch);                             // Add a child
        }

        public int calculateDepth()
        {
            int maxDepth = 0;                               
            foreach (Branch branch in branches)            // Repeat until all branches have been visited
            {
                int depth = branch.calculateDepth();       // Call oneself again, recursively calculate depth in each branch
                if (depth > maxDepth)                      // Compare if current is bigger
                    maxDepth = depth;                      // If current depth is bigger, set to new max depth
            }
            return maxDepth + 1;        
        }
    }
}