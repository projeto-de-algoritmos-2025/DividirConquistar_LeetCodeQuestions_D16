#include <vector>

class Solution {
public:
    long long numberOfPairs(vector<int>& nums1, vector<int>& nums2, int diff) {
        int n = nums1.size();
        vector<long long> arr(n);
        
        for (int i = 0; i < n; i++) {
            arr[i] = (long long)nums1[i] - nums2[i];
        }
        
        return mergeSort(arr, 0, n - 1, diff);
    }
    
private:
    long long mergeSort(vector<long long>& arr, int left, int right, int diff) {
        if (left >= right) return 0;
        
        int mid = left + (right - left) / 2;
        long long count = 0;

        count += mergeSort(arr, left, mid, diff);
        count += mergeSort(arr, mid + 1, right, diff);

        int j = mid + 1;
        for (int i = left; i <= mid; i++) {
            while (j <= right && arr[j] < arr[i] - diff) {
                j++;
            }
            count += (right - j + 1);
        }

        merge(arr, left, mid, right);
        
        return count;
    }
    
    void merge(vector<long long>& arr, int left, int mid, int right) {
        vector<long long> temp;
        int i = left, j = mid + 1;
        
        while (i <= mid && j <= right) {
            if (arr[i] <= arr[j]) {
                temp.push_back(arr[i++]);
            } else {
                temp.push_back(arr[j++]);
            }
        }
        
        while (i <= mid) temp.push_back(arr[i++]);
        while (j <= right) temp.push_back(arr[j++]);
        
        for (int i = 0; i < temp.size(); i++) {
            arr[left + i] = temp[i];
        }
    }
};