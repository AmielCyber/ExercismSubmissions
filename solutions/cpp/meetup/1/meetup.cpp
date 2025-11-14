#include "meetup.h"

namespace meetup {
    scheduler::scheduler(const boost::gregorian::months_of_year month, const int year): month(month), year(year) {
    }

    boost::gregorian::date scheduler::first_monday() const {
        return GetDaySchedule(Schedule::First, boost::date_time::Monday);
    }

    boost::gregorian::date scheduler::first_tuesday() const {
        return GetDaySchedule(Schedule::First, boost::date_time::Tuesday);
    }

    boost::gregorian::date scheduler::first_wednesday() const {
        return GetDaySchedule(Schedule::First, boost::date_time::Wednesday);
    }

    boost::gregorian::date scheduler::first_thursday() const {
        return GetDaySchedule(Schedule::First, boost::date_time::Thursday);
    }

    boost::gregorian::date scheduler::first_friday() const {
        return GetDaySchedule(Schedule::First, boost::date_time::Friday);
    }

    boost::gregorian::date scheduler::first_saturday() const {
        return GetDaySchedule(Schedule::First, boost::date_time::Saturday);
    }

    boost::gregorian::date scheduler::first_sunday() const {
        return GetDaySchedule(Schedule::First, boost::date_time::Sunday);
    }

    boost::gregorian::date scheduler::second_monday() const {
        return GetDaySchedule(Schedule::Second, boost::date_time::Monday);
    }

    boost::gregorian::date scheduler::second_tuesday() const {
        return GetDaySchedule(Schedule::Second, boost::date_time::Tuesday);
    }

    boost::gregorian::date scheduler::second_wednesday() const {
        return GetDaySchedule(Schedule::Second, boost::date_time::Wednesday);
    }

    boost::gregorian::date scheduler::second_thursday() const {
        return GetDaySchedule(Schedule::Second, boost::date_time::Thursday);
    }

    boost::gregorian::date scheduler::second_friday() const {
        return GetDaySchedule(Schedule::Second, boost::date_time::Friday);
    }

    boost::gregorian::date scheduler::second_saturday() const {
        return GetDaySchedule(Schedule::Second, boost::date_time::Saturday);
    }

    boost::gregorian::date scheduler::second_sunday() const {
        return GetDaySchedule(Schedule::Second, boost::date_time::Sunday);
    }

    boost::gregorian::date scheduler::third_monday() const {
        return GetDaySchedule(Schedule::Third, boost::date_time::Monday);
    }

    boost::gregorian::date scheduler::third_tuesday() const {
        return GetDaySchedule(Schedule::Third, boost::date_time::Tuesday);
    }

    boost::gregorian::date scheduler::third_wednesday() const {
        return GetDaySchedule(Schedule::Third, boost::date_time::Wednesday);
    }

    boost::gregorian::date scheduler::third_thursday() const {
        return GetDaySchedule(Schedule::Third, boost::date_time::Thursday);
    }

    boost::gregorian::date scheduler::third_friday() const {
        return GetDaySchedule(Schedule::Third, boost::date_time::Friday);
    }

    boost::gregorian::date scheduler::third_saturday() const {
        return GetDaySchedule(Schedule::Third, boost::date_time::Saturday);
    }

    boost::gregorian::date scheduler::third_sunday() const {
        return GetDaySchedule(Schedule::Third, boost::date_time::Sunday);
    }

    boost::gregorian::date scheduler::fourth_monday() const {
        return GetDaySchedule(Schedule::Fourth, boost::date_time::Monday);
    }

    boost::gregorian::date scheduler::fourth_tuesday() const {
        return GetDaySchedule(Schedule::Fourth, boost::date_time::Tuesday);
    }

    boost::gregorian::date scheduler::fourth_wednesday() const {
        return GetDaySchedule(Schedule::Fourth, boost::date_time::Wednesday);
    }

    boost::gregorian::date scheduler::fourth_thursday() const {
        return GetDaySchedule(Schedule::Fourth, boost::date_time::Thursday);
    }

    boost::gregorian::date scheduler::fourth_friday() const {
        return GetDaySchedule(Schedule::Fourth, boost::date_time::Friday);
    }

    boost::gregorian::date scheduler::fourth_saturday() const {
        return GetDaySchedule(Schedule::Fourth, boost::date_time::Saturday);
    }

    boost::gregorian::date scheduler::fourth_sunday() const {
        return GetDaySchedule(Schedule::Fourth, boost::date_time::Sunday);
    }

    boost::gregorian::date scheduler::last_monday() const {
        return GetDaySchedule(Schedule::Last, boost::date_time::Monday);
    }

    boost::gregorian::date scheduler::last_tuesday() const {
        return GetDaySchedule(Schedule::Last, boost::date_time::Tuesday);
    }

    boost::gregorian::date scheduler::last_wednesday() const {
        return GetDaySchedule(Schedule::Last, boost::date_time::Wednesday);
    }

    boost::gregorian::date scheduler::last_thursday() const {
        return GetDaySchedule(Schedule::Last, boost::date_time::Thursday);
    }

    boost::gregorian::date scheduler::last_friday() const {
        return GetDaySchedule(Schedule::Last, boost::date_time::Friday);
    }

    boost::gregorian::date scheduler::last_saturday() const {
        return GetDaySchedule(Schedule::Last, boost::date_time::Saturday);
    }

    boost::gregorian::date scheduler::last_sunday() const {
        return GetDaySchedule(Schedule::Last, boost::date_time::Sunday);
    }

    boost::gregorian::date scheduler::monteenth() const {
        return GetDaySchedule(Schedule::Teenth, boost::date_time::Monday);
    }

    boost::gregorian::date scheduler::tuesteenth() const {
        return GetDaySchedule(Schedule::Teenth, boost::date_time::Tuesday);
    }

    boost::gregorian::date scheduler::wednesteenth() const {
        return GetDaySchedule(Schedule::Teenth, boost::date_time::Wednesday);
    }

    boost::gregorian::date scheduler::thursteenth() const {
        return GetDaySchedule(Schedule::Teenth, boost::date_time::Thursday);
    }

    boost::gregorian::date scheduler::friteenth() const {
        return GetDaySchedule(Schedule::Teenth, boost::date_time::Friday);
    }

    boost::gregorian::date scheduler::saturteenth() const {
        return GetDaySchedule(Schedule::Teenth, boost::date_time::Saturday);
    }

    boost::gregorian::date scheduler::sunteenth() const {
        return GetDaySchedule(Schedule::Teenth, boost::date_time::Sunday);
    }

    boost::gregorian::date scheduler::GetDaySchedule(const Schedule schedule, const boost::gregorian::greg_weekday weekday) const {
        if (schedule == Schedule::Teenth) {
            return GetTeenthWeekday(weekday);
        }
        return GetNthWeekday(schedule, weekday);
    }

    boost::gregorian::date scheduler::GetNthWeekday(const Schedule schedule, const boost::gregorian::greg_weekday weekday) const {
        using namespace boost::gregorian;
        switch (schedule) {
            case Schedule::First: {
                nth_day_of_the_week_in_month nth_day_of_week(nth_day_of_the_week_in_month::first, weekday, month);
                return nth_day_of_week.get_date(year);
            }
            case Schedule::Second: {
                nth_day_of_the_week_in_month nth_day_of_week(nth_day_of_the_week_in_month::second, weekday, month);
                return nth_day_of_week.get_date(year);
            }
            case Schedule::Third: {
                nth_day_of_the_week_in_month nth_day_of_week(nth_day_of_the_week_in_month::third, weekday, month);
                return nth_day_of_week.get_date(year);
            }
            case Schedule::Fourth: {
                nth_day_of_the_week_in_month nth_day_of_week(nth_day_of_the_week_in_month::fourth, weekday, month);
                return nth_day_of_week.get_date(year);
            }
            case Schedule::Last: {
                nth_day_of_the_week_in_month nth_day_of_week(nth_day_of_the_week_in_month::fifth, weekday, month);
                return nth_day_of_week.get_date(year);
            }
            default:
                throw std::invalid_argument("Invalid schedule");
        }
    }

    boost::gregorian::date scheduler::GetTeenthWeekday(const boost::gregorian::greg_weekday weekday) const {
        const auto teenth_day = boost::gregorian::date(year, month, 13);
        if (teenth_day.day_of_week() != weekday) {
            return boost::gregorian::next_weekday(teenth_day, weekday);
        }
        return teenth_day;
    }
}  // namespace meetup
