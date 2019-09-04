package edu.birzeit.myapplication.models;


import com.google.gson.annotations.SerializedName;

public class UserRecord {

    @SerializedName("id")
    private long Id;

    @SerializedName("instructionCare")
    private String InstructionCare;

    @SerializedName("Provider")
    private String Provider;

    @SerializedName("FinalState")
    private int FinalState;

    @SerializedName("UserId")
    private long UserId;

    @SerializedName("Date")  /////////////////////////////////////////////////////////////////
    private String Date;

    @SerializedName("Rating")
    private String Rating;

    @SerializedName("algorithmID")
    private long algorithmID;

    @Override
    public String toString() {
        return "UserRecord{" +
                "Id=" + Id +
                ", InstructionCare='" + InstructionCare + '\'' +
                ", Provider='" + Provider + '\'' +
                ", FinalState=" + FinalState +
                ", UserId=" + UserId +
                ", Date='" + Date + '\'' +
                ", Rating='" + Rating + '\'' +
                ", algorithmID=" + algorithmID +
                '}';
    }

    public long getId() {
        return Id;
    }

    public void setId(long id) {
        Id = id;
    }

    public String getInstructionCare() {
        return InstructionCare;
    }

    public void setInstructionCare(String instructionCare) {
        InstructionCare = instructionCare;
    }

    public String getProvider() {
        return Provider;
    }

    public void setProvider(String provider) {
        Provider = provider;
    }

    public int getFinalState() {
        return FinalState;
    }

    public void setFinalState(int finalState) {
        FinalState = finalState;
    }

    public long getUserId() {
        return UserId;
    }

    public void setUserId(long userId) {
        UserId = userId;
    }

    public String getDate() {
        return Date;
    }

    public void setDate(String date) {
        Date = date;
    }

    public String getRating() {
        return Rating;
    }

    public void setRating(String rating) {
        Rating = rating;
    }

    public long getAlgorithmID() {
        return algorithmID;
    }

    public void setAlgorithmID(long algorithmID) {
        this.algorithmID = algorithmID;
    }
}
