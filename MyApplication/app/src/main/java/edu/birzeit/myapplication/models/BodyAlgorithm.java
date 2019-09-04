package edu.birzeit.myapplication.models;


import com.google.gson.annotations.SerializedName;

public class BodyAlgorithm {

    @SerializedName("IdAlgorithm")
    private long IdAlgorithm;

    @SerializedName("IdBodyPart")
    private long IdBodyPart;

    @Override
    public String toString() {
        return "BodyAlgorithm{" +
                "IdAlgorithm=" + IdAlgorithm +
                ", IdBodyPart=" + IdBodyPart +
                '}';
    }

    public long getIdAlgorithm() {
        return IdAlgorithm;
    }

    public void setIdAlgorithm(long idAlgorithm) {
        IdAlgorithm = idAlgorithm;
    }

    public long getIdBodyPart() {
        return IdBodyPart;
    }

    public void setIdBodyPart(long idBodyPart) {
        IdBodyPart = idBodyPart;
    }
}
