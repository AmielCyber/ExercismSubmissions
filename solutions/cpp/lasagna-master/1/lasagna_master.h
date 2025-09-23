#pragma once
#include <string>
#include <vector>

namespace lasagna_master {

struct amount {
  int noodles;
  double sauce;
};

int preparationTime(std::vector<std::string> &, int = 2);

void addSecretIngredient(std::vector<std::string> &,
                         const std::vector<std::string> &);

void addSecretIngredient(std::vector<std::string> &, std::string);
std::vector<double> scaleRecipe(const std::vector<double> &, int);
amount quantities(const std::vector<std::string> &);

} // namespace lasagna_master
