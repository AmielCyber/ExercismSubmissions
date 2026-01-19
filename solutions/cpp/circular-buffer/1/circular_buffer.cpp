#include "circular_buffer.h"
#include <stdexcept>
#include <string>

namespace circular_buffer {

template <typename T>
circular_buffer<T>::circular_buffer(const size_t capacity) : buffer(capacity) {
  buffer.reserve(capacity);
}

template <typename T> T circular_buffer<T>::read() {
  if (curr_size == 0) {
    throw std::domain_error("Buffer is empty!");
  }
  size_t prev_read_ptr = read_ptr;
  increment_ptr(read_ptr);
  --curr_size;
  return buffer[prev_read_ptr];
}

template <typename T> void circular_buffer<T>::write(T val) {
  if (curr_size == buffer.size()) {
    throw std::domain_error("Buffer is full!");
  }
  buffer[write_ptr] = val;
  increment_ptr(write_ptr);
  ++curr_size;
}

template <typename T> void circular_buffer<T>::overwrite(T val) {
  if (curr_size < buffer.size()) {
    write(val);
  } else {
    buffer[read_ptr] = val;
    increment_ptr(read_ptr);
  }
}
template <typename T> void circular_buffer<T>::clear() {
  write_ptr = 0;
  read_ptr = 0;
  curr_size = 0;
}

template <typename T> void circular_buffer<T>::increment_ptr(size_t &ptr) {
  ++ptr;
  if (ptr == buffer.size()) {
    ptr = 0;
  }
}

} // namespace circular_buffer
template class circular_buffer::circular_buffer<int>;
template class circular_buffer::circular_buffer<std::string>;
