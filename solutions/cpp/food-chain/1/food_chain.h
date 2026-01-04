#pragma once

#include <array>
#include <string>
namespace food_info {
constexpr size_t FIRST_VERSE = 1;
constexpr size_t LAST_VERSE = 8;
constexpr size_t SPIDER_VERSE = 3;
const std::array<const std::string, 9> animal = {
    "", "fly", "spider", "bird", "cat", "dog", "goat", "cow", "horse"};
const std::array<const std::string, 9> animal_adj = {
    "",
    "I don't know why she swallowed the fly. Perhaps she'll die.",
    "It wriggled and jiggled and tickled inside her.",
    "How absurd to swallow a bird!",
    "Imagine that, to swallow a cat!",
    "What a hog, to swallow a dog!",
    "Just opened her throat and swallowed a goat!",
    "I don't know how she swallowed a cow!",
    "She's dead, of course!",
};
} // namespace food_info
namespace food_chain {
std::string verse(size_t verse_number);
std::string verses(size_t start_verse_num, size_t end_verse_num);
std::string sing();
} // namespace food_chain
