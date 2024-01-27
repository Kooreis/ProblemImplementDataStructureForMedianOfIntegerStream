Here is a TypeScript solution using two heaps (a max heap and a min heap) to constantly find the median of a stream of integers:

```typescript
class MaxHeap {
    private heap: number[] = [];

    public insert(val: number) {
        this.heap.push(val);
        this.bubbleUp(this.heap.length - 1);
    }

    public extractMax(): number {
        const max = this.heap[0];
        const end = this.heap.pop();
        if (this.heap.length > 0) {
            this.heap[0] = end;
            this.sinkDown(0);
        }
        return max;
    }

    public peek(): number {
        return this.heap[0];
    }

    public size(): number {
        return this.heap.length;
    }

    private bubbleUp(index: number) {
        let parentIndex = Math.floor((index - 1) / 2);
        while (index > 0 && this.heap[parentIndex] < this.heap[index]) {
            [this.heap[parentIndex], this.heap[index]] = [this.heap[index], this.heap[parentIndex]];
            index = parentIndex;
            parentIndex = Math.floor((index - 1) / 2);
        }
    }

    private sinkDown(index: number) {
        let left = 2 * index + 1;
        let right = 2 * index + 2;
        let largest = index;
        if (left < this.heap.length && this.heap[left] > this.heap[largest]) {
            largest = left;
        }
        if (right < this.heap.length && this.heap[right] > this.heap[largest]) {
            largest = right;
        }
        if (largest !== index) {
            [this.heap[largest], this.heap[index]] = [this.heap[index], this.heap[largest]];
            this.sinkDown(largest);
        }
    }
}

class MinHeap {
    private heap: number[] = [];

    public insert(val: number) {
        this.heap.push(val);
        this.bubbleUp(this.heap.length - 1);
    }

    public extractMin(): number {
        const min = this.heap[0];
        const end = this.heap.pop();
        if (this.heap.length > 0) {
            this.heap[0] = end;
            this.sinkDown(0);
        }
        return min;
    }

    public peek(): number {
        return this.heap[0];
    }

    public size(): number {
        return this.heap.length;
    }

    private bubbleUp(index: number) {
        let parentIndex = Math.floor((index - 1) / 2);
        while (index > 0 && this.heap[parentIndex] > this.heap[index]) {
            [this.heap[parentIndex], this.heap[index]] = [this.heap[index], this.heap[parentIndex]];
            index = parentIndex;
            parentIndex = Math.floor((index - 1) / 2);
        }
    }

    private sinkDown(index: number) {
        let left = 2 * index + 1;
        let right = 2 * index + 2;
        let smallest = index;
        if (left < this.heap.length && this.heap[left] < this.heap[smallest]) {
            smallest = left;
        }
        if (right < this.heap.length && this.heap[right] < this.heap[smallest]) {
            smallest = right;
        }
        if (smallest !== index) {
            [this.heap[smallest], this.heap[index]] = [this.heap[index], this.heap[smallest]];
            this.sinkDown(smallest);
        }
    }
}

class MedianFinder {
    private maxHeap = new MaxHeap();
    private minHeap = new MinHeap();

    public addNum(num: number) {
        this.maxHeap.insert(num);
        this.minHeap.insert(this.maxHeap.extractMax());
        if (this.maxHeap.size() < this.minHeap.size()) {
            this.maxHeap.insert(this.minHeap.extractMin());
        }
    }

    public findMedian(): number {
        if (this.maxHeap.size() > this.minHeap.size()) {
            return this.maxHeap.peek();
        } else {
            return (this.maxHeap.peek() + this.minHeap.peek()) / 2.0;
        }
    }
}

const mf = new MedianFinder();
mf.addNum(1);
mf.addNum(2);
console.log(mf.findMedian()); // 1.5
mf.addNum(3);
console.log(mf.findMedian()); // 2
```

This solution maintains two heaps: a max heap to store the smaller half of the input numbers and a min heap to store the larger half. The median is then either the maximum element in the max heap (when the total number of inputs is odd) or the average of the maximum element in the max heap and the minimum element in the min heap (when the total number of inputs is even).