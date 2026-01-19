#pragma once
#include <cstddef>
#include <vector>

namespace circular_buffer {
template <typename T> class circular_buffer {
  std::vector<T> buffer;
  size_t curr_size = 0;
  size_t read_ptr = 0;
  size_t write_ptr = 0;

public:
  circular_buffer(const size_t capacity);
  T read();
  void write(T val);
  void overwrite(T val);
  void clear();

private:
  void increment_ptr(size_t &ptr);
};
} // namespace circular_buffer
