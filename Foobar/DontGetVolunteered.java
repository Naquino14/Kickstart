import java.util.ArrayList;

public class DontGetVolunteered {
    public static void main(String[] args) {
        System.out.println(solution(63, 62));
    }

    public static int solution(int src, int dest) {
        var grids = new ArrayList<boolean[][]>();
        if (src == dest)
            return 0;

        for (;;) 
        {
            // step 1 is to project every possible move from src
            // there are 8 possible moves
            // any move is out of bounds if its negative, or if its greater than the size of the grid

            // grid formation
            var grid = new boolean[8][8];
            for (int i = 0; i < 8; i++) // set all squares to false
                for (int j = 0; j < 8; j++) // thanks copilot
                    grid[i][j] = false;

            // get coordinates of src and dest
            var srcCoords = NumToCoords(src);
            var destCoords = NumToCoords(dest);

            // calc coords for every point

            var movesList = new ArrayList<Coordinate[]>();

            if (grids.size() == 0) // use src coords
            {
                // calculate the stepping points
                var baseCoords = CalcSteppingPoints(srcCoords);
                movesList.add(baseCoords);
            } else // otherwise use the previous grids coords
            {
                var ctxBasePointsGrid = grids.get(grids.size() - 1); // get the grid to check its base points
                var points = new ArrayList<Coordinate>(); // store base points
                for (int i = 0; i < ctxBasePointsGrid.length; i++) // loop thru x
                    for (int j = 0; j < ctxBasePointsGrid[i].length; j++) // loop thu y
                        if (ctxBasePointsGrid[i][j]) // if the grid is true
                            points.add(new Coordinate(i, j)); // add it to the points
                // calculate the stepping points
                for (Coordinate p : points)
                    movesList.add(CalcSteppingPoints(p)); // POST SUBMISSION: i could have probably thrown this in the previous loop
            }

            // check if coordinates are valid
            // remember, 
            // any move is out of bounds if its negative, or if its greater than the size of the grid
            for (Coordinate[] steps : movesList)
                for (int i = 0; i < steps.length; i++)
                    {
                        if (steps[i].x < 0 || steps[i].x >= 8 || steps[i].y < 0 || steps[i].y >= 8)
                            continue;
                        grid[steps[i].x][steps[i].y] = true;
                    }

            // step 2 is to check if a projected move lands on dest
            for (int i = 0; i < 64; i++)
            {
                var ctxCoords = NumToCoords(i);
                if (grid[ctxCoords.x][ctxCoords.y] && (ctxCoords.x == destCoords.x && ctxCoords.y == destCoords.y))
                    return grids.size() + 1;
            }

            // add the grid
            grids.add(grid);
        }
    }

    static Coordinate NumToCoords(int num) // just converts a number on the grid to its respective coordinate
    {
        var coords = new Coordinate(0, 0);
        coords.y = num / 8;
        coords.x = num % 8;
        return coords;
    }

    static Coordinate[] CalcSteppingPoints(Coordinate srcCoords) 
    {
        var points = new Coordinate[8];
        for (int i = 0; i < 8; i++)
            points[i] = new Coordinate();
        points[0].x = srcCoords.x + 1;
        points[0].y = srcCoords.y + 2;
        points[1].x = srcCoords.x + 2;
        points[1].y = srcCoords.y + 1;
        points[2].x = srcCoords.x + 2;
        points[2].y = srcCoords.y - 1;
        points[3].x = srcCoords.x + 1;
        points[3].y = srcCoords.y - 2;
        points[4].x = srcCoords.x - 1;
        points[4].y = srcCoords.y - 2;
        points[5].x = srcCoords.x - 2;
        points[5].y = srcCoords.y - 1;
        points[6].x = srcCoords.x - 2;
        points[6].y = srcCoords.y + 1;
        points[7].x = srcCoords.x - 1;
        points[7].y = srcCoords.y + 2;
        return points;
    }

    public static class Coordinate {
        public int x;
        public int y;
        
        public Coordinate()
        {
            this.x = 0;
            this.y = 0;
        }

        public Coordinate(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
}
