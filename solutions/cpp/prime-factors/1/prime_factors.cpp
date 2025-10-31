#include "prime_factors.h"
namespace prime_factors {
std::vector<long long> of(long long num) {
  std::vector<long long> primes{};
  for (long candidate = 2; num > 1; candidate++) {
    for (; num % candidate == 0; num /= candidate) {
      primes.emplace_back(candidate);
    }
  }
  return primes;
}
} // namespace prime_factors
