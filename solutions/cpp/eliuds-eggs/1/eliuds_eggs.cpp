#include "eliuds_eggs.h"
#include <bitset>
#include <cstddef>

namespace chicken_coop {

// TODO: add your solution here

std::size_t positions_to_quantity(std::size_t eggs) {
  std::string binary_egg = std::bitset<32>(eggs).to_string();
  std::size_t num_of_eggs = 0;
  for (auto egg : binary_egg) {
    if (egg == '1') {
      ++num_of_eggs;
    }
  }
  return num_of_eggs;
}
} // namespace chicken_coop
