```cpp
#include <iostream>
#include <queue>
#include <vector>

using namespace std;

class MedianFinder {
    priority_queue<int> lo;                             
    priority_queue<int, vector<int>, greater<int>> hi;  

public:
    void addNum(int num) {
        lo.push(num);                                   

        hi.push(lo.top());                              
        lo.pop();

        if (lo.size() < hi.size()) {                    
            lo.push(hi.top());
            hi.pop();
        }
    }

    double findMedian() {
        return lo.size() > hi.size() ? lo.top() : (lo.top() + hi.top()) * 0.5;
    }
};

int main() {
    MedianFinder mf;
    int num;
    while (cin >> num) {
        mf.addNum(num);
        cout << "Current median: " << mf.findMedian() << endl;
    }
    return 0;
}
```