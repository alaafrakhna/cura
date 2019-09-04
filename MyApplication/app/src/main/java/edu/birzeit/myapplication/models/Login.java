package edu.birzeit.myapplication.models;


import com.google.gson.annotations.SerializedName;

public class Login {

    @SerializedName("email")
    private String Email;

    @SerializedName("password")
    private String Password;




    public Login() {
    }

    public Login(String email, String password) {

        Password = password;
        Email = email;
    }





    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        this.Email = email;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        this.Password = password;
    }


}
