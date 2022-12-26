using System;
using System.Reflection;

class Hello
{

    static void Main()
    {
        Random rnd = new Random();
        int N = Convert.ToInt32(Console.ReadLine());
        int[] nums = new int[N];

        for (int i = 0; i < N; i++)
        {
            nums[i] = rnd.Next(1, N);
        }
        nums = nums.Distinct().ToArray();

        foreach (int i in nums)
            Console.WriteLine(i);

        Array.Sort(nums);

        int first = 0;
        int last = 0;
        List<string> rngs = new List<string>();
        for (int i = 0; i < nums.Length - 1; i++)
        {
            int flag = nums[i + 1] - nums[i];
            if (flag == 1)
            {
                if (first == 0)
                    first = nums[i];
            }
            else if ((flag != 1) || (flag == 1  && nums[nums.Length-1]>1))
            {
                last = nums[i];
                if (first != 0)
                {
                    rngs.Add(Convert.ToString(first) + "," + Convert.ToString(last));
                }
                first = 0;
                last = 0;
            }

        }
        int maxL = 0;
        string res = "";
        foreach (string j in rngs)
        { 
            string[] el = j.Split(new char[] { ',' });
            int[] ints = Array.ConvertAll(el, s => int.Parse(s));
            int curL = ints[1] - ints[0];
            if (curL > maxL)
            {
                maxL = curL;
                res = j;
                curL = 0;
            }    
        }
        Console.WriteLine("----------------------");
        Console.WriteLine(res);
    }
}