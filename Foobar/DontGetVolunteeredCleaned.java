import java.util.ArrayList;

public class DontGetVolunteeredCleaned {
    public static int solution(int src, int dest) {
        var grids = new ArrayList<boolean[][]>();
        if (src == dest)
            return 0;

        for (;;) 
        {
            var grid = new boolean[8][8];
            for (int i = 0; i < 8; i++) 
                for (int j = 0; j < 8; j++)
                    grid[i][j] = false;
            var srcCoords = NumToCoords(src);
            var destCoords = NumToCoords(dest);
            var movesList = new ArrayList<Coordinate[]>();

            if (grids.size() == 0)
            {
                var baseCoords = CalcSteppingPoints(srcCoords);
                movesList.add(baseCoords);
            } else {
                var ctxBasePointsGrid = grids.get(grids.size() - 1);
                var points = new ArrayList<Coordinate>();
                for (int i = 0; i < ctxBasePointsGrid.length; i++)
                    for (int j = 0; j < ctxBasePointsGrid[i].length; j++)
                        if (ctxBasePointsGrid[i][j])
                            points.add(new Coordinate(i, j));
                for (var p : points)
                    movesList.add(CalcSteppingPoints(p));
            }

            for (var steps : movesList)
                for (int i = 0; i < steps.length; i++)
                    {
                        if (steps[i].x < 0 || steps[i].x >= 8 || steps[i].y < 0 || steps[i].y >= 8)
                            continue;
                        grid[steps[i].x][steps[i].y] = true;
                    }
            
            for (int i = 0; i < 64; i++)
            {
                var ctxCoords = NumToCoords(i);
                if (grid[ctxCoords.x][ctxCoords.y] && (ctxCoords.x == destCoords.x && ctxCoords.y == destCoords.y))
                    return grids.size() + 1;
            }
            grids.add(grid);
        }
    }

    static Coordinate NumToCoords(int n)
    {
        var c = new Coordinate(0, 0);
        c.y = n / 8;
        c.x = n % 8;
        return c;
    }

    static Coordinate[] CalcSteppingPoints(Coordinate c) 
    {
        var p = new Coordinate[8];
        for (int i = 0; i < 8; i++)
            p[i] = new Coordinate();
        p[0].x = c.x + 1;
        p[0].y = c.y + 2;
        p[1].x = c.x + 2;
        p[1].y = c.y + 1;
        p[2].x = c.x + 2;
        p[2].y = c.y - 1;
        p[3].x = c.x + 1;
        p[3].y = c.y - 2;
        p[4].x = c.x - 1;
        p[4].y = c.y - 2;
        p[5].x = c.x - 2;
        p[5].y = c.y - 1;
        p[6].x = c.x - 2;
        p[6].y = c.y + 1;
        p[7].x = c.x - 1;
        p[7].y = c.y + 2;
        return p;
    }

    public static class Coordinate {
        public int x;
        public int y;
        
        public Coordinate()
        { this(0,0); }

        public Coordinate(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
}
