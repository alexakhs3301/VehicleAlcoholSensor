#include <stddef.h>
#include "DimalList.cpp"
template <typename T>
class Queue {
public:
    void Enqueue(const T &value) {
        data.push_back(value);
    }

    void Dequeue() {
        if (IsEmpty()) {
            return;
        }
        data.pop_front();
    }

    T Peek() const {
        if (IsEmpty()) {
            return T();  // Return default value for the type
        }
        return data.front();
    }

    bool IsEmpty() const {
        return data.empty();
    }

    size_t Size() const {
        return data.size();
    }

private:
    List<T> data;
};
