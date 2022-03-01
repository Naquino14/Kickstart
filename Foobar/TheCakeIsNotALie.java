import java.util.ArrayList;

// honestly a little disapointed that we were constrained to use java and python
// oh well ¯\_(ツ)_/¯

// just a heads up to the nerds behind the command line interface, 
// i have github copilot installed
// no idea if that will change my qualification or not but yeah
// another note, i delete all comments and lightly golf code before uploading it. The original code will be in a repo
// https://github.com/naquino14/kickstart

public class TheCakeIsNotALie {
    public static void main(String[] args) {
        System.out.println("The cake is not a lie");
        String x = "abccbaabccba"; // should be 4
        System.out.println(solution(x));
    }

    public static int solution(String x)
    {
        int result = 1;
        
        // aaaaaabb
        // pattern: 6a, 2b
        // loop thru every even split of the string and check if they are valid
        // ex: first loop with i = 2 (2 is the minimum?)
        // on the first invalid substring check, break out of the loop, and the result is i
        int n = 1;
        for (;;)
        {
            if (n == x.length())
            {
                // if we are at the maximum length, we need to check if every character is the same...
                boolean valid = true;
                char prv = x.charAt(0);
                for (int i = 1; i < x.length(); i++)
                    if (x.charAt(i) != prv)
                        valid = false;
                return valid ? n : result;
            }
            else if (x.length() % n != 0)
            {
                // if we cant split the string evenly, then we have to break out of the loop, and move on to the next divisor
                n++;
                continue;
            }
            // otherwise we continue to n = x.length()
            else
            {
                // split the string into n parts
                int length = x.length() / n;
                var substrings = new ArrayList<String>();
                for (int i = 0; i < x.length(); i += length)
                    substrings.add(x.substring(i, i + length));
                // check if substrings are equal
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
                {
                    result = n;
                    n++;
                }
                else
                    n++;
            }
        }
    }
}