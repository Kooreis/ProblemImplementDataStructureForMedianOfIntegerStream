Here is a JavaScript solution using two heaps (a max heap and a min heap) to keep track of the median of a stream of integers. The max heap stores the smaller half of the stream and the min heap stores the larger half. The median is then either the root of the max heap (if the stream has an odd number of integers) or the average of the roots of the two heaps (if the stream has an even number of integers).

```javascript
class MinHeap {
    constructor() {
        this.heap = [];
    }

    insert(num) {
        this.heap.push(num);
        this.bubbleUp();
    }

    bubbleUp() {
        let index = this.heap.length - 1;
        while (index > 0) {
            let element = this.heap[index],
                parentIndex = Math.floor((index - 1) / 2),
                parent = this.heap[parentIndex];

            if (parent >= element) break;
            this.heap[index] = parent;
            this.heap[parentIndex] = element;
            index = parentIndex;
        }
    }

    extractMin() {
        const min = this.heap[0];
        this.heap[0] = this.heap.pop();
        this.sinkDown();
        return min;
    }

    sinkDown() {
        let index = 0,
            length = this.heap.length,
            element = this.heap[0];

        while (true) {
            let leftChildIdx = 2 * index + 1,
                rightChildIdx = 2 * index + 2,
                leftChild, rightChild,
                swap = null;

            if (leftChildIdx < length) {
                leftChild = this.heap[leftChildIdx];
                if (leftChild < element) swap = leftChildIdx;
            }

            if (rightChildIdx < length) {
                rightChild = this.heap[rightChildIdx];
                if ((swap !== null && rightChild < leftChild) || (swap === null && rightChild < element)) {
                    swap = rightChildIdx;
                }
            }

            if (swap === null) break;
            this.heap[index] = this.heap[swap];
            this.heap[swap] = element;
            index = swap;
        }
    }
}

class MaxHeap extends MinHeap {
    bubbleUp() {
        let index = this.heap.length - 1;
        while (index > 0) {
            let element = this.heap[index],
                parentIndex = Math.floor((index - 1) / 2),
                parent = this.heap[parentIndex];

            if (parent <= element) break;
            this.heap[index] = parent;
            this.heap[parentIndex] = element;
            index = parentIndex;
        }
    }

    sinkDown() {
        let index = 0,
            length = this.heap.length,
            element = this.heap[0];

        while (true) {
            let leftChildIdx = 2 * index + 1,
                rightChildIdx = 2 * index + 2,
                leftChild, rightChild,
                swap = null;

            if (leftChildIdx < length) {
                leftChild = this.heap[leftChildIdx];
                if (leftChild > element) swap = leftChildIdx;
            }

            if (rightChildIdx < length) {
                rightChild = this.heap[rightChildIdx];
                if ((swap !== null && rightChild > leftChild) || (swap === null && rightChild > element)) {
                    swap = rightChildIdx;
                }
            }

            if (swap === null) break;
            this.heap[index] = this.heap[swap];
            this.heap[swap] = element;
            index = swap;
        }
    }
}

class MedianFinder {
    constructor() {
        this.lowers = new MaxHeap();
        this.highers = new MinHeap();
    }

    addNum(num) {
        if (!this.lowers.heap.length || num < this.lowers.heap[0]) {
            this.lowers.insert(num);
        } else {
            this.highers.insert(num);
        }

        if (this.lowers.heap.length - this.highers.heap.length >= 2) {
            this.highers.insert(this.lowers.extractMax());
        } else if (this.highers.heap.length > this.lowers.heap.length) {
            this.lowers.insert(this.highers.extractMin());
        }
    }

    findMedian() {
        if (this.lowers.heap.length === this.highers.heap.length) {
            return (this.lowers.heap[0] + this.highers.heap[0]) / 2;
        } else {
            return this.lowers.heap[0];
        }
    }
}
```