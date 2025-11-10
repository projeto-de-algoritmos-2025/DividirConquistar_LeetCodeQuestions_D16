public class Solution {
    private int counter;
    
    public int[][] SpecialGrid(int n) {
        int size = 1 << n; 
        int[][] grid = new int[size][];
        for (int i = 0; i < size; i++) {
            grid[i] = new int[size];
        }
        
        counter = 0;
        FillQuadrant(grid, 0, 0, size);
        
        return grid;
    }
    
    private void FillQuadrant(int[][] grid, int row, int col, int size) {
        if (size == 1) {
            grid[row][col] = counter++;
            return;
        }
        
        int half = size / 2;
        
        // 1. Top-Right (menores valores)
        FillQuadrant(grid, row, col + half, half);
        
        // 2. Bottom-Right
        FillQuadrant(grid, row + half, col + half, half);
        
        // 3. Bottom-Left
        FillQuadrant(grid, row + half, col, half);
        
        // 4. Top-Left (maiores valores)
        FillQuadrant(grid, row, col, half);
    }
}