#pragma once

#include <string>
#include <unordered_set>
namespace allergies {
class allergy_test {
public:
  allergy_test(unsigned int allergy_score);
  bool is_allergic_to(std::string item);
  std::unordered_set<std::string> get_allergies();

private:
  enum class Items {
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128,
  };
  std::unordered_set<std::string> allergies;
  void set_allergies(int allergy_score);
};
} // namespace allergies
