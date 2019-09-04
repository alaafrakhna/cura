package edu.birzeit.myapplication.models;


import com.google.gson.annotations.SerializedName;

public class TrustedContact {
    @SerializedName("id")
    private long Id;

    @SerializedName("name")
    private String Name;

    @SerializedName("phone")
    private String phone;

    @SerializedName("contactOrder")
    private int ContactOrder;

    @SerializedName("idUser")
    private long IdUser;


    public TrustedContact() {
    }
    public TrustedContact(String name, String phone,int contactOrder, long idUser ) {
        Name = name;
        phone = phone;
        ContactOrder = contactOrder;
        IdUser = idUser;
    }


    @Override
    public String toString() {
        return "TrustedContact{" +
                "Id=" + Id +
                ", Name='" + Name + '\'' +
                ", phone='" + phone + '\'' +
                ", ContactOrder=" + ContactOrder +
                ", IdUser=" + IdUser +
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

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public int getContactOrder() {
        return ContactOrder;
    }

    public void setContactOrder(int contactOrder) {
        ContactOrder = contactOrder;
    }

    public long getIdUser() {
        return IdUser;
    }

    public void setIdUser(long idUser) {
        IdUser = idUser;
    }
}
