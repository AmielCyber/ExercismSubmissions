#pragma once
#include <iostream>
#include <memory>
#include <stack>

namespace binary_search_tree {
template <typename T> class binary_tree {
protected:
  std::unique_ptr<binary_tree> left_node;
  std::unique_ptr<binary_tree> right_node;
  const T root_data;

public:
  explicit binary_tree(T root_data) : root_data(root_data) {}

  T data() const { return root_data; }

  void insert(T data) {
    if (data <= root_data) {
      if (left_node == nullptr) {
        left_node = std::make_unique<binary_tree>(data);
        return;
      }
      left_node->insert(data);
    } else {
      if (right_node == nullptr) {
        right_node = std::make_unique<binary_tree>(data);
        return;
      }
      right_node->insert(data);
    }
  }
  const std::unique_ptr<binary_tree> &left() const { return left_node; }
  const std::unique_ptr<binary_tree> &right() const { return right_node; }

  /**
   * Input Iterator
   */
  class iterator {
  protected:
    std::stack<binary_tree *> stack{};

  public:
    using iterator_category = std::input_iterator_tag;
    using difference_type = std::ptrdiff_t;
    using value_type = T;

    explicit iterator(binary_tree *node) {
      stack.push(nullptr);
      auto ptr = node;
      while (ptr) {
        stack.push(ptr);
        ptr = ptr->left().get();
      }
    }
    const T &operator*() const { return stack.top()->root_data; }

    // TIME: O(H), SPACE: O(H), where H is the maximum height
    // Worst case is where H = N, thus TIME: O(N), SPACE: O(N)
    iterator &operator++() {
      if (stack.empty()) {
        stack.push(nullptr);
      }
      if (stack.top() == nullptr) {
        return *this;
      }
      auto current = stack.top();
      stack.pop();
      if (current->right()) {
        auto ptr = current->right().get();
        while (ptr) {
          stack.push(ptr);
          ptr = ptr->left().get();
        }
      }
      return *this;
    }
    iterator operator++(int) {
      iterator temp = *this;
      ++*this;
      return temp;
    }

    bool operator==(const iterator &other) const {
      if (stack.empty() && other.stack.empty()) {
        return true;
      }
      if (stack.empty() || other.stack.empty()) {
        return false;
      }
      return stack.top() == other.stack.top();
    }

    bool operator!=(const iterator &other) const { return !(*this == other); }
  };

  iterator begin() { return iterator{this}; }
  static iterator end() { return iterator{nullptr}; }
};
} // namespace binary_search_tree