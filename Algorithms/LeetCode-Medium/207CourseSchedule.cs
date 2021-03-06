﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Algorithms.LeetCode_Medium
{
    // This solution makes the most sense: https://leetcode.com/problems/course-schedule/discuss/58713/OO-easy-to-read-java-solution
    class _207CourseSchedule
    {
        //public static void Main()
        //{
        //    int[][] prerequisites = new int[5][]
        //    {
        //        new int[2]{ 2, 0 },
        //        new int[2]{ 2, 1 },
        //        new int[2]{ 3, 2 },
        //        new int[2]{ 4, 3 },
        //        new int[2]{ 2, 3 }
        //    };

        //    var result = CanFinish(5, prerequisites);

        //    Console.WriteLine(result);
        //    Console.ReadLine();
        //}
        
        class Course
        {
            public bool visited = false;
            public bool tested = false;
            public List<Course> pre = new List<Course>();
            public void add(Course c)
            {
                pre.Add(c);
            }
        }
        private static bool isCyclic(Course cur)
        {
            if (cur.tested == true) return false; // If not tested yet, but has been visited, in loop because visited is first
            if (cur.visited == true) return true;  // if visited already then we're now in a loop
            cur.visited = true; // set to true before going in loop
            foreach (Course c in cur.pre) // can go from curr = 2, see 3 as pre-req.. 3 has 2 as a pre-req but 2 .visited = true and tested = false.. so will fail and show cyclic
            {
                if (isCyclic(c)) // recursive call
                {
                    return true;
                }
            }
            cur.tested = true;
            return false;
        }

        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            Course[] courses = new Course[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                courses[i] = new Course(); // add new empty course
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                courses[prerequisites[i][0]].add(courses[prerequisites[i][1]]); // add pre-reqs, reference existing object
            }
            for (int i = 0; i < numCourses; i++)
            {
                if (isCyclic(courses[i])) return false; // check if cyclic
            }
            return true;
        }

        //public static bool CanFinish(int numCourses, int[][] prerequisites)
        //{
        //    // if non-cyclic + # vertices hit = # clases hit, true
        //    // see if cyclic, if cyclic false
        //    if (numCourses <= 0) return false;
        //    Queue<int> queue = new Queue<int>();
        //    int[] inDegree = new int[numCourses]; // represents if each class is a prereq

        //    for (int i = 0; i < prerequisites.Length; i++)
        //    {
        //        inDegree[prerequisites[i][1]]++; // in int[] index for course, add 1 if its a pre-req for something else
        //    }

        //    for (int i = 0; i < inDegree.Length; i++)
        //    {
        //        if (inDegree[i] == 0) queue.Enqueue(i); // start with a course that is NOT a pre-req for anything else
        //    }

        //    while (queue.Count != 0)
        //    {
        //        int i = queue.Dequeue();

        //        for (int j = 0; j < prerequisites.Length; j++)
        //        {
        //            if (i == prerequisites[j][0]) // find current class in prereq 2d array
        //            {
        //                inDegree[prerequisites[j][1]]--; // decrease inDegree for each pre-req found

        //                if (inDegree[prerequisites[j][1]] == 0) queue.Enqueue(prerequisites[j][1]); // add pre-reqs to queue
        //            }
        //        }
        //    }

        //    for (int i = 0; i < inDegree.Length; i++)
        //    {
        //        if (inDegree[i] != 0) return false; // if everything in inDegree array is 0 we're good, if not then bad
        //    }

        //    return true;
        //}
    }
}
