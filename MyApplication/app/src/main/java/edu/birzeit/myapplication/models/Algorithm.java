package edu.birzeit.myapplication.models;


import com.google.gson.annotations.SerializedName;

public class Algorithm {

    @SerializedName("id")
    private long Id;

    @SerializedName("Name")
    private String Name;

    @SerializedName("FirstStep")
    private String FirstStep;

    @SerializedName("InjeryORIllness")
    private int InjeryORIllness;


    @Override
    public String toString() {
        return "Algorithm{" +
                "Id=" + Id +
                ", Name='" + Name + '\'' +
                ", FirstStep='" + FirstStep + '\'' +
                ", InjeryORIllness=" + InjeryORIllness +
                '}';
    }

    public long getId() {
        return Id;
    }

    public void setId(long id) {
        Id = id;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getFirstStep() {
        return FirstStep;
    }

    public void setFirstStep(String firstStep) {
        FirstStep = firstStep;
    }

    public int getInjeryORIllness() {
        return InjeryORIllness;
    }

    public void setInjeryORIllness(int injeryORIllness) {
        InjeryORIllness = injeryORIllness;
    }
}
