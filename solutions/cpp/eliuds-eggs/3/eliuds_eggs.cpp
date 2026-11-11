#include "eliuds_eggs.h"
#include <bitset>
#include <cstddef>

namespace chicken_coop {

// TODO: add your solution here

std::size_t positions_to_quantity(std::size_t eggs) {
  std::size_t num_of_eggs = 0;
  while (eggs > 0) {
    num_of_eggs += eggs & 1;
    eggs = eggs >> 1;
  }
  return num_of_eggs;
}
} // namespace chicken_coop
