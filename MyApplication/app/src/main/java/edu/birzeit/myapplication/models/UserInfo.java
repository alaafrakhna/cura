package edu.birzeit.myapplication.models;


import com.google.gson.annotations.SerializedName;

public class UserInfo {

    @SerializedName("id")
    private long Id;

    @SerializedName("name")
    private String Name;

    @SerializedName("gender")
    private String Gender;

    @SerializedName("doB")
    private String DoB;

    @SerializedName("password")
    private String Password;

    @SerializedName("email")
    private String Email;

    public UserInfo() {
    }

    public UserInfo(String name, String email, String password, String gender, String doB) {
        Name = name;
        Gender = gender;
        DoB = doB;
        Password = password;
        Email = email;
    }

    @Override
    public String toString() {
        return "UserInfo{" +
                "Id=" + Id +
                ", Name='" + Name + '\'' +
                ", Gender=" + Gender +
                ", DoB=" + DoB +
                ", Password='" + Password + '\'' +
                ", Email='" + Email + '\'' +
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

    public String getGender() {
        return Gender;
    }

    public void setGender(String gender) {
        Gender = gender;
    }

    public String getDoB() {
        return DoB;
    }

    public void setDoB(String doB) {
        DoB = doB;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        Password = password;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        Email = email;
    }
}

