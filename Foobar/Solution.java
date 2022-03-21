import java.util.InputMismatchException;
import java.util.Scanner;

public class Solution {

    static int[][] p = new int[201][201];

    public static void fillP() {
        p[1][1] = 1;
        p[2][2] = 1;
        for (int w = 3; w < 201 ; w++)
             for (int m = 1; m <= w; m++)
                if (w-m == 0)
                    p[w][m] = 1 + p[w][m-1];
                else if (w-m < m) 
                    p[w][m] =  p[w-m][w-m] + p[w][m-1];
                else if (w-m == m)
                    p[w][m] = p[m][m-1] + p[w][m-1];
                else if (w-m >m)
                    p[w][m] = p[w-m][m-1] + p[w][m-1];
    }

    public static int answer(int n) 
    { return p[n][n] - 1; }

    public static void main(String[] args) {
        System.out.println("Generating table...");
        fillP();
        System.out.println("Input a value:");
        try (var scanner = new Scanner(System.in)) {
            for(;;)
            {
                int inp;
                try
                { inp = scanner.nextInt(); }
                catch (InputMismatchException u)
                { break; }
                System.out.println("For n = " + inp + " r = " + answer(inp));
            }
        }
    }

}