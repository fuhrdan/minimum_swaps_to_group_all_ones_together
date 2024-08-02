//*****************************************************************************
//** 2134. Minimum Swaps to Group All 1's Together II  leetcode              **
//** This was an interesting problem, I solved it with help from ChatGPT     **
//** which was not necessary.  My rant is about something similar.           **
//** I graduated college in 2000.  All of my textbooks have these algorith   **
//** concepts.  I studied them and learned them.  In the late 2000's, early  **
//** 2010, the terminology started to change.  The two-pointer method, which **
//** I learned, is now called the sliding-window. (They are similar, but     **
//** different).  It's the same as rebranding distributed computing into     **
//** cloud computing.  I know all of this stuff.  I learned it with old names**
//** and slightly differently.  If you are reading this, know the same thing **
//** will happen to you.  Names and styles will change, and if you aren't    **
//** keeping up or changing with it, you will be left behind.  Always learn, **
//** study and keep up to date on this.                              -Dan    **
//*****************************************************************************


int minSwaps(int* nums, int numsSize) {
    // Step 1: Count the total number of 1's
    int totalOnes = 0;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] == 1) {
            totalOnes++;
        }
    }

    // If there are no 1's or only one 1, no swaps are needed
    if (totalOnes <= 1) {
        return 0;
    }

    // Step 2: Extend the array to simulate circular behavior
    int extendedSize = numsSize * 2;
    int* extendedNums = (int*)malloc(extendedSize * sizeof(int));
    for (int i = 0; i < extendedSize; i++) {
        extendedNums[i] = nums[i % numsSize];
    }

    // Step 3: Use sliding window to count 0's in windows of size totalOnes
    int minSwaps = totalOnes; // Start with maximum swaps equal to totalOnes
    int zeroCount = 0;

    // Initialize the first window
    for (int i = 0; i < totalOnes; i++) {
        if (extendedNums[i] == 0) {
            zeroCount++;
        }
    }
    minSwaps = zeroCount; // Update minSwaps for the first window

    // Slide the window
    for (int i = totalOnes; i < extendedSize; i++) {
        // Remove the element going out of the window
        if (extendedNums[i - totalOnes] == 0) {
            zeroCount--;
        }
        // Add the new element coming into the window
        if (extendedNums[i] == 0) {
            zeroCount++;
        }
        // Update the minimum swaps needed
        if (zeroCount < minSwaps) {
            minSwaps = zeroCount;
        }
    }

    // Clean up
    free(extendedNums);
    
    return minSwaps;
}