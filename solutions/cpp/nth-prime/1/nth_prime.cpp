#include "nth_prime.h"
#include <stdexcept>
#include <vector>

namespace nth_prime {
int nth(int num) {
  static std::vector<int> primes{2};
  if (num < 1) {
    throw std::domain_error("");
  }
  if (num <= static_cast<int>(primes.size()))
    return primes[num - 1];
  for (int n = primes.back() + 1; static_cast<int>(primes.size()) < num; ++n) {
    bool is_prime = true;
    for (int p : primes) {
      if (n % p == 0) {
        is_prime = false;
        break;
      }
    }
    if (is_prime) {
      primes.push_back(n);
    }
  }
  return primes.back();
}

} // namespace nth_prime
