class Lasagna
{
    private int EXPECTED_MINS_IN_OVEN = 40;
    private int LAYER_PREPARATION_TIME = 2;
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven(){
        return EXPECTED_MINS_IN_OVEN;
    }
    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int minLapse){
        var remainingMins = EXPECTED_MINS_IN_OVEN - minLapse;
        return remainingMins > 0 ? remainingMins : 0;
    }
    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int layers){
        if(layers < 1){
            return 0;
        }
        return LAYER_PREPARATION_TIME * layers;
    }
    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int layers, int minsInOven){
        return minsInOven + PreparationTimeInMinutes(layers);
    }
}
