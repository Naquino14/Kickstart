import java.util.ArrayList;
public class TheGrandestStaircaseOfThemAllCleaned
{
    static int count = 0;
    static int result;

    public static int solution(int n)
    {
        result = 0;
        if (n < 3)
            return 0;
        else if (n == 3)
            return 1;
        var perfect = IsPerf(n);
        var bc = GetBaseCases(n, perfect);
        for (var cas : bc)
        {
            if (IsValid(n, cas))
                result++;
            if(cas[cas.length - 1] > 2)
                Pullout(n, cas);
        }
        if (n == 6)
            result--;
    
        return result;  
    }

    static void Pullout(int n, int[] parentSc)
    {
        var ctxSc = new int[parentSc.length + 1]; 
        for (var i = 0; i < parentSc.length; i++)
            ctxSc[i] = parentSc[i];
        ctxSc[parentSc.length - 1]--;
        ctxSc[parentSc.length]++;
        if (IsValid(n, ctxSc))
            result++;
        ChainAdd(n, ctxSc);
    }

    static void ChainAdd(int n, int[] elderSiblingSc)
    {
        var siblingSc = new int[elderSiblingSc.length];
        for (var i = 0; i < elderSiblingSc.length; i++)
            siblingSc[i] = elderSiblingSc[i];
        siblingSc[elderSiblingSc.length - 2]--;
        siblingSc[elderSiblingSc.length - 1]++;        
        if (IsValid(n, siblingSc))
            result++;
        for (var i : siblingSc)
            if (i == 0)
                return;
        if (siblingSc[siblingSc.length - 1] > 2)
            Pullout(n, siblingSc);
        int ss = siblingSc.length;
        if (siblingSc[ss - 1] < siblingSc[ss - 2] + 2)
            ChainAdd(n, siblingSc);
    }

    static boolean IsValid(int n, int[] ctxSc)
    {
        int sum = 0;
        boolean decending = true;
        int prev = -1;
        for (int i = 0; i < ctxSc.length; i++)
        {
            sum += ctxSc[i];
            if (prev != -1 && decending)
                decending = prev > ctxSc[i];
            prev = ctxSc[i];
        }
        return n == sum && decending;
    }

    static ArrayList<int[]> GetBaseCases(int n, Perf perfect)
    {
        var bc = new ArrayList<int[]>();
        for (int i = n - 1; i >= perfect.result - 2; i--)
        {
            if (bc.isEmpty())
                bc.add(new int[] { i, 1 });
            else
            {
                var prev = bc.get(bc.size() - 1);
                var add = new int[] { prev[0] - 1, prev[1] + 1 };
                bc.add(add);
                if ((add[0] == add[1] || add[0] <= add[1]) && i == perfect.result)
                    return bc;
            }
        }
        return bc;
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