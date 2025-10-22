#include "sieve.h"
#include <vector>

namespace sieve {
std::vector<int> primes(int num) {
  if (num < 2) {
    return std::vector<int>{};
  }
  std::vector<int> prime_list{2};
  for (int candidate = prime_list.back() + 1; candidate <= num; ++candidate) {
    bool is_prime = true;
    for (int i = 0; i < static_cast<int>(prime_list.size()) && is_prime; ++i) {
      is_prime = candidate % prime_list[i] != 0;
    }
    if (is_prime) {
      prime_list.push_back(candidate);
    }
  }

  return prime_list;
}
} // namespace sieve
