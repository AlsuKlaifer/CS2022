namespace AISD
{
    public class Count
    {
        public static void Recursion(char[] charList, int loBound, int upBound)
        {
            for (int i = loBound; i <= upBound; i++)
            {
                swap(ref charList[loBound], ref charList[i]);
                if (loBound == upBound)
                {
                    Console.Write(charList);
                    Console.WriteLine("");
                }
                Recursion(charList, loBound + 1, upBound);
                swap(ref charList[loBound], ref charList[i]);
            }
        }
        public static void swap(ref char a, ref char b)
        {
            if (a == b) return;
            a ^= b;
            b ^= a;
            a ^= b;
        }
    }
}
