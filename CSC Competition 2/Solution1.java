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

    public static List<Integer> sort_colors(List<Integer> all_colors, List<Integer> color_order, int n, int m) {
        List<Integer> o = new ArrayList<>();
        all_colors.forEach(e -> o.add(e));

        CompareColors comparator = new CompareColors(color_order);
        o.sort(comparator);

        return o;
    }

}

class CompareColors implements Comparator<Integer> {
    static Map<Integer, Integer> order;

    public CompareColors(List<Integer> order) {
        CompareColors.order = new TreeMap<>();
        for (int i = 0; i < order.size(); i++) {
            Integer e = order.get(i);
            CompareColors.order.put(e, i);
        }
    }

    @Override
    public int compare(Integer o1, Integer o2) {
        int o1i = order.get(o1),
                o2i = order.get(o2);
        if (o1i > o2i)
            return 1;
        else if (o2i > o1i)
            return -1;
        else
            return 0;
    }

}

public class Solution1 {
    public static void main(String[] args) throws IOException {
        BufferedReader bufferedReader = new BufferedReader(new FileReader("input.txt"));
        BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter("output.txt"));

        String[] firstMultipleInput = bufferedReader.readLine().replaceAll("\\s+$", "").split(" ");

        int n = Integer.parseInt(firstMultipleInput[0]);

        int m = Integer.parseInt(firstMultipleInput[1]);

        List<Integer> all_colors = Stream.of(bufferedReader.readLine().replaceAll("\\s+$", "").split(" "))
                .map(Integer::parseInt)
                .collect(toList());

        List<Integer> color_order = Stream.of(bufferedReader.readLine().replaceAll("\\s+$", "").split(" "))
                .map(Integer::parseInt)
                .collect(toList());

        List<Integer> result = Result.sort_colors(all_colors, color_order, n, m);

        bufferedWriter.write(result.toString());
        bufferedWriter.newLine();

        bufferedReader.close();
        bufferedWriter.close();
    }
}
