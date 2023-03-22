template <typename T>
class List {
  private:
    T *array;
    int capacity;
    int count;
    int frontIndex;

  public:
    List(int initial_capacity = 10) {
      capacity = initial_capacity;
      count = 0;
      frontIndex = 0;
      array = new T[capacity];
    }

    ~List() {
      delete[] array;
    }

    void add(T item) {
      if (count == capacity) {
        resize();
      }
      array[count++] = item;
    }

    T get(int index) {
      if (index < 0 || index >= count) {
        return T();
      }
      return array[index];
    }

    T max_value() {
      if (count == 0) {
        return T(); // Return the default value of T if the list is empty
      }

      T max_element = array[0];
      for (int i = 1; i < count; i++) {
        if (array[i] > max_element) {
          max_element = array[i];
        }
      }
      return max_element;
    }

    void push_back(T item) {
        if (count == capacity) {
            resize();
        }
        array[count++] = item;
    }

    void pop_front() {
        if (empty()) {
            return;
        }
        frontIndex++;
    }

    T front() const {
        if (empty()) {
            return T();
        }
        return array[frontIndex];
    }

    bool empty() const {
        return frontIndex >= count;
    }

    int size() const {
        return count - frontIndex;
    }

    void clear() {
        count = 0;
        frontIndex = 0;
    }


  private:
    void resize() {
      capacity *= 2;
        T *new_array = new T[capacity];
        for (int i = frontIndex; i < count; i++) {
            new_array[i - frontIndex] = array[i];
        }
        count -= frontIndex;
        frontIndex = 0;
        delete[] array;
        array = new_array;
    }
};
