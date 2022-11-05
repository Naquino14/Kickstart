import java.io.*;
import java.math.*;
import java.security.*;
import java.text.*;
import java.util.*;
import java.util.concurrent.*;
import java.util.function.*;
import java.util.regex.*;
import java.util.stream.*;
import static java.util.stream.Collectors.joining;
import static java.util.stream.Collectors.toList;

class Result {

    public static int findFirstPositive(List<Integer> nums, int size) {
        var sortedNums = new ArrayList<Integer>();
        var candidates = new HashSet<Integer>();
        nums.forEach(e -> sortedNums.add(e));

        sortedNums.sort(new CompareNums());

        for (int i = 1; i < sortedNums.size(); i++) {
            int prv = sortedNums.get(i - 1),
                    slf = sortedNums.get(i),
                    diff = slf - prv;
            if (diff > 1 && slf - 1 > 0)
                candidates.add(slf - 1);
        }

        for (Integer e : nums) {
            if (!candidates.contains(e))
                continue;
            else
                return e;
        }
        return size;
    }

}

class CompareNums implements Comparator<Integer> {

    @Override
    public int compare(Integer o1, Integer o2) {
        if (o1 > o2)
            return 1;
        else if (o2 > o1)
            return -1;
        else
            return 0;
    }

}

public class Solution2 {
    public static void main(String[] args) throws IOException {
        BufferedReader bufferedReader = new BufferedReader(new FileReader("input.txt"));
        BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter("output.txt"));

        int n = Integer.parseInt(bufferedReader.readLine().trim());

        List<Integer> nums = Stream.of(bufferedReader.readLine().replaceAll("\\s+$", "").split(" "))
                .map(Integer::parseInt)
                .collect(toList());

        int result = Result.findFirstPositive(nums, n);

        bufferedWriter.write(String.valueOf(result));
        bufferedWriter.newLine();

        bufferedReader.close();
        bufferedWriter.close();
    }
}
