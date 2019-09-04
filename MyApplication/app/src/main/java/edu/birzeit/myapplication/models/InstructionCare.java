package edu.birzeit.myapplication.models;

import com.google.gson.annotations.SerializedName;

public class InstructionCare {

    @SerializedName("id")
    private long Id;

    @SerializedName("algorithmID")
    private long algorithmID;

    @SerializedName("State")
    private int State;

    @SerializedName("instructionCare")
    private String instructionCare;

    @Override
    public String toString() {
        return "InstructionCare{" +
                "Id=" + Id +
                ", algorithmID=" + algorithmID +
                ", State=" + State +
                ", instructionCare='" + instructionCare + '\'' +
                '}';
    }

    public long getId() {
        return Id;
    }

    public void setId(long id) {
        Id = id;
    }

    public long getAlgorithmID() {
        return algorithmID;
    }

    public void setAlgorithmID(long algorithmID) {
        this.algorithmID = algorithmID;
    }

    public int getState() {
        return State;
    }

    public void setState(int state) {
        State = state;
    }

    public String getInstructionCare() {
        return instructionCare;
    }

    public void setInstructionCare(String instructionCare) {
        this.instructionCare = instructionCare;
    }
}
