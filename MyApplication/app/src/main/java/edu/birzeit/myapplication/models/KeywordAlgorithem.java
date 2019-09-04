package edu.birzeit.myapplication.models;


import com.google.gson.annotations.SerializedName;

public class KeywordAlgorithem {

    @SerializedName("id")
    private long Id;

    @SerializedName("IdAlgorithem")
    private long IdAlgorithem;

    @SerializedName("Keyword")
    private String Keyword;

    @Override
    public String toString() {
        return "KeywordAlgorithem{" +
                "Id=" + Id +
                ", IdAlgorithem=" + IdAlgorithem +
                ", Keyword='" + Keyword + '\'' +
                '}';
    }

    public long getId() {
        return Id;
    }

    public void setId(long id) {
        Id = id;
    }

    public long getIdAlgorithem() {
        return IdAlgorithem;
    }

    public void setIdAlgorithem(long idAlgorithem) {
        IdAlgorithem = idAlgorithem;
    }

    public String getKeyword() {
        return Keyword;
    }

    public void setKeyword(String keyword) {
        Keyword = keyword;
    }
}
