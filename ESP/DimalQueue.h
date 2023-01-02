#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_QUEUE_SIZE 100

typedef struct {
    void* data;
    size_t element_size;
    int head;
    int tail;
    int size;
} Queue;

void init_queue(Queue* q, size_t element_size) {
    q->data = malloc(MAX_QUEUE_SIZE * element_size);
    q->element_size = element_size;
    q->head = 0;
    q->tail = 0;
    q->size = 0;
}

void free_queue(Queue* q) {
    free(q->data);
}

int is_empty(Queue* q) {
    return q->size == 0;
}

int is_full(Queue* q) {
    return q->size == MAX_QUEUE_SIZE;
}

void enqueue(Queue* q, void* element) {
    if (is_full(q)) {
        printf("Queue is full!\n");
        return;
    }
    memcpy((char*)q->data + (q->tail * q->element_size), element, q->element_size);
    q->tail = (q->tail + 1) % MAX_QUEUE_SIZE;
    q->size++;
}

void dequeue(Queue* q, void* element) {
    if (is_empty(q)) {
        printf("Queue is empty!\n");
        return;
    }
    memcpy(element, (char*)q->data + (q->head * q->element_size), q->element_size);
    q->head = (q->head + 1) % MAX_QUEUE_SIZE;
    q->size--;
}