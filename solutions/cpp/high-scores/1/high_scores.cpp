#include "high_scores.h"

#include <algorithm>
#include <functional>
#include <vector>

namespace arcade {

std::vector<int> HighScores::list_scores() { return std::vector<int>(scores); }

int HighScores::latest_score() { return scores.back(); }

int HighScores::personal_best() {
  return *std::max_element(scores.begin(), scores.end());
}

std::vector<int> HighScores::top_three() {
  auto sorted_scores = std::vector<int>(scores.begin(), scores.end());
  std::sort(sorted_scores.begin(), sorted_scores.end(), std::greater<int>());

  int sorted_scores_size = sorted_scores.size() >= 3 ? 3 : sorted_scores.size();
  return std::vector<int>(sorted_scores.begin(),
                          sorted_scores.begin() + sorted_scores_size);
}

} // namespace arcade
