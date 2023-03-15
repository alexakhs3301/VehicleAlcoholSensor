#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct {
    void* data;
    size_t element_size;
    int capacity;
    int size;
    int head;
    int tail;
} Queue;

void init_queue(Queue* q, size_t element_size) {
    q->element_size = element_size;
    q->capacity = 10;
    q->size = 0;
    q->head = 0;
    q->tail = 0;
    q->data = malloc(q->capacity * q->element_size);
}

void free_queue(Queue* q) {
    free(q->data);
}

int is_empty(Queue* q) {
    return q->size == 0;
}

void enqueue(Queue* q, void* element) {
    if (q->size == q->capacity) {
        q->capacity *= 2;
        q->data = realloc(q->data, q->capacity * q->element_size);
    }
    memcpy((char*)q->data + (q->tail * q->element_size), element, q->element_size);
    q->tail = (q->tail + 1) % q->capacity;
    q->size++;
}

void dequeue(Queue* q, void* element) {
    if (is_empty(q)) {
        printf("Queue is empty!\n");
        return;
    }
    memcpy(element, (char*)q->data + (q->head * q->element_size), q->element_size);
    q->head = (q->head + 1) % q->capacity;
    q->size--;
}