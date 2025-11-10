public class Solution {
    private Random random = new Random();
    
    public string KthLargestNumber(string[] nums, int k) {
        int n = nums.Length;
        return QuickSelect(nums, 0, n - 1, n - k);
    }
    
    private string QuickSelect(string[] nums, int left, int right, int k) {
        if (left == right) {
            return nums[left];
        }

        int randomPivot = left + random.Next(right - left + 1);
        
        // DIVIDIR
        int pivotIndex = Partition(nums, left, right, randomPivot);
        
        // CONQUISTAR
        if (k == pivotIndex) {
            return nums[k];
        } else if (k < pivotIndex) {
            return QuickSelect(nums, left, pivotIndex - 1, k);
        } else {
            return QuickSelect(nums, pivotIndex + 1, right, k);
        }
    }
    
    private int Partition(string[] nums, int left, int right, int pivotIndex) {
        string pivot = nums[pivotIndex];

        Swap(nums, pivotIndex, right);
        
        int storeIndex = left;

        for (int i = left; i < right; i++) {
            if (CompareStrings(nums[i], pivot) < 0) {
                Swap(nums, storeIndex, i);
                storeIndex++;
            }
        }

        Swap(nums, storeIndex, right);
        return storeIndex;
    }
    
    private void Swap(string[] nums, int i, int j) {
        string temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
    
    private int CompareStrings(string a, string b) {
        if (a.Length != b.Length) {
            return a.Length.CompareTo(b.Length);
        }
        return string.Compare(a, b, StringComparison.Ordinal);
    }
}