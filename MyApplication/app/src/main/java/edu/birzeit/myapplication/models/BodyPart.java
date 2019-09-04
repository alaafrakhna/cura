package edu.birzeit.myapplication.models;


import com.google.gson.annotations.SerializedName;

public class BodyPart   {

    @SerializedName("id")
    private long Id;

    @SerializedName("Name")
    private String Name;

    @SerializedName("Description")
    private String Description;

    @Override
    public String toString() {
        return "BodyPart{" +
                "Id=" + Id +
                ", Name='" + Name + '\'' +
                ", Description='" + Description + '\'' +
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

    public String getDescription() {
        return Description;
    }

    public void setDescription(String description) {
        Description = description;
    }
}
