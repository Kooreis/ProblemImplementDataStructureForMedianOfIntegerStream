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