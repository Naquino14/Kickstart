import java.util.ArrayList;
public class HeyIAlreadyDidThatCleaned {
    static int solution(String n, int b)
    {
        var nList = new ArrayList<String>();
        String startLoop = "";
        for(;;)
        {
            if (startLoop != "")
            {
                int i = 0;
                for (; i < nList.size(); i++)
                    if (nList.get(i).equals(startLoop))
                        break;
                return nList.size() - i - 1;
            }
            int x = Integer.parseInt(Sort(n, false), b), 
                y =  Integer.parseInt(Sort(n, true), b);
            var z = Integer.toString(x - y, b);
            n = z;
            if (startLoop == "")
                for (int i = 0; i < nList.size(); i++)
                    if (n.equals(nList.get(i)))
                            startLoop = n;
            nList.add(z);
        }
    }

    static String Sort(String n, boolean descending)
    {
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
