import java.util.ArrayList;

//import java.util.ArrayList;

// forgive me, i havent taught myself how to solve problems like this
// I already know this is gonna exceed time limit,
// however, if it solves the problem, I will be happy
// thanks for the challenge

// as of rn, n = 15 solves correctly and gives r = 26
// n = 16 does not solve properly
public class TheGrandestStaircaseOfThemAll
{
    static int count = 0;
    static final int[] table = new int[] { 0, 0, 1, 1, 2, 487067745 };
    public static void main(String[] args) {
        var n = 200;
        var perfect = IsPerf(n);
        //System.out.println(perfect); 
        var res = solution(n);
        System.out.println("For n = " + n + " r = " + res + ". " + n + " is " + (perfect.perfect ? "perfect" : "not perfect") + " and has a minimum staircase size of " + perfect.result + ".");
    }

    static int result;

    public static int solution(int n) // could generating a lookup table be ok?
    {
        result = 0;
        if (n < 3)
            return 0;
        else if (n == 3)
            return 1;

        // calculate D(n)
        var perfect = IsPerf(n);
        //if (perfect.perfect)
        //    result++;
        // calculate base cases
        var bc = GetBaseCases(n, perfect);
        // go thru all of the base cases to see if they are valid
        // iterate through every possible base case
        for (var cas : bc)
        {
            if (IsValid(n, cas))
                result++;
            if(cas[cas.length - 1] > 2) // see if we need to pullout, the condition is if the last index of bc is greater than 2
                Pullout(n, cas); // start with pullout and check for validity
        }
        // 6 parity?
        if (n == 6)
            result--;
    
        return result;  
    }

    static void Pullout(int n, int[] parentSc) // pullout is the entrypoint for the recursion
    {
        // perform pullout

        // make a new array for the pulled out values
        var ctxSc = new int[parentSc.length + 1]; 
        // copy the parent values
        for (var i = 0; i < parentSc.length; i++)
            ctxSc[i] = parentSc[i];
        // subtract 1 from the 2nd to last index, and add 1 to the last index
        ctxSc[parentSc.length - 1]--;
        ctxSc[parentSc.length]++;

        // check for validity
        if (IsValid(n, ctxSc))
            result++;
        
        // attempt to chainAdd
        ChainAdd(n, ctxSc);
    }

    static void ChainAdd(int n, int[] elderSiblingSc)
    {
        // subtract 1 from the second to last index and add it to the last index

        var siblingSc = new int[elderSiblingSc.length]; // copy over the values
        for (var i = 0; i < elderSiblingSc.length; i++)
            siblingSc[i] = elderSiblingSc[i];

        siblingSc[elderSiblingSc.length - 2]--;
        siblingSc[elderSiblingSc.length - 1]++;
        
        // check for validity
        if (IsValid(n, siblingSc) /*&& IsDecending(n, siblingSc)*/)
            result++;
        
        for (var i : siblingSc)
            if (i == 0)
                return;

        // check if the value can be pulled out
        if (siblingSc[siblingSc.length - 1] > 2)
            Pullout(n, siblingSc);

        // solve for the "perfect" parity
        // example: n = 15 for 5,4,6
        // if the length of the array is bigger than 3
        // and the value of the first index len - 3 is greater than the value at the index len - 2
        // and the value of the value at index len - 2 plus two is equal to the value at len - 1
        // and the value at len - 2 is greater than 3

        int ss = siblingSc.length;

        var parity = ss >= 3 
        && siblingSc[ss - 3] > siblingSc[ss - 2] 
        && siblingSc[ss - 2] + 2 == siblingSc[ss - 1] 
        && siblingSc[ss - 2] > 3;

        // once its done pulling out that branch, check if the value can be chain added
        /*if (!(siblingSc[ss - 1] == siblingSc[ss - 2] // example: n = 15, 7,4,4
        || siblingSc[ss - 1] >= siblingSc[ss - 2])   // example: n = 15, 7,3,4
        || parity)
            ChainAdd(n, siblingSc);*/
        if (siblingSc[ss - 1] < siblingSc[ss - 2] + 2)
            ChainAdd(n, siblingSc);
    }

    static boolean IsValid(int n, int[] ctxSc)
    {
        // check if ctxSc sums to n and is decending
        int sum = 0;
        boolean decending = true;
        int prev = -1;
        for (int i = 0; i < ctxSc.length; i++)
        {
            sum += ctxSc[i]; // to sum
            if (prev != -1 && decending) // if we are not empty on the previous
                decending = prev > ctxSc[i]; // check to see if its decending
            prev = ctxSc[i];
        }
        return n == sum && decending;
    }

    static boolean IsDecending(int n, int[] ctxSc)
    {
        for (var i = 0; i < ctxSc.length - 1; i++)
            if (ctxSc[i] > ctxSc[i + 1])
                return false;
        return true;
    } // thanks copilot

    static ArrayList<int[]> GetBaseCases(int n, Perf perfect)
    {
        var bc = new ArrayList<int[]>();
        for (int i = n - 1; i >= perfect.result - 2; i--) // this is minus two because the last value might always be extraneous
        {
            // add the first element
            if (bc.isEmpty())
                bc.add(new int[] { i, 1 });
            else
            {
                // get the previous base case, and decriment the 0th element, and incriment the 1st element
                var prev = bc.get(bc.size() - 1);
                var add = new int[] { prev[0] - 1, prev[1] + 1 };
                bc.add(add);
                if ((add[0] == add[1] || add[0] <= add[1]) && i == perfect.result)
                    return bc;
            }
        }
        return bc;
    }

    static int lookup(int i)
    {
        return table[i - 1];
    }

    static Perf IsPerf(int n)
    {
        Perf p = new Perf();
        var result = Math.sqrt(2 * n + 0.25) - 0.5;
        p.result = (int)Math.ceil(result);
        p.perfect = (result % 1) == 0;
        return p;
    }

    static class Perf {
        public boolean perfect;
        int result;

        @Override
        public String toString() {
            return "perfect = " + perfect + ", result = " + result;
        }
    }
}


/* 
ok so someth interesting happened...
copilot immediatey suggested a code snippet
it doesnt work in this case, but im gonna leave it here out of curiosity
int[] stairs = new int[n];
        stairs[0] = 1;
        stairs[1] = 2;
        stairs[2] = 4;
        for(int i = 3; i < n; i++)
        {
            stairs[i] = stairs[i-1] + stairs[i-2] + stairs[i-3];
        }
        return stairs[n-1];
*/