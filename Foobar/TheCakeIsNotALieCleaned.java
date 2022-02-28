import java.util.ArrayList;
public class TheCakeIsNotALieCleaned {
    public static int solution(String x)
    {
        int result = 1;
        int n = 1;
        for (;;)
        {
            if (n == x.length())
            {
                boolean valid = true;
                char prv = x.charAt(0);
                for (int i = 1; i < x.length(); i++)
                    if (x.charAt(i) != prv)
                        valid = false;
                return valid ? n : result;
            }
            else if (x.length() % n != 0)
            { n++; continue; }
            else
            {
                int length = x.length() / n;
                var substrings = new ArrayList<String>();
                for (int i = 0; i < x.length(); i += length)
                    substrings.add(x.substring(i, i + length));
                String prevSubstring = substrings.get(0);
                boolean valid = true;
                for (int i = 1; i < substrings.size(); i++)
                {
                    if (!prevSubstring.equals(substrings.get(i)))
                        {
                            valid = false;
                            break;
                        }
                    else
                        prevSubstring = substrings.get(i);
                }
                if (valid)
                    result = n;
                n++;
            }
        }
    }
}
