package edu.birzeit.myapplication.models;


import com.google.gson.annotations.SerializedName;

public class KeyWordBody {

    @SerializedName("id")
    private long Id;

    @SerializedName("IdBodyPart")
    private long IdBodyPart;

    @SerializedName("KeyWord")
    private String KeyWord;

    @Override
    public String toString() {
        return "KeyWordBody{" +
                "Id=" + Id +
                ", IdBodyPart=" + IdBodyPart +
                ", KeyWord='" + KeyWord + '\'' +
                '}';
    }

    public long getId() {
        return Id;
    }

    public void setId(long id) {
        Id = id;
    }

    public long getIdBodyPart() {
        return IdBodyPart;
    }

    public void setIdBodyPart(long idBodyPart) {
        IdBodyPart = idBodyPart;
    }

    public String getKeyWord() {
        return KeyWord;
    }

    public void setKeyWord(String keyWord) {
        KeyWord = keyWord;
    }
}
