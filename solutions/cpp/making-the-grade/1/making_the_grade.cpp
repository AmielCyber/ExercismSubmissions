#include <array>
#include <string>
#include <vector>

// Round down all provided student scores.
std::vector<int> round_down_scores(std::vector<double> student_scores) {
    std::vector<int> round_student_scores(student_scores.size());
    for (int i = 0; i < student_scores.size(); ++i) {
        round_student_scores[i] = static_cast<int>(student_scores[i]);
    }
    return round_student_scores;
}

// Count the number of failing students out of the group provided.
int count_failed_students(std::vector<int> student_scores) {
    int failed_students = 0;
    for (const int score: student_scores) {
        if (score <= 40)
            ++failed_students;
    }
    return failed_students;
}

// Create a list of grade thresholds based on the provided highest grade.
std::array<int, 4> letter_grades(int highest_score) {
    std::array<int, 4> grade_threshold{41, 0, 0, highest_score};
    const int grade_range = (highest_score - 40) / 4;
    for (int i = 1; i < grade_threshold.size(); ++i) {
        grade_threshold[i] = grade_threshold[i - 1] + grade_range;
    }
    return grade_threshold;
}

// Organize the student's rank, name, and grade information in ascending order.
std::vector<std::string>
student_ranking(std::vector<int> student_scores,
                std::vector<std::string> student_names) {
    std::vector<std::string> rankings(student_scores.size());
    for (int i = 0; i < student_scores.size(); ++i) {
        rankings[i] = std::to_string(i + 1) + ". " + student_names[i] + ": " +
                      std::to_string(student_scores[i]);
    }
    return rankings;
}

// Create a string that contains the name of the first student to make a perfect
// score on the exam.
std::string perfect_score(std::vector<int> student_scores,
                          std::vector<std::string> student_names) {
    for (int i = 0; i < student_scores.size(); ++i) {
        if (student_scores[i] == 100)
            return student_names[i];
    }
    return "";
}
