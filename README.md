# Question: How do you implement a data structure to constantly find the median of a stream of integers? JavaScript Summary

The provided JavaScript code implements a data structure to find the median of a stream of integers. It uses two heaps, a max heap and a min heap, to keep track of the median. The max heap stores the smaller half of the stream, while the min heap stores the larger half. The code defines three classes: MinHeap, MaxHeap, and MedianFinder. The MinHeap class has methods to insert a number into the heap, bubble up the inserted number to its correct position, extract the minimum number, and sink down the number at the root to its correct position. The MaxHeap class extends the MinHeap class and overrides the bubbleUp and sinkDown methods to maintain the max heap property. The MedianFinder class uses an instance of MaxHeap to store the lower half of the numbers and an instance of MinHeap to store the upper half. When a new number is added, it is inserted into the appropriate heap. If the sizes of the heaps differ by more than one, the root of the larger heap is moved to the smaller heap to balance them. The median is then either the root of the max heap (if the total number of numbers is odd) or the average of the roots of the two heaps (if the total number of numbers is even).

---

# TypeScript Differences

The TypeScript version of the solution is similar to the JavaScript version in terms of logic and implementation. Both versions use two heaps (a max heap and a min heap) to keep track of the median of a stream of integers. The max heap stores the smaller half of the stream and the min heap stores the larger half. The median is then either the root of the max heap (if the stream has an odd number of integers) or the average of the roots of the two heaps (if the stream has an even number of integers).

However, there are some differences between the two versions due to the features and syntax of TypeScript:

1. Type Annotations: TypeScript version uses type annotations to ensure that variables are of the correct type. For example, the `insert` method in the `MaxHeap` class has a parameter `val` of type `number`. This ensures that only numbers can be inserted into the heap.

2. Access Modifiers: TypeScript version uses access modifiers (`private`, `public`) to control the visibility of properties and methods in a class. For example, the `heap` property in the `MaxHeap` and `MinHeap` classes is marked as `private`, which means it can only be accessed within the same class.

3. Method Return Types: TypeScript allows specifying the return type of functions and methods. For example, the `extractMax` method in the `MaxHeap` class is specified to return a number.

4. Array Destructuring: Both versions use array destructuring to swap elements in the heap. However, TypeScript ensures type safety during this operation.

5. The TypeScript version includes additional helper methods like `peek` and `size` in the heap classes, which return the top element and the size of the heap respectively. These methods are used in the `MedianFinder` class to simplify the logic of finding the median.

In summary, while the core logic of the solution remains the same, the TypeScript version leverages features of TypeScript to provide better type safety and encapsulation.

---

# C++ Differences

The C++ version of the solution uses the STL priority_queue to implement the heaps, while the JavaScript version implements the heaps from scratch. The priority_queue in C++ automatically sorts the elements in the queue, so there is no need to manually implement the bubbleUp and sinkDown methods as in the JavaScript version.

In the C++ version, the max heap (lo) is implemented using a priority_queue with default comparison operator (less), and the min heap (hi) is implemented using a priority_queue with a custom comparison operator (greater). In the JavaScript version, the max heap is implemented by extending the min heap and overriding the bubbleUp and sinkDown methods.

The addNum method in both versions works similarly: it adds the new number to the max heap, then moves the maximum element of the max heap to the min heap to ensure that all elements in the max heap are less than or equal to the elements in the min heap. If the size of the min heap becomes greater than the size of the max heap, it moves the minimum element of the min heap back to the max heap. This ensures that the max heap always contains the median(s).

The findMedian method in both versions also works similarly: if the max heap has more elements, it returns the maximum element of the max heap as the median; otherwise, it returns the average of the maximum element of the max heap and the minimum element of the min heap as the median.

The main difference between the two versions is the language features and libraries they use: the JavaScript version uses classes, inheritance, and arrays, while the C++ version uses priority_queue from the STL.

---
