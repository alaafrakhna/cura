package com.example.testretrofit;

import java.util.List;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;
public interface MyApiEndPointInterface {
    @GET("/api/user/getAllUsers")
    Call<List<UserInfo>> getAllUsers();
}