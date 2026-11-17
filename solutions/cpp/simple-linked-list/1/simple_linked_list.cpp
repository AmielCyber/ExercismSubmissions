#include "simple_linked_list.h"
#include <cstddef>
#include <memory>
#include <stdexcept>
#include <utility>

namespace simple_linked_list {

std::size_t List::size() const { return this->current_size; }

void List::push(int entry) {
  // TODO: Implement a function that pushes an Element with `entry` as data to
  // the front of the list.
  std::unique_ptr<Element> next_head = std::make_unique<Element>(entry);
  next_head->next = std::move(this->head);
  this->head = std::move(next_head);
  ++this->current_size;
}

int List::pop() {
  // TODO: Implement a function that returns the data value of the first
  // element in the list then discard that element.
  if (!this->head) {
    throw std::invalid_argument("There is nothing to pop.");
  }
  int val = this->head->data;
  std::unique_ptr<Element> old_head = std::move(this->head);
  this->head = std::move(old_head->next);
  old_head->next = nullptr;
  --this->current_size;
  return val;
}

void List::reverse() {
  // TODO: Implement a function to reverse the order of the elements in the
  // list.
  if (!this->head) {
    return;
  }
  Element *tail_ptr = this->head.get();
  while (tail_ptr->next) {
    std::unique_ptr<Element> next_head = std::move(tail_ptr->next);
    tail_ptr->next = std::move(next_head->next);
    next_head->next = std::move(this->head);
    this->head = std::move(next_head);
  }
}

} // namespace simple_linked_list
