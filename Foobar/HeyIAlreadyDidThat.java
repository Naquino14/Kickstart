import java.util.ArrayList;

public class HeyIAlreadyDidThat {
    public static void main(String[] args) {
        System.out.println(solution("1211", 10));
    }

    static int solution(String n, int b)
    {
        // n will always be a nonnegative integer in base b
        // b will always be a positive integer
        // n will always be a nonempty string
        // two integers x and y are created
        // x and y will be the length of n and
        // x is the digits of n in ascending order and
        // y is the digits of n in descending order
        // define z as x - y
        // assign n to z and repeat

        // im gonna start by writing out this function
        // then ill come back to implement the solution 
        
        // math must be done base b
        
        // create a list of strings
        var nList = new ArrayList<String>();
        String startLoop = "";
        
        for(;;) // the breakout condition is when we see that a number previously in a stack is present in the loop
        {
            if (startLoop != "")
            {
                int i = 0;
                for (; i < nList.size(); i++)
                    if (nList.get(i).equals(startLoop))
                        break;
                return nList.size() - i - 1;
            }

            // parse the integer with base b
            int x = Integer.parseInt(Sort(n, false), b), y;

            // sort y into descending order
            y = Integer.parseInt(Sort(n, true), b);

            // x and y are now in base 10

            // subtract x from y and assign to z in base b
            // i think if i just comvert from base b to base 10, 
            // subtract, then convert back, it should work...

            // convert z from base 10 to base b
            String z = Integer.toString(x - y, b);

            n = z;

            // TODO: is this in the right place?
            // TODO: ?????
            // check the nList to see if we are looping
            if (startLoop == "")
                for (int i = 0; i < nList.size(); i++)
                    if (n.equals(nList.get(i)))
                            startLoop = n;

            nList.add(z);
        }
    }

    static String Sort(String n, boolean descending)
    {
        // if ascending is true, sort n into ascending order
        // if ascending is false, sort n into descending order
        if (descending)
        {
            char[] nArray = n.toCharArray();
            for (int i = 0; i < nArray.length; i++)
            {
                for (int j = i + 1; j < nArray.length; j++)
                {
                    if (nArray[i] > nArray[j])
                    {
                        char temp = nArray[i];
                        nArray[i] = nArray[j];
                        nArray[j] = temp;
                    }
                }
            }
            return new String(nArray);
        }
        else
        {
            char[] nArray = n.toCharArray();
            for (int i = 0; i < nArray.length; i++)
            {
                for (int j = i + 1; j < nArray.length; j++)
                {
                    if (nArray[i] < nArray[j])
                    {
                        char temp = nArray[i];
                        nArray[i] = nArray[j];
                        nArray[j] = temp;
                    }
                }
            }
            return new String(nArray);
        }
    }
}
